@ECHO OFF
::********************************************************************************************************************
:: Purpose	:	지정한 파일을 FTP로 업로드
:: Creator	:	Kim Ki Won
:: Create	:	2016년 9월 25일 일요일 오후 10:47:31
:: Modifier	:	
:: Update	:	
:: Comment	:	
::				
::********************************************************************************************************************

::************************************************************************************************************** Label
SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
:START

SET cwd=%~dp0
CD /d %cwd%

IF NOT EXIST "%~1" ECHO. && ECHO 해당 파일이 없습니다. && ECHO. && PAUSE && GOTO :END

SET winscp=..\_Utils\WinSCP\winSCP
SET mlsFTP=x10.iptime.org
SET userName=contract
SET password=a12345678B
SET port=21
SET server=ftp://%userName%:%password%@%mlsFTP%:%port%
SET local=%~1
SET remote=%2

ECHO.
ECHO 사내 FTP로 업로드
ECHO "%WinSCP%" /command "option batch off" "option confirm on" "option transfer binary" "open %server% -passive=ON" "put ""%local%"" %remote% -neweronly" "exit"
"%WinSCP%" /command "option batch off" "option confirm on" "option transfer binary" "open %server% -passive=ON" "put ""%local%"" %remote% -neweronly" "exit"


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
