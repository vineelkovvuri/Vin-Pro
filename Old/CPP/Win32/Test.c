#define UNICODE
#include<windows.h>


#define _UNICODE
#include<stdio.h>

#include<tchar.h>

TCHAR * pathStr ;
TCHAR * pathExt ;

TCHAR ** split(TCHAR* str, TCHAR delim){

	int count = 0,i;
	TCHAR * ptr,start;
	TCHAR ** substrings;
	start = str;
	for(count = 1; (ptr = _tcschr(start,delim)) != NULL; start = ptr+1,count++);

	_tprintf(_T("\n\n%d "),count);
	substrings = (TCHAR **)malloc(sizeof(TCHAR*)*(count+1));
	for(i = 0; i < count; i++){
		substrings[i] = (TCHAR *)malloc(sizeof(TCHAR)*(MAX_PATH));
	}
	substrings = (TCHAR **)malloc(sizeof(TCHAR*)*(count+1));
	start = str;
	for(i = 0; (ptr = _tcschr(start,delim)) != NULL; start = ptr+1,i++){
		_tcscspn(substrings[i],start,)
	}



}


//int searchFile(TCHAR* name, TCHAR path){

//	TCHAR * ptr;
//	TCHAR * start = pathExt;
//	while((ptr = _tcschr(start,_T(';'))) != NULL){


//	}


//}

int _tmain(int argc, char ** argv)
{
	if(argc >= 1){
		DWORD res;
		TCHAR comp[MAX_PATH];
		res = GetEnvironmentVariable(_T("PATH"),NULL,0);
		pathStr = malloc((sizeof(TCHAR)+1)*res);
		res = GetEnvironmentVariable(_T("PATH"),pathStr,res);
		_tprintf(_T("%d %s"),res,pathStr);
		//split(pathStr, _T(';'));

		_stscanf_s(comp,_("%[^;]"),pathStr);
		_tprintf(_T("%s"),comp);





	}
	return 0;
}


