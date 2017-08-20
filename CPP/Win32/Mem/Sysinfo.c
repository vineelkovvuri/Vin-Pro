//Brief description of system 

#include<windows.h>
#include<tchar.h>

_tmain()
{
	SYSTEM_INFO si ;
	
	GetSystemInfo(&si);
	printf("\nNo of Processors : %d",si.dwNumberOfProcessors);
	printf("\nlpMaximumApplicationAddress : %ld",si.lpMaximumApplicationAddress);
	printf("\nlpMinimumApplicationAddress : %ld",si.lpMinimumApplicationAddress);
	printf("\n dwPageSize : %d",si.dwPageSize);
}

/*
   typedef struct _SYSTEM_INFO { 
   union { 
   	DWORD dwOemId;
   	struct {     
	   WORD wProcessorArchitecture; 
	   WORD wReserved;  
   	}; 
   }; 
   DWORD dwPageSize;
   LPVOID lpMinimumApplicationAddress;
				//Pointer to the highest memory address 
				//accessible to applications and DLLs.
				//NOTE : it does not points to a variable 
				//containing highest memory
				//so si.lpMaximumApplicationAddress
				//its gives the highest memory accessible
				//not *(si.lpMaximumApplicationAddress)
   LPVOID lpMaximumApplicationAddress;  
   DWORD_PTR dwActiveProcessorMask;
   DWORD dwNumberOfProcessors;
   DWORD dwProcessorType;
   DWORD dwAllocationGranularity;
   WORD wProcessorLevel;
   WORD wProcessorRevision;
   } SYSTEM_INFO;
*/  
