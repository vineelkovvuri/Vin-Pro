
//This is auto generated C template by vim 
//To move to Body field press CTRL+j


#include<windows.h>
#include<tchar.h>

#define _UNICODE
_tmain()
{
	HINSTANCE hins;
	HICON hic;
	hins = LoadLibrary(_T("c:\\windows\\regedit.exe"));
	if(hins)
	{
		hic = LoadIcon(hins,MAKEINTRESOURCE(100));
		ShellAbout(NULL,_T("Vineel from windows Shell"),_T("**********Hai this is Vineel**********"),hic);
		DestroyIcon(hic);
		FreeLibrary(hins);
	}


}



