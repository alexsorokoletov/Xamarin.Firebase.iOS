## Automatic way of binding Firebase pods for Xamarin iOS
The tool provides "automatic" way to bind all the pods for Firebase iOS for Xamarin

It is a two step process. First you generate the bindings automatically (via bind.sh ) then you compile the bindings and package then as nuget.

To some extent this tool is similar to Xamarin's *Objective Sharpie*. Biggest difference is that this tool works with CocoaPod hierachy and generates set of dependent packages with Xamarin.iOS bindings mimicking hierarchy of CocoaPod

### How to use
Prerequisites: run `mozroots --import --sync` to import SSL root certificates.

**First stage - generate bindings**

To generate bindings `sh bind.sh POD=FirebaseDatabase` or `sh bind.sh POD=Firebase/Messaging` or use other pod names (see here https://firebase.google.com/docs/ios/setup in _Available Pods_ section)

Other options:
- POD=podName
- X-VERSION=version (override versions in all packages --- use with caution and for tests)

**Second stage - compile and package as nuget**
To compile bindings and package then, run `sh FirebaseDatabase.build.sh` script in the `bindings` folder. This script is generated automatically and will show any errors in the bindings you need to correct.

After 2nd stage you should have a set of nuget packages ready for publishing in folder `bindings/packages-raw`

Between 1st and 2nd stages you are expected to check generated bindings and make sure they compile

### Building generated bindings
1. To build all bindings use `sh _____.build.sh` script in `bindings` folder. 
1. To compile single binding use `msbuild -p:Configuration=Release` to compile in Release in the specific binding folder (e.g. bindings/AWSCore)


#### Things to fix and improve
1. support bundle resources (for example GoogleSignIn)
1. generate sim + arm libs for custom cocoapods (those that don't host framework already) **done** 
1. if cocoapod produces empty result and has dependencies - generate umbrella nuspec (VERIFY: POD Firebase/Core most probably doesn't have any binaries generated)
1. better way of namespaces (use dependencies graph, Luke) **done**
1. detailed nuspec packages and support for sub-version updates
1. use pods private/public headers for header search -I (still issue with AWSCognito and other) **done**
1. support weak_frameworks linker flag
1. way to generate multiple pods at once
1. remove newlines from assembly descriptions (AssemblyDescription)
1. automate nuget things
1. check on single pod without dependencies


#### Contribution
Please ping me if you want to collaborate, extend, fix or change the project. I will be happy to sort out the process and answer any questions
