                   
                   ASSUME CS:CODE,DS:DATA,SS:CODE

.DATA
                   ORG   2500H

CMD55  EQU  0FFE6H              ;8255 LOW COMMAND REG ADDRESS
STRING DB   C8H,C1H,88H,88H     ;03=0 9F=2 25=1 0d=3
PORTB  EQU  0FFE2H
PORTC  EQU  0FFE4H               ;TO GENERATE CLOCK PULSES
DATA ENDS

.CODE
                   ORG 2000H

                 MOV AX,0000H
                 MOV DS,AX
                 MOV DX,CMD55
                 MOV AL,80H
                 OUT DX,AL
                


                 LEA SI,STRING          ;LOAD ADDRESS OF STRING TO  SI
                 MOV CL,04              ;TOT CHARACETRS


LOOP2:           MOV AX,[SI]
                 MOV BL,08H
                 
                 
LOOP1:           MOV DX,PORTB
                 OUT DX,AL

                 MOV AH,AL               ;TO KEEP COPY OF AL

;TO GENERATE CLOCK PULSE TO DISPLAY
                 
                 MOV DX,PORTC

                 MOV AL,00H                ;clock
				 OUT DX,AL

                 MOV AL,01H
                 OUT DX,AL

                 mov al,00h
                 out dx,al

                 MOV AL,AH         ;

                 shr AL,1                ;TO SEND NEXT BIT OF DATA
                 dec bl
                 JNZ LOOP1

                 CALL DELAY

                 INC SI   ;next number
                 DEC CL   ;count--
                 JNZ LOOP2

DELAY:
                 PUSH CX
                 MOV  CX,0FFH
				 BACK:LOOP BACK
                 POP  CX
                 RET

CODE ENDS
END





