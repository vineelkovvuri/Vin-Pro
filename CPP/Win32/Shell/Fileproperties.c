#include<windows.h>
#include<tchar.h>
#include<shlobj.h>


#define _UNICODE

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
		PSTR szCmdLine, int iCmdShow)
{

	HWND hwd;
	hwd = GetFocus();
	SHObjectProperties(hwd,SHOP_FILEPATH,L"d:\\songs\\krrish-01.mp3",NULL);
	Sleep(60000);
}
