@echo off

msbuild /m /t:restore,cbstoreg:publish,secwim2wim:publish,tocbs:publish,tocbsffu:publish,tocbsvhdx:publish,tocbswim:publish,tospkg:publish,tospkgffu:publish,tospkgvhdx:publish,tospkgwim:publish /p:Platform=x64 /p:RuntimeIdentifier=win-x64 /p:PublishDir="%CD%\publish\artifacts\win-x64\CLI" /p:PublishSingleFile=true /p:PublishTrimmed=false /p:Configuration=Release MobilePackageGen.sln