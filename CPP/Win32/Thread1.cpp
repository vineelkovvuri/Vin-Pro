
#include<windows.h>
#include<stdio.h>

int wmain()
{
	wchar_t x[] = L"vineel";
	char *p= (char*)&x;
	
	wprintf(L"%c",p[0]);	
	wprintf(L"%c",p[1]);
	wprintf(L"%c",p[2]);
}
