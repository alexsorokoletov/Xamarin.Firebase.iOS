// include Fake lib
#r @"./packages/auto/FAKE/tools/FakeLib.dll"
#r @"./packages/auto/FSharp.Data/lib/net40/FSharp.Data.dll"
#r @"./packages/auto/Newtonsoft.Json/lib/net40/Newtonsoft.Json.dll"

open Fake
open System.IO
open FSharp.Data
open Fake.NuGetHelper
open System
open System.Collections
open System.Collections.Generic
open System.Net
open System.Text.RegularExpressions
open Newtonsoft.Json

let podsFolder = "pods/" 
let bindingsFolder = "bindings/"
let sampleCSProject = "csproject.template.xml"
let sampleAssemblyInfo = "assemblyinfo.template.xml"
let sampleNuspec = "nuspec.template.xml"
let sampleXCodeProject = "xcode.template"

let rootNamespace = "DreamTeam.Xamarin.Firebase"

type PodDependencyNode = {Name:string; Children:List<PodDependencyNode>}

type Podspec = JsonProvider<"./podspec.sample.json">
let getPodSpecUrl podName =
    let pageUrl = "http://cocoapods.org/pods/"+podName
    let webClient = new WebClient();
    let podPage = webClient.DownloadString(pageUrl);
    printfn "%d" podPage.Length
    Regex.Matches(podPage, @"<a href=""(http.+\.podspec\.json)"">")
        |> Seq.cast<Match>
        |> Seq.head
        |> fun m -> m.Groups.Item(1)
        |> fun g -> g.Value

let (|Prefix|_|) (p:string) (s:string) =
    if s.StartsWith(p) then
        Some(s.Substring(p.Length))
    else
        None

let makeRawGithubUrl s =
    match s with
    | Prefix "https://github.com/CocoaPods/Specs/blob/" rest -> "https://raw.githubusercontent.com/CocoaPods/Specs/" + rest
    | _ -> s

let unzipWithTar targetFolder zipFile =
    CreateDir targetFolder
    CleanDir targetFolder
    let result = ExecProcess (fun info ->  
       info.FileName <- "tar"
       info.Arguments <- "-xzf " + zipFile + " -C " + targetFolder) System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during tar -xzf  %s -C %s" zipFile targetFolder



let podSpecFileName podName =
    Path.Combine(podsFolder, podName+".json")   

let podNameWithoutSubSpec (pod:string)=
    if pod.Contains("/") then pod.Substring(0, pod.IndexOf("/")) else pod 

let specForPod podName =
    let podSpecFile = podSpecFileName (podNameWithoutSubSpec podName)
    let podSpec = Podspec.Parse(File.ReadAllText podSpecFile)
    podSpec

let podSubSpec (pod:string)=
    if pod.Contains("/") then pod.Substring(pod.IndexOf("/") + 1) else "" 
         
let downloadPodSpec (pod:string) =
    tracefn "Downloading details for pod %s" pod
    let podName = podNameWithoutSubSpec pod
    let podUrl = getPodSpecUrl podName
                        |> makeRawGithubUrl
    tracefn "Loading spec from %s" podUrl
    let podSpecJson = (new WebClient()).DownloadString(podUrl)
    let podSpecFile = podSpecFileName podName
    tracefn "Saving spec to %s" podSpecFile
    File.WriteAllText(podSpecFile, podSpecJson);
    specForPod podName

let downloadPod (podSpec:Podspec.Root) =
    let podContent = podSpec.Source.Http
    tracefn "downloading content from %s" podContent
    let targetFolder = System.IO.Path.Combine(podsFolder, podSpec.Name)
    CreateDir targetFolder
    CleanDir targetFolder
    let targetPath = System.IO.Path.Combine(targetFolder, podSpec.Name + ".zip")
    let expandFolder = System.IO.Path.Combine(targetFolder, podSpec.Name)
    if System.IO.File.Exists(targetPath) then
        System.IO.File.Delete(targetPath)
    let file = (new WebClient()).DownloadFile(podContent, targetPath)
    unzipWithTar expandFolder targetPath
    expandFolder

let private fileSafePodName (pod:string) =
    pod.Replace("/", "_").Replace("+", "_")

let podBindingsFolder podName =
    let safePodName = fileSafePodName podName
    Path.Combine(bindingsFolder, safePodName)

