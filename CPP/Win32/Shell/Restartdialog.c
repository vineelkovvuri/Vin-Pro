#include<windows.h>
#include<tchar.h>
#include<shlobj.h>


#define _UNICODE

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
		PSTR szCmdLine, int iCmdShow)
{

	HWND hwd;
	hwd = GetFocus();
	RestartDialog(hwd,L"Vineel is Shutting the System",EWX_SHUTDOWN);
}
