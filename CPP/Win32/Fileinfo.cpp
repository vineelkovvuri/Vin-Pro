#define UNICODE
#include<windows.h>



int wmain()
{

	wchar_t file[1024] = L"c:\\windows\\system32\\kernel32.dll";
	DWORD temp;
	DWORD size = GetFileVersionInfoSizeEx(FILE_VER_GET_LOCALISED,file,&temp);
	
	LPVOID lpBuff = (BYTE*)malloc(size*2);

	if(GetFileVersionEx(FILE_VER_GET_LOCALISED,file,0,size,lpBuff)!=0)
	{
		VerQueryValue(lpBuff,

	}

}

