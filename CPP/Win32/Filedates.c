

#include<windows.h>
#include<tchar.h>
_tmain()
{
	HANDLE h;
	FILETIME fC,fL,fM;
	SYSTEMTIME st;
	0x72873
	h = CreateFile(_T("d:\\a.txt"),GENERIC_READ|GENERIC_WRITE,
			FILE_SHARE_READ,NULL,OPEN_ALWAYS,FILE_ATTRIBUTE_READONLY,NULL);
	GetFileTime(h,&fC,&fL,&fM);
	FileTimeToSystemTime(&fC,&st);
	_tprintf(_T("%d %d %d %d %d %d %d %d "),st.wYear,st.wMonth,st.wDayOfWeek,st.wDay
			,st.wHour,st.wMinute,st.wSecond,st.wMilliseconds); 
}
