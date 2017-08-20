#include<windows.h>
#include<tchar.h>

#define _UNICODE




int _tmain()
{
	HINSTANCE hm;
	typedef BOOL (*Fun)();
	
	Fun p;

	hm = LoadLibrary(_T("User32.dll"));
	if(hm != NULL)
	{
		p = (Fun)GetProcAddress(hm,"LockWorkStation");

		if(p!=NULL)
			p();

		FreeLibrary(hm);

	}
}
