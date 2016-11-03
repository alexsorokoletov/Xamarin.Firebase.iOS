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
let packagesDirUnsorted = "packages-raw"
let packagesDirSorted = "packages-good"
let packagesSourceName = "DT.Automatic"
let packagesTempDir = "packages-tmp"
let packagesTargetFramework = "Xamarin.iOS"

let sampleCSProject = "csproject.template.xml"
let sampleAssemblyInfo = "assemblyinfo.template.xml"
let samplePackagesConfig = "packages.template.xml"
let sampleNuspec = "nuspec.template.xml"
let sampleXCodeProject = "xcode.template"

let rootNamespace = "DreamTeam.Xamarin."
let rn = Environment.NewLine

type PodDependencyNode = {Name:string; Children:List<PodDependencyNode>}

type Podspec = JsonProvider<"./podspec.sample.json">

let firstRegexMatch input (regex:string) = 
     Regex.Matches(input, regex)
        |> Seq.cast<Match>
        |> Seq.head
        |> fun m -> m.Groups.Item(1)
        |> fun g -> g.Value

let getPodSpecUrl podName =
    let pageUrl = "http://cocoapods.org/pods/"+podName
    let webClient = new WebClient();
    let podPage = webClient.DownloadString(pageUrl);
    // printfn "%d" podPage.Length
    firstRegexMatch podPage @"<a href=""(http.+\.podspec\.json)"">"

let (|Prefix|_|) (p:string) (s:string) =
    if s.StartsWith(p) then
        Some(s.Substring(p.Length))
    else
        None

let makeRawGithubUrl s =
    match s with
    | Prefix "https://github.com/CocoaPods/Specs/blob/" rest -> "https://raw.githubusercontent.com/CocoaPods/Specs/" + rest
    | _ -> s

let freshDirectory d = 
    DeleteDir d
    CreateDir d

let unzipWithTar targetFolder zipFile =
    freshDirectory targetFolder
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

let sbLine (line:String) (sb:System.Text.StringBuilder) =
    sb.AppendLine(line)

let downloadPodSpec (pod:string) =
    tracefn "Downloading details for pod %s" pod
    let podName = podNameWithoutSubSpec pod
    let podUrl = getPodSpecUrl podName
                        |> makeRawGithubUrl
    // tracefn "Loading spec from %s" podUrl
    let podSpecJson = (new WebClient()).DownloadString(podUrl)
    let podSpecFile = podSpecFileName podName
    // tracefn "Saving spec to %s" podSpecFile
    File.WriteAllText(podSpecFile, podSpecJson);
    specForPod podName
let private fileSafePodName (pod:string) =
    pod.Replace("/", "_").Replace("+", "_").Replace("-","_")

let podBindingsFolder podName =
    let safePodName = fileSafePodName podName
    Path.Combine(bindingsFolder, safePodName)
let downloadPod2 podName =
    let safePodName = fileSafePodName podName
    let targetFolder = System.IO.Path.Combine(podsFolder, safePodName, "XCode")
    freshDirectory targetFolder
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
        // tracefn "looking for deps for %s subspec" subSpec
        let podSubSpec = podSpec.Subspecs |> Seq.pick (fun s -> if s.Name = subSpec then Some(s) else None )
        let dependenciesOptional = podSubSpec.JsonValue.TryGetProperty "dependencies"
        if dependenciesOptional.IsSome then
                    dependenciesOptional.Value.Properties() 
                        |> Seq.map (fun (k,v) -> k)
                        |> Seq.toList
                else
                    []

let private alwaysArray (json: JsonValue) propertyName = //todo extension method?
    let j = json.TryGetProperty propertyName
    if j.IsSome then
        match j.Value with
            | JsonValue.String single -> [|single|]
            | JsonValue.Array array -> array |> Array.map (fun a -> a.AsString())
            | _ -> [||]
    else
        [||]

let generateLinkWith (podSpec:Podspec.Root) (podName:string) =
   let safePodName = fileSafePodName podName 
   let linkWithContent = new System.Text.StringBuilder()
   linkWithContent.AppendLine("using ObjCRuntime;") |> ignore
   linkWithContent.AppendFormat(@"[assembly: LinkWith (""{0}.a"", {1}", safePodName, Environment.NewLine) |> ignore
   if (podSpec.Frameworks.Length > 0) then
        linkWithContent.AppendFormat(@"Frameworks = ""{0}"",{1}", String.Join(" ", podSpec.Frameworks), Environment.NewLine) |> ignore
   let libraries = alwaysArray podSpec.JsonValue "libraries"
   if not <| Array.isEmpty libraries then
        let linkerFlags = libraries 
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


