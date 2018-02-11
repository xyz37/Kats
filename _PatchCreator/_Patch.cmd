@ECHO OFF
::********************************************************************************************************************
:: Purpose	:	migration용 자동화 스크립트
:: Creator	:	Kim Ki Won
:: Create	:	2015년 7월 27일 월요일
:: Modifier	:	
:: Update	:	
:: Comment	:	
::				
::********************************************************************************************************************

::************************************************************************************************************** Label
SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
:START

CALL :__CheckReg

SET targetProc=ICP
SET targetDir=D:\Gachisoft\%targetProc%
SET listFile=_TargetList.txt
SET defaultListFile=_Target2Default.txt
ECHO %targetDir%

CALL :__KillProcess "%targetProc%.exe"

ECHO.
ECHO 기본 파일 복사중...
ECHO.
FOR /F "usebackq tokens=* delims=" %%F IN (%defaultListFile%) DO (
	SET target=%%~F
	SET ext=%%~xF
	XCOPY /y /c /d ".\%%~F" %targetDir%\!target:%%~nxF=!
)

ECHO.
ECHO 설치 파일 복사중...
ECHO.
FOR /F "usebackq tokens=* delims=" %%F IN (%listFile%) DO (
	SET target=%%~F
	SET ext=%%~xF
	XCOPY /y /c ".\%%~F" %targetDir%\!target:%%~nxF=!
)
::	IF /i "!ext!"==".config" XCOPY /y /c ".\%%~F" %targetDir%\!target:%%~nxF=!
::	IF /i NOT "!ext!"==".config" XCOPY /y /c ".\%%~F" %targetDir%\!target:%%~nxF=!
ECHO.
ECHO 설치 파일 복사 완료.
ECHO.

PUSHD "%targetDir%" 
START "%targetProc%.exe"

CHOICE /c yn /t 1 /d y >nul
GOTO :END

::************************************************ Inner  Batch ************************************************ Label
:__CheckReg
REG QUERY HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer /v link> NUL

IF NOT "%ERRORLEVEL%"=="0" REGEDIT /S "_Default.reg"

GOTO :EOF
::********************************************************************************************************************

::************************************************ Inner  Batch ************************************************ Label
:__KillProcess
SET processName=%~1
SET userName=%userName%
SET filter=/fi "imagename eq %processName%"
SET userFilter=/fi "username eq %userName%" /fi "username eq SYSTEM"

:: AML으로 실행하면 SYSTEM 계정이므로 사용자 필터 조건을 제외한다.
IF NOT "%userName%"=="" SET filter=%filter%
::IF NOT "%userName%"=="" SET filter=%filter% %userFilter%

TASKLIST %filter% | FINDSTR %processName%> NUL

IF "%ERRORLEVEL%"=="0" TASKKILL /f /t /im %processName% && ECHO %processName% 프로세스를 강제 종료 했습니다.
::IF "%ERRORLEVEL%"=="0" TASKKILL /f %userFilter% /im %processName% && ECHO %processName% 프로세스를 강제 종료 했습니다.

GOTO :EOF
::********************************************************************************************************************

:END
ENDLOCAL
EXIT 