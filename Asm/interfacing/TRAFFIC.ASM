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
PORTS           DB   88H,83H,0F2H    ;Allowing vehicles from south to east,west,north
                DB   88H,87H,0F2H    ;Amber on
                DB   88H,88H,00H     ;All Pedestrians on
                DB   38H,88H,0F4H    ;Allowing vehicles from west to east,south,north
                DB   78H,88H,0F4H    ;Amber on
                DB   88H,88H,00H     ;All Pedestrians on
                DB   83H,88H,0F8H    ;Allowing vehicles from north to east,west,south
                DB   87H,88H,0F8H    ;Amber on
                DB   88H,88H,00H     ;All Pedestrians on
                DB   88H,38H,0F1H    ;Allowing vehicles from east to west,south,north
                DB   88H,78H,0F1H    ;Amber on
                DB   88H,88H,00H     ;All Pedestrians on
                ;DB   88H,88H,00H     ;Dummy
DATA ENDS

CODE SEGMENT
                ORG 2000H
                                  
                MOV AX,0000H
                MOV DS,AX
                MOV DX,COMDRL           ;MAKE IT AS OUTPUT

                MOV AL,80H
                OUT DX,AL

AGAIN:          MOV CX,5
                MOV SI,OFFSET PORTS
NEXT_STATE:     MOV AL,[SI]
                MOV DX,PORTAL     
                OUT DX,AL         ;keeping in port A

                INC SI
                ADD DX,2
                MOV AL,[SI]
                OUT DX,AL         ;keeping in port B 

                INC SI
                ADD DX,2
                MOV AL,[SI]
                OUT DX,AL         ;keeping in port C

                CALL GREEN_DELAY
                INC SI

                MOV AL,[SI]
                MOV DX,PORTAL
                OUT DX,AL              

                INC SI
                ADD DX,2
                MOV AL,[SI]
                OUT DX,AL

                INC SI
                ADD DX,2
                MOV AL,[SI]
                OUT DX,AL

                CALL AMBER_DELAY
                INC SI

                LOOP NEXT_STATE
                JMP AGAIN
;-----------------------------------------------------
GREEN_DELAY:    PUSH CX
                MOV BL,1FH
DLY5:           MOV CX,FFFFH
                LOOP $
                DEC BL
                JNZ DLY5
                POP CX
                RET
;-----------------------------------------------------
AMBER_DELAY:    PUSH CX
                MOV BL,0CH
DLY10:          MOV CX,FFFFH
                LOOP $
                DEC BL
                JNZ DLY10
                POP CX
                RET
;-----------------------------------------------------

OVER:           NOP
                INT 3
CODE ENDS