let downloadPod2 podName =
    let safePodName = fileSafePodName podName
    let targetFolder = System.IO.Path.Combine(podsFolder, safePodName, "XCode")
    CreateDir targetFolder
    CleanDir targetFolder
    CopyDir targetFolder sampleXCodeProject (fun _ -> true)
    let podFile = Path.Combine(targetFolder, "Podfile")
    let replacements = [ "@PodName@", podName]
    processTemplates replacements [podFile]
    let result = ExecProcess (fun info ->  
                                info.FileName <- "pod"
                                info.WorkingDirectory <- targetFolder
                                info.Arguments <- "install") System.TimeSpan.MaxValue
    if result <> 0 then failwith "Error during pod install" 
    let expandFolder = Path.Combine(targetFolder, "Pods", (podNameWithoutSubSpec podName))
    expandFolder    

let podDependencies (podSpec: Podspec.Root) (podName:string) =
    let subSpec = podSubSpec podName
    if String.IsNullOrEmpty subSpec then
        let dependenciesOptional = podSpec.JsonValue.TryGetProperty "dependencies"
        if dependenciesOptional.IsSome then
            dependenciesOptional.Value.Properties() 
                |> Seq.map (fun (k,v) -> k)
                |> Seq.toList
        else
            []
    else    
        tracefn "looking for deps for %s subspec" subSpec
        let podSubSpec = podSpec.Subspecs |> Seq.pick (fun s -> if s.Name = subSpec then Some(s) else None )
        let dependenciesOptional = podSubSpec.JsonValue.TryGetProperty "dependencies"
        if dependenciesOptional.IsSome then
                    dependenciesOptional.Value.Properties() 
                        |> Seq.map (fun (k,v) -> k)
                        |> Seq.toList
                else
                    []

let generateLinkWith (podSpec:Podspec.Root) =
   let linkWithContent = new System.Text.StringBuilder()
   linkWithContent.AppendLine("using ObjCRuntime;") |> ignore
   linkWithContent.AppendFormat(@"[assembly: LinkWith (""{0}.a"", {1}", podSpec.Name, Environment.NewLine) |> ignore
   if (podSpec.Frameworks.Length > 0) then
        linkWithContent.AppendFormat(@"Frameworks = ""{0}"",{1}", String.Join(" ", podSpec.Frameworks), Environment.NewLine) |> ignore
   if (podSpec.Libraries.Length > 0) then
        let linkerFlags = podSpec.Libraries 
                            |> Seq.cast<string>
                            |> Seq.map (fun s -> "-l"+s)
                            |> Seq.toArray
        linkWithContent.AppendFormat(@"LinkerFlags = ""{0}"",{1}", String.Join(" ", linkerFlags), Environment.NewLine) |> ignore
   linkWithContent.AppendLine(@"IsCxx = true,") |> ignore
   linkWithContent.AppendLine(@"SmartLink = true,") |> ignore
   linkWithContent.AppendLine(@"ForceLoad = true)]") |> ignore
   linkWithContent.ToString();


let isFrameworkSpec (podSpec: Podspec.Root) =
    let vendoredFrameworkOptional = podSpec.JsonValue.TryGetProperty "vendored_frameworks"
    vendoredFrameworkOptional.IsSome 


let podHeadersLocation (podName:string) = //todo check for pods with subspec like
    tracefn "Get headers location for pod %s " podName
    let truePodName = podNameWithoutSubSpec podName
    let podSubSpec = podSubSpec podName
    let podSpec = specForPod podName
    let podFolder = fileSafePodName podName
    let isFramework = isFrameworkSpec podSpec
    if isFramework then
        Path.Combine(podsFolder, podFolder, "XCode", "Pods", truePodName, podSpec.VendoredFrameworks.[0], "Headers")
    else 
        tracefn "Can't get headers location for a pod that is not providing framework %s" podName    
        ""

let podFrameworkLocation (podName:string) = //todo check for pods with subspec like
    let truePodName = podNameWithoutSubSpec podName
    let podSubSpec = podSubSpec podName
    let podSpec = specForPod podName
    let podFolder = fileSafePodName podName
    let isFramework = isFrameworkSpec podSpec
    if isFramework then
        Path.Combine(podsFolder, podFolder, "XCode", "Pods", truePodName, "Frameworks", "frameworks")
    else 
        ""

let getDependentHeadersLocations (podSpec: Podspec.Root) (podName:string)= 
    let dependencyHeaders = new System.Text.StringBuilder()
    let dependencies = podDependencies podSpec podName
    match dependencies with 
        | [] -> [||]
        | _ ->  dependencies |> Seq.filter(fun k ->
                                            let path = podHeadersLocation k
                                            tracefn "probing for dep headers %s" path
                                            Directory.Exists(path)
                                            )    
                                        |> Seq.map (podFrameworkLocation >> fun k-> "-F " + k)
                                        |> Seq.toArray               


let copyBinaryAndGenerateLinkWith podName (podSpec: Podspec.Root) podExpandedFolder = 
    let fwName = podSpec.VendoredFrameworks.[0]    
    let binaryName = Path.Combine(podExpandedFolder, fwName, podName)
    let bindingFolder = podBindingsFolder podName
    CreateDir bindingFolder
    CleanDir bindingFolder
    let dotAName = Path.Combine(bindingFolder, podName + ".a");
    CopyFile dotAName binaryName 
    let linkWithFile = Path.Combine(bindingFolder, podName + ".linkwith.cs");
    let linkerSuggestions = generateLinkWith podSpec
    File.WriteAllText(linkWithFile, linkerSuggestions)

let generateCSharpBindingsFromFolder podName (podSpec: Podspec.Root) podExpandedFolder =
    let bindingFolder = podBindingsFolder podName
    let fwName = podSpec.VendoredFrameworks.[0]    
    let iosSdkInSharpie = "iphoneos10.1" //todo detect from sharpie output
    let headersFolder = Path.Combine(podExpandedFolder, fwName, "Headers")
    if Directory.Exists(headersFolder) then
        let rootHeaderFile = Path.Combine(headersFolder, podName + ".h")
        let allHeaders = Path.Combine(headersFolder, "*.h")
        let dependenciesHeaders = getDependentHeadersLocations podSpec podName
        let depHeadersOption = if dependenciesHeaders.Length > 0 then (" " + String.Join(" ", getDependentHeadersLocations podSpec podName)) else "" 
        printfn "DEPENDENT HEADERS: %s" depHeadersOption
        let sharpieArgs =  "-tlm-do-not-submit bind -output " + bindingFolder + " -sdk "+ iosSdkInSharpie + " -scope " + allHeaders + " " 
                            + rootHeaderFile + " -n " + rootNamespace + " -c -I" + headersFolder +  depHeadersOption + " -v"
        printfn "Running sharpie %s" sharpieArgs                            
        let result = ExecProcess (fun info ->  
                                    info.FileName <- "sharpie"
                                    info.Arguments <- sharpieArgs) System.TimeSpan.MaxValue
        if result <> 0 then failwithf "Error during sharpie %s " sharpieArgs
    else
        let apiDefinitionFile = Path.Combine(bindingFolder, "ApiDefinitions.cs")
        let structsAndEnumsFile = Path.Combine(bindingFolder, "StructsAndEnums.cs")
        [ apiDefinitionFile;structsAndEnumsFile] |> Seq.iter (fun f-> File.WriteAllText(f, ""))
        printfn "Empty files generated for API definition since there are no headers in %s" podName 


let generateCSProject podName (podSpec: Podspec.Root) podExpandedFolder =
    let replacements = 
            [ "@ProjectGuid@", Guid.NewGuid().ToString("B").ToUpper()
              "@RootNamespace@", rootNamespace
              "@AssemblyName@", podName
              "@PodName@", podName
              "@Description@", "Xamarin binding ===" + podSpec.Description ]
    let bindingFolder = podBindingsFolder podName
    let csProjectFile = Path.Combine(bindingFolder, podName + ".csproj")
    let assemblyInfoFolder = Path.Combine(bindingFolder, "Properties")
    let assemblyInfoFile = Path.Combine(assemblyInfoFolder,  "AssemblyInfo.cs")
    let nuspecFile = Path.Combine(bindingFolder, podName + ".nuspec")
    CreateDir assemblyInfoFolder 
    CopyFile csProjectFile sampleCSProject
    CopyFile assemblyInfoFile sampleAssemblyInfo
    CopyFile nuspecFile sampleNuspec
    processTemplates replacements [csProjectFile; assemblyInfoFile]
    let dependencies = podDependencies podSpec podName
    let depBuilder = new System.Text.StringBuilder()
    match dependencies with 
        | [] -> tracefn "No dependencies for %s" podName
        | _ ->  dependencies 
                |> Seq.iter (fun (subPod) -> 
                                let subPodSpec = specForPod subPod
                                let subPodVersion =  (subPodSpec.JsonValue.GetProperty "version").AsString() + ".0"
                                let packageName = "DT.Xamarin." + fileSafePodName subPod
                                depBuilder.AppendFormat(@"<dependency id=""{0}"" version=""{1}"" />{2}", packageName, subPodVersion, Environment.NewLine) |> ignore
                             )
    let nugetParams = 
            [ "@PackageId@", "DT.Xamarin." + fileSafePodName podName
              "@Version@", (podSpec.JsonValue.GetProperty "version").AsString() + ".0" 
              "@Authors@", "DreamTeam Mobile"
              "@Summary@", podSpec.Summary
              "@Description@", "Xamarin binding === " + podSpec.Description
              "@ProjectUrl@", podSpec.Homepage
              "@ReleaseNotes@", ""
              "@Dependencies@", depBuilder.ToString()
               ]
    processTemplates nugetParams [nuspecFile]
    trace "1"


