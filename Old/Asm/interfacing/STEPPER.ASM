                OUTPUT 2500AD
                SYMBOLS ON
                ASSUME CS:CODE,DS:DATA,SS:CODE
DATA SEGMENT

                 ORG 2200H

PORTAL          EQU     FFE0H
PORTAH          EQU     FFE1H

PORTBL          EQU     FFE2H
PORTBH          EQU     FFE3H

PORTCL          EQU     FFE4H
PORTCH          EQU     FFE5H

COMDRL          EQU     FFE6H
COMDRH          EQU     FFE7H

FORWARD         DB 09H,0AH,06H,05H
BACKWARD        DB 05H,06H,0AH,09H
DATA ENDS

CODE SEGMENT
                ORG 2000H
                                  
                MOV AX,0000H
                MOV DS,AX
                MOV DX,COMDRL           ;MAKE IT AS OUTPUT

                MOV AL,80H
                OUT DX,AL
                MOV CX,100
                MOV DX,PORTAL
BACK:           MOV BL,4
                MOV SI,OFFSET BACKWARD
NEXT_CODE:      MOV AL,[SI]
                OUT DX,AL
                CALL DELAY
                INC SI
                DEC BL
                JNZ NEXT_CODE
                LOOP BACK
                JMP OVER
;-----------------------------------------------------
DELAY:          PUSH CX
                
                MOV CX,FFFH
                LOOP $
                POP CX
                RET
;-----------------------------------------------------
OVER:           NOP
                INT 3
CODE ENDS
