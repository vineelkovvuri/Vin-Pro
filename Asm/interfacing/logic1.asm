

                ;----------LOGIC CONTROLLER-------------
;;This program demonstrate the logic controller
;; PORT A as output
;; PORT B, PORT C AS INPUT
;; Care fully connect the output side link to input side of controller card
;;       by using copper cable.
;;       If it is 0 @ outside that same willbe appered at input side of card
;;                      i.e OFF state of corresponding LED.
;;           otherwise default state is ON of LED. 
;; The glow of LED at ouputside of module is corresponding Logic 1 i.e +5v
;;              +5 volts -1 logic High
;;                   GND -0 logic Low

;;----------------------------------------------------------
                OUTPUT 2500AD
                SYMBOLS ON
                ASSUME CS:CODE,DS:CODE,SS:CODE
DATA SEGMENT
                        ORG 2400H
PORTAH          EQU     FFE1H           ;io address for high byte u32 [j5]
PORTAL          EQU     FFE0H           ;port A low byte  U27 chip [j4] 

PORTBH          EQU     FFE3H
PORTBL          EQU     FFE2H

PORTCH          EQU     FFE5H
PORTCL          EQU     FFE4H

CMDRH           EQU     FFE7H           ;U32 chip [high byte commdreg]
CMDRL           EQU     FFE6H           ;U27 chip [low byte commdreg]
DATA ENDS
END 

CODE SEGMENT
                                ORG 2000H
                MOV     AX,0000         ;SEGMENT
                MOV     DS,AX           ;initialse

				MOV     DX,CMDRL        ;CMD REG
                MOV     AL,10001011B    ; ..8255 control word
                                        ;CONFIG PORTS PORTA-OUT, PORTB-IN
                OUT     DX,AL           ;SELECT PORT A AS OUTPUT............

				MOV     DX,0FFE0H       ;PORT A LOW SELECT
                MOV     AL,0H
                OUT     DX,AL

				CALL    DELAY
                CALL    DELAY
                CALL    DELAY

				MOV     DX,PORTBL
                IN      AL,DX           ;IT READS DATABITS OF PORT B AS INPUT

				MOV     DX,PORTAL
                OUT     DX,AL

				INT     3
        DELAY:
                PUSH    CX
                MOV     CX,FFFFH
                LOOP    $
                POP     CX
                RET

CODE ENDS

        ;----8255 CONTROL WORD-------
;       D7      D6      D5      D4      D3      D2      D1      D0

;       D7      ---> MODE SET FLAG 1=ACTIVE

;.......GROUP A..........
;       D6,D5   --->MODE SELECTION
;       D4      --->PORTA       1=INPUT, 0=OUTPUT
;       D3      --->PORT C UPPER

;........GROUP B......
;       D2      --->MODE SELECTION
;       D1      --->PORTB
;       D0      --->PORT C LOWER

