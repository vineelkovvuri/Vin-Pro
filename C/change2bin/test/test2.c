#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>

// Component names should be in lowercase
LPCWSTR ValidComponents[] = {
    L"minkernel",
    NULL
};

// Blacklisted path names should be in lowercase
LPCWSTR BlackListedPaths[] = {
    L"test",
    L"\\kit\\src\\",
    L"\\dsf_kit\\src\\",
    L"\\pgo\\",
    L"\\pogo\\",
    L"\\apiset\\downlevel\\",
    L"\\bin\\idw\\",
    L"\\bvtbin\\",
    L"\\nopogo\\",
    L"\\dbg\\",
    L"\\lnm\\",
    L"\\minwin\\",
    L"\\bldtools\\",
    L"\\none\\",
    L"\\lnm_gamecore\\",
    L"\\downlevel\\",
    L"\\monad\\",
    L"\\monadcoreclr\\",
    L"\\openssh\\",
    L"\\wdtf\\",
    L"\\loc",
    NULL
};


BOOLEAN
IsValidComponent (
    _In_ LPCWSTR Component
    )

{

    LPCWSTR *Comp;

    Comp = ValidComponents;
    while (*Comp) {
        if (wcsstr(Component, *Comp) != NULL) {
            return TRUE;
        }

        Comp++;
    }

    return FALSE;
}

BOOLEAN
IsBlackListedPath (
    _In_ LPCWSTR Bin
    )

{

    LPCWSTR *BlackListedPath;

    BlackListedPath = BlackListedPaths;
    while (*BlackListedPath) {
        if (wcsstr(Bin, *BlackListedPath) != NULL) {
            return TRUE;
        }

        BlackListedPath++;
    }

    return FALSE;
}

DWORD
ParseBinplaceLine (
    _In_ LPCWSTR Line,
    _Inout_ LPWSTR Component,
    _Inout_ LPWSTR Bin,
    _Inout_ LPWSTR Pdb
)

{

    DWORD Status;
    DWORD64 BinLength;
    DWORD64 ComponentLength;
    DWORD64 PdbLength;
    LPCWSTR BinPtr;
    LPCWSTR ComponentPtr;
    LPCWSTR PdbPtr;
    LPCWSTR Ptr;

    Status = ERROR_SUCCESS;

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
    StringCchCopyNW(Bin, MAX_PATH, BinPtr, BinLength);
    _wcslwr(Bin);
    if (IsBlackListedPath(Bin) != FALSE) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    // Get to 4th pdb path
    Ptr = wcsstr(Ptr, L":\\");
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    PdbPtr = --Ptr; //Get back to Driver letter
    Ptr = wcschr(PdbPtr, L'\t');
    if (Ptr == NULL) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    PdbLength = Ptr - PdbPtr;
    StringCchCopyNW(Pdb, MAX_PATH, PdbPtr, PdbLength);
    _wcslwr(Pdb);

Exit:
    return Status;
}


int main()
{

    WCHAR Line[4000];
    WCHAR Component[MAX_PATH];
    WCHAR Bin[MAX_PATH];
    WCHAR Pdb[MAX_PATH];
    DWORD Status;

    FILE *fp;

    fp = _wfopen(L"C:\\Users\\vineelko\\Desktop\\19h1_release_svc_1907b.log", L"r");

    while (fgetws(Line, 4000, fp)) {
        Status = ParseBinplaceLine (Line,
                    Component,
                    Bin,
                    Pdb);
        if (Status == ERROR_SUCCESS) {
//            wprintf(L"\n%s", Component);
            wprintf(L"\n%s", Bin);
//            wprintf(L"\n%s", Pdb);
        }
    }


    return 0;
}



