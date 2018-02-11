@ECHO OFF
SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
:START

REG QUERY HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer /v link> NUL

:: reg add "HKCU\Software\Microsoft\Command Processor" /v EnableExtensions /t REG_DWORD /d 1 /f
::REGEDIT /S "_Default.reg"

:END
ENDLOCAL
EXIT 