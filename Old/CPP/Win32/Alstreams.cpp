#include<windows.h>
#include<tchar.h>
#include<stdio.h>


int _tmain(int argc,TCHAR *argv[])
{

	HANDLE hFile = CreateFile(argv[1],GENERIC_READ,FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_NORMAL,NULL);
	WIN32_STREAM_ID sid ;
	ZeroMemory(&sid,sizeof(sid));
	DWORD ret;
	TCHAR streamName[1024];
	LPVOID lp = NULL;

	BackupRead(hFile,(LPBYTE)&sid,sizeof(sid),&ret,false,false,&lp);
	BackupRead(hFile,(LPBYTE)streamName,sid.dwStreamNameSize,&ret,false,false,&lp);
	_tprintf(_T("\n%d %d => %s"),sizeof(LARGE_INTEGER), ret,streamName);
	
//	for(int i=0;i<ret;i++)
//	{
//		_tprintf(_T("%c "),((LPBYTE)&sid)[i]);
//	}
//
	CloseHandle(hFile);

}
