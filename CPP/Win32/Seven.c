
#define _WIN32_WINNT 0x0500
#include<windows.h>
#include<tchar.h>


_tmain(int argc,LPTSTR args[])
{
	SetVolumeMountPoint(_T("c:\\e\\"),_T("i:\\"));
	printf("%d",GetLastError());
}
