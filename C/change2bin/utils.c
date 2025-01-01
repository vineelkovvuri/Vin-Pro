#include <Windows.h>
#include <strsafe.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>

UINT DaysInYear[50] = {
                       0,     365, 730, 1095, 1461, 1826, 2191,
    2556, 2922, 3287, 3652, 4017, 4383, 4748, 5113, 5478, 5844,
    6209, 6574, 6939, 7305, 7670, 8035, 8400, 8766, 9131, 9496,
    9861, 10227, 10592, 10957, 11322, 11688, 12053, 12418, 12783, 13149
};
UINT DaysInMonth1[12] = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334,};
UINT DaysInMonth2[12] = {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335,};

BOOLEAN
CheckYear (int Year)
{
    // If a Year is multiple of 400,
    // then it is a leap Year
    if (Year % 400 == 0)
        return TRUE;

    // Else If a Year is multiple of 100,
    // then it is not a leap Year
    if (Year % 100 == 0)
        return FALSE;

    // Else If a Year is multiple of 4,
    // then it is a leap Year
    if (Year % 4 == 0)
        return TRUE;
    return FALSE;
}

UINT
GetDaysSince2005 (
    _In_ SYSTEMTIME *Date
    )

{

    assert(Date->wYear >= 2005 && Date->wYear < 2040);

    return DaysInYear[Date->wYear - 2005] +
    (CheckYear(Date->wYear) ? DaysInMonth2[Date->wMonth - 1] : DaysInMonth1[Date->wMonth - 1]) +
    Date->wDay;
}

BOOLEAN
FileExists (
    _In_ LPCWSTR FilePath
    )

{

    HANDLE Handle;

    Handle = CreateFile(FilePath,
                        GENERIC_READ,
                        FILE_SHARE_READ,
                        NULL,
                        OPEN_EXISTING,
                        FILE_ATTRIBUTE_NORMAL,
                        NULL);

    if (Handle == INVALID_HANDLE_VALUE) {
        return FALSE;

    } else {
        CloseHandle(Handle);
        return TRUE;
    }
}

LPWSTR
StrTrimEnd (
    _Inout_ LPWSTR String
    )

{

    size_t Length;

    Length = wcslen(String);
    while (String[Length - 1] == L'\n') {
        String[--Length] = 0;
    }

    return String;
}

BOOLEAN
StrEndsWith (
    _In_ LPCWSTR String,
    _In_ LPCWSTR Suffix
    )

{
    size_t Length1;
    size_t Length2;

    Length1 = wcslen(String);
    Length2 = wcslen(Suffix);

    if (Length1 >= Length2) {
        return _wcsicmp(&String[Length1 - Length2], Suffix) == 0;
    }

    return FALSE;
}

BOOLEAN
StrIsEmpty (
    _In_ LPCWSTR String
    )

{
    return wcslen(String) == 0;
}

INT
StringCompare (
    CONST VOID* Ptr1,
    CONST VOID* Ptr2
    )

{
    LPCWSTR Str1 = *(LPCWSTR*)Ptr1;
    LPCWSTR Str2 = *(LPCWSTR*)Ptr2;

    return wcscmp(Str1, Str2);
}
