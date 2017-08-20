
#include<windows.h>
#include<tchar.h>
BOOL WINAPI MyHandler(DWORD dwCtrlType)
{
	switch(dwCtrlType)
	{
		case  CTRL_C_EVENT:
			printf("CTRL_C_EVENT");
			return TRUE;
		case  CTRL_BREAK_EVENT:
			printf("CTRL_BREAK_EVENT");
			return TRUE;
		case  CTRL_CLOSE_EVENT:
			printf("CTRL_CLOSE_EVENT");
			return TRUE;
		default:
			return FALSE;
	}
}

_tmain()
{
	PHANDLER_ROUTINE pHand  = MyHandler;
	SetConsoleCtrlHandler(pHand,TRUE);
	Sleep(30000);
}
