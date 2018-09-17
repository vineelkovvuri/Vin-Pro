
#define UNICODE
#include<windows.h>

#define _UNICODE
#include<stdio.h>

//to uninstall the app delete *\\shell\\Copy Path  key
int wmain(int argc,wchar_t *argv[])
{
	//Install to registry for adding itself to windows context menu ;)
	HKEY key;
	if(RegOpenKeyEx(HKEY_CLASSES_ROOT,L"*\\shell\\Copy Path",0,KEY_WRITE,&key) != ERROR_SUCCESS) //if the key is not present;
	{
		if(RegCreateKeyEx(HKEY_CLASSES_ROOT,L"*\\shell\\Copy Path\\command",0,NULL,REG_OPTION_NON_VOLATILE,KEY_WRITE,NULL,&key,NULL) == ERROR_SUCCESS) //Create New One 
		{
			wchar_t path[MAX_PATH]={0},temp[MAX_PATH]={0};
			GetModuleFileName(NULL,path,MAX_PATH*sizeof(wchar_t));
			wsprintf(temp,L"\"%s\" \"%%1\" ",path);
			RegSetValueEx(key,NULL,0,REG_SZ,(LPBYTE)temp, (wcslen(temp)+1)*sizeof(wchar_t)); //Set the value.
			RegCloseKey(key);
			MessageBox(NULL,L"Installed Successfully to registry",L"Born 2 Code",MB_OK);
		}
	}
	else  //if already installed to registry............. go ahead 
	{
		HANDLE hMem1;
		OpenClipboard(NULL);
		hMem1 = GlobalAlloc(GMEM_ZEROINIT,(wcslen(argv[1])+1)*sizeof(wchar_t));
		lstrcpy((LPWSTR)hMem1,argv[1]);
		SetClipboardData(CF_UNICODETEXT,hMem1);
		CloseClipboard();
	}
}
