
// test1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

struct Process
{
	//DWORD pid;
	TCHAR szProcName[100];
	TCHAR szModuName[100][100];
	HMODULE hModule[100];
	int noOfModules;
};

int _tmain(int argc, _TCHAR* argv[])
{
	
	DWORD pid[50],cb;
	Process proc[50];
	HANDLE hProcess;

	if(!EnumProcesses(pid,sizeof(pid),&cb))return 0;//get the process IDS
	int noOfProc;
	noOfProc = cb/sizeof(DWORD);			   //number of processes	
	
	for(int i=0;i<noOfProc;i++)
	{
		hProcess = OpenProcess( PROCESS_QUERY_INFORMATION|PROCESS_VM_READ,FALSE,pid[i]);
		GetModuleBaseName(hProcess,NULL,proc[i].szProcName,sizeof(proc[i].szProcName)/sizeof(TCHAR));
		EnumProcessModules(hProcess,proc[i].hModule,sizeof(proc[i].hModule),&cb);
		proc[i].noOfModules = cb/sizeof(HMODULE);
		_tprintf(_T("\n%s %d"),proc[i].szProcName,proc[i].noOfModules);
		//printf("asdfasdfs");
	/*	for(int j=0;j<proc[i].noOfModules;j++)
		{
			
			GetModuleFileNameEx(hProcess,proc[i].hModule[j],proc[i].szModuName[j],sizeof(proc[i].szModuName[j])/sizeof(TCHAR));
			
		}
		*/	
		CloseHandle(hProcess);
	}

/*

	int choice ,index;
	while(1)
	{
		printf("\n1.Display\n2.Modules\n3.Exit\nOption : ");
		scanf("%d",&choice);
		switch(choice)
		{
		case 1:
			for(int i =2;i<noOfProc;i++)
			{
				_tprintf(TEXT("\n%d %s"),pid[i],proc[i].szProcName);
			}
			break;
		case 2:
			printf("\nEnter index :");
			scanf("%d",&index);
			_tprintf(_T("\n%d %s"),pid[index],proc[index].szProcName);
			for(int j = 0;j<proc[index].noOfModules;j++)
			{
				_tprintf(TEXT("\n\t%s"),proc[index].szModuName[j]);
			}
			break;
		case 3: return 0;
		}
	}
	return 0;
	*/
}

