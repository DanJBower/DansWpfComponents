@ECHO OFF
setlocal

cd "%~dp0"

dotnet publish /p:DebugType=None /p:DebugSymbols=false /p:PublishReadyToRun=true /p:PublishSingleFile=true /p:PublishReadyToRunShowWarnings=true /p:PublishTrimmed=false /p:IncludeNativeLibrariesForSelfExtract=true "DansWpfComponents\DansWpfComponents.Demo\DansWpfComponents.Demo.csproj" -o "." -c release

endlocal
pause