let podHeadersLocation (podName:string) = 
    // tracefn "Get headers location for pod %s " podName
    let truePodName = podNameWithoutSubSpec podName
    let podSubSpec = podSubSpec podName
    let podSpec = specForPod podName
    let podFolder = fileSafePodName podName
    let isFramework = isFrameworkSpec podSpec
    if isFramework then
        Path.Combine(podsFolder, podFolder, "XCode", "Pods", truePodName, podSpec.VendoredFrameworks.[0], "Headers")
    else 
        let guessFrameworkPath = Path.Combine(podsFolder, podFolder, "XCode", "Pods", truePodName, truePodName) 
        let bestGuess = Path.Combine(guessFrameworkPath, truePodName + ".h")
        if File.Exists bestGuess then
            guessFrameworkPath
        else
            traceFAKE "Can't get headers location for a pod that is not providing framework %s" podName        
            ""

let podFrameworkLocation (podName:string) = 
    let truePodName = podNameWithoutSubSpec podName
    let podSubSpec = podSubSpec podName
    let podSpec = specForPod podName
    let podFolder = fileSafePodName podName
    let isFramework = isFrameworkSpec podSpec
    if isFramework then
        let fwName = podSpec.VendoredFrameworks.[0]
        let fwContainerDir = firstRegexMatch fwName @"(.+)/.+?\.framework"
        " -F " + Path.Combine(podsFolder, podFolder, "XCode", "Pods", truePodName, fwContainerDir)
    else 
        let guessFrameworkPath = Path.Combine(podsFolder, podFolder, "XCode", "Pods", truePodName) 
        let bestGuess = Path.Combine(guessFrameworkPath, truePodName, truePodName + ".h")
        if File.Exists bestGuess then
            " -I " + guessFrameworkPath
        else
            traceFAKE "Did not guess framework location for a pod that is not providing framework %s" podName        
            ""

let getDependentHeadersLocations (podSpec: Podspec.Root) (podName:string)= 
    let dependencyHeaders = new System.Text.StringBuilder()
    let dependencies = podDependencies podSpec podName |> List.append [podName]
    printfn "DEPS for headers %A" dependencies 
    match dependencies with 
        | [] -> [||]
        | _ ->  dependencies |> Seq.filter(fun k ->
                                            let path = podHeadersLocation k
                                            tracefn "probing for dep headers %s" path
                                            Directory.Exists(path)
                                            )    
                                        |> Seq.map podFrameworkLocation
                                        |> Seq.toArray               

let getDependenciesUsings (podSpec: Podspec.Root) (podName:string) = 
    let usings = new System.Text.StringBuilder()
    let dependencies = podDependencies podSpec podName |> List.sort
    dependencies |> Seq.iter(fun k ->
                                let podNamespace = rootNamespace + fileSafePodName k
                                usings.AppendFormat("using {0};{1}", podNamespace, Environment.NewLine) |> ignore    
                            )    
    usings.ToString()               

let copyBinaryAndGenerateLinkWith podName (podSpec: Podspec.Root) podExpandedFolder = 
    let fwName = podSpec.VendoredFrameworks.[0]
    let fwBinaryName = firstRegexMatch fwName @".+/(.+?)\.framework"
    let binaryName = Path.Combine(podExpandedFolder, fwName, fwBinaryName)
    let bindingFolder = podBindingsFolder podName
    freshDirectory bindingFolder
    let dotAName = Path.Combine(bindingFolder, podName + ".a");
    CopyFile dotAName binaryName 
    let linkWithFile = Path.Combine(bindingFolder, podName + ".linkwith.cs");
    let linkerSuggestions = generateLinkWith podSpec podName
    File.WriteAllText(linkWithFile, linkerSuggestions)

let fixShapieBugs structsFile apiDefinitionFile =
    //workaround for bug https://bugzilla.xamarin.com/show_bug.cgi?id=46360
    let baseTypes = [" : nint", " : long"
                     " : nuint", " : ulong" 
                     ]
    processTemplates baseTypes [structsFile]

