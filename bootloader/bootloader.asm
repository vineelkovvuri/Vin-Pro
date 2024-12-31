; START:

; Tell compiler to generate 16 bit code
bits 16

; Bootloader specification states, that Bootloader program will be loaded
; at segment 0x0000 and address 0x07C0.
; We can use "org" directive to set program origin.
; Fixed address is of 0x0000 and 0x07C0 is 0x7C00.

;org 0x7c00 ; But i don't like it, so i will setup segments manually.

; A. Jump to the code --------------------------------------

jmp bootloader

; B.Define data, procedures here ---------------------------

message db 13,10," * [ !!! NASM: Hello World :NASM !!! ]  *",13,10,0

printMessage:
    ; -----------------
    push ax
    ; -----------------
    .loop:
            ; -----------
            lodsb
            or al,al
            jz .quitLoop
            mov ah,0x0e
            int 0x10
            jmp .loop
    ; -----------------
    .quitLoop:
    ; -----------------
    pop ax
    ; -----------------
    ret


; Here, with label "bootloader" starts our code: --------------

bootloader:
    ; This dummy instruction will make Bochs debugger to break
    ; if magic_break: enabled=1 in config file
    xchg bx,bx
    ; or we can type lb 0x7c00 in the Bochs debugger GUI's command line

    ; CLI - Interrupts:
    ; disable interrupts when setting up segments,
    ; because, changes in segment registers,
    ; could fire some interrut and ruin something for us.

    cli

    ; Setup segments, just here where we are loaded at.
    mov ax,0x07c0
    mov ds,ax
    mov gs,ax
    mov fs,ax
    mov es,ax

    ; Setup stack segment.
    ; Bios memory map description on the internet states, that:
    ; Address:
    ; from: 0x00007E00,
    ; to: 0x0007FFFF
    ; is (480.5 KiB, RAM (guaranteed free for use), Conventional memory)
    ; So let's setup our stack segment there.

    ; Setup stack segment address
    mov ax,0x07e0
    mov ss,ax
    mov bp,ax

    ; Setup stack segment pointer (roof) of 256 bytes
    mov sp,0xff

    ; STI - Interrupts:
    ; enable interrupts, so, software and hardware can call them.

    sti

    ; Display message on the screen
    mov si,message
    call printMessage

    ; Display message on the screen
    mov si,message
    call printMessage

    ; Display message on the screen
    mov si,message
    call printMessage

    ; Now stop cpu, so we could see the result

    ; Clear interrupts and halt cpu
    cli
    hlt

    ; Finish Bootloader: -------------------------------------------------------------

    ; Bootloader, must be, total in sizeof 512 bytes.
    ; The last two bytes are constant numbers.

    ; Fill rest of file with zeroes, how many zeroes needed?
    ; 510 - (Current location) - (Start of file) define bytes with value of zero
    times 510 - ($-$$) db 0

    ; Here comes last two signature bytes,
    ; so, cpu can recoginze, that this is a valid bootloader
    DB 0x55
    DB 0xAA

    ; END, but for Bochs emulator, this file will be recognized as a hard disk,
    ; so, let's make it a bit bigger, just to fool Bochs

    times 1024*1024 db 0
