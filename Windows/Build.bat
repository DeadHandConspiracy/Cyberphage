@echo off
setlocal

:: Default target if no argument is provided
if "%1"=="" goto :help

:: Route to targets based on first argument
if /i "%1"=="build" goto :build
if /i "%1"=="clean" goto :clean
if /i "%1"=="run" goto :run
if /i "%1"=="publish" goto :publish
if /i "%1"=="test" goto :test

goto :help

:build
echo Building project...
dotnet build --configuration Release
goto :end

:clean
echo Cleaning project...
dotnet clean
goto :end

:run
echo Running project...
dotnet run --configuration Release
goto :end

:publish
echo Publishing project...
:: dotnet publish --configuration Release --output ./publish
dotnet publish -c Release -r win-x64 --self-contained=true -p:PublishSingleFile=true   
goto :end

:test
echo Running tests...
dotnet test
goto :end

:help
echo Usage: build.bat [target]
echo Targets: build, clean, run, publish, test
goto :end

:end
endlocal   