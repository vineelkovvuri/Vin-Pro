#define UNICODE
#define _UNICODE

#include <Windows.h>
#include <stdio.h>
#include <wchar.h>

#define CREATED_DATE  (1 << 0)
#define MODIFIED_DATE (1 << 1)
#define ACCESSED_DATE (1 << 2)

#define SIZE_SORT (1 << 0)
#define DATE_SORT (1 << 1)
#define NAME_SORT (1 << 2)

#define RIGHT_MARIGN_COLUMNS (1)
#define ATTRIBUTES_FIELD_WIDTH (5 + RIGHT_MARIGN_COLUMNS)
#define FILESIZE_FIELD_WIDTH (5 + RIGHT_MARIGN_COLUMNS)
#define DATETIME_FIELD_WIDTH (17 + RIGHT_MARIGN_COLUMNS)

// .----------------------------------------------------------------.
// |ATTRIBUTES_FIELD_WIDTH|FILESIZE_FIELD_WIDTH|DATETIME_FIELD_WIDTH|
// `----------------------------------------------------------------'

/* Command Line Arguments */
BOOL recursive = FALSE;
DWORD dateType = 0;
DWORD sortType = 0;
WCHAR srcPath[MAX_PATH] = {0};

void TrimTrailingSlash(_Inout_ WCHAR* path)
{
    int len = wcslen(path);
    if (path[len - 1] == L'\\')
        path[len - 1] = L'\0';
}

int GetMonthOrdinal(_In_ WCHAR* month)
{
    //djb2 Hashing : http://www.cse.yorku.ca/~oz/hash.html
    unsigned long hash = 5381;

    hash = ((hash << 5) + hash) + month[0]; /* hash * 33 + c */
    hash = ((hash << 5) + hash) + month[1]; /* hash * 33 + c */
    hash = ((hash << 5) + hash) + month[2]; /* hash * 33 + c */
    hash &= 0xFF; // This is okay since we know the input strings

    if (hash == 0x9e) return 1;  // Jan
    if (hash == 0x12) return 2;  // Feb
    if (hash == 0x65) return 3;  // Mar
    if (hash == 0x48) return 4;  // Apr
    if (hash == 0x6c) return 5;  // May
    if (hash == 0x32) return 6;  // Jun
    if (hash == 0x30) return 7;  // Jul
    if (hash == 0xe2) return 8;  // Aug
    if (hash == 0x6d) return 9;  // Sep
    if (hash == 0x2b) return 10; // Oct
    if (hash == 0x78) return 11; // Nov
    if (hash == 0x91) return 12; // Dec

    return 0;
}

WCHAR* GetMonthName(_In_ WORD month)
{
    static WCHAR *monthNames[] = {
        L"",
        L"Jan", L"Feb", L"Mar",
        L"Apr", L"May", L"Jun",
        L"Jul", L"Aug", L"Sep",
        L"Oct", L"Nov", L"Dec",
    };

    if (month > 12 || month < 1)
        return NULL;

    return monthNames[month];
}

