
#include<windows.h>
#include<tchar.h>
#include<Psapi.h>

BOOL __stdcall DllMain(HINSTANCE hInst,DWORD fdwReason,LPVOID lpvReserved)
{

	TCHAR data[1024]={0};
	DWORD bRet;
	SYSTEMTIME startTime;
	HANDLE hFile = CreateFile(_T("c:\\a.txt"),FILE_APPEND_DATA,FILE_SHARE_READ|FILE_SHARE_WRITE ,NULL,OPEN_ALWAYS,FILE_ATTRIBUTE_NORMAL,NULL);
	switch( fdwReason ) 
	{ 
		case DLL_PROCESS_ATTACH:
			GetModuleFileName(NULL,data,sizeof(data)/sizeof(TCHAR));
			GetLocalTime(&startTime);
			wsprintf(data,_T("%s(%d) opened at => %d:%d:%d(hh:mm:ss) \r\n"),data,GetProcessId(GetCurrentProcess()),startTime.wHour,startTime.wMinute,startTime.wSecond);
			WriteFile(hFile,data,lstrlen(data)*sizeof(TCHAR),&bRet,NULL);
			break;

		case DLL_THREAD_ATTACH:
			// Do thread-specific initialization.
			break;

		case DLL_THREAD_DETACH:
			// Do thread-specific cleanup.
			break;

		case DLL_PROCESS_DETACH:
			GetModuleFileName(NULL,data,sizeof(data)/sizeof(TCHAR));
			GetLocalTime(&startTime);
			wsprintf(data,_T("%s(%d) closed at => %d:%d:%d(hh:mm:ss) \r\n"),data,GetProcessId(GetCurrentProcess()),startTime.wHour,startTime.wMinute,startTime.wSecond);
			WriteFile(hFile,data,lstrlen(data)*sizeof(TCHAR),&bRet,NULL);
			break;
	}

	CloseHandle(hFile);
	return TRUE;
}
