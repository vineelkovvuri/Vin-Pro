#include"..\MyHeader.h"



_tmain()
{
	HANDLE hFile,hMemMapObj;
	char * buf,i;
	hFile = CreateFile("d:\\a.txt",GENERIC_READ|GENERIC_WRITE,
			0,
			NULL,
			OPEN_ALWAYS,
			FILE_ATTRIBUTE_NORMAL,
			NULL);
	hMemMapObj = CreateFileMapping(
			hFile,
			NULL,
			PAGE_READWRITE,//makes the mapped region both read write
			0,
			0,
			NULL);
	buf = (char *)MapViewOfFile(
			hMemMapObj,
			FILE_MAP_WRITE,
			0,
			0,
			0);
	for(i=0;i<10;i++)
		buf[i]='A'+i;
	
	for(i=0;i<10;i++)
		printf("%c\t",buf[i]);

	UnmapViewOfFile(buf);

	CloseHandle(hMemMapObj);
	CloseHandle(hFile);
	
}

