	       OUTPUT 2500AD
	       SYMBOLS ON

	       ASSUME CS:CODE,DS:DATA,SS:CODE
DATA SEGMENT

	       ORG 2200H    ;origin for data

PORTAH	       EQU    FFE1H
PORTAL	       EQU    FFE0H

PORTBH	       EQU    FFE3H
PORTBL	       EQU    FFE2H

PORTCH	       EQU    FFE5H
PORTCL	       EQU    FFE4H

CMDRH	       EQU    FFE7H
CMDRL	       EQU    FFE6H

RUN_F	       DB     09H,0AH,06H,05H
RUN_R	       DB     05H,06H,0AH,09H

COMD_STEP      DB     6

DATA ENDS

CODE SEGMENT
	       ORG    2000H
START:

	       MOV    AX,0000	;SEGMENT
	       MOV    DS,AX
	       MOV    DX,CMDRL
	       MOV    AL,80H
	       OUT    DX,AL
	       MOV    DX,PORTAL
	       MOV    CL,200

R2:
	       MOV    CH,4
	       MOV    SI,OFFSET RUN_R

R1:	       MOV    AL,[SI]
	       OUT    DX,AL
	       CALL   DELAY
	       INC    SI

	       DEC    CH

	       JNZ    R1
	       DEC    CL
	       JNZ    R2
	       INT    03H
	       RET
;----------------------------------------------------------
DELAY:	       PUSH   CX
	       MOV    CX,0FFFH
BACK:	       LOOP   BACK
	       POP    CX

	       RET
;------------------------------------------------------------
CODE ENDS
     END
