#define UNICODE
#include<windows.h>

#define _UNICODE
#include<string.h>
#include<stdio.h>


//sample prog used to load any desired dll into the process address space........
//and causes the debugger to break 

int wmain(int argc,wchar_t *argv[])
{
	if(argc == 2)
	{
		HMODULE hDll = LoadLibrary(argv[1]);

		if(hDll != NULL) {
			wprintf(L"\n%s moudle loaded sucessfully",argv[1]);
//			DebugBreak();
			FreeLibrary(hDll);
		}
		else
		{
			wprintf(L"\n%s moudle failed to load",argv[1]);
		}
	}
}



