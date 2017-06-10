@echo off

echo BUILDING

rem Borrowed and inspired from Akka.net : https://github.com/akkadotnet/akka.net

pushd %~dp0


SETLOCAL
SET CACHED_NUGET=%LocalAppData%\NuGet\NuGet.exe
SET NUGET_DIR=.nuget
SET PACKAGE_DIR=packages

IF EXIST %CACHED_NUGET% goto copynuget
echo Downloading latest version of NuGet.exe...
IF NOT EXIST %LocalAppData%\NuGet md %LocalAppData%\NuGet
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest 'https://www.nuget.org/nuget.exe' -OutFile '%CACHED_NUGET%'"

:copynuget
IF EXIST %NUGET_DIR%\nuget.exe goto restore
md %NUGET_DIR%
copy %CACHED_NUGET% %NUGET_DIR% > nul

:restore

%NUGET_DIR%\NuGet.exe update -self

pushd %~dp0

%NUGET_DIR%\NuGet.exe update -self

%NUGET_DIR%\NuGet.exe install FAKE -OutputDirectory %PACKAGE_DIR% -ExcludeVersion -Version 4.16.1
%NUGET_DIR%\NuGet.exe install FSharp.Data -OutputDirectory %PACKAGE_DIR%\FAKE -ExcludeVersion -Version 2.3.2

rem cls

set encoding=utf-8
%PACKAGE_DIR%\FAKE\tools\FAKE.exe Fake\build.fsx %*

popd