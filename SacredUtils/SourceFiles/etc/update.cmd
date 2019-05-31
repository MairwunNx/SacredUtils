echo off
cd "%~dp0"

echo Starting updating SacredUtils ...

set executableFileName=%1
set updaterFileName=%2
set backupFolderName=%3
set updateHashString=%4

echo Assigned properties:
echo     Executable file name: %executableFileName%
echo     Updater file name: %updaterFileName%
echo     Backup folder name: %backupFolderName%
echo     Updater md5 hash: %updateHashString%

call :ProcessLoop

:ProcessLoop
QPROCESS "SacredUtils.exe">NUL
if %ERRORLEVEL% EQU 0 call :KillProcess
if %ERRORLEVEL% EQU 1 call :Validate

:KillProcess
tasklist | find /i "SacredUtils.exe" && taskkill /im SacredUtils.exe /F
call :ProcessLoop

:Validate
echo Process not SacredUtils.exe not found or killed
echo Checking updater file availability ...
if Not Exist %updaterFileName% call :UpdateNotExists
echo Checking updater file availability ...
echo Checking SacredUtils new update hash sum ...
call :CheckMd5

:UpdateNotExists
echo Update not can be continue, because update file not exists
pause
exit

:CheckMd5
for /f "delims=" %%a in ('@certutil -hashfile %updaterFileName% MD5 ^| find /v "hash of file" ^| find /v "CertUtil"') do @set hash=%%a 
if hash EQU %updateHashString% call :Update
if hash NEQ %updateHashString% call :FailUpdate

:FailUpdate
echo Update file have different md5 hash! Update file damaged!
echo Wrong md5 hash is: %hash%
pause
exit

:Update
echo Checking Md5 hash of update file done
echo Removing old SacredUtils version ...
del %executableFileName%
echo Copying new update to old SacredUtils name ...
copy %updaterFileName% %executableFileName%
echo Finishing updating ...
call :Finish

:Finish
echo Updating SacredUtils done!
start %executableFileName%
