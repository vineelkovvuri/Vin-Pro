#include<windows.h>
#include<tchar.h>
#define UNICODE
#define _UNICODE

_tmain()//int q,LPTSTR arg[])
{
	TCHAR buf[]="Hai this is Vineel From Win32API..!";
	DWORD wrote;
	HANDLE h1,h2,h3;
	h1=CreateFile(_T("CONOUT$"),GENERIC_READ|GENERIC_WRITE,
				  FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_READONLY,NULL);
	
	WriteFile(h1,buf,sizeof(buf),&wrote,NULL);	
	//printf("asdfklasjdfasdf");
	CloseHandle(h1);

}

