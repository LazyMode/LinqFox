@echo off
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\LinqEx.nuspec" LinqX
popd
echo.
echo Done.
