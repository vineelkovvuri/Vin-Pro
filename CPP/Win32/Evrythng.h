/* EvryThng.h -- All standard and custom include files. */
#include "Exclude.h"
      /* Excludes definitions not required by sample programs. */
#include "envirmnt.h"
#include <windows.h>
#include <tchar.h>
#include <stdio.h>
#include <io.h>
#include "support.h"
#ifdef _MT
#include <process.h>
/* DWORD_PTR (pointer precision unsigned integer) is used for integers
 * that are converted to handles or pointers.
 * This eliminates Win64 warnings regarding conversion between
 * 32-bit and 64-bit data, as HANDLEs and pointers are 64 bits in
 * Win64 (see Chapter 16). This is enabled only if _Wp64 is defined.
 */
#if !defined(_Wp64)
#define DWORD_PTR DWORD
#define LONG_PTR LONG
#define INT_PTR INT
#endif
