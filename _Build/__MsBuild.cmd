@ECHO OFF
REM ********************************************************************************************************************
REM *	Purpose		:	MS Build의 기본 옵션을 적용한 Wrapper입니다.
REM *	Creator		:	Kim Ki Won
REM *	Create		:	2009년 6월 24일 수요일 오후 6:58:21
REM *	Modifier	:	Kim Ki Won
REM *	Update		:	2017년 3월 13일 월요일 오후 5:08:43
REM *	Comment		:	VS2017 설치 후 MSBuild가 작동 되도록 수정
REM ********************************************************************************************************************

REM ************************************************************************************************************** Label
:START
SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
SET fxPath=
SET vsVersion=

CALL :__GetFXPath

CLS
ECHO.
ECHO ******** MSBuild Wrapper in %fxPath% ********
ECHO ******** Visual Studio Version %vsVersion% ********
ECHO.

"%fxPath%\MSBuild.exe" /MaxCpuCount:%NUMBER_OF_PROCESSORS% /clp:ShowCommandLine %*

REM ShowEventId
REM /p:Configuration=Release
REM /p:Configuration=Debug
REM /t:Rebuild
REM /t:Clean

GOTO END

REM ************************************************ Inner  Batch ************************************************ Label
:__GetFXPath
SET x64=0
IF EXIST "%ProgramFiles(x86)%" SET x64=1
SET fxPath=%SystemRoot%\Microsoft.NET\Framework

IF "%x64%"=="1" SET fxPath=%SystemRoot%\Microsoft.NET\Framework64
FOR /f %%F IN ('dir /ad /one /b "%SystemRoot%\Microsoft.NET\Framework64\v*"') DO SET vsVersion=%%F
IF NOT "%vsVersion%"=="" SET fxPath=%fxPath%\%vsVersion%

SET msbuildPath=%ProgramFiles%\MSBuild

IF "%x64%"=="1" SET msbuildPath=%ProgramFiles(x86)%\MSBuild
IF EXIST "%msbuildPath%" FOR /f %%F IN ('dir /ad /one /b "%msbuildPath%\1*"') DO SET vsVersion=%%F
IF NOT "%vsVersion%"=="" SET fxPath=%msbuildPath%\%vsVersion%\Bin

:: VS2017일 경우(%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin)
::SET pf=%ProgramFiles%
::IF "%x64%"=="1" SET pf=%ProgramFiles(x86)%
SET rootKey=HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\VisualStudio\SxS\VS7
IF "%x64%"=="1" SET rootKey=HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\SxS\VS7

IF "%vsVersion%"=="15.0" (
	FOR /f "tokens=1,3* delims= " %%F IN ('REG QUERY %rootKey%') DO IF "%%F"=="15.0" SET fxPath=%%G %%HMSBuild\15.0\Bin
)

::	IF EXIST "%pf%\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin" SET fxPath="%pf%\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin"
::	IF EXIST "%pf%\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin" SET fxPath="%pf%\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin"

GOTO :EOF
REM ********************************************************************************************************************

REM ************************************************************************************************************** Label
:USAGE
ECHO.
ECHO  
ECHO.
ECHO    %~nx0 : ^< ^>
ECHO.
ECHO        ex) %~nx0 
ECHO.

REM ************************************************************************************************************** Label
:END
ENDLOCAL
