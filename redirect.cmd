@echo off
powershell -ep bypass -f redirect.ps1 Linq LinqFox
powershell -ep bypass -f redirect.ps1 LinqX LinqFox
pushd Release\nupkg
powershell -ep bypass -f "..\..\package.ps1" "..\..\Linq.nuspec" "..\Portable\LinqFox"
powershell -ep bypass -f "..\..\package.ps1" "..\..\LinqX.nuspec" "..\Portable\LinqFox"
popd
echo.
echo Done.
