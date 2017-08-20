

print macro str
mov ah,9
lea dx,str
int 21h
endm

.dosseg
.model small
.stack

.data
    res db 2 dup('$')
    num1 db 20 dup(0)
    num2 db 20 dup(0)
    sum db 20 dup(0)
	msg db 0dh,0ah,'hai$'
.code
.startup
     
    mov ah,1
    mov si,0 
    mov di,0
.while 1
    int 21h
	.break .if al==13
	sub al,'0'
    mov num1[si],al
    inc si    
.endw
;print msg
.while 1
    int 21h
	.break .if al==13
	sub al,'0'
    mov num2[di],al
    inc di    
.endw
;print msg
;print msg
	mov cx,si
	dec si
    dec di
.while (si!=-1||di!=-1)
    mov ax,0    
    mov al,num1[si]
    add al,num2[di]
    add al,dl
    div bl
    mov sum[si],ah
    mov dl,al             ;Store the Remainder
    dec si
    dec di
.endw
.if si ==-1
     .while(di!=-1)
	  mov al,num2[di]
	  mov sum[di],al
	  inc di
	  .endw
.elseif di==-1
     .while(si!=-1)
	  mov al,num1[si]
	  mov sum[si],al
	  inc si
	  .endw
.endif

    mov ah,9       
    mov si,0
    
printf:
    mov al,sum[si]
    add al,'0'
    mov res[0],al
    lea dx,res
    int 21h
    inc si
  loop printf
	.exit
end

