# Core Op-codes

    0: ADD 
    1: BJUMP
    2: COMP
    3: CREATE
    4: DIE
    5: JUMP
    6: MOVE
    7: SCAN
    8: SET
    9: SUB
    10: TRANS
    11: TURN
    12: BANK


# Instruction set level:

    1:'DIE' 'MOVE'
    2:'TURN' 'JUMP'
    3:'SCAN' #1 - #20, #Active, %Active
    4:'ADD' 'SET' 'SUB':3 & 2
    5:'COMP' 'BJUMP' 'TRANS':2 & 2
    6:'CREATE': 2 & 2 & 2


# Current additional ideas
### Parasitic & Code Disruption
- INJECT: Overwrites a single line of code in an adjacent robot's memory banks.
- MUTATE: Randomly alters a specific line of code or a register in a target robot.
- SHIELD: Temporarily immunizes a robot from being scanned, overwritten, or modified by rivals.
- FORGE: Forces a target robot to execute a single specific instruction on its next turn.
### Sensor & Navigation Upgrades
- PING: Scans the entire row or column for the closest obstacle or rival.
- RADAR: Returns the exact coordinates and absolute facing direction of the closest enemy.
- SENSE: Detects if the current tile contains any environmental hazards or passive items.
### Data Manipulation & Flow Control
- RAND: Generates a random number within a specified range and stores it in a register.
- SWAP: Exchanges the values of two memory registers instantly to pivot logic.
- DJNZ: Decrements a register and jumps to a specific line if the result is not zero.
- NOP: Does absolutely nothing for one cycle, acting as a crucial timing delay.
### Energy & Resource Management
- SIPHON: Steals execution cycles or energy from an adjacent robot to power itself.
- SHARE: Transfers internal variables, registers, or energy to an adjacent friendly robot.
- BOOST: Consumes extra resources to execute two commands in a single game tick.
