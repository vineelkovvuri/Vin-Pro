
//This is auto generated C template by vim 
//To move to Body field press CTRL+j

#define UNICODE
#include<windows.h>
#include<stdio.h>
#include<string.h>

#define IsDir(data) (data.dwFileAttributes&FILE_ATTRIBUTE_DIRECTORY) \
	==  FILE_ATTRIBUTE_DIRECTORY
#define ValidDir(data) lstrcmpi(data.cFileName,L".")&&lstrcmpi(data.cFileName,L"..")
#define PATH_LEN 1000
TCHAR temp[PATH_LEN];
WIN32_FIND_DATA data;

void DelTree(wchar_t *path)
{
	HANDLE h;
	TCHAR temp1[PATH_LEN];
	wsprintf(temp,L"%s%s",path,L"*.*");//path = c:\windows name = *.*
	h = FindFirstFile(temp,&data);	//temp = c:\windows\*.*
	if(h!=INVALID_HANDLE_VALUE){ 	//Check whether we got valid handle or not 
		do{
			if(IsDir(data)){
				if(ValidDir(data)){
					wsprintf(temp1,L"%s%s\\",path,data.cFileName); 
					DelTree(temp1);
					RemoveDirectory(temp1);
				}
			}			
			else{
				wsprintf(temp1,L"%s%s",path,data.cFileName); 
				wprintf(L"\n%s",temp1);			
				DeleteFile(temp1);
			}
		}while(FindNextFile(h,&data));
		FindClose(h);
	}
}
int wmain()
{
	wchar_t path[1024]=L"\\\\?\\C:\\Documents and Settings\\harsha\\Desktop\\;";
	DelTree(path);
}







