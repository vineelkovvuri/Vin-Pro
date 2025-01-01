#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include "c2b.h"

typedef struct _BINPLACE_LINE_FILTER {
    LPCWSTR *BlackListedPaths;
    DWORD NumBlackListedPaths;
    LPCWSTR *ValidComponentPaths;
    DWORD NumValidComponentPaths;
} BINPLACE_LINE_FILTER, *PBINPLACE_LINE_FILTER;

BOOLEAN
IsValidComponent (
    _In_ LPCWSTR Component,
    _In_ PBINPLACE_LINE_FILTER Filter
    )

{

    DWORD Index;
    LPWSTR *ValidComponentPaths;

    ValidComponentPaths = Filter->ValidComponentPaths;
    for (Index = 0; Index < Filter->NumValidComponentPaths; Index++) {
        if (wcsstr(Component, *ValidComponentPaths) != NULL) {
            return TRUE;
        }

        ValidComponentPaths++;
    }

    return FALSE;
}

BOOLEAN
IsBlackListedPath (
    _In_ LPCWSTR Bin,
    _In_ PBINPLACE_LINE_FILTER Filter
    )

{

    DWORD Index;
    LPWSTR *BlackListedPaths;

    BlackListedPaths = Filter->BlackListedPaths;
    for (Index = 0; Index < Filter->NumBlackListedPaths; Index++) {
        if (wcsstr(Bin, *BlackListedPaths) != NULL) {
            return TRUE;
        }

        BlackListedPaths++;
    }

    return FALSE;
}

DWORD
ParseBinplaceLine (
    _In_ LPCWSTR Line,
    _In_ PBINPLACE_LINE_FILTER Filter,
    _Inout_ LPWSTR* Bin,
    _Inout_ LPWSTR* Pdb
    )
{

    DWORD Status;
    LPCWSTR BinPtr;
    LPCWSTR BinPtrRet;
    LPCWSTR ComponentPtr;
    LPCWSTR PdbPtr;
    LPCWSTR PdbPtrRet;
    LPCWSTR Ptr;
    size_t BinLength;
    size_t ComponentLength;
    size_t PdbLength;
    WCHAR Component[MAX_PATH];

    Status = ERROR_SUCCESS;
    BinPtrRet = NULL;
    PdbPtrRet = NULL;


    ComponentPtr = Line;
    Ptr = wcschr(ComponentPtr, L'\t');
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    ComponentLength = Ptr - ComponentPtr;
    StringCchCopyNW(Component, MAX_PATH, ComponentPtr, ComponentLength);
    _wcslwr(Component);
    if (IsValidComponent(Component) == FALSE) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    // Skip Second path
    Ptr = wcsstr(Ptr, L":\\");
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    Ptr += 2;

    // Get to 3rd exe/dll path
    Ptr = wcsstr(Ptr, L":\\");
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    BinPtr = --Ptr; // Get back to Driver letter
    Ptr = wcschr(BinPtr, L'\t');
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    BinLength = Ptr - BinPtr;
    BinPtrRet = calloc(BinLength, sizeof(WCHAR));
    StringCchCopyNW(BinPtrRet, MAX_PATH, BinPtr, BinLength);
    _wcslwr(BinPtrRet);
    if (IsBlackListedPath(BinPtrRet) != FALSE) {
        Status = ERROR_INVALID_PARAMETER;
        goto FreeAlloc;
    }

    if (StrEndsWith(BinPtrRet, L".exe") == FALSE &&
        StrEndsWith(BinPtrRet, L".sys") == FALSE &&
        StrEndsWith(BinPtrRet, L".dll") == FALSE &&
        StrEndsWith(BinPtrRet, L".efi") == FALSE) {
        Status = ERROR_INVALID_PARAMETER;
        goto FreeAlloc;
    }

    // Get to 4th pdb path
    Ptr = wcsstr(Ptr, L":\\");
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto FreeAlloc;
    }

    PdbPtr = --Ptr; //Get back to Driver letter
    Ptr = wcschr(PdbPtr, L'\t');
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto FreeAlloc;
    }

    PdbLength = Ptr - PdbPtr;
    PdbPtrRet = calloc(PdbLength, sizeof(WCHAR));
    StringCchCopyNW(PdbPtrRet, MAX_PATH, PdbPtr, PdbLength);
    _wcslwr(PdbPtrRet);
    if (StrEndsWith(PdbPtrRet, L".pdb") == FALSE) {
        Status = ERROR_INVALID_PARAMETER;
        goto FreeAlloc;
    }

    return Status;

FreeAlloc:
    free(BinPtrRet);
    free(PdbPtrRet);
Exit:
    return Status;
}


DWORD
ConvertBinplaceLineRelativeToBuildPath (
    _In_ LPCWSTR BuildPath,
    _Inout_ LPWSTR Bin,
    _Inout_ LPWSTR Pdb
    )
{

    WCHAR Temp[MAX_PATH];
    LPCWSTR Flavors[] = {L"amd64fre", L"x86fre", L"arm64fre", L"woafre", NULL};
    LPCWSTR Suffix;
    LPCWSTR *Arch;

    Arch = Flavors;
    while (*Arch) {
        Suffix = wcsstr(Bin, Arch);
        if (Suffix != NULL) {
            // Skip flavor
            Suffix += wcslen(Arch) + 1;
            StringCchPrintf(Temp,
                            MAX_PATH,
                            L"%s\\%s\\bin\\%s",
                            BuildPath,
                            Arch,
                            Suffix);

            StringCchCopyW(Bin, MAX_PATH, Temp);
        }

        Suffix = wcsstr(Pdb, Arch);
        if (Suffix != NULL) {
            // Skip flavor
            Suffix += wcslen(Arch) + 1;
            StringCchPrintf(Temp,
                            MAX_PATH,
                            L"%s\\%s\\%s",
                            BuildPath,
                            Arch,
                            Suffix);

            StringCchCopyW(Pdb, MAX_PATH, Temp);
            break;
        }

        Arch++;
    }

    return ERROR_SUCCESS;
}

#if 0
DWORD
EnsureCapacity (
    _Inout_ PVOID* Array,
    _In_ INT  ArraySize,
    _Inout_ PINT ArrayCapacity,
    _Inout_ INT ElementSize
    )

{

    DWORD Status;
    PVOID NewArray;
    INT NewArrayCapacity;

    Status = ERROR_SUCCESS;
    NewArrayCapacity = *ArrayCapacity * 2;
    NewArray = NULL;

    if (ArraySize < *ArrayCapacity) {
        goto Exit;
    }

    NewArray = realloc(*Array, ElementSize * NewArrayCapacity);
    if (NewArray == NULL) {
        Status = ERROR_NOT_ENOUGH_MEMORY;
        goto Exit;
    }

    *Array = NewArray;
    *ArrayCapacity = NewArrayCapacity;

Exit:
    return Status;
}
#endif

DWORD
BinplaceParseLog (
    _Inout_ PBUILD_ARTIFACT Artifact
    )
{

    DWORD PathsCountRet;
    DWORD Status;
    FILE *File;
    PBIN_PDB PathsRet, TempBinPdb;
    WCHAR BinplaceLogPath[MAX_PATH];
    WCHAR Line[MAX_LINE];
    BINPLACE_LINE_FILTER Filter;
    struct BIN_PDB_WRAPPER {
        BIN_PDB BinPdb;
        struct BIN_PDB_WRAPPER *Next;
    } *Head, *Curr;

    Status = ERROR_SUCCESS;
    PathsRet = NULL;
    PathsCountRet = 0;
    Filter.BlackListedPaths = Artifact->BlackListedPaths;
    Filter.NumBlackListedPaths = Artifact->NumBlackListedPaths;
    Filter.ValidComponentPaths = Artifact->ValidComponentPaths;
    Filter.NumValidComponentPaths = Artifact->NumValidComponentPaths;

    StringCchPrintfW(BinplaceLogPath,
                    MAX_PATH,
                    L"%s\\amd64fre\\bin\\build_logs\\binplace.log",
                    Artifact->BuildPath);

    File = _wfopen(BinplaceLogPath, L"r");
    if (File == NULL) {
        Status = ERROR_FILE_NOT_FOUND;
        goto Exit;
    }

    while (fgetws(Line, MAX_LINE, File)) {
        Curr = calloc(1, sizeof(struct BIN_PDB_WRAPPER));
        Status = ParseBinplaceLine(Line,
                                    &Filter,
                                    &Curr->BinPdb.Bin,
                                    &Curr->BinPdb.Pdb);

        if (Status != ERROR_SUCCESS) {
            free(Curr);
            continue;
        }

        Status = ConvertBinplaceLineRelativeToBuildPath(Artifact->BuildPath,
                                                    Curr->BinPdb.Bin,
                                                    Curr->BinPdb.Pdb);

        if (Status != ERROR_SUCCESS) {
            free(Curr);
            continue;
        }

        PathsCountRet++;
        Curr->Next = Head;
        Head = Curr;
    }

    TempBinPdb = PathsRet = calloc(sizeof(BIN_PDB), PathsCountRet);
    if (PathsRet == NULL) {
        Status = ERROR_NOT_ENOUGH_MEMORY;
        goto Exit;
    }

    while (Head != NULL) {
        memcpy(&TempBinPdb, &Head->BinPdb, sizeof(BIN_PDB));
        TempBinPdb++;
        Curr = Head;
        Head = Head->Next;
        free(Curr);
    }

    Artifact->BinPdbArray = PathsRet;
    Artifact->NumBinPdbArray = PathsCountRet;
    Status = ERROR_SUCCESS;

Exit:
    if (File != NULL) {
        fclose(File);
    }

    return Status;
}
