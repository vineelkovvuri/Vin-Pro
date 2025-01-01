#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>


// Blacklisted path names should be in lowercase
LPCWSTR *BlackListedPaths;

// Component names should be in lowercase
LPCWSTR *ValidComponentPaths;

#define MAX_LINE 4000

LPWSTR
StrTrimEnd (
    _Inout_ LPWSTR String
    )

{

    DWORD64 Length;

    Length = wcslen(String);
    while (String[Length - 1] == L'\n') {
        String[--Length] = 0;
    }

    return String;
}

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
    _Out_ LPCWSTR **Result
    )

{

    DWORD Count;
    DWORD i;
    DWORD64 LineLength;
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
    TempResult = calloc(Count + 1, sizeof (LPCWSTR));

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

        LineLength = wcslen(StrTrimEnd(Line));

        // Skip blank lines
        if (LineLength == 0) {
            continue;
        }

        TempResult[i] = calloc(LineLength + 1, sizeof(WCHAR));
        StringCchCopyW(TempResult[i], MAX_PATH, Line);
        i++;
    }

    TempResult[i] = NULL;
    *Result = TempResult;

Exit:

    if (File != NULL) {
        fclose(File);
    }

    return Status;
}

DWORD
ParseConfigFile (
    _In_ LPCWSTR ConfigPath
    )

{

    DWORD Status;

    Status = ConfigReadSection(ConfigPath,
                                L"[blacklisted paths]",
                                &BlackListedPaths);

    if (Status != ERROR_SUCCESS) {
        goto Exit;
    }

    Status = ConfigReadSection(ConfigPath,
                                L"[valid component paths]",
                                &ValidComponentPaths);

Exit:
    return Status;
}

int main()
{

    DWORD Status;
    LPCWSTR *Path;

    Status = ParseConfigFile(L"g:\\19h1\\src\\termsrv\\change2bin\\test\\config.txt");

    if (Status == ERROR_SUCCESS) {
        Path = BlackListedPaths;
        while (*Path) {
            wprintf(L"\n%s", *Path++);
        }

        Path = ValidComponentPaths;
        while (*Path) {
            wprintf(L"\n%s", *Path++);
        }
    }

    return 0;
}
