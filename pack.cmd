@echo off
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\LinqEx.nuspec" LinqEx
popd
echo.
echo Done.
