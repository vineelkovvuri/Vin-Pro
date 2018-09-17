#define UNICODE
#include<windows.h>


#define _UNICODE
#include<string.h>
#include<stdio.h>

FILETIME ct1,et1,kt1,ut1;
int ekt = 0;
DWORD WINAPI ThreadFun1(PVOID pData)
{
	DWORD result = 0;
	int i=0;
	//	wprintf(L"%d",GetCurrentThread());
	for(;i<100;i++)
		wprintf(L"\nThread id = %d => %d",GetCurrentThreadId(),i);
	GetThreadTimes(GetCurrentThread(),&ct1,&et1,&kt1,&ut1);
	wprintf(L"\nt => %d", kt1.dwLowDateTime);
	return result;
}

int wmain()
{
	int i=0;
	DWORD id1 = 1,id2=2;
	DWORD tid = 0;
	FILETIME ct,et,kt,ut;
	HANDLE h1,h2;
	//	wprintf(L"%d",GetCurrentProcess());
	h1 = CreateThread(NULL,0,ThreadFun1,&id1,0,&tid);
 	h2 = CreateThread(NULL,0,ThreadFun1,&id2,0,&tid);

	WaitForSingleObject(h1,INFINITE);
	WaitForSingleObject(h2,INFINITE);
	GetProcessTimes(GetCurrentProcess(),&ct,&et,&kt,&ut);
	wprintf(L"\nkt => %d", kt.dwLowDateTime);


}

