	.file	"test.c"
	.def	___main;	.scl	2;	.type	32;	.endef
	.text
.globl _main
	.def	_main;	.scl	2;	.type	32;	.endef
_main:
LFB0:
	pushl	%ebp
LCFI0:
	movl	%esp, %ebp
LCFI1:
	andl	$-16, %esp
LCFI2:
	pushl	%edi
LCFI3:
	pushl	%esi
LCFI4:
	pushl	%ebx
LCFI5:
	subl	$20, %esp
LCFI6:
	call	___main
	movl	%esp, %edx
	movl	$__ZZ4mainE3C.0, %ebx
	movl	$4, %eax
	movl	%edx, %edi
	movl	%ebx, %esi
	movl	%eax, %ecx
	rep movsl
	movl	$20, 4(%esp)
	movl	$0, %eax
	addl	$20, %esp
	popl	%ebx
LCFI7:
	popl	%esi
LCFI8:
	popl	%edi
LCFI9:
	leave
LCFI10:
	ret
LFE0:
	.section .rdata,"dr"
	.align 4
__ZZ4mainE3C.0:
	.long	1
	.long	2
	.long	3
	.long	4
