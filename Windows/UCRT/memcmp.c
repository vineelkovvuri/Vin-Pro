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

INT
MemCmp(
    CONST PVOID Buffer1,
    CONST PVOID Buffer2,
    SIZE_T Count)
{
    BYTE Byte1 = 0;
    BYTE Byte2 = 0;
    for (SIZE_T Index = 0; Index < Count; Index++) {
        Byte1 = ((CONST PBYTE)Buffer1)[Index];
        Byte2 = ((CONST PBYTE)Buffer2)[Index];
        if (Byte1 != Byte2) {
            return Byte1 - Byte2;
        }
    }
    return Byte1 - Byte2;
}


int
main()
{
    
}