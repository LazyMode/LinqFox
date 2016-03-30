@echo off
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\LinqFox.nuspec" Portable\LinqFox
popd
echo.
echo Done.
