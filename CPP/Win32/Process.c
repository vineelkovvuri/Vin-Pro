#define UNICODE
#include<windows.h>
#include<psapi.h>
#define _UNICODE
#include<stdio.h>

int wmain(int argc, wchar_t* argv[])
{

	wchar_t szProcName [1024]={0};	
	DWORD pid[50],cb;
	HANDLE hProcess;
	int noOfProc;int i=0;
	if(!EnumProcesses(pid,sizeof(pid),&cb))return 0;//get the process IDS

	noOfProc = cb/sizeof(DWORD);			   //number of processes	

	for(;i<noOfProc;i++)
	{
		if(hProcess = OpenProcess( PROCESS_QUERY_INFORMATION|PROCESS_VM_READ,FALSE,pid[i]))
		{
			GetModuleBaseName(hProcess,NULL,szProcName,1024);
			wprintf(L"\n%s %d",szProcName,pid[i]);
			CloseHandle(hProcess);
		}
	}
	return 0;
}

