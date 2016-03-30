@echo off
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\LinqEx.nuspec" Portable\Linq Net20\Linq Net35\Linq Net40\Linq SL\Linq UWP\Linq
popd
echo.
echo Done.
