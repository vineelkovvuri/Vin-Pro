rem == ResetPartitions-UEFI.txt ==
convert gpt
rem == 1. System partition =========================
create partition efi size=500
format quick fs=fat32 label="System"
assign letter="S"
rem == 2. Microsoft Reserved (MSR) partition =======
create partition msr size=16
rem == 3. Windows partition ========================
rem ==    a. Create the Windows partition ==========
create partition primary 
rem ==    b. Create space for the recovery tools partition ===
shrink minimum=1000
rem ==    c. Prepare the Windows partition ========= 
format quick fs=ntfs label="Windows"
assign letter="W"
rem == 4. Windows RE tools partition ===============
create partition primary
format quick fs=ntfs label="Windows RE tools"
assign letter="T"
set id=de94bba4-06d1-4d40-a16a-bfd50179d6ac
gpt attributes=0x8000000000000001
list volume
exit