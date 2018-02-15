@ECHO OFF
::********************************************************************************************************************
:: Purpose	:	Patch를 생성 합니다.
:: Creator	:	Kim Ki Won
:: Create	:	2016년 12월 7일 수요일 오후 7:48:24
:: Modifier	:	
:: Update	:	
:: Comment	:	
::				param1 : workingFolder : SPC 등
::				param2 : targetProc : SortPlanChanger 등
::				param3 : targetFTP : SPC 등
::				param4 : ftp upload 여부
::********************************************************************************************************************

::************************************************************************************************************** Label
SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
:START

:: 실행파일 이름만 지정
SET workingFolder=%~1
SET targetProc=%~2
SET targetFTP=%~3
SET upload=%4

SET cwd=%~dp0
CD /d %cwd%

PUSHD ..\_PatchCreator
CALL _CreatePatch.cmd "%workingFolder%" "%targetProc%" noPrompt
POPD

SET cwd=%~dp0
ECHO.

IF "%upload%"=="" CHOICE /c YN /d Y /t 5 /m "사내 FTP로 Patch 파일을 업로드 하시겠습니까?"
IF "%upload%"=="" IF "%ERRORLEVEL%"=="1" CALL "%cwd%__UploadFTP.cmd" "%outputFile%" /_9Projects/K-Packet/Patch/%targetFTP%/

GOTO END

::************************************************ Inner  Batch ************************************************ Label
:__
GOTO :EOF
::********************************************************************************************************************

::************************************************************************************************************** Label
:USAGE
ECHO.
ECHO  
ECHO.
ECHO    %~nx0 : ^< ^>
ECHO            
ECHO.
ECHO        ex) %~nx0 
ECHO.

::************************************************************************************************************** Label
:END
ENDLOCAL

EXIT
