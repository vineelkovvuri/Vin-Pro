

#include<windows.h>
#include<tchar.h>

//Last Modified: Thu Apr 26 2007 5:15:24 PM 
_tmain(int argc,LPTSTR args[])
{
		WIN32_FIND_DATA data;
		TCHAR buf[1024];
		HANDLE h;
		h = FindFirstFile(_T(args[1]),&data);
		_tprintf("%s",data.cFileName);

		while(FindNextFile(h,&data)!=0)
		{
			_tprintf("\n%s",data.cFileName);

			if((data.dwFileAttributes&FILE_ATTRIBUTE_DIRECTORY)==FILE_ATTRIBUTE_DIRECTORY)
			_tprintf("        Directory");		
		}
		FindClose(h);
}

