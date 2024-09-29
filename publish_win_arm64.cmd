@echo off

msbuild /m /t:restore,cbstoreg:publish,secwim2wim:publish,mobilepackagegen:publish /p:Platform=arm64 /p:RuntimeIdentifier=win-arm64 /p:PublishDir="%CD%\publish\artifacts\win-arm64" /p:PublishTrimmed=false /p:Configuration=Release /p:IncludeNativeLibrariesForSelfExtract=true MobilePackageGen.sln

mkdir %CD%\publish\artifacts\win-arm64-symbols
move %CD%\publish\artifacts\win-arm64\*.pdb %CD%\publish\artifacts\win-arm64-symbols\