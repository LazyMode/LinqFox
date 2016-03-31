@echo off
setlocal
set pack=%~n0
set pack=%pack:pack-=%
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\%pack%.nuspec" "Portable\%pack%"
popd
echo.
echo Done.
