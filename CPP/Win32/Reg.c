#include<windows.h>
#include<tchar.h>
#define UNICODE
main()
{
	HKEY rk ;
	DWORD x,y;
	RegOpenKeyEx(HKEY_LOCAL_MACHINE,_T("SOFTWARE"),0,KEY_WRITE,&rk);
	{
	printf("true");
	 RegCloseKey(rk);

// GetSystemRegistryQuota(&x,&y);
 //printf("%d %d",x,y);
	}
}
