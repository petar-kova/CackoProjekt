@echo off
setlocal

echo [1/2] Restoring NuGet packages...
dotnet restore CackoProjekt.sln
if errorlevel 1 exit /b %errorlevel%

echo [2/2] Building solution...
dotnet build CackoProjekt.sln --configuration Debug --no-restore
