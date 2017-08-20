#define UNICODE
#include<windows.h>

#define _UNICODE
#include<tchar.h>
#include<stdio.h>

int _tmain(int argc, _TCHAR* argv[])
{
	TCHAR szProcName [1024]={0};	
	DWORD pid[50],cb;
	HANDLE hProcess;
	int noOfProc;
	int i;
	if(!EnumProcesses(pid,sizeof(pid),&cb))
		return 0;//get the process IDS

	noOfProc = cb/sizeof(DWORD);			   //number of processes	
	
	for(i=0;i<noOfProc;i++)
	{
		hProcess = OpenProcess( PROCESS_QUERY_INFORMATION|PROCESS_VM_READ,FALSE,pid[i]);
		GetModuleBaseName(hProcess,NULL,szProcName,sizeof(szProcName)/sizeof(TCHAR));
		_tprintf(_T("\n%s"),szProcName);
		CloseHandle(hProcess);
	}

	return 0;
}

