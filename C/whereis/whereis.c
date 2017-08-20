#define UNICODE
#include<windows.h>

#define _UNICODE
#include<stdio.h>

#define WIN32_LEAN_AND_MEAN
#define IsDir(data) ((data.dwFileAttributes&FILE_ATTRIBUTE_DIRECTORY) \
											==  FILE_ATTRIBUTE_DIRECTORY)


wchar_t* pathStr = 0;
wchar_t* pathExt = 0;


void MakeClearPath(wchar_t * path){
	int len ;

	len = wcslen(path);
	if(path[len-1] == L'\\'){
			return;
	}
	else if(path[len-1] == L'.'){
		path[len-1] = L'\0';
		return;
	}
	else {
		path[len] = L'\\';
		path[len+1] = L'\0';
		return;
	}
}


wchar_t** split(wchar_t* str, wchar_t delim,DWORD* num){
	int count = 0,i=0,j=0,k=0;
	wchar_t** pathComp=0;

	//Count the strings
	for(i=0,count = 1; str[i];i++){
		if(str[i] == delim) count++;
	}

	////memory allocation
	pathComp = (wchar_t**)calloc((count+1),sizeof(wchar_t*));
	for(i = 0; i < count; i++)
		pathComp[i] = (wchar_t*)calloc((MAX_PATH),sizeof(wchar_t));

	//copy
	for(i = 0,j = 0,k = 0;;i++){
		//break if end component is reached
		if(str[i] == 0 && k != 0){
			pathComp[j][k] = L'\0';
			j++;
			break;
		}
		else if(str[i] != delim)pathComp[j][k++] = str[i];
		else if(str[i] == delim && k == 0);
		else if(str[i] == delim){
			pathComp[j][k] = L'\0';
			//wprintf(L" ");
			j++;
			k = 0;
		}
	}

	*num = j;
	return pathComp;
}



int wmain(int argc, wchar_t ** argv)
{
	if(argc == 2){

		DWORD res,i,j;
		wchar_t filename[MAX_PATH],fullpath[MAX_PATH];
		wchar_t ** pathComp, **extComp;
		DWORD pathcount= 0, extcount= 0;



		res = GetEnvironmentVariable(L"PATH",NULL,0);
		pathStr = (wchar_t*)malloc((sizeof(wchar_t)+1)*res);
		GetEnvironmentVariable(L"PATH",pathStr,res);
		pathComp = split(pathStr, L';',&pathcount);
		//wprintf(L"\n%s",pathStr);


		for(i = 0 ; i < pathcount; i++){
			MakeClearPath(pathComp[i]);
		//	wprintf(L"\n%s",pathComp[i]);
		}

		res = GetEnvironmentVariable(L"PATHEXT",NULL,0);
		pathExt = (wchar_t*)malloc((sizeof(wchar_t)+1)*res);
		GetEnvironmentVariable(L"PATHEXT",pathExt,res);
		extComp = split(pathExt, L';',&extcount);

		wcscpy(filename,argv[1]);
		_wcsupr(filename);

		for (i = 0; i < pathcount; i++){
			for (j = 0; j < extcount; j++){
				int len = wcslen(pathComp[i])+wcslen(filename)+wcslen(extComp[j])+1;
				swprintf(fullpath,len,L"%s%s%s",pathComp[i], filename,extComp[j]);
				fullpath[len] = L'\0';
				if(INVALID_FILE_ATTRIBUTES != GetFileAttributes(fullpath)){
					wprintf(L"\n%s",fullpath);
					goto out;
				}
			}
		}
		out:;
	}
	else{
		wprintf(L"\nUsage:\n------\nwhereis.exe <command without extension>\n");
	}
	return 0;
}


