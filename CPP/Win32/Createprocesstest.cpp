
#include<windows.h>
#include<tchar.h>
#include<stdio.h>
#include<strsafe.h>
#include<psapi.h>
#define _UNICODE

extern "C" const IMAGE_DOS_HEADER __ImageBase;

extern "C" void __declspec(naked) _cdecl _penter()
{
	_tprintf(_T("\n%s"),__FUNCTION__);

	_asm ret
}
int _tmain()//HINSTANCE hInst,HINSTANCE hPrev,PTSTR pszCmdLine, int nShow)
{
	HANDLE h;
	h = GetCurrentProcess();
	_tprintf(_T("%d"),h);

	//	HMODULE hMod[256];
	//	DWORD nMods;
	//	EnumProcessModules(h,hMod,sizeof(hMod),&nMods);
	//	nMods = nMods/sizeof(HMODULE);
	//	TCHAR modName[256];
	//	for(int i=0;i<nMods;i++)
	//	{
	//		_tprintf(_T("\n%#10x"),hMod[i]);
	//		GetModuleFileNameEx(h, hMod[i], modName,sizeof(modName)/sizeof(TCHAR));
	//		_tprintf(_T("\t%s"),modName);
	//	}
	//		_tprintf(_T("\n%#10x"),&__ImageBase);
}

