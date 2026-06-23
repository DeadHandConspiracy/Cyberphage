:;# Polyglot script for Windows and Linux
:;# Run in bash: ./Build.cmd
:;# Run in cmd: Build.cmd

:<<BATCH
@echo off
setlocal

CALL "%CD%\Windows\Build.bat" %1
exit /b
BATCH

# Linux code starts here
make -C Linux
exit 0