let generateCSharpBindingsForFramework podName (podSpec: Podspec.Root) podExpandedFolder =
    let bindingFolder = podBindingsFolder podName
    let fwName = podSpec.VendoredFrameworks.[0]    
    let fwBinaryName = firstRegexMatch fwName @".+/(.+?)\.framework"
    let iosSdkInSharpie = "iphoneos10.0" //todo detect from sharpie output
    let headersFolder = Path.Combine(podExpandedFolder, fwName, "Headers")
    let apiDefinitionFile = Path.Combine(bindingFolder, "ApiDefinitions.cs")
    let structsAndEnumsFile = Path.Combine(bindingFolder, "StructsAndEnums.cs")
    if Directory.Exists(headersFolder) then
        let rootHeaderFile = Path.Combine(headersFolder, fwBinaryName + ".h")
        let allHeaders = Path.Combine(headersFolder, "*.h")
        let podNamespace = rootNamespace + fileSafePodName podName
        let dependenciesHeaders = getDependentHeadersLocations podSpec podName
        let depHeadersOption = if dependenciesHeaders.Length > 0 then (" " + String.Join(" ", getDependentHeadersLocations podSpec podName)) else "" 
        printfn "DEPENDENT HEADERS: %s" depHeadersOption
        let sharpieArgs =  "-tlm-do-not-submit bind -output " + bindingFolder + " -sdk "+ iosSdkInSharpie + " -scope " + allHeaders + " " 
                            + rootHeaderFile + " -n " + podNamespace + " -c -I" + headersFolder +  depHeadersOption + " -v"
        printfn "Running sharpie %s" sharpieArgs                            
        let result = ExecProcess (fun info ->  
                                    info.FileName <- "sharpie"
                                    info.Arguments <- sharpieArgs) System.TimeSpan.MaxValue
        if result <> 0 then failwithf "Error during sharpie %s " sharpieArgs
        let additionalUsings = getDependenciesUsings podSpec podName
        fixShapieBugs structsAndEnumsFile apiDefinitionFile
        if not <| String.IsNullOrWhiteSpace additionalUsings then
            let apiDefinition = File.ReadAllText(apiDefinitionFile)
            let apiWithUsings = additionalUsings + apiDefinition
            //TODO in this case we should not add using clause to parent pod
            File.WriteAllText(apiDefinitionFile, apiWithUsings)
    else
        [ apiDefinitionFile;structsAndEnumsFile] |> Seq.iter (fun f-> File.WriteAllText(f, ""))
        printfn "Empty files generated for API definition since there are no headers in %s" podName 


let generateCSharpBindingsForCustom podName (podSpec: Podspec.Root) =
    let bindingFolder = podBindingsFolder podName
    let safePodName = fileSafePodName podName
    let truePodName = podNameWithoutSubSpec podName
    let podXCodeDir = Path.Combine(podsFolder, safePodName, "XCode")
    let buildOutDir = Path.Combine(podXCodeDir, "build-out")
    let iosSdkInSharpie = "iphoneos10.0" //todo detect from sharpie output
    let headersFolder = buildOutDir
    let possibleUmbrellaHeader = Path.Combine(headersFolder, truePodName + ".h")
    let mainHeader = if File.Exists possibleUmbrellaHeader then
                        possibleUmbrellaHeader  
                      else
                        let allHeaders = Path.Combine(headersFolder, "*.h")
                        let allHeaderFiles = !! allHeaders |> Seq.toArray //expand wildcard otherwise ExecProcess fails
                        let allHeadersString = String.Join(" ", allHeaderFiles)
                        allHeadersString

    let podPrivate = "-I " + Path.Combine(podXCodeDir, "Pods", "Headers", "Private")
    let podPublic = "-I" + Path.Combine(podXCodeDir, "Pods", "Headers", "Public")
    let dependenciesHeaders = [podPrivate; podPublic] |> Seq.toArray
    let depHeadersOption = if dependenciesHeaders.Length > 0 then (" " + String.Join(" ", dependenciesHeaders)) else "" 
    printfn "DEPENDENT HEADERS: %s" depHeadersOption
    let podNamespace = rootNamespace + safePodName
    let sharpieArgs =  "-tlm-do-not-submit bind -output " + bindingFolder + " -sdk "+ iosSdkInSharpie + " -scope " + headersFolder 
                             + " " + mainHeader 
                             + " -n " + podNamespace + " -c -I" + headersFolder +  depHeadersOption + " -v"
    printfn "Running sharpie %s" sharpieArgs                            
    let result = ExecProcess (fun info ->  
                                info.FileName <- "sharpie"
                                info.Arguments <- sharpieArgs) System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during sharpie %s " sharpieArgs
    let apiDefinitionFile = Path.Combine(bindingFolder, "ApiDefinitions.cs")
    let structsAndEnumsFile = Path.Combine(bindingFolder, "StructsAndEnums.cs")
    fixShapieBugs structsAndEnumsFile apiDefinitionFile
    //todo insert dependencies namespaces here
    trace "7"