BOOL IsDirectory(_In_ WIN32_FIND_DATA *fdata)
{
    if (!(fdata->dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
        return FALSE;

    return TRUE;
}

BOOL IsValidDirectoryName(_In_ WIN32_FIND_DATA *fdata)
{
    if (!wcscmp(fdata->cFileName, L"."))
        return FALSE;

    if (!wcscmp(fdata->cFileName, L".."))
        return FALSE;

    return TRUE;
}

WCHAR* GetFileSizeString(_In_ WIN32_FIND_DATA *fdata)
{
    WCHAR *sizeStr = NULL;
    ULONG64 fileSize = 0;

#define KB (1024ULL)
#define MB (1024ULL * 1024ULL)
#define GB (1024ULL * 1024ULL * 1024ULL)
#define TB (1024ULL * 1024ULL * 1024ULL * 1024ULL)

// 1 extra character for \0
#define FILESIZE_STRING_LENGTH (FILESIZE_FIELD_WIDTH + 1)

    fileSize = ((ULONG64)fdata->nFileSizeHigh << 32) | fdata->nFileSizeLow;
    sizeStr = malloc(sizeof(WCHAR) * FILESIZE_STRING_LENGTH);

    if (fileSize < KB)
        swprintf(sizeStr, FILESIZE_STRING_LENGTH, L"%4I64uB ", fileSize);
    else if (fileSize >= KB && fileSize < MB)
        swprintf(sizeStr, FILESIZE_STRING_LENGTH, L"%4I64uK ", fileSize/KB);
    else if (fileSize >= MB && fileSize < GB)
        swprintf(sizeStr, FILESIZE_STRING_LENGTH, L"%4I64uM ", fileSize/MB);
    else if (fileSize >= GB && fileSize < TB)
        swprintf(sizeStr, FILESIZE_STRING_LENGTH, L"%4I64uG ", fileSize/GB);
    else if (fileSize >= TB)
        swprintf(sizeStr, FILESIZE_STRING_LENGTH, L"%4I64uT ", fileSize/TB);

    return sizeStr;
}

WCHAR* GetDateString(_In_ WIN32_FIND_DATA *fdata)
{
    SYSTEMTIME stUTC, stLocal;
    WCHAR *stString = NULL;
    FILETIME *ftime = NULL;

    // Create date string based on requested date type
    if (dateType & CREATED_DATE)
        ftime = &fdata->ftCreationTime;
    else if (dateType & MODIFIED_DATE)
        ftime = &fdata->ftLastWriteTime;
    else if (dateType & ACCESSED_DATE)
        ftime = &fdata->ftLastAccessTime;

// 1 extra character for \0
#define DATETIME_STRING_LENGTH (DATETIME_FIELD_WIDTH + 1)
    if (FileTimeToSystemTime(ftime, &stUTC)) {
        if (SystemTimeToTzSpecificLocalTime(NULL, &stUTC, &stLocal)) {
            // 1 extra character for end of the string
            stString = malloc(sizeof(WCHAR) * DATETIME_STRING_LENGTH);
            swprintf(stString,
                    DATETIME_STRING_LENGTH,
                    L"%4u %3s %02u %02u:%02u ",
                    stLocal.wYear,
                    GetMonthName(stLocal.wMonth),
                    stLocal.wDay,
                    stLocal.wHour,
                    stLocal.wMinute);
        }
    }

    return stString;
}

WCHAR* GetAttributesString(_In_ DWORD attributes)
{
    WCHAR *attribStr = NULL;

// 1 extra character for \0
#define ATTRIBUTES_STRING_LENGTH (ATTRIBUTES_FIELD_WIDTH + 1)

    attribStr = malloc(sizeof(WCHAR) * ATTRIBUTES_STRING_LENGTH);

    attribStr[0] = attributes & FILE_ATTRIBUTE_DIRECTORY ? L'D' : L'F';
    attribStr[1] = attributes & FILE_ATTRIBUTE_HIDDEN ? L'H' : L' ';
    attribStr[2] = attributes & FILE_ATTRIBUTE_SYSTEM ? L'S' : L' ';
    attribStr[3] = attributes & FILE_ATTRIBUTE_READONLY ? L'R' : L' ';
    attribStr[4] = attributes & FILE_ATTRIBUTE_REPARSE_POINT ? L'R' : L' ';
    attribStr[5] = L' ';
    attribStr[6] = L'\0';

    return attribStr;
}

WCHAR* CreateLongListingItem(_In_ WIN32_FIND_DATA *fdata)
{
    WCHAR *item = NULL;
    WCHAR *dateTimeStr = NULL;
    WCHAR *sizeStr = NULL;
    WCHAR *attrStr = NULL;

    item = malloc(sizeof(WCHAR) * MAX_PATH);
    attrStr = GetAttributesString(fdata->dwFileAttributes);
    sizeStr = GetFileSizeString(fdata);
    dateTimeStr = GetDateString(fdata);
    swprintf(item,
            MAX_PATH,
            L"%s%s%s%s",
            attrStr,
            sizeStr,
            dateTimeStr,
            fdata->cFileName);

Cleanup:
    free(attrStr);
    free(sizeStr);
    free(dateTimeStr);
    return item;
}

void ResizeFileList(_Inout_ WCHAR ***pFileList, _Inout_ UINT *capacity)
{
    WCHAR **fileList = *pFileList;

    fileList = realloc(fileList, 2 * (*capacity) * sizeof (WCHAR *));
    *capacity *= 2;
    *pFileList = fileList;
}

int GetSizeSuffixWeight(_In_ WCHAR SizeSuffix)
{
    switch (SizeSuffix) {
        case 'B':
            return 1;
        case 'K':
            return 2;
        case 'M':
            return 3;
        case 'G':
            return 4;
        case 'T':
            return 5;
    }
    return -1;
}

int SizeComparer(const void *p, const void *q)
{
    WCHAR *item1 = *(WCHAR**)p;
    WCHAR *item2 = *(WCHAR**)q;

    WCHAR *pSizeStart = &item1[ATTRIBUTES_FIELD_WIDTH];
    WCHAR *qSizeStart = &item2[ATTRIBUTES_FIELD_WIDTH];

    WCHAR *pSizeEnd = pSizeStart + FILESIZE_FIELD_WIDTH - 1 - RIGHT_MARIGN_COLUMNS;
    WCHAR *qSizeEnd = qSizeStart + FILESIZE_FIELD_WIDTH - 1 - RIGHT_MARIGN_COLUMNS;

    if (GetSizeSuffixWeight(*pSizeEnd) != GetSizeSuffixWeight(*qSizeEnd))
        return GetSizeSuffixWeight(*pSizeEnd) - GetSizeSuffixWeight(*qSizeEnd);
    else
        return wcstol(pSizeStart, NULL, 10) - wcstol(qSizeStart, NULL, 10);
}

int DateComparer(const void *p, const void *q)
{
    int diff = 0;
    WCHAR *item1 = *(WCHAR**)p;
    WCHAR *item2 = *(WCHAR**)q;

    WCHAR *pDateStart = &item1[ATTRIBUTES_FIELD_WIDTH + FILESIZE_FIELD_WIDTH];
    WCHAR *qDateStart = &item2[ATTRIBUTES_FIELD_WIDTH + FILESIZE_FIELD_WIDTH];

    WCHAR *pDateEnd = pDateStart + DATETIME_FIELD_WIDTH - 1 - RIGHT_MARIGN_COLUMNS;
    WCHAR *qDateEnd = qDateStart + DATETIME_FIELD_WIDTH - 1 - RIGHT_MARIGN_COLUMNS;

// L"2015 Nov 11 11:01 "
#define YEAR_FIELD_START   (0)
#define MONTH_FIELD_START  (YEAR_FIELD_START  + 4 + 1) /* START + YEAR  + SEPERATOR */
#define DAY_FIELD_START    (MONTH_FIELD_START + 3 + 1) /* START + MONTH + SEPERATOR */
#define HOUR_FIELD_START   (DAY_FIELD_START   + 2 + 1) /* START + DAY   + SEPERATOR */
#define MINUTE_FIELD_START (HOUR_FIELD_START  + 2 + 1) /* START + HOUR  + SEPERATOR */

    diff = wcstol(pDateStart + YEAR_FIELD_START, NULL, 10) -
           wcstol(qDateStart + YEAR_FIELD_START, NULL, 10);
    if (diff != 0)
        return diff;

    diff = GetMonthOrdinal(pDateStart + MONTH_FIELD_START) -
           GetMonthOrdinal(qDateStart + MONTH_FIELD_START);
    if (diff != 0)
        return diff;

    diff = wcstol(pDateStart + DAY_FIELD_START, NULL, 10) -
           wcstol(qDateStart + DAY_FIELD_START, NULL, 10);
    if (diff != 0)
        return diff;

    diff = wcstol(pDateStart + HOUR_FIELD_START, NULL, 10) -
           wcstol(qDateStart + HOUR_FIELD_START, NULL, 10);
    if (diff != 0)
        return diff;

    diff = wcstol(pDateStart + MINUTE_FIELD_START, NULL, 10) -
           wcstol(qDateStart + MINUTE_FIELD_START, NULL, 10);
    if (diff != 0)
        return diff;

    return 0;
}

int NameComparer(const void *p, const void *q)
{
    WCHAR *item1 = *(WCHAR**)p;
    WCHAR *item2 = *(WCHAR**)q;

    WCHAR *pNameStart = &item1[ATTRIBUTES_FIELD_WIDTH + FILESIZE_FIELD_WIDTH + DATETIME_FIELD_WIDTH];
    WCHAR *qNameStart = &item2[ATTRIBUTES_FIELD_WIDTH + FILESIZE_FIELD_WIDTH + DATETIME_FIELD_WIDTH];

    return wcscmp(pNameStart, qNameStart);
}

void SortLongListing(_Inout_ WCHAR **longFileList, _In_ UINT listSize)
{
    if (sortType & SIZE_SORT)
        qsort(longFileList, listSize, sizeof(WCHAR *), SizeComparer);
    else if (sortType & DATE_SORT)
        qsort(longFileList, listSize, sizeof(WCHAR *), DateComparer);
    else if (sortType & NAME_SORT)
        qsort(longFileList, listSize, sizeof(WCHAR *), NameComparer);
    else ;
        // no sorting is required
}

WCHAR** GenerateLongListing(_In_z_ WCHAR *path, _Out_ DWORD *fileListCount)
{
    WCHAR **longFileList = NULL;
    WCHAR wpath[MAX_PATH] = {0};
    WIN32_FIND_DATA fdata = {0};
    UINT capacity = 1024;
    HANDLE handle;
    UINT i = 0;

    // allocate memory for long file list array
    longFileList = malloc(sizeof(WCHAR*) * capacity);

    swprintf(wpath, MAX_PATH, L"%s\\*", path);

    handle = FindFirstFile(wpath, &fdata);
    if (handle != INVALID_HANDLE_VALUE) {
        do {
            WCHAR *item = NULL;

            // Skip . and .. directories
            if (!IsValidDirectoryName(&fdata))
                continue;

            item = CreateLongListingItem(&fdata);

            if (i == capacity)
                ResizeFileList(&longFileList, &capacity);

            longFileList[i++] = item;

        } while (FindNextFile(handle, &fdata));

        FindClose(handle);
    }

    *fileListCount = i;

    //sort the list
    SortLongListing(longFileList, i);

    return longFileList;
}

void PopulateLongListing(_In_z_ WCHAR *path)
{
    WCHAR **fileList = NULL;
    DWORD fileListCount = 0;
    UINT i;

    fileList = GenerateLongListing(path, &fileListCount);

    for (i = 0; i < fileListCount; i++)
        wprintf(L"%s\n", fileList[i]);

    // Free the file list
    for (i = 0; i < fileListCount; i++)
        free(fileList[i]);
    free(fileList);

    return;
}

void PopulateLongListingRecursive(_In_z_ WCHAR *path)
{
    WIN32_FIND_DATA fdata = {0};
    WCHAR wpath[MAX_PATH] = {0};
    HANDLE handle;

    swprintf(wpath, MAX_PATH, L"%s\\*", path);

    // first list all files in the current directory
    PopulateLongListing(path);

    // iterate over all directories
    handle = FindFirstFile(wpath, &fdata);
    if (handle != INVALID_HANDLE_VALUE) {
        do {
            WCHAR *subDirPath = NULL;

            if (!IsValidDirectoryName(&fdata) || !IsDirectory(&fdata))
                continue;

            subDirPath = malloc(sizeof(WCHAR) * MAX_PATH);
            swprintf(subDirPath, MAX_PATH, L"%s\\%s", path, fdata.cFileName);
            wprintf(L"%s:\n", subDirPath);
            PopulateLongListingRecursive(subDirPath);
            free(subDirPath);
        } while (FindNextFile(handle, &fdata));

        FindClose(handle);
    }
}

void PrintUsage()
{
    wprintf(L"ls.exe [-r] [-d:<c|m|a>] [-s:<s|d|n>] <path>");
    wprintf(L"\n  -r recursive listing");
    wprintf(L"\n  -d:c list created date");
    wprintf(L"\n  -d:m list modified date");
    wprintf(L"\n  -d:a list last accessed date");
    wprintf(L"\n  -s:s sort by file size");
    wprintf(L"\n  -s:d sort by file date");
    wprintf(L"\n  -s:n sort by file name");
    wprintf(L"\n  ");
}

BOOL ParseArguments(_In_ int argc, _In_ WCHAR *argv[])
{
    int i;
    WCHAR *cmdline = NULL;

    if (argc < 2) {
        PrintUsage();
        return FALSE;
    }

    cmdline = GetCommandLine();

    if (wcsstr(cmdline, L" -r "))
        recursive = TRUE;
    else
        recursive = FALSE;

    if (wcsstr(cmdline, L" -d:")) {
        WCHAR* dateStr = wcsstr(cmdline, L" -d:");
        dateStr += wcslen(L" -d:");
        dateType = 0;
        if (*dateStr == L'c')
            dateType |= CREATED_DATE;
        else if (*dateStr == L'm')
            dateType |= MODIFIED_DATE;
        else if (*dateStr == L'a')
            dateType |= ACCESSED_DATE;
        else {
            wprintf(L"Expected c or m or a for -d\n");
            PrintUsage();
            return FALSE;
        }
    }
    else {
        dateType |= MODIFIED_DATE;
    }

    if (wcsstr(cmdline, L" -s:")) {
        WCHAR* sortStr = wcsstr(cmdline, L" -s:");
        sortStr += wcslen(L" -s:");
        sortType = 0;
        if (*sortStr == L's')
            sortType |= SIZE_SORT;
        else if (*sortStr == L'd')
            sortType |= DATE_SORT;
        else if (*sortStr == L'n')
            sortType |= NAME_SORT;
        else {
            wprintf(L"Expected s or d or n for -s\n");
            PrintUsage();
            return FALSE;
        }
    }
    else {
        sortType = 0;
    }

    // directory should be always specified as last argument
    wcscpy_s(srcPath, _countof(srcPath), argv[argc - 1]);
    TrimTrailingSlash(srcPath);

#if DEBUG
    wprintf(L"%d %d %d %s\n", recursive, dateType, sortType, srcPath);
#endif

    return TRUE;
}

int wmain(int argc, WCHAR *argv[])
{
    if (!ParseArguments(argc, argv))
        return -1;

    if (recursive)
        PopulateLongListingRecursive(srcPath);
    else
        PopulateLongListing(srcPath);

    return 0;
}
