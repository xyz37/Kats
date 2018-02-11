@ECHO OFF
::********************************************************************************************************************
:: Purpose	:	 Release 빌드
:: Creator	:	Kim Ki Won
:: Create	:	2017년 11월 3일 금요일 16:52:13
:: Modifier	:	
:: Update	:	
:: Comment	:	
::				
::********************************************************************************************************************

::************************************************************************************************************** Label
SETLOCAL ENABLEEXTENSIONS ENABLEDELAYEDEXPANSION 
:START

PUSHD "%~dp0"

SET task=Build
SET target=..\_Kats.sln
SET platform=Any CPU

IF NOT "%1"=="" (
	SET target="%~1\%~nx1.csproj"
	SET platform=Any CPU
)

SET configuration=Release
CALL :__InnerBuild %task% "%platform%" %configuration% "%target%"

::SET configuration=ReleaseNet40
::CALL :__InnerBuild %task% "%platform%" %configuration% "%target%"

::SET configuration=Debug
::CALL :__InnerBuild %task% "%platform%" %configuration% "%target%"

::SET configuration=DebugNet40
::CALL :__InnerBuild %task% "%platform%" %configuration% "%target%"

POPD

GOTO END

::************************************************ Inner  Batch ************************************************ Label
:__InnerBuild
CALL "%~dp0__msbuild" /t:%1 /p:Platform="%~2" /p:Configuration=%3 "%~4"
IF NOT "%ERRORLEVEL%"=="0" PAUSE

::CALL msbuild /t:%1 /p:Platform=x86 /p:Configuration=%3 "%~4"
::IF NOT "%ERRORLEVEL%"=="0" PAUSE

::CALL msbuild /t:%1 /p:Platform=x64 /p:Configuration=%3 "%~4"
::IF NOT "%ERRORLEVEL%"=="0" PAUSE
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

