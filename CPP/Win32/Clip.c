#include<windows.h>
#include<tchar.h>
#include<conio.h>
#define _UNICODE

_tmain()
{
	HANDLE hMem1,hMem2 ;
	TCHAR st[] =_T("Hacked By Born 2 Code"); 

	OpenClipboard(NULL);
	hMem1 = GetClipboardData(CF_TEXT);
	_tprintf(_T("\n%s"),hMem1);
	EmptyClipboard();
	CloseClipboard();

	OpenClipboard(NULL);
	hMem2 = GlobalAlloc(GMEM_ZEROINIT,sizeof(st));
	lstrcpy(hMem2,st);
	SetClipboardData(CF_TEXT,hMem2);
	CloseClipboard();

	getch();
}
