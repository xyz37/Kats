@ECHO OFF
::********************************************************************************************************************
:: Purpose	:	마이그레이션용 자동 실행 파일을 생성 합니다.
:: Creator	:	Kim Ki Won
:: Create	:	2015년 7월 27일 월요일
:: Modifier	:	
:: Update	:	
:: Comment	:	param1: _Output 폴더의 작업 폴더 이름
::				param2: 공백이 없는 실행 파일 이름만
::				param3: 설치 시 프롬프트 여부 prompt:(blank), noPrompt:not blank
::
::				SFX_Module : Description (https://sevenzip.osdn.jp/chm/cmdline/switches/sfx.htm)
::				- 7z.sfx : Windows version.
::				- 7zCon.sfx : Console version.
::				- 7zS.sfx : Windows version for installers.
::				- 7zSD.sfx : Windows version for installers (uses MSVCRT.dll).
::********************************************************************************************************************

::************************************************************************************************************** Label
::SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
:START

IF "%~1"=="" GOTO USAGE
IF "%~2"=="" GOTO USAGE

SET cwd=%~dp0
CD /d %cwd%

SET workItem=%~1
SET workPath=..\_Output\%workItem%
SET targetProc=%~2
SET askPrompt=%3

IF NOT EXIST "%workPath%" ECHO. && ECHO %workItem% 프로젝트를 먼저 빌드 해서 _Output 폴더에 등록해야 합니다. && ECHO. && PAUSE && GOTO :EOF
CALL :__GetFullPath "%workPath%"

PUSHD "%CD%\%~1"

SET targetProcPath=%workPath%\%targetProc%.exe
SET listFile=_TargetList.txt
SET defaultListFile=_Target2Default.txt
SET targetFiles=
::SET zipFile=%targetProc%_Patch
SET zipFile=%workItem%_Patch
SET zipFileName=%zipFile%.7z
SET configFilename=config.txt
SET tempPath=_Temp
SET outputPath=..\..\_Patch

IF NOT EXIST "%tempPath%" MD "%tempPath%"
IF NOT EXIST "%outputPath%" MD "%outputPath%"

::CALL :__GenerateList
IF NOT EXIST "%listFile%" GOTO USAGE

CALL :__GetFileVersion "%targetProcPath%"

:: Get Default list files
FOR /F "usebackq tokens=* delims=" %%F IN (%defaultListFile%) DO SET targetFiles=!targetFiles!"%CD%\%%~F" 
:: Get Target list files
FOR /F "usebackq tokens=* delims=" %%F IN (%listFile%) DO SET targetFiles=!targetFiles!"%%~F" 

IF EXIST "%tempPath%\%zipFileName%" DEL /q "%tempPath%\%zipFileName%"

SET cwd=%CD%\

ECHO Bin Output   : %workPath%
ECHO Current      : %CD%
ECHO Patch Output : %outputPath%

PUSHD %workPath%

"%cwd%..\7za" a "%cwd%%tempPath%\%zipFileName%" "%cwd%%defaultListFile%" "%cwd%%listFile%" %targetFiles%
:: Patch.cmd 이용시
::"%cwd%\..\7za" a "%cwd%%tempPath%\%zipFileName%" "%cwd%_Patch.cmd" "%cwd%\..\_Setup.cmd" "%cwd%\..\_Default.reg" "%cwd%%defaultListFile%" "%cwd%%listFile%" %targetFiles%
POPD

CALL :__CreateConfig %configFilename% %fileVersion%

SET outputFilePath=%outputPath%\%zipFile%_%fileVersion%.exe
COPY /y /b ..\7zS.sfx + %configFilename% + "%tempPath%\%zipFileName%" "%outputFilePath%"

GOTO :END

::************************************************ Inner  Batch ************************************************ Label
:__GetFullPath
SET workPath=%~dpnx1

GOTO :EOF
::********************************************************************************************************************

::************************************************ Inner  Batch ************************************************ Label
:__GenerateList
CHOICE /c YN /M "오늘 변경된 파일 목록을 자동 생성하시겠습니까?(10초후 기본:N)" /d N /t 10
ECHO.

IF "%ERRORLEVEL%"=="2" GOTO :EOF

IF EXIST "%listFile%" DEL /q "%listFile%"

ECHO.
ECHO 변경된 파일을 검색 중입니다.
ECHO.
::FOR /F "usebackq tokens=1,2* delims= " %%F IN (`forfiles /p "%workPath%" /d 0 /s /c "cmd /c echo @isdir @path"`) DO (
FOR /F "usebackq tokens=1,2* delims= " %%F IN (`forfiles /p "%workPath%" /s /c "cmd /c echo @isdir @path"`) DO (
	IF "%%F"=="FALSE" (
		SET tempPath=%%~G %%~H
		SET tempPath=!tempPath:"=!
		@ECHO !tempPath:%workPath%\=!
		@ECHO !tempPath:%workPath%\=!>> "%listFile%"
	)
)
ECHO.
ECHO 변경된 파일 목록을 만들었습니다.
ECHO.

GOTO :EOF
::********************************************************************************************************************

::************************************************ Inner  Batch ************************************************ Label
:__GetFileVersion
SET targetPath=%~1
SET targetPath2=%targetPath:\=\\%
ECHO %targetPath%
ECHO %targetPath2%

FOR /F %%F IN ('wmic datafile where name^="%targetPath2%" get version ^| FINDSTR /C:"1."') DO SET fileVersion=%%F

GOTO :EOF
::********************************************************************************************************************

::************************************************ Inner  Batch ************************************************ Label
:__CreateConfig
SET output=%1
SET version=%2

CHCP 65001

ECHO ;^^!@Install@^^!UTF-8^^!>%output%
ECHO Title="%targetProc% Patcher (%version%)">>%output%
IF "%askPrompt%"=="" ECHO BeginPrompt="Are you sure want to upgrade ?">>%output%
IF "%askPrompt%"=="" ECHO RunProgram="InPatch.Updater.exe">>%output%
IF NOT "%askPrompt%"=="" ECHO RunProgram="InPatch.Updater.exe -noprompt">>%output%
ECHO ;^^!@InstallEnd@^^!>>%output%

CHCP 949

GOTO :EOF
::********************************************************************************************************************

::************************************************************************************************************** Label
:USAGE
ECHO.
ECHO %listFile% 파일이 없습니다. 
ECHO _TargetList.sample 파일을 _TargetList.txt 파일로 복사하여
ECHO 업그레이드 할 파일을 작성한뒤 다시 실행하십시오.
ECHO.
PAUSE 
::************************************************************************************************************** Label

:END
POPD 

:: outputFile 변수 때문에 호출하는 곳에서 제거 한다.
::ENDLOCAL
SET outputFile=%zipFile%_%fileVersion%.exe

::EXIT
