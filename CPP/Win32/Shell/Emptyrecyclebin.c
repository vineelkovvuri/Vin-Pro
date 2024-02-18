#include<windows.h>
#include<tchar.h>
#include<shlobj.h>


#define _UNICODE

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
		PSTR szCmdLine, int iCmdShow)
{

	HWND hwd;
	hwd = GetFocus();
	SHEmptyRecycleBin(hwd,_T("d:\\"),SHERB_NOSOUND);//repeat for all drives.........

}
