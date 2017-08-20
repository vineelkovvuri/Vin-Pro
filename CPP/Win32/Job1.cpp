#define UNICODE

#include<windows.h>

#include<stdio.h>


#pragma comment(lib, "user32.lib")

int wmain()
{
	BOOL IsInJob = false;
	IsProcessInJob(GetCurrentProcess(),NULL,&IsInJob);
	if(IsInJob)
	{
		wprintf(L"Yes");
	}
	else 
	{
		HANDLE hJob = CreateJobObject(NULL,L"VINEEL");

		JOBOBJECT_BASIC_LIMIT_INFORMATION jbli={ 0 };
		jbli.PerJobUserTimeLimit.QuadPart = 140000;
		jbli.LimitFlags = JOB_OBJECT_LIMIT_JOB_TIME;
		
		SetInformationJobObject(hJob,JobObjectBasicLimitInformation,&jbli,sizeof(jbli));

		STARTUPINFO si={sizeof(si)};
		PROCESS_INFORMATION pi;
		wchar_t appname[] = L"test.exe";
		CreateProcess(NULL,appname,NULL,NULL,false,CREATE_SUSPENDED,NULL,NULL,&si,&pi);
		AssignProcessToJobObject(hJob,pi.hProcess);
		ResumeThread(pi.hThread);
		CreateProcess(NULL,appname,NULL,NULL,false,CREATE_SUSPENDED,NULL,NULL,&si,&pi);
		AssignProcessToJobObject(hJob,pi.hProcess);
		ResumeThread(pi.hThread);

		CreateProcess(NULL,appname,NULL,NULL,false,CREATE_SUSPENDED,NULL,NULL,&si,&pi);
		AssignProcessToJobObject(hJob,pi.hProcess);
		ResumeThread(pi.hThread);

		Sleep(-1);
//		WaitForSingleObject(pi.hProcess,INFINITE);
//		CloseHandle(pi.hProcess);
		
		CloseHandle(hJob);
	}
}



