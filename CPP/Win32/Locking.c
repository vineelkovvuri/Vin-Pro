#include<windows.h>
#include<tchar.h>
#include<stdlib.h>
_tmain()
{
	HANDLE h1;
	OVERLAPPED ol;
	h1=CreateFile(_T("d:\\a.txt"),GENERIC_READ|GENERIC_WRITE,
			FILE_SHARE_READ,NULL,OPEN_ALWAYS,FILE_ATTRIBUTE_NORMAL,NULL);

	ol.Offset=0;
	ol.OffsetHigh=0;	
	ol.hEvent=0;

	LockFileEx(h1,LOCKFILE_EXCLUSIVE_LOCK,0,20,0,&ol);
	while(1);
}