let getPackageVersionForPod (podSpec: Podspec.Root) =
    let realVersion = (podSpec.JsonValue.GetProperty "version").AsString() + ".0"
    let overrideVersion = getBuildParamOrDefault "VERSION" "0.0.1"// ""
    if not <| String.IsNullOrEmpty(overrideVersion) then overrideVersion else realVersion

let buildCSProjReferences podDependencies =
    let references = new System.Text.StringBuilder();
    podDependencies |> List.iter (fun subPod -> 
                                    let dllName = fileSafePodName subPod
                                    let packageName = "DT.Xamarin." + fileSafePodName subPod
                                    let subPodSpec = specForPod subPod
                                    let subPodVersion =  getPackageVersionForPod subPodSpec
                                    references.AppendFormat(@"    <Reference Include=""{0}"">{1}", dllName, rn) |> ignore
                                    references.AppendFormat(@"      <HintPath>..\{0}\{1}.{2}\lib\{3}\{4}.dll</HintPath>{5}", packagesTempDir, packageName, subPodVersion, packagesTargetFramework, dllName, rn) 
                                        |> sbLine "      <Private>True</Private>" |> sbLine "    </Reference>" |> ignore 
                                 )
    references.ToString()

let generateCSProject podName (podSpec: Podspec.Root) podExpandedFolder =
    let safePodName = fileSafePodName podName
    let podNamespace = rootNamespace + safePodName
    let dependencies = podDependencies podSpec podName
    let references = buildCSProjReferences dependencies
    let replacements = 
            [ "@ProjectGuid@", Guid.NewGuid().ToString("B").ToUpper()
              "@RootNamespace@", podNamespace
              "@AssemblyName@", safePodName
              "@PodName@", safePodName
              "@References@", references
              "@Description@", "Xamarin binding ===" + podSpec.Description.Replace("\r"," ").Replace("\n"," ") ]
    let bindingFolder = podBindingsFolder podName
    let dllName = safePodName
    let csProjectFile = Path.Combine(bindingFolder, dllName + ".csproj")
    let assemblyInfoFolder = Path.Combine(bindingFolder, "Properties")
    let assemblyInfoFile = Path.Combine(assemblyInfoFolder,  "AssemblyInfo.cs")
    let nuspecFile = Path.Combine(bindingFolder, safePodName + ".nuspec")
    CreateDir assemblyInfoFolder 
    CopyFile csProjectFile sampleCSProject
    CopyFile assemblyInfoFile sampleAssemblyInfo
    CopyFile nuspecFile sampleNuspec
    processTemplates replacements [csProjectFile; assemblyInfoFile]
    let depBuilder = new System.Text.StringBuilder();
    match dependencies with 
        | [] -> tracefn "No dependencies for %s" podName
        | _ ->  dependencies 
                |> Seq.iter (fun (subPod) -> 
                                let subPodSpec = specForPod subPod
                                let subPodVersion =  getPackageVersionForPod subPodSpec
                                let packageName = "DT.Xamarin." + fileSafePodName subPod
                                depBuilder.AppendFormat(@"    <dependency id=""{0}"" version=""{1}"" />{2}", packageName, subPodVersion, Environment.NewLine) |> ignore
                             )
    let nugetParams = 
            [ "@PackageId@", "DT.Xamarin." + fileSafePodName podName
              "@Version@", getPackageVersionForPod podSpec 
              "@Authors@", "DreamTeam Mobile"
              "@Summary@", podSpec.Summary
              "@Description@", "Xamarin binding === " + podSpec.Description
              "@ProjectUrl@", podSpec.Homepage
              "@ReleaseNotes@", ""
              "@DllName@", dllName
              "@Dependencies@", depBuilder.ToString()
               ]
    processTemplates nugetParams [nuspecFile]
    if not <| List.isEmpty dependencies then
        let packagesConfig = Path.Combine(bindingFolder, "packages.config")
        CopyFile packagesConfig samplePackagesConfig
        let pb = new System.Text.StringBuilder()
        dependencies |> List.iter (fun subPod -> 
                                      let subPodSpec = specForPod subPod
                                      let subPodVersion =  getPackageVersionForPod subPodSpec
                                      let packageName = "DT.Xamarin." + fileSafePodName subPod
                                      pb.AppendFormat(@"<package id=""{0}"" version=""{1}"" targetFramework=""{2}"" />{3}", packageName, subPodVersion, packagesTargetFramework ,  Environment.NewLine) |> ignore
                                  )
        processTemplates ["@Packages@", pb.ToString() ] [packagesConfig]                    
    trace ""

