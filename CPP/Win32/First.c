

#include<windows.h>
	CHAR  buffer[1024];
main()
{
	LPCTSTR s = TEXT("d:\\a.txt");
	DWORD dwAccess = GENERIC_READ|GENERIC_WRITE;
	DWORD dwShareMode = FILE_SHARE_READ;
	DWORD dwCreate = OPEN_EXISTING;
	DWORD dwAttr = FILE_ATTRIBUTE_READONLY;

	DWORD read=0;
	int count=0,i;
	HANDLE out,h = CreateFile(s,dwAccess,dwShareMode,NULL,dwCreate,dwAttr,NULL);
	out = GetStdHandle(STD_OUTPUT_HANDLE);
	if(h!=INVALID_HANDLE_VALUE)
	{
		while(ReadFile(h,buffer,1024,&read,NULL)&&read>0)
		{
			WriteFile(out,buffer,read,&i,NULL);
			count++;
		}
	}
	printf("\n=====\n%d",count);
	CloseHandle(h);
	CloseHandle(out);
}
