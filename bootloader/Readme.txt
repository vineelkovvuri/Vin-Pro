
"C:\r\hyperv\MU_BASECORE\BaseTools\Bin\mu_nasm_extdep\Windows-x86-64\nasm.exe" -f bin bootloader.asm -o bootloader.bin
update the path of bootloader.bin in bochsrc.bxrc

Launch Bochs Debugger:
"C:\Program Files\Bochs-2.8\bochsdbg.exe" -q -f bochsrc.bxrc


Article on Bochs DBG:
https://www.fysnet.net/bochsdbg/index.htm

Other Articles:
https://thasso.xyz/2024/07/13/setting-up-an-x86-cpu.html
    src: https://github.com/thass0/blog-code/tree/main/2024-07-13-setting-up-an-x86-cpu

Real Mode:
- only 20 bits addressable memory
- segment registers act like base address holder of segments

Protected Mode:
- segment registers act like segment selectors
- segment descriptors will contain the actual segment base address and size(also called as limit)