let rec downloadPodsRecursive (podName:string) = 
    let podSpec = downloadPodSpec podName
    let dependencies = podDependencies podSpec podName
    match dependencies with 
        | [] -> tracefn "No dependencies for %s" podName
        | _ ->  dependencies |> Seq.iter (fun (k) -> 
                                    printfn "Dependency %s found for %s" k podName
                                    downloadPodsRecursive k
                                    )


let compileNonFrameworkProjectForArchitecure podName sim podXCodeDir buildOutDir =
    //see https://gist.github.com/madhikarma/09e553c508f870639570
    let architectureArgs = if sim then @" -arch i386 -arch x86_64 -sdk ""iphonesimulator""" else @" -sdk ""iphoneos"""
    let xcodeArgs = @"clean build -workspace EmptyProject.xcworkspace -scheme EmptyProject"
                    + architectureArgs
                    + @" CODE_SIGN_IDENTITY="""" CODE_SIGNING_REQUIRED=NO"
                    + " ONLY_ACTIVE_ARCH=NO"
                    + " SYMROOT=" + buildOutDir 
                    + " CONFIGURATION_BUILD_DIR=" + buildOutDir
    let result = ExecProcess (fun info ->  
       info.FileName <- "xcodebuild"
       info.WorkingDirectory <- podXCodeDir
       info.Arguments <- xcodeArgs) System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during xcodebuild %s" xcodeArgs
    let architectureExt = if sim then ".sim.a" else ".device.a"
    let binaryFile = "lib" + podNameWithoutSubSpec podName + ".a"
    let binaryFinalFile = "lib" + podNameWithoutSubSpec podName + architectureExt
    let binaryPath = Path.Combine(buildOutDir, binaryFile)
    if File.Exists binaryPath then
        let binaryFinalPath  = Path.Combine(buildOutDir, binaryFinalFile)
        CopyFile binaryFinalPath binaryPath
        binaryFinalPath
    else
        traceFAKE "VERIFY: POD %s most probably doesn't have any binaries generated" podName
        ""

let createUniversalLib file1 file2 outFile =
    //see https://gist.github.com/madhikarma/09e553c508f870639570
    //lipo -create -output "${HOME}/Desktop/${FRAMEWORK_NAME}.framework/${FRAMEWORK_NAME}" "${SRCROOT}/build/Release-iphoneos/${FRAMEWORK_NAME}.framework/${FRAMEWORK_NAME}" "${SRCROOT}/build/Release-iphonesimulator/${FRAMEWORK_NAME}.framework/${FRAMEWORK_NAME}"
    let lipoArgs = "-create -output " + outFile + " " + file1 + " " + file2
    let result = ExecProcess (fun info ->  
       info.FileName <- "lipo"
       info.Arguments <- lipoArgs) System.TimeSpan.MaxValue
    if result <> 0 then failwithf "Error during lipo %s" lipoArgs

let compileNonFrameworkProject podName (podSpec: Podspec.Root) =
    let safePodName = fileSafePodName podName
    let podXCodeDir = Path.Combine(podsFolder, safePodName, "XCode")
    let buildOutDir = Path.Combine(podXCodeDir, "build-out")
    freshDirectory buildOutDir
    let absOutDir = (DirectoryInfo buildOutDir).FullName
    let armPath = compileNonFrameworkProjectForArchitecure podName false podXCodeDir absOutDir
    if not <| String.IsNullOrEmpty armPath then
        let simPath = compileNonFrameworkProjectForArchitecure podName true podXCodeDir absOutDir
        let binaryFileName = "lib" + podNameWithoutSubSpec podName + ".a"
        let binaryPath = Path.Combine(buildOutDir, binaryFileName)
        createUniversalLib armPath simPath binaryPath
        let bindingFolder = podBindingsFolder podName
        let safePodName = fileSafePodName podName
        freshDirectory bindingFolder
        let dotAName = Path.Combine(bindingFolder, safePodName + ".a");
        CopyFile dotAName binaryPath 
        let linkWithFile = Path.Combine(bindingFolder, safePodName + ".linkwith.cs");
        let linkerSuggestions = generateLinkWith podSpec podName
        File.WriteAllText(linkWithFile, linkerSuggestions)
        true
    else
        traceFAKE "VERIFY: POD %s most probably doesn't have any binaries generated" podName
        false

let generateBindingForPod podName = 
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
        generateCSharpBindingsForFramework podName podSpec podExpandedFolder
        generateCSProject podName podSpec podExpandedFolder
        true
    else
        traceFAKE "GENERATING BINDINGS FOR NON-FRAMEWORK COCOAPOD %s" podName
        let producesBinary = compileNonFrameworkProject podName podSpec
        if producesBinary then
            generateCSharpBindingsForCustom podName podSpec
            generateCSProject podName podSpec podExpandedFolder
            true
        else
            false

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

let generateBuildScript podName depGraph =
    let buildScriptFileName = Path.Combine(bindingsFolder, (fileSafePodName podName) + ".build.sh")
    let script = new System.Text.StringBuilder();
    let rawDir = packagesDirUnsorted
    let nugetSourceDir = Path.Combine(bindingsFolder, packagesDirSorted)
    Path.Combine(bindingsFolder, rawDir) |> freshDirectory 
    nugetSourceDir |> freshDirectory
    let absDirPath = (DirectoryInfo nugetSourceDir).FullName
    Path.Combine(bindingsFolder, packagesTempDir) |> freshDirectory
    script.AppendLine("#!/bin/bash") |> sbLine "set -e" |> ignore
    script.AppendFormat("nuget sources Remove -Name {0} || true {1}", packagesSourceName, rn)  |> ignore
    script.AppendFormat("nuget sources Add -Name {0} -Source {1}{2}", packagesSourceName, absDirPath, rn)  |> ignore
    depGraph |> List.iter (fun subPod ->
                            script.AppendFormat(@"echo ""------------------------- Processing Binding {0}...""{1}", subPod, rn) |> ignore
                            script.AppendFormat(@"pushd {0}{1}", fileSafePodName subPod, rn) |> sbLine "rm -f *.nupkg" |>  ignore
                            script.AppendFormat(@"[ -f packages.config ] && nuget restore -source {0} -PackagesDirectory ../{1} || echo ""no restore required for this project""{2}", packagesSourceName, packagesTempDir, rn) |> ignore
                            script.AppendLine("msbuild /t:Clean") |> ignore
                            script.AppendFormat(@"msbuild /p:Configuration=Release{0}", rn) |> ignore
                            script.AppendFormat(@"nuget pack *.nuspec{0}", rn) |> ignore
                            script.AppendFormat(@"cp -f *.nupkg ../{0}/ {1}",rawDir, rn) |>  sbLine "popd" |> sbLine "nuget init packages-raw packages-good" |> ignore 
                            script.AppendFormat(@"nuget list -source {0} {1}",packagesSourceName, rn) 
                                |> sbLine "nuget init packages-raw packages-good"
                                |> ignore 
                          )
    script.AppendFormat("nuget sources Remove -Name {0}{1}", packagesSourceName, rn) |> ignore
    if File.Exists buildScriptFileName then 
        File.Delete buildScriptFileName
    File.WriteAllText(buildScriptFileName, script.ToString())
    ""

Target "CleanPods" ( fun()->
    trace "CleanPods"
    freshDirectory podsFolder
    File.WriteAllText(Path.Combine(podsFolder, "empty.txt"), "")
);

Target "CleanBindings" ( fun()->
    trace "CleanBindings"
    freshDirectory bindingsFolder
    File.WriteAllText(Path.Combine(bindingsFolder, "empty.txt"), "")
);

Target "Bind" ( fun()->
    let podName = getBuildParamOrDefault "POD" ""
    if String.IsNullOrEmpty(podName) then
        traceFAKE "You must specify pod name as a POD variable: sh bind.sh POD=FirebaseAnalytics"
    else
        downloadPodsRecursive podName
        let mapping = buildDependencyGraph podName
        let nonEmptyPods = mapping |> List.filter generateBindingForPod
        generateBuildScript podName nonEmptyPods |> ignore
);

// start build
RunTargetOrDefault("Bind")