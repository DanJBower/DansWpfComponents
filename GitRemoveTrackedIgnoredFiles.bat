@REM Turn off default echo output
@ECHO OFF

@REM Set local so that the script doesn't set the current directory outside the process.
setlocal

cd "%~dp0"

@REM Remove all files
git rm -r --cached .

@REM Stage all changes - This re-adds the existing files but can't re-add the ignored files
git add .

endlocal
pause
