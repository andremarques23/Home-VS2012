@echo off

REM --------------------------------------------------------------------------------------
REM Set up the PROJECTROOT and ENLISTMENTROOT environment variables

call %~dp0FindRoot.cmd

REM --------------------------------------------------------------------------------------
REM Set up the global tools directory

set STTOOLS=%ENLISTMENTROOT%\tools


REM --------------------------------------------------------------------------------------
REM Set up the IsWoW64 environment variables

CALL %STTOOLS%\iswow64.exe > nul
SET /A IsWow64=%errorlevel%


REM --------------------------------------------------------------------------------------
REM Enable VS Path Variables

SET "VSINSTALLDIR=%ProgramFiles%\Microsoft Visual Studio 11.0"
if exist "%STTOOLS%\developers\%USERNAME%\vsinstalldir.cmd" (
    call "%STTOOLS%\developers\%USERNAME%\vsinstalldir.cmd"
)

SET BitSize=x86
if "%IsWoW64%" == "1" (
	SET PROCESSOR_ARCHITECTURE=x86
	SET "VSINSTALLDIR=C:\Program Files (x86)\Microsoft Visual Studio 11.0"
) 

if exist "%VSINSTALLDIR%\VC\vcvarsall.bat" (
  REM Calling vsvarsall.bat x64 will make the VSCT.exe compiler fail.
  REM call "%VSINSTALLDIR%\VC\vcvarsall.bat" %PROCESSOR_ARCHITECTURE%
  call "%VSINSTALLDIR%\VC\vcvarsall.bat" x86
) else (
	ECHO Unable to find "%VSINSTALLDIR%\VC\vcvarsall.bat"
)


REM --------------------------------------------------------------------------------------
REM Set up ReSharper dlls if installed

SET ReSharperFound=0

SET "RESHARPERINSTALLDIR=%ProgramFiles%\JetBrains\ReSharper\v5.1\Bin"

if "%IsWoW64%" == "1"  (
	SET "RESHARPERINSTALLDIR=%PROGRAMFILES(x86)%\JetBrains\ReSharper\v5.1\Bin"
)

IF EXIST "%RESHARPERINSTALLDIR%\JetBrains.Annotations.dll" ( SET ReSharperFound=1 )

IF "%ReSharperFound%"=="0" GOTO ResharperDone

echo JetBrains ReSharper was found so copying referenced assemblies...

DEL /F /Q "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\*.dll"
COPY /Y "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.ActionManagement.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\" >nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.DocumentManager.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\" >nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.DocumentModel.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.IDE.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.ProjectModel.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.Shell.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.TextControl.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.UI.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.Platform.ReSharper.Util.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Daemon.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Feature.Services.CSharp.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Feature.Services.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Features.Environment.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Intentions.CSharp.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Intentions.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Psi.CSharp.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.Psi.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul
COPY "%RESHARPERINSTALLDIR%\JetBrains.ReSharper.TestFramework.dll" "%PROJECTROOT%\Src\AddIns\ReSharper\ReferencedAssemblies\">nul

:ResharperDone
REM --------------------------------------------------------------------------------------
REM Set up the VSSDK environment variables

set VSSDKROOT=%STTOOLS%\VisualStudioSDK\2010.RTM
set VSSDKBUILD=%VSSDKROOT%\VisualStudioIntegration\Tools\Build

REM VsSDKInstall is needed for the targets file
set VsSDKInstall=%VSSDKROOT%
set VsSDKIncludes=%VSSDKROOT%\VisualStudioIntegration\Common\Inc
set VsSDKCommonAssemblies=%VSSDKROOT%\VisualStudioIntegration\Common\Assemblies
set VsSDKToolsPath=%VSSDKROOT%\VisualStudioIntegration\Tools\Bin

REM --------------------------------------------------------------------------------------
REM Set up the global bin drop location

set ROOTBIN=%PROJECTROOT%\bin

REM --------------------------------------------------------------------------------------
REM Set up the Test environment variables

set MSTESTPATH=%STTOOLS%\MSTest\10.0
set TESTBIN=%PROJECTROOT%\test\TestBin\

if NOT exist %PROJECTROOT%\Test ( mkdir %PROJECTROOT%\Test )
if NOT exist %PROJECTROOT%\Test\TestBin ( mkdir %PROJECTROOT%\Test\TestBin\ )

REM --------------------------------------------------------------------------------------
REM Set up the Wix environment variables

set WixToolsDirectory=%ENLISTMENTROOT%\Tools\wix\wix.3.5.1526.0

REM --------------------------------------------------------------------------------------
REM Set up the Signing environment variables

set SAAssemblyOriginatorKeyFile=%PROJECTROOT%\src\StyleCop.snk
set SAInternalKeyFile=%PROJECTROOT%\src\StyleCop.snk
set SADelaySign=false

REM --------------------------------------------------------------------------------------
REM Set path and user environment

CALL %STTOOLS%\dequote.cmd PATH

SET OLDPATH=%PATH%
PATH ;
SET PATH=%PATH%%STTOOLS%;
SET PATH=%PATH%%PROJECTROOT%\tools;
SET PATH=%PATH%%STTOOLS%\developers\%USERNAME%;
SET PATH=%PATH%%OLDPATH%

cd /d "%PROJECTROOT%"

REM --------------------------------------------------------------------------------------
REM Run user specific env script

if exist "%STTOOLS%\developers\%USERNAME%" (

    if exist "%STTOOLS%\developers\%USERNAME%\aliases.pub" (
        call "%STTOOLS%\alias.exe" -f "%STTOOLS%\developers\%USERNAME%\aliases.pub"
    )

    if exist "%STTOOLS%\developers\%USERNAME%\userenv.cmd" (
        call "%STTOOLS%\developers\%USERNAME%\userenv.cmd"
    )
)

REM --------------------------------------------------------------------------------------
REM Run user specific env script
 
if exist "%PROJECTROOT%\tools\developers\%USERNAME%" (
    
    if exist "%PROJECTROOT%\tools\developers\%USERNAME%\aliases.pub" (
        call "%STTOOLS%\alias.exe" -f %PROJECTROOT%\tools\developers\%USERNAME%\aliases.pub
    )

    if exist "%PROJECTROOT%\tools\developers\%USERNAME%\userenv.cmd" (
        call "%PROJECTROOT%\tools\developers\%USERNAME%\userenv.cmd"
    )
)

REM --------------------------------------------------------------------------------------
REM Routine to configure strong name verification for processor architectures.

if "%IsWoW64%" == "1"  (
   call :StrongNameConfiguration x86
   call :StrongNameConfiguration AMD64
) else (
   call :StrongNameConfiguration x86
) 

:----------------------------------------------------------------------
:
: Install Powershell if needed also
: Set the Power Shell execution policy to 'RemoteSigned'.
: 

Echo.
Echo Ensuring powershell scripts can be executed
call %PROJECTROOT%\..\tools\Scripts\ensure-powershell.cmd
:----------------------------------------------------------------------

goto :EOF

:StrongNameConfiguration

REM Register our public key for verification skipping
set ARCHITECTURE=%1
%STTOOLS%\%ARCHITECTURE%\Sn.exe -q -Vr *,ddd0da4d3e678217
%STTOOLS%\%ARCHITECTURE%\Sn.exe -q -Vr *,31bf3856ad364e35

goto :EOF