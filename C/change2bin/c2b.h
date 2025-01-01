#pragma once

#define MAX_LINE 4000

#define CONFIG_FILE_PATH    L"config.txt"
#define DEFAULT_BRANCH_SECTION_NAME L"[default branches]"
#define BLACKLIST_PATHS_SECTION_NAME L"[blacklisted paths]"
#define VALID_COMPONENT_PATHS_SECTION_NAME L"[valid component paths]"

typedef struct _BIN_PDB {
    WCHAR *Bin;
    WCHAR *Pdb;
    BOOLEAN Impacted;
} BIN_PDB, *PBIN_PDB;

typedef struct _BUILD_ARTIFACT {
    WCHAR BuildPath[MAX_PATH];
    PBIN_PDB BinPdbArray;
    DWORD NumBinPdbArray;

    //
    // Filter
    //
    LPWSTR *BlackListedPaths;
    DWORD NumBlackListedPaths;
    LPWSTR *ValidComponentPaths;
    DWORD NumValidComponentPaths;

    //
    // Input Functions
    //
    LPCWSTR *FunctionNames;
    DWORD NumFunctionNames;

    //
    // Default Branches
    //
    LPCWSTR *DefaultBranches;
    DWORD NumDefaultBranches;
} BUILD_ARTIFACT, *PBUILD_ARTIFACT;

//
// Build share API
//

DWORD
FindGoodBuild (
    _Inout_ PBUILD_ARTIFACT Artifact
    );

//
// Time related API
//

UINT
GetDaysSince2005 (
    _In_ SYSTEMTIME *Date
    );

//
// File Related
//

BOOLEAN
FileExists (
    _In_ LPCWSTR FilePath
    );

//
// Config Parsing external functions
//

DWORD
ParseConfigFile (
    _In_ LPCWSTR ConfigPath
    );

//
// Parse Func.txt file
//

DWORD
ParseSymbolsInputFile (
    _In_ LPCWSTR FuncPath
    );

//
// Symbol file processing
//

VOID
FindSymbols (
    _In_ PBUILD_ARTIFACT Artifact
    );


//
// Binplace Log Parsing external functions
//

DWORD
BinplaceParseLog (
    _Inout_ PBUILD_ARTIFACT Artifact
    );

//
// String Utility APIs
//

LPWSTR
StrTrimEnd (
    _Inout_ LPWSTR String
    );

BOOLEAN
StrEndsWith (
    _In_ LPCWSTR String,
    _In_ LPCWSTR Suffix
    );

BOOLEAN
StrIsEmpty (
    _In_ LPCWSTR String
    );

INT
StringCompare (
    CONST VOID* Ptr1,
    CONST VOID* Ptr2
    );


