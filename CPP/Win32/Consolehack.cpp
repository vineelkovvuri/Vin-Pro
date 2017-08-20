#include<windows.h>
#include<shlwapi.h>
#include<tchar.h>
#include<stdio.h>

#define H(x)   _tprintf(_T(x));Sleep(250);

void __stdcall TimerProc( HWND hwn, UINT uMsg,UINT_PTR idEvent,DWORD dwTime)
{
	HWND hwnd = GetForegroundWindow();
	TCHAR text[1024];
	GetWindowText(hwnd,text,1024);

	if(StrStr(text,_T("cmd.exe"))!=NULL)
	{
		FreeConsole();   // Free the Default Console
		DWORD pid;
		GetWindowThreadProcessId(hwnd,&pid);
		AttachConsole(pid);
		HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
		SetConsoleTextAttribute(hConsole,FOREGROUND_RED|BACKGROUND_BLUE | BACKGROUND_GREEN | BACKGROUND_RED);
		H("U");
		H(" ");
		H("R");
		H(" ");
		H("D");
		H("E");
		H("A");
		H("D");
		H(" ");
		H("-");
		H(" ");
		H("H");
		H("A");
		H("C");
		H("K");
		H("E");
		H("D");
		H(" ");
		H("B");
		H("Y");
		H(" ");
		H("B");
		H("O");
		H("R");
		H("N");
		H("2");
		H("C");
		H("O");
		H("D");
		H("E");
		/*H("_");
		  H("\b");
		  H("_");
		  H("\b");
		  H("_");
		  H("\b");
		  H("_");
		  H("\b");*/


		FreeConsole();
		SendMessage(hwnd,WM_CLOSE,0,0);
		AllocConsole();
		SetConsoleTitle(_T("Open command prompt i ll c its END he he he - Vineel"));
	}
}

//BOOL WINAPI HandlerRoutine(DWORD dwCtrlType)
//{
//	switch(dwCtrlType)
//	{
//	case CTRL_C_EVENT:
//		PostQuitMessage(0);
//		return true;
//	}
//}


int _tmain()
{

		SetConsoleTitle(_T("Open command prompt i ll c its END he he he - Vineel"));

	SetTimer(NULL,12345,5000,TimerProc);
	MSG msg;
	while(GetMessage(&msg,NULL,0,0)>0)
	{
		DispatchMessage(&msg);
	}
}

