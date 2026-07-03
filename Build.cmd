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

clear

# Define options using an array
options=("Build" "Rebuild" "Clean" "Exit")

# Customize the prompt (default is #?)
PS3="Select an option (1-4): "

# Display menu and handle selection
select opt in "${options[@]}"; do
    case $opt in
        "Build")
            echo "You selected ${options[0]}"
			current_dir=$(pwd)
			make -f $current_dir/Linux/makefile test
			break
            ;;
        "Rebuild")
            echo "You selected ${options[1]}"
            ;;
        "Clean")
            echo "You selected ${options[2]}"
            ;;
        "Exit")
            echo "Exiting..."
            break
            ;;
        *)
            echo "Invalid selection. Please try again."
            ;;
    esac
done

exit 0