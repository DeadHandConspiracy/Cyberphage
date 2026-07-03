# The main Program name
TARGET := Cyberphage

# GCC Compiler and flags
CC := gcc
CFLAGS := -Wall -Wextra -g
CLDFLAGS :=

# DMD Compiler and flags
DC := dmd
DFLAGS :=
DLDFLAGS :=

# Returns the absolute path of the directory containing the current Makefile
C_DIR := $(dir $(abspath $(lastword $(MAKEFILE_LIST))))

# Returns the absolute path of the directory containing D language files.
D_DIR := $(subst linux,'D Lang',$(C_DIR))

# Include both .c and .d files in SRC
C_SRC := $(wildcard *.c)
D_SRC := $(shell find $(D_DIR) -name "*.d")

# Create the object directory if it doesn't exist
OBJ_DIR := OBJ 
$(shell mkdir -p $(OBJ_DIR))

# Create the binary directory if it doesn't exist
BIN_DIR := BIN
$(shell mkdir -p $(BIN_DIR))

# Generate .o object files only from the .c files in SRC
C_OBJ := $(filter %.c,$(SRC):.c=.o)


# Default target builds the executable
all: $(TARGET)


# Link object files into the final executable
$(TARGET): $(OBJ)
	$(CC) $(CFLAGS) -o $@ $^ $(CLDFLAGS)



# Pattern rule: compile any .c file to a .o file
%.o: %.c
	$(CC) $(C_SRC) $(CFLAGS) -c $< -o $@


	
%.o: %.d
	$(DC) $(D_SRC) $(DFLAGS) -c $< -o $@



# Clean up build artifacts
.PHONY: clean
clean:
	rm -f $(OBJ) $(TARGET)


# This is my test command <it will be removed>
.PHONY: test
test:
	@echo Location of Makefile: $(C_DIR)
	@echo Location of D files: $(D_DIR)
	@echo C Source files: $(C_SRC)
	@echo D Source files: $(D_SRC)
	@echo $(DC) $(D_SRC) $(DFLAGS) -c $< -o $@

