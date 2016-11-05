#!/bin/bash
set -e
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
echo "------------------------- Processing Binding FirebaseDatabase..."
pushd FirebaseDatabase
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
echo "------------------------- Processing Binding Firebase/Database..."
pushd Firebase.Database
rm -f *.nupkg
nuget pack *.nuspec
cp -f *.nupkg ../packages-raw/ 
popd
nuget init packages-raw packages-good
nuget list -source DT.Automatic 
nuget init packages-raw packages-good
