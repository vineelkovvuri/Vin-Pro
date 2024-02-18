#include<windows.h>
#include<tchar.h>
#include<shellapi.h>


#define _UNICODE

int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,
		PSTR szCmdLine, int iCmdShow)
{

	SHFILEOPSTRUCT s={0};
	
	s.hwnd = GetFocus();
	s.wFunc = FO_COPY;
	s.pFrom = _T("d:\\songs\\vineel\\telugu\0\0");
	s.pTo = _T("d:\0");
	s.fFlags = 0;
	s.lpszProgressTitle = _T("Vineel From Shell - Feeling the power of WIN32 API");

	SHFileOperation(&s);

}
