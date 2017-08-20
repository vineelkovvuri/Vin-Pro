
#define UNICODE

#include<windows.h>
#include<stdio.h>


int wmain()
{
	STARTUPINFO st = {sizeof(st)};
	PROCESS_INFORMATION pi = {0};
	wchar_t apppath[1024] = L"notepad.exe";
	CreateProcess(0,apppath,0,0,true,0,0,0,&st,&pi);


	WaitForSingleObject(pi.hProcess,INFINITE);


	wprintf(L"%p",pi.hProcess);

	return 0;
}

