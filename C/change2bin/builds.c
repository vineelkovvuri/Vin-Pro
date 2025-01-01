#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>

#include "c2b.h"

BOOLEAN
IsBuildWithIn10Days (
    _In_ SYSTEMTIME *Date1,
    _In_ SYSTEMTIME *Date2
    )

/*++

Routine Description:

    This routine will find if the difference between number of days between
    two given dates is less than 10 days

Arguments:

    Date1 - First date of the build

    Date2 - Second date of the build

Return Value:

    BOOLEAN. Returns TRUE if the given dates are 10 days apart, FALSE if not

++*/

{

    return (GetDaysSince2005(Date1) - GetDaysSince2005(Date2)) < 10;
}

BOOLEAN
IsGoodBuild (
    _In_ LPCWSTR RootPath,
    _In_ LPWIN32_FIND_DATAW Data
    )

/*++

Routine Description:

    This routine validates if the given build path is a valid path or not.

Parameter Description:

    RootPath - Path to the build directory

    Data - WIN32_FIND_DATAW is the info about file/directory

Return Value:

    BOOLEAN, returns TRUE if the build is a good candidate, FALSE otherwise

++*/

{

    DWORD Attrib;
    WCHAR TempPath[MAX_PATH];
    SYSTEMTIME FileTimeAsSystemTime;
    SYSTEMTIME TodaySystemTime;

    FileTimeToSystemTime(&Data->ftCreationTime, &FileTimeAsSystemTime);
    GetSystemTime(&TodaySystemTime);
    if (IsBuildWithIn10Days(&TodaySystemTime, &FileTimeAsSystemTime) == FALSE) {
        return FALSE;
    }

    StringCchPrintfW(TempPath,
                     MAX_PATH,
                     L"%s\\%s\\amd64fre\\fastbuild",
                     RootPath,
                     Data->cFileName);

    Attrib = GetFileAttributes(TempPath);
    if (Attrib != INVALID_FILE_ATTRIBUTES &&
        (Attrib & FILE_ATTRIBUTE_DIRECTORY) == FILE_ATTRIBUTE_DIRECTORY) {

        //wprintf(L"\nFailed in amd64fre\\fastbuild %s", Data->cFileName);
        return FALSE;
    }

    StringCchPrintfW(TempPath,
                     MAX_PATH,
                     L"%s\\%s\\x86fre\\fastbuild",
                     RootPath,
                     Data->cFileName);

    Attrib = GetFileAttributes(TempPath);
    if (Attrib != INVALID_FILE_ATTRIBUTES &&
        (Attrib & FILE_ATTRIBUTE_DIRECTORY) == FILE_ATTRIBUTE_DIRECTORY) {

        //wprintf(L"\nFailed in x86fre\\fastbuild %s", Data->cFileName);
        return FALSE;
    }

    StringCchPrintfW(TempPath,
                     MAX_PATH,
                     L"%s\\%s\\amd64fre\\bin",
                     RootPath,
                     Data->cFileName);

    Attrib = GetFileAttributes(TempPath);
    if (Attrib == INVALID_FILE_ATTRIBUTES) {
        //wprintf(L"\nFailed in amd64fre\\bin %s", Data->cFileName);
        return FALSE;
    }

    StringCchPrintfW(TempPath,
                     MAX_PATH,
                     L"%s\\%s\\x86fre\\bin",
                     RootPath,
                     Data->cFileName);

    Attrib = GetFileAttributes(TempPath);
    if (Attrib == INVALID_FILE_ATTRIBUTES) {
        //wprintf(L"\nFailed in x86fre\\bin %s", Data->cFileName);
        return FALSE;
    }

    StringCchPrintfW(TempPath,
                     MAX_PATH,
                     L"%s\\%s\\amd64fre\\bin\\build_logs\\binplace.log",
                     RootPath,
                     Data->cFileName);

    Attrib = GetFileAttributes(TempPath);
    if (Attrib == INVALID_FILE_ATTRIBUTES) {
        //wprintf(L"\nFailed in amd64fre\\bin\\build_logs\\binplace.log %s",
        //        Data->cFileName);

        return FALSE;
    }

    return TRUE;
}

VOID
PrintDates (
    _In_ LPWIN32_FIND_DATAW Data
    )

{

    SYSTEMTIME FileTimeAsSystemTime;

    FileTimeToSystemTime(&Data->ftCreationTime, &FileTimeAsSystemTime);
    wprintf(L"Created Time :%d", FileTimeAsSystemTime.wYear);
    FileTimeToSystemTime(&Data->ftLastAccessTime, &FileTimeAsSystemTime);
    wprintf(L"ftLastAccessTime Time :%d", FileTimeAsSystemTime.wYear);
    FileTimeToSystemTime(&Data->ftLastWriteTime, &FileTimeAsSystemTime);
    wprintf(L"ftLastWriteTime Time :%d", FileTimeAsSystemTime.wYear);

    wprintf(L"\n");
}

DWORD
FindGoodBuild (
    _Inout_ PBUILD_ARTIFACT Artifact
    )

{

    HANDLE Handle;
    WIN32_FIND_DATAW FileData;
    WCHAR TempPath[MAX_PATH];
    DWORD Status = ERROR_SUCCESS;

    StringCchPrintfW(TempPath,
                 MAX_PATH,
                 L"%s\\*.*",
                 Artifact->BuildPath);

    Handle = FindFirstFileW(TempPath, &FileData);
    if (Handle == INVALID_HANDLE_VALUE) {
        return ERROR_FILE_NOT_FOUND;
    }

    do {
        if ((wcscmp(FileData.cFileName, L".") == 0) ||
            (wcscmp(FileData.cFileName, L"..") == 0)) {

            continue;
        }

        if (IsGoodBuild(Artifact->BuildPath, &FileData) != FALSE) {
            StringCchPrintfW(Artifact->BuildPath,
                            MAX_PATH,
                            L"%s\\%s",
                            Artifact->BuildPath,
                            FileData.cFileName);

            goto Exit;
        }
    } while (FindNextFileW(Handle, &FileData));

    Status = ERROR_FILE_NOT_FOUND;

Exit:
    FindClose(Handle);
    return Status;
}

#if 0
DWORD
GetAllGoodBuilds (
    _Outptr_result_buffer_(*Count) PBUILD_ARTIFACT *BuildArtifacts,
    _Out_ PUINT Count
    )
{

    DWORD Status;
    PBUILD_ARTIFACT ArtifactsToReturn;
    UINT Index;

    *Count = 0;
    Status = ERROR_SUCCESS;

    ArtifactsToReturn = calloc(ARRAYSIZE(Branches), sizeof(BUILD_ARTIFACT));
    for (Index = 0; Index < ARRAYSIZE(Branches); Index += 1) {
        StringCchPrintfW(ArtifactsToReturn[*Count].BuildPath,
                        MAX_PATH,
                        L"\\\\winbuilds\\release\\%s",
                        Branches[Index]);

        wprintf(L"\nEnumerating.. %s", ArtifactsToReturn[*Count].BuildPath);
        Status = GetGoodBuild(&ArtifactsToReturn[*Count]);

        if (Status == ERROR_FILE_NOT_FOUND) {
            Status = ERROR_SUCCESS;
            continue;
        }

        *Count += 1;
    }

    *BuildArtifacts = ArtifactsToReturn;
    return Status;
}
#endif