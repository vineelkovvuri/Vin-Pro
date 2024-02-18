
//Heap Operations

#include<windows.h>
#include<tchar.h>

DWORD Find(DWORD dwFlag)
{
	switch(dwFlag)
	{
		case STATUS_NO_MEMORY :
			printf("\nSTATUS_NO_MEMORY ");
			return EXCEPTION_EXECUTE_HANDLER;
		case STATUS_ACCESS_VIOLATION :
			printf("\nSTATUS_ACCESS_VIOLATION ");
			return EXCEPTION_EXECUTE_HANDLER;
		default :
			return EXCEPTION_EXECUTE_HANDLER;
	}

}
_tmain()
{
	HANDLE h ;
	int * p,i;
	//Getting Handle to Default Process Heap Memory

	h = HeapCreate(HEAP_GENERATE_EXCEPTIONS,15,20);//GetProcessHeap();
	__try{	
		p = (int*)HeapAlloc(h,HEAP_GENERATE_EXCEPTIONS|HEAP_ZERO_MEMORY,2424);//heap
		printf("%d\n ",HeapSize(h,HEAP_NO_SERIALIZE,p));
		for(i=0;i<5;i++)
			p[i] = 'A'+i;
		for(i=0;i<5;i++)
			printf("%c  ",p[i]);

		HeapFree(h,HEAP_NO_SERIALIZE,p);
	}
	__except(Find(GetExceptionCode()))
	{
		HeapDestroy(h); //free Heap
	}
}