let rec downloadPodsRecursive (podName:string) = 
    let podSpec = downloadPodSpec podName
    let dependencies = podDependencies podSpec podName
    match dependencies with 
        | [] -> tracefn "No dependencies for %s" podName
        | _ ->  dependencies |> Seq.iter (fun (k) -> 
                                    printfn "Dependency %s found for %s" k podName
                                    downloadPodsRecursive k
                                    )

let rec generateBindingForPod podName = 
    tracefn "generating bindings for pod %s" podName
    let podSpec = specForPod podName
    // let dependencies = podDependencies podSpec podName
    // match dependencies with 
    //     | [] -> tracefn "No dependencies for %s" podName
    //     | _ ->  dependencies |> Seq.iter (fun (k) -> 
    //                                 printfn "Dependency %s" k
    //                                 generateBindingForPod k
    //                                 )
    let podExpandedFolder = downloadPod2 podName
    let vendoredFrameworkOptional = podSpec.JsonValue.TryGetProperty "vendored_frameworks"
    let isFramework = vendoredFrameworkOptional.IsSome 
    if isFramework then
        copyBinaryAndGenerateLinkWith podName podSpec podExpandedFolder
        generateCSharpBindingsFromFolder podName podSpec podExpandedFolder
        generateCSProject podName podSpec podExpandedFolder
    trace "3"

let rec addDependentPods (list:List<string>) (pod:string) = 
    let spec = specForPod pod
    list.Add pod
    let dependencies = podDependencies spec pod 
    dependencies |> Seq.iter (fun d -> addDependentPods list d)


let private listIntersect l1 l2 =
    Set.intersect (Set.ofList l1) (Set.ofList l2) |> Set.toList



let rec sortGraphRecursively source res =
   match source with
   | head :: tail ->
            let pod = head
            let spec = specForPod pod
            let dependencies = podDependencies spec pod
            let isEmpty = List.isEmpty dependencies
            let allDepsResolved = List.isEmpty (listIntersect dependencies res)
            if isEmpty || allDepsResolved then
                let sourceCopy = List.except [pod] source
                let resCopy = List.append [pod] res
                sortGraphRecursively sourceCopy resCopy
            else
                res
   | [] -> res

let sortDependencyGraph all =
    let sortedList = sortGraphRecursively all List.empty
    sortedList

let buildDependencyGraph podName =
    let allPods = new List<string>()
    addDependentPods allPods podName
    let allPodsUnique = allPods |> Seq.distinct |> List.ofSeq
    printfn "List of pods: %A" allPodsUnique
    let tree = sortDependencyGraph allPodsUnique
    printfn "Sorted dependency graph: %A" tree
    tree

Target "Clean" ( fun()->
    trace "Clean"
);

Target "Bind" ( fun()->
    let podName = getBuildParamOrDefault "POD" ""
    if String.IsNullOrEmpty(podName) then
        tracefn "You must specify pod name as a POD variable: sh bind.sh POD=FirebaseAnalytics"
    else
        downloadPodsRecursive podName
        let mapping = buildDependencyGraph podName
        mapping |> List.iter generateBindingForPod
        trace "2"
        //generateBindingForPod podName
);


"Clean"
    ==> "Bind"

// start build
RunTargetOrDefault("Bind")