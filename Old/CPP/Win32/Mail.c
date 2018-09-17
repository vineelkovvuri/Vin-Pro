#include<windows.h>
#include<mapi.h>
#include<tchar.h>
#include<stdio.h>

typedef ULONG (*fun)(LHANDLE lhSession,  ULONG ulUIParam,  lpMapiMessage lpMessage,  FLAGS flFlags,  ULONG ulReserved );

_tmain()
{
	HINSTANCE h;	
	fun f;

	h = LoadLibrary("MAPI32.DLL");
	if(h)
	{
		f = (fun)GetProcAddress(h,"MAPISendMail");
		if(f)
		{
			char body[] = "hai WIN32 api ROCKS.............!!!!!!";
			char sub[] = "Hai this mail is from vineel coded using C and Win32 api.....";
			MapiMessage mm = {0};
			MapiRecipDesc md = {0};
			mm.lpszSubject = sub;
			mm.lpszNoteText = body;
			mm.nRecipCount = 1;
			mm.lpOriginator = &md;
			mm.lpRecips = &md;
			md.ulRecipClass = MAPI_TO;
			md.lpszName = "Vineel";
			md.lpszAddress= "SMTP:vineel567@yahoo.co.in";
			
			if(SUCCESS_SUCCESS == f(0,0,&mm,MAPI_NEW_SESSION ,0))printf("Sucess");


			FreeLibrary(h);
		}
	}



}


