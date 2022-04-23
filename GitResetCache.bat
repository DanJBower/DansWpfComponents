@REM Turn off default echo output
@ECHO OFF

@REM Set local so that the script doesn't set the current directory outside the process.
setlocal

cd "%~dp0"

@REM If you have an issue where file changes / deletitions are not being detected, this will reset the git cache.
git rm -r --cached .

@ REM Unstage all changes - Don't want to commit all the files being deleted from cache
git reset

endlocal
pause
