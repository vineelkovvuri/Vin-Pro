


code segment
start:

mov ax,0
mov cx,100

back :
      add ax,cx
	  loop back

mov ax,4c00h
int 21h

code ends
 end start


