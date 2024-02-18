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

PVOID       // Input Buffer is a pointer to CONST VOID but expects the function to return pointer to Non CONST VOID!!!!
MemChr(
    CONST VOID* Buffer, // The input is a pointer to CONST VOID
    INT Char,
    SIZE_T Count)
{
    CONST BYTE* BufferPtr = (CONST BYTE*)Buffer;
    for (SIZE_T Index = 0; Index < Count; Index++) {
        if (*BufferPtr == (BYTE)Char) {
            return (PVOID)BufferPtr; // This is weirdest part removing constness
        }
        BufferPtr++;
    }
    return NULL;
}

//Must read about Typedef and CONST http://vineelkovvuri.com/txts/TypedefAndConstInC-21-Sep-2018.txt


INT
main()
{

}
