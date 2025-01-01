#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include <dia2.h>
#include "c2b.h"

// Symbols/Functions to search in pdb


DWORD
ParseSymbolsInputFile (
    _Inout_ PBUILD_ARTIFACT Artifact
    )

{
    DWORD Status;
    DWORD LineCount;
    WCHAR Line[MAX_LINE];
    DWORD LineLength;
    LPCWSTR *TempFunctionNames;
    FILE *File;

    Status = ERROR_SUCCESS;
    File = NULL;
    LineCount = 0;

    File = _wfopen(FuncPath, L"r");
    if (File == NULL) {
        Status = ERROR_FILE_NOT_FOUND;
        goto Exit;
    }

    while (fgetws(Line, MAX_LINE, File) != NULL) {
        StrTrimEnd(Line);
        if (StrIsEmpty(Line)) {
            continue;
        }

        LineCount++;
    }

    rewind(File);
    TempFunctionNames = Artifact->FunctionNames = calloc(LineCount + 1, sizeof(LPCWSTR));
    while (fgetws(Line, MAX_LINE, File) != NULL) {
        StrTrimEnd(Line);
        if (StrIsEmpty(Line)) {
            continue;
        }

        *TempFunctionNames = _wcsdup(Line);
        TempFunctionNames++;
    }

    TempFunctionNames = NULL;
    qsort(Artifact->FunctionNames, LineCount, sizeof(LPCWSTR), StringCompare);
    Artifact->NumFunctionNames = LineCount;

Exit:
    if (File != NULL) {
        fclose(File);
    }

    return Status;
}

#if 0
//#define PDBUTIL_COMMANDLINE L" pretty -no-compiler-generated -no-system-libs -sym-types=all  <withnames> <pdbpath>";
#define PDBUTIL_COMMANDLINE L" pretty -no-compiler-generated -no-system-libs -sym-types=all  ";
#endif

IDiaDataSource *DiaDataSource;

static BOOLEAN DiaCOMInitialized = FALSE;

DWORD
InitDiaCOM (
    VOID
)
{

    HRESULT Hr;
    DWORD Status;

    Status = ERROR_SUCCESS;

    if (FAILED(CoInitialize(NULL))) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    DiaCOMInitialized = TRUE;

    Hr = CoCreateInstance(__uuidof(DiaSource),
                          NULL,
                          CLSCTX_INPROC_SERVER,
                          __uuidof(IDiaDataSource),
                          (void **)DiaDataSource);

    if (FAILED(Hr)) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

Exit:
    return Status;
}

VOID
FreeDiaCOM (
    VOID
    )
{

    if (DiaDataSource) {
        DiaDataSource->Release();
        DiaDataSource = NULL;
    }

    if (DiaCOMInitialized != FALSE) {
        CoUninitialize();
        DiaCOMInitialized = FALSE;
    }
}

DWORD
FindSymbolsInternal (
    _In_ PBIN_PDB BinPdb,
    )

{
	//DWORD tag;
	BSTR Name;
	HRESULT Hr;
	IDiaEnumSymbols* DiaEnumSymbols;
	IDiaSymbol* DiaSymbol;
	ULONG Retrived;
    DWORD Status;
    IDiaSession *DiaSession;
    IDiaSymbol *DiaGlobalSymbol;
    PVOID Found;

    Status = ERROR_SUCCESS;
    DiaSession = NULL;
    DiaGlobalSymbol = NULL;
    DiaEnumSymbols = NULL;
    DiaSymbol = NULL;

    Hr = (*DiaDataSource)->loadDataFromPdb(BinPdb->Pdb);
    if (FAILED(Hr)) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    // Open a session for querying symbols
    Hr = (*DiaDataSource)->openSession(&DiaSession);
    if (FAILED(Hr)) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    // Retrieve a reference to the global scope
    Hr = (*DiaSession)->get_globalScope(&DiaGlobalSymbol);
    if (FAILED(Hr)) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    // Find all children symbols in the global scope
    Hr = DiaGlobalSymbol->findChildren(SymTagNull,
                                        NULL,
                                        nsNone,
                                        &DiaEnumSymbols);

	if (FAILED(Hr)) {
        Status = ERROR_INVALID_FUNCTION;
		goto Exit;
	}

    BinPdb->Impacted = FALSE;
	while ((DiaEnumSymbols->Next(1, &DiaSymbol, &Retrived) == S_OK) &&
            (Retrived == 1)) {

		//DiaSymbol->get_symTag(&tag);
        if (SUCCEEDED(DiaSymbol->get_name(&Name))) {
            Found = bsearch(Name,
                            FunctionNames,
                            NumFunctionNames,
                            sizeof(LPCWSTR),
                            StringCompare);

            if (Found != NULL) {
                wprintf(L"\n%s", Name);
                BinPdb->Impacted = TRUE;
            }

            SysFreeString(Name);
        }

        if (DiaSymbol != NULL) {
            DiaSymbol->Release();
            DiaSymbol = NULL;
        }
	}

Exit:
    if (DiaEnumSymbols != NULL) {
        DiaEnumSymbols->Release();
        DiaEnumSymbols = NULL;
    }

    if (DiaGlobalSymbol != NULL) {
        DiaGlobalSymbol->Release();
        DiaGlobalSymbol = NULL;
    }

    if (DiaSession != NULL) {
        DiaSession->Release();
        DiaSession = NULL;
    }

    return Status;
}

VOID
FindSymbols (
    _In_ PBUILD_ARTIFACT Artifact
    )

{

    DWORD Status;
    DWORD Index;
    PBIN_PDB BinPdb;

    Status = ERROR_SUCCESS;
    BinPdb = Artifact->BinPdbArray;

    for (Index = 0; Index < Artifact->NumBinPdbArray; Index++, BinPdb++) {
        wprintf(L"\n[%d/%d] %s %s",
                Index,
                Artifact->NumBinPdbArray,
                BinPdb->Bin,
                BinPdb->Pdb);

        Status = FindSymbolsInternal(BinPdb);
        if (Status != ERROR_SUCCESS) {
            continue;
        }
    }

    wprintf(L"\nBelow are the list of impacted binaries");
    BinPdb = Artifact->BinPdbArray;
    for (Index = 0; Index < Artifact->NumBinPdbArray; Index++, BinPdb++) {
        if (BinPdb->Impacted != FALSE) {
            wprintf(L"\n%s", BinPdb->Bin);
        }
    }
}

