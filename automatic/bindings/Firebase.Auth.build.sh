#!/bin/bash
set -e
rm -rf packages-tmp/*.*
rm -rf packages-good/*.*
rm -rf packages-raw/*.*
nuget sources Remove -Name DT.Automatic || true 
nuget sources Add -Name DT.Automatic -Source /Users/alex/work/dt/Xamarin.Firebase.iOS/automatic/bindings/packages-good
echo "------------------------- Processing Binding GoogleSymbolUtilities..."
pushd GoogleSymbolUtilities
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding FirebaseInstanceID..."
pushd FirebaseInstanceID
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding GTMSessionFetcher/Core..."
pushd GTMSessionFetcher.Core
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding GoogleToolboxForMac/NSString+URLArguments..."
pushd GoogleToolboxForMac.NSString_URLArguments
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding GoogleToolboxForMac/NSData+zlib..."
pushd GoogleToolboxForMac.NSData_zlib
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding GoogleInterchangeUtilities..."
pushd GoogleInterchangeUtilities
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding GoogleToolboxForMac/NSDictionary+URLArguments..."
pushd GoogleToolboxForMac.NSDictionary_URLArguments
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding FirebaseCore..."
pushd FirebaseCore
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding FirebaseAnalytics..."
pushd FirebaseAnalytics
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding FirebaseAuth..."
pushd FirebaseAuth
rm -f *.nupkg
[ -f packages.config ] && nuget restore -source DT.Automatic -PackagesDirectory ../packages-tmp || echo "no restore required for this project"
msbuild /t:Clean
msbuild /p:Configuration=Release
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding Firebase/Core..."
pushd Firebase.Core
rm -f *.nupkg
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
echo "------------------------- Processing Binding Firebase/Auth..."
pushd Firebase.Auth
rm -f *.nupkg
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
