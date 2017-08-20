
//#include<windows.h>
#include<winbase.h>
#include<tchar.h>

_tmain()
{
	DWORD read;
	TCHAR buf[1024];
	HANDLE in,out;
	in = GetStdHandle(STD_INPUT_HANDLE);
//	out = GetStdHandle(STD_OUTPUT_HANDLE);
//	ReadConsole(in,buf,1024,&read,NULL);
//	WriteConsole(out,buf,read,&read,NULL);
	CloseHandle(in);
//	CloseHandle(out);

}
