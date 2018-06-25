// LongFileDir.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Windows.h>
#include <string.h>

//
// According to MSDN each path component in C:\Component1\Component2\.....
// Cannot exceed 255 // But with \\?\ The entire length of the path can be
// upto 32,767
//
// MSDN:
// The Windows API has many functions that also have Unicode versions to permit
// an extended-length path for a maximum total path length of 32,767 characters.
// This type of path is composed of components separated by backslashes, each
// up to the value returned in the lpMaximumComponentLength parameter of the
// GetVolumeInformation function (this value is commonly 255 characters).
// To specify an extended-length path, use the "\\?\" prefix.
// For example, "\\?\D:\very long path".
//


int wmain(int argc, WCHAR **argv)
{
	if (argc != 3)
	{
		wprintf(L"\nUsage: Program.exe dir|file \\\\?\\%%CD%%\\<filename|dirname>");
		wprintf(L"\n       Program.exe dir \\\\?\\%%CD%%\\verylooooooooooooooongggggggggggggggggdirrrrrrrrrrrrrrname");
		wprintf(L"\n       Program.exe file \\\\?\\%%CD%%\\verylooooooooooooooongggggggggggggggggfileeeeeeeeeeeename");
		return 0;
	}
	if (_wcsicmp(argv[1], L"dir") == 0) {
		wprintf(L"\nInput = %s", argv[2]);
		if (!CreateDirectory(argv[2], NULL)) {
			wprintf(L"\nError creating directory = %d", GetLastError());
		}
	}
	else {
		HANDLE hFile;
		wprintf(L"\nInput = %s", argv[2]);
		hFile = CreateFile(argv[2], GENERIC_READ | GENERIC_WRITE, FILE_SHARE_WRITE, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

		if (hFile == INVALID_HANDLE_VALUE) {
			wprintf(L"\nError creating file = %d", GetLastError());
		}
	}
    return 0;
}

