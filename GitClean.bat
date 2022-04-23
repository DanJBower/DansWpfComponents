@ECHO OFF
setlocal

cd "%~dp0"

git clean -f -d -X

endlocal
pause
