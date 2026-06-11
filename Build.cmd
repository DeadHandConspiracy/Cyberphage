:;# Polyglot script for Windows and Linux
:;# Run in bash: ./Build.cmd
:;# Run in cmd: Build.cmd

:<<BATCH
@echo off
echo [Windows] OS: %OS%
echo [Windows] Current dir: %CD%

CALL "%CD%\window\make.bat"
exit /b
BATCH

# Linux code starts here
echo "[Linux] OS: $(uname -s)"
echo "[Linux] Current dir: $(pwd)"
exit 0