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
;                     0  1   2   3  4   5   6    7   8   9
DISP            DB  C0H,F9H,A4H,B0H,99h,92H,82H,F8H,80H,90H
               
DATA ENDS

CODE SEGMENT
                ORG 2000H

                MOV AX,0000H
                MOV DS,AX
                MOV DX,COMDRL           ;MAKE IT AS OUTPUT
                MOV AL,80H
                OUT DX,AL




AGAIN:          MOV SI, OFFSET DISP

                               MOV CL,0AH


NEXT:           MOV AL,[SI]

                INC SI

                MOV BL,8H

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


                MOV CH,3H
LP1:            MOV BL,8H

                MOV AL,COH

LOOP2:          ROL AL,1
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
                JNZ LOOP2

                DEC CH
                JNZ LP1
                CALL DELAY
                
                DEC CL
                JNZ NEXT

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
