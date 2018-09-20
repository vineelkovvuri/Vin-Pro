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
MemCCpy(
    PVOID Dest,
    CONST PVOID Src,
    INT Char,
    SIZE_T Count)
{
    PBYTE SrcByte = Src;
    PBYTE DestByte = Dest;
    BOOL Found = FALSE;

    for (SIZE_T Index = 0; Index < Count; Index++) {
        *DestByte++ = *SrcByte++;
        if (*SrcByte == (BYTE)Char) {
            Found = TRUE;
            break;
        }
    }

    return Found ? DestByte : NULL;
}

#if 0
PVOID                                                // The return type will be declared in a seperate line
MemCCpy(                                             // Function's opening brace will on this line
    PVOID Dest,                                      // Parameter names always follow PascalNamingConvention
    CONST PVOID Src,                                 // Data types always follow predefined types
    INT Char,
    SIZE_T Count)
{                                                    // Opening brace always start in a new line for the method
    PBYTE SrcByte = Src;                             // Even local variables follow PascalNaming
    PBYTE DestByte = Dest;

    for (SIZE_T Index = 0; Index < Count; Index++) { // Even loop variable follows PascalNaming!
        *DestByte++ = *SrcByte++;
        if (*SrcByte == (BYTE)Char) {                // Opening brace for control structures follow K&R
            return DestByte;
        }
    }
    return DestByte;
}
#endif


int main()
{

}