/*++

Copyright (c) 1989  Microsoft Corporation

Module Name:

    ucrt.c

Abstract:

    This module implements UCRT functions

Author:

    Vineel Kovvuri (vineelko) 29-Aug-2018

Environment:

    User mode only.

--*/

#include <Windows.h>

PVOID
MemCpy(
    PVOID Dest,
    CONST PVOID Src,
    SIZE_T Count)
{
    for (SIZE_T Index = 0; Index < Count; Index++) {
        ((CONST PBYTE)Dest)[Index] = ((CONST PBYTE)Src)[Index];
    }
    return Dest;
}


int
main()
{
    
}