#include<windows.h>
#include<tchar.h>
#include<float.h>
DWORD Analyse(DWORD code)
{
	return EXCEPTION_EXECUTE_HANDLER;
}
_tmain()
{
	float t = 1;
	DWORD new,old = 	_controlfp(0,0);

	new = old & ~(EM_OVERFLOW | EM_UNDERFLOW
   | EM_INEXACT | EM_ZERODIVIDE | EM_DENORMAL | EM_INVALID);

	_controlfp(old,MCW_EM);
	__try{
		t=t/0;
		printf("%f",t);
	}
	__except(Analyse(GetExceptionCode())){
	printf("%d",sizeof(float));
	_clearfp();
	_controlfp(old,0xFFFFFFFF);
	}

	sdfgsdgf
		gfsdfgs
		fgsdfgsd



}

