
;; ___________KeyBoard Interfacing using 8255(PPI)______________________________

;	This program demonstrate 3 x 8 keys encoding & decoding  
;	(3 rows:scan lines, 8 lines:return lines i.e standard KB)
;
;	keyBoard module is connected to 8255 LOW (Even addresses)
;	Display(logic controller is connected to 8255 High (Odd addresses)
	
;	If no key is pressed  it is 00
;	If    key is pressed  it is not equal 00

;	For keyboard's keys arrangement as well as their hexa code,
;       observe the manual

;	It working starts from upper row then down to  (R2-R0) horizantal lines
;	                       Left cols to right side (c0-c7) vertical lines

;xc:	"At starting it it set active high of row R2, and then starting from
;        col c0
;        Starting checking value col c0, if any key is pressed go for decoding
;        If not comes to next rows and check it again,
;        again if not next row R0, if not"

;xv:	Then shift ot next col c1, and repeat same procedure xc

;       Here not, jmp to next col and repeat the same procedure of xc, xv
;	
;	finally any key value is not equal to 00,
;       it is assumed  as a key is pressed and display on output.







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
DATA ENDS
CODE SEGMENT
                ORG 2000H
                MOV AX,0000H
                MOV DS,AX
                MOV AL,10010000B    	;port A i/p, port C o/p for keyboard   8255 low
                MOV DX,COMDRL
                OUT DX,AL
                MOV AL,10000010B    	;port A O/p, port B I/p for logic control 8255 high
                MOV DX,COMDRH
                OUT DX,AL


   KEYSCAN:     MOV CL,00000100B 	;make 2nd row high & rows 1,0 low
                MOV BL,0         	;to find out clolumn number

   NEXTROW:     ;CALL DELAY
                MOV AL,CL		;to save in working register AL
                MOV DX,PORTCL		;select portC for ouput
                OUT DX,AL
                CALL DELAY		;wait min.time to detect the key
                MOV DX,PORTAL		;to select portA as input
                IN AL,DX                ;reading from portA
                CMP AL,00H              ;checking the value of key status
                JNE  CHECK_COL          ;If any key is pressed that is not
                                        ;equal to the value 00, so jump to
                                        ;label CHECK_COL

					;if no key is pressed
                SHR CL			;shift right to next col
                CMP CL,00		;compare the col, 
                JE KEYSCAN		;If equal to 00,jump to label KEYSCAN
                JMP NEXTROW		;if not go to nexr row

CHECK_COL:      SHR AL			;shift to next col 
                CMP AL,00H		;if col is equal 00 i.e it is starting col
                JE OVER			;col is 00 means same is repeating
                INC BL                  ;to identify the col, incrementing col number
                JMP CHECK_COL           ;to check the col number

OVER:           CMP CL,01H              ;checking the value of CL in label
                                        ;KEYSCAN
                JNE SKIP		;after shifting, if it is not equal
                                        ;to 01, jump label SKIP
                MOV CL,00H		;to clear the Cl value

SKIP:           SHL CL			;these are  used for col adjustments,
                                        ;increments
                SHL CL
                OR CL,BL                ;encoded key value will be present in CL
                
                MOV AL,CL		;recall the Cl value into working
                                        ;register AL
                MOV DX,PORTAH		;select 8255 High to send the output
                                        ;to Logic Controller
                OUT DX,AL
                JMP KEYSCAN		;jump to KEYSCAN to start from beginning
;-----------------------------------------
DELAY:          PUSH CX
                MOV CX,FFFH
                LOOP $
                POP CX
                RET
;------------------------------------
CODE ENDS



