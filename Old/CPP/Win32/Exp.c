

#include<windows.h>
#include<tchar.h>
_tmain()
{
	int i=10,j;
	__try{
	j=i/0;
	}
	__except(EXCEPTION_EXECUTE_HANDLER){
		printf("ERROR");
	}

}
