#define _UNICODE
#include<windows.h>

#define UNICODE
#include<stdio.h>

int wmain(int argc, WCHAR **argv){

	if(argc == 3){
		HANDLE hFile;
		LARGE_INTEGER li;
		li.QuadPart = _wtoi(argv[2])*1024*1024; // bytes

		if(li.QuadPart != 0){
			hFile = CreateFile(argv[1],GENERIC_WRITE,0,NULL,CREATE_ALWAYS,FILE_ATTRIBUTE_NORMAL,NULL);
			if(hFile != INVALID_HANDLE_VALUE){
				if (SetFilePointer(hFile,li.LowPart,&li.HighPart,0) != INVALID_SET_FILE_POINTER)
					SetEndOfFile(hFile);
				CloseHandle(hFile);
			}
			else{
				wprintf(L"Error %d",GetLastError());
			}
		}
	}
	else{
		wprintf(L"Usage:\n--------\nnullfile.exe <path> <size in MB>");
	}
}
