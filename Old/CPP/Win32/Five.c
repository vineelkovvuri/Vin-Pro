

#include<windows.h>
#include<tchar.h>
 
_tmain()
{
	LPCTSTR from=_T("d:\\a.txt");
	LONG t=1024;
	DWORD size=0;
	HANDLE h = CreateFile(from,GENERIC_READ|GENERIC_WRITE,FILE_SHARE_READ,NULL,OPEN_ALWAYS,
							FILE_ATTRIBUTE_NORMAL,NULL);
	SetFilePointer(h,1000,NULL,FILE_END);
	SetEndOfFile(h);
	
	CloseHandle(h);	
}
