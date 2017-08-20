#include<windows.h>
#include<tchar.h>
#include<stdio.h>
int _tmain()
{
	HANDLE hDrive;
	//open the cd rom............
	hDrive= CreateFile(_T("\\\\.\\d:"),GENERIC_READ,FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_NORMAL,NULL);
	if(hDrive != INVALID_HANDLE_VALUE)
	{
		DWORD ret ; //return value of DeviceIOControl................
		DeviceIoControl(hDrive,IOCTL_STORAGE_LOAD_MEDIA  ,NULL,0,NULL,0,&ret,0);
	}
}

