if exist FS0:\cbmr_app_debug.efi then
    FS0:
endif

if exist FS1:\cbmr_app_debug.efi then
    FS1:
endif

if exist FS2:\cbmr_app_debug.efi then
    FS2:
endif

if exist FS3:\cbmr_app_debug.efi then
    FS3:
endif

load cbmr_driver_debug.efi

cbmr_app_debug.efi
