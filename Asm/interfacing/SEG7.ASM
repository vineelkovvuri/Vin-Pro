
                OUTPUT  2500AD
                SYMBOLS ON
                ASSUME   DS:DATA,CS:CODE,SS:CODE

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
DISP            DB   FFH,FFH,FFH,FFH    
                DB   C6H,86H,C7H,86H    
                DB   BFH,C0H,DEH,87H    
                DB   BFH,92H,91H,92H
                DB   92H,C8H,86H,87H    
               
DATA ENDS

CODE SEGMENT
                ORG 2000H

                MOV AX,0000H
                MOV DS,AX
                MOV DX,COMDRL           ;MAKE IT AS OUTPUT

                MOV AL,80H
                OUT DX,AL

AGAIN:          MOV SI,OFFSET DISP
                MOV CL,5

LOOP3:          MOV CH,4
LOOP2:          MOV BL,8
                MOV AL,[SI]
                INC SI
LOOP1:          ROL AL,1

                MOV DX,PORTBL
                OUT DX,AL
                MOV AH,AL

                
                MOV AL,1
                MOV DX,PORTCL
                OUT DX,AL
                DEC AL
                OUT DX,AL

                MOV AL,AH
                DEC BL
                JNZ LOOP1
                DEC CH
                JNZ LOOP2
                CALL DELAY
                DEC CL
                JNZ LOOP3
                JMP AGAIN
;--------------------------------------
DELAY:
         PUSH CX
         MOV BH,0CH
DL5:     MOV CX,FFFFH
         LOOP $
         DEC BH
         JNZ DL5
         POP CX
         RET

CODE ENDS
 END
