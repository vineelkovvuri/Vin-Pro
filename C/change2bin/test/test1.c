#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>


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
    /*if (IsValidComponent(ComponentPtr, ComponentLength) != FALSE) {
        StringCchCopyNW(Component, MAX_PATH, Line, Length);
    }*/

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

    // Copy all the components

    StringCchCopyNW(Component, MAX_PATH, ComponentPtr, ComponentLength);
    StringCchCopyNW(Bin, MAX_PATH, BinPtr, BinLength);
    StringCchCopyNW(Pdb, MAX_PATH, PdbPtr, PdbLength);

Exit:
    return Status;
}


int main()
{

    WCHAR Line[4000];
    WCHAR Component[4000] = L"";
    WCHAR Bin[4000] = L"";
    WCHAR Pdb[4000] = L"";
    DWORD Status;

    FILE *fp;

    fp = _wfopen(L"C:\\Users\\vineelko\\Desktop\\19h1_release_svc_1907b.log", L"r");

    while (fgetws(Line, 4000, fp)) {
        Status = ParseBinplaceLine (Line,
                    Component,
                    Bin,
                    Pdb);
        if (Status == ERROR_SUCCESS) {
            wprintf(L"\n%s", Component);
            wprintf(L"\n%s", Bin);
            wprintf(L"\n%s", Pdb);
        }
    }


    return 0;
}



