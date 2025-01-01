#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include "c2b.h"

DWORD
ConfigGetSection (
    _In_ LPCWSTR ConfigPath,
    _In_ LPCWSTR SectionName,
    _Out_ LPDWORD SectionStart,
    _Out_ LPDWORD SectionSize
    )

{

    BOOLEAN SectionFound;
    DWORD Count;
    DWORD StartLine;
    DWORD Status;
    FILE *File;
    WCHAR Line[MAX_LINE];

    Count = 0;
    File = NULL;
    SectionFound = FALSE;
    StartLine = 0;
    Status = ERROR_SUCCESS;

    File = _wfopen(ConfigPath, L"r");
    if (File == NULL) {
        Status = ERROR_FILE_NOT_FOUND;
        goto Exit;
    }

    // Find the section
    while (fgetws(Line, MAX_LINE, File) != NULL) {
        StartLine++;
        if (wcsstr(Line, SectionName) != NULL) {
            SectionFound = TRUE;
            break;
        }
    }

    if (SectionFound == FALSE) {
        Status = ERROR_INVALID_PARAMETER;
        goto Exit;
    }

    // Count the lines under the section
    while (fgetws(Line, MAX_LINE, File) != NULL && Line[0] != L'[') {
        //Skip Blank lines
        if (StrTrimEnd(Line)[0] == 0) {
            continue;
        }

        Count++;
    }

    *SectionStart = StartLine;
    *SectionSize = Count;

Exit:
    if (File != NULL) {
        fclose(File);
    }

    return Status;
}

DWORD
ConfigReadSection (
    _In_ LPCWSTR ConfigPath,
    _In_ LPCWSTR SectionName,
    _Out_ LPCWSTR **Result,
    _Out_ PDWORD  NumResult
    )

{

    DWORD Count;
    DWORD i;
    size_t LineLength;
    DWORD StartLine;
    DWORD Status;
    FILE *File;
    LPWSTR *TempResult;
    WCHAR Line[MAX_LINE];

    Count = 0;
    File = NULL;
    StartLine = 0;
    Status = ERROR_SUCCESS;

    Status = ConfigGetSection(ConfigPath,
                                SectionName,
                                &StartLine,
                                &Count);

    if (Status != ERROR_SUCCESS) {
        goto Exit;
    }

    // Allocate the buffer to string pointers + 1 for NULL
    TempResult = calloc(Count, sizeof (LPCWSTR));
    File = _wfopen(ConfigPath, L"r");
    if (File == NULL) {
        Status = ERROR_FILE_NOT_FOUND;
        goto Exit;
    }

    // Skip to the start of the section body
    for (i = 0; i < StartLine; i++) {
        if (fgetws(Line, MAX_LINE, File) == NULL) {
            Status = ERROR_FILE_NOT_FOUND;
            goto Exit;
        }
    }

    for (i = 0; i < Count;) {
        if (fgetws(Line, MAX_LINE, File) == NULL) {
            Status = ERROR_FILE_NOT_FOUND;
            goto Exit;
        }

        // Skip blank lines
        if (StrIsEmpty(StrTrimEnd(Line))) {
            continue;
        }

        TempResult[i] = _wcsdup(Line);
        i++;
    }

    *Result = TempResult;
    *NumResult = i;

Exit:

    if (File != NULL) {
        fclose(File);
    }

    return Status;
}


