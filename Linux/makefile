# Compiler and flags
CC = gcc
CFLAGS = -Wall -Wextra -g
LDFLAGS =

# Automatically find all .c files and convert to .o files
SRC = $(wildcard *.c)
OBJ = $(SRC:.c=.o)
TARGET = myprogram

# Default target builds the executable
all: $(TARGET)

# Link object files into the final executable
$(TARGET): $(OBJ)
	$(CC) $(CFLAGS) -o $@ $^ $(LDFLAGS)

# Pattern rule: compile any .c file to a .o file
%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@

# Clean up build artifacts
.PHONY: clean
clean:
	rm -f $(OBJ) $(TARGET)