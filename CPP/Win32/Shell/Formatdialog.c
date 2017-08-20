#include<windows.h>
#include<tchar.h>
#include<shlobj.h>


//#define _UNICODE

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
		PSTR szCmdLine, int iCmdShow)
{

	HWND hwd;
	hwd = GetFocus();
	SHFormatDrive(hwd,2,SHFMT_ID_DEFAULT,0);	

}
