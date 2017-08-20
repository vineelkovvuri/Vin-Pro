/*
* This program collects basic hardware and software information of 
* Windows based PC.
* It is written in C using Win32 api
*
*	 							 	 By
*                          K.Vineel Kumar Reddy. B.Tech IV/IV IT
*                          Gayatri Vidya Parishad College of Engg.
*                          Vishakapatnam,Andhra Pradesh.
*	                                  INDIA. 
*/

#define UNICODE
#include<windows.h>
#include<winuser.h>
#include<winbase.h>
#include<psapi.h>

#define _UNICODE
#include<tchar.h>
#include<stdio.h>
#include<string.h>



#pragma comment(lib,"kernel32.lib")
#pragma comment(lib,"user32.lib")
#pragma comment(lib,"gdi32.lib")
#pragma comment(lib,"advapi32.lib")
#pragma comment(lib,"shell32.lib")
#pragma comment(lib,"psapi.lib")

int compare(const void *x,const void *y)
{
	return *(int*)x - *(int*)y;
}

void PrintSystemName()
{
	TCHAR compName[40];
	DWORD size=40;
	if(GetComputerName(compName,&size)!=0)
		_tprintf(_T("\nComputer Name : %s "),compName);
}

void PrintUserName()
{
	TCHAR uName[40];
	DWORD size = 40;
	if(GetUserName(uName,&size) != 0)
		_tprintf(_T("\nLogged user name : %s"),uName);
}

void PrintSystemUpTime()
{
	unsigned int t,d,h,m,s;
	t = GetTickCount();
	t/=1000;
	d = t/86400;	//days
	t = t%86400;
	h = t/3600;
	t = t%3600;
	m = t/60;
	t = t%60;
	s = t;

	_tprintf(_T("\nSystem Up Time(D:H:M:S) = %u:%u:%u:%u"),d,h,m,s);	
}
void PrintHardDrivesInfo()
{
	int drives,i=0;
	__int64 nFree,nTotal,nHDFree=0,nHDTotal=0;
	TCHAR dName[40],volName[40];

	_tprintf(_T("\n\nHard Disk Info:"));
	_tprintf(_T(  "\n---------------"));
	drives = GetLogicalDrives();  //the bits in 'drives' variable indicates available drives
	while(drives != 0)
	{
		if((drives&1) == 1) //if bit is on then that drive is present	
		{	  
			wsprintf(dName,_T("%c:\\"),'A'+i);	
			if(GetDriveType(dName) == DRIVE_FIXED)
			{	
				if(GetDiskFreeSpaceEx(dName,(PULARGE_INTEGER)&nFree,(PULARGE_INTEGER)&nTotal,NULL)!= 0)
				{
					_tprintf(_T("\n%s"),dName);
					nHDFree += nFree;
					nHDTotal += nTotal;	
					_tprintf(_T(" Free : %6.2I64fGB Total : %6.2I64fGB  "),nFree/(1024*1024*1024.0),nTotal/(1024*1024*1024.0));
					GetVolumeInformation(dName,NULL,0,NULL,NULL,NULL,volName,10);
					_tprintf(_T("%s"),volName);
				}
			}
		}
		drives>>=1;
		i++;
	}
	_tprintf(_T("\n==========================================="));
	_tprintf(_T("\n    Free : %6.2I64fGB Total : %6.2I64fGB"),nHDFree/(1024*1024*1024.0),nHDTotal/(1024*1024*1024.0));
	_tprintf(_T("\n==========================================="));
}

void PrintCDRomInfo()
{
	int i=0;
	HANDLE hDrive;
	DWORD drives;
	TCHAR driveName[10];
	_tprintf(_T("\n\nDevices With Removable Storage"));
	_tprintf(_T(  "\n------------------------------"));
	drives = GetLogicalDrives();  //the bits in 'drives' variable indicates available drives
	while(drives != 0)
	{
		if((drives&1) == 1) 	  //if bit is on then that drive is present	
		{
			wsprintf(driveName,_T("%c:\\"),'A'+i);	
			if(GetDriveType(driveName) == DRIVE_CDROM)
			{	
				wsprintf(driveName,_T("\\\\.\\%c:"),'A'+i);	
				//open the cd rom............
				hDrive= CreateFile(driveName,0,FILE_SHARE_READ,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_NORMAL,NULL);
				if(hDrive != INVALID_HANDLE_VALUE)
				{
					DWORD ret ; //return value of DeviceIOControl................
					CHAR buffer[1024];   //Must be big enough hold DEVICE_MEDIA_INFO
					PGET_MEDIA_TYPES mediaTypes;
					if(DeviceIoControl(hDrive,IOCTL_STORAGE_GET_MEDIA_TYPES_EX,NULL,0,buffer,sizeof(buffer),&ret,0)!=0)
					{
						mediaTypes = (PGET_MEDIA_TYPES) buffer;
						switch ( mediaTypes->DeviceType ) 
						{
						case FILE_DEVICE_CD_ROM:
							_tprintf(_T("\n%c:\\ => CD-ROM"),'A'+i);
							goto Info;
						case FILE_DEVICE_DVD:
							_tprintf(_T("\n%c:\\ => DVD-ROM"),'A'+i);
							goto Info;
Info:
							{
								DEVICE_MEDIA_INFO mediaInfo = mediaTypes->MediaInfo[1];
								switch(mediaInfo.DeviceSpecific.RemovableDiskInfo.MediaCharacteristics)
								{
								case MEDIA_ERASEABLE:
									_tprintf(_T(" Eraseable "));
									break;
								case MEDIA_READ_ONLY:
									_tprintf(_T(" Read-Only "));
									break;
								case MEDIA_READ_WRITE:
									_tprintf(_T(" Read-Write "));
									break;
								case MEDIA_WRITE_ONCE:
									_tprintf(_T(" Write Once "));
									break;
								case MEDIA_WRITE_PROTECTED:
									_tprintf(_T(" Write Protected "));
									break;
								}
							}
						}
					}
					CloseHandle(hDrive);
				}
			}
		}
		drives>>=1;
		i++;
	}
}
void PrintMonitorInfo()
{
	int width,height,i=0;	
	_tprintf(_T("\n\nMonitor Info:"));
	_tprintf(_T(  "\n-------------"));
	//Enumerating the display devices.........
	DISPLAY_DEVICE dd = {sizeof(DISPLAY_DEVICE)};
	while(EnumDisplayDevices(NULL,i,&dd,0 )!=0)
	{
		if((dd.StateFlags&DISPLAY_DEVICE_MIRRORING_DRIVER) != DISPLAY_DEVICE_MIRRORING_DRIVER)
		{
			_tprintf(_T("\n%s "),dd.DeviceString);
			//determine the primary device or not
			if((dd.StateFlags&DISPLAY_DEVICE_ATTACHED_TO_DESKTOP) == DISPLAY_DEVICE_ATTACHED_TO_DESKTOP)
				_tprintf(_T("--> Primary"));
		}
		i++;
	}
	//Monitor Resolution
	width = GetSystemMetrics(SM_CXSCREEN);
	height = GetSystemMetrics(SM_CYSCREEN);
	_tprintf(_T("\n\nMonitor Resolution : %dx%d"),width,height);
}

void PrintOSInfo()
{
	TCHAR windirName[55];
	OSVERSIONINFO verInfo={sizeof(OSVERSIONINFO)};
	_tprintf(_T("\n\nOS Info: "));
	_tprintf(_T(  "\n--------"));
	_tprintf(_T("\nVersion : "));
	GetVersionEx(&verInfo);
	if(verInfo.dwMajorVersion == 4 && verInfo.dwMinorVersion == 10)_tprintf(_T(" Windows 98 %s Build %d"),verInfo.szCSDVersion,verInfo.dwBuildNumber);
	if(verInfo.dwMajorVersion == 5 && verInfo.dwMinorVersion == 0)_tprintf(_T(" Windows 2000 %s Build %d"),verInfo.szCSDVersion,verInfo.dwBuildNumber);
	if(verInfo.dwMajorVersion == 5 && verInfo.dwMinorVersion == 1)_tprintf(_T(" Windows XP %s Build %d"),verInfo.szCSDVersion,verInfo.dwBuildNumber);
	if(verInfo.dwMajorVersion == 5 && verInfo.dwMinorVersion == 2)_tprintf(_T(" Windows 2003 %s Build %d"),verInfo.szCSDVersion,verInfo.dwBuildNumber);

	GetWindowsDirectory(windirName,55);
	_tprintf(_T("\nWindows Directory : %s "),windirName);

	GetSystemDirectory(windirName,55);
	_tprintf(_T("\nSystem Directory  : %s "),windirName);
}

void PrintProcessorInfo()
{
	HKEY hKey,tempKey;//Pointer to HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor
	TCHAR subKeyName[40],tempKeyName[40];
	BYTE valBuf[100];
	int i=0,t;
	DWORD size=100;
	_tprintf(_T("\n\nProcessor Info:"));
	_tprintf(_T(  "\n---------------"));
	//sexiest of all .......!!!!
	//Finding the number of cores(logical processor) using cpuid instruction.....
	__asm
	{
		mov eax,01h		//01h for getting number of cores present in the physical processor
			cpuid
			mov t,ebx
	}
	_tprintf(_T("\nNumber of logical processors(cores) : %d"),(t>>16)&0xff);  
	if(RegOpenKeyEx(HKEY_LOCAL_MACHINE,L"HARDWARE\\DESCRIPTION\\System\\CentralProcessor",0,KEY_READ,&hKey) == ERROR_SUCCESS)
	{
		while(RegEnumKey(hKey,i++,subKeyName,40) != ERROR_NO_MORE_ITEMS)
		{
			if(RegOpenKeyEx(hKey,subKeyName,0,KEY_READ,&tempKey) == ERROR_SUCCESS)
			{
				size = 100;
				if(RegQueryValueEx(tempKey,_T("ProcessorNameString"),NULL,NULL,valBuf,&size) == ERROR_SUCCESS) 
					_tprintf(_T("\nProcessor  %s : %s"),subKeyName,valBuf);
				size = 100;
				if(RegQueryValueEx(tempKey,_T("Identifier"),NULL,NULL,valBuf,&size) == ERROR_SUCCESS) 
					_tprintf(_T(" %s"),valBuf);
				RegCloseKey(tempKey);
			}
		}
		RegCloseKey(hKey);
	}
}

void PrintMemoryInfo()
{
	MEMORYSTATUSEX ms={sizeof(MEMORYSTATUSEX)};
	GlobalMemoryStatusEx(&ms);
	_tprintf(_T("\n\nMemory Info:"));
	_tprintf(_T(  "\n------------"));
	_tprintf(_T("\nTotal Physical Memory     : %8.2I64fMB \nAvailable Physical Memory : %8.2I64fMB \nUsed Physical Memory      : %8.2I64fMB \n\n"),ms.ullTotalPhys/(1024*1024.0),ms.ullAvailPhys/(1024*1024.0),ms.ullTotalPhys/(1024*1024.0)-ms.ullAvailPhys/(1024*1024.0));

}

void ChangeNotePadSettings()
{
	HKEY hKey,tempKey;
	wchar_t fname[] = _T("Lucida Console");
	//My little registry hack to change the notepad font to 'Lucida Console'...........
	if(RegOpenKeyEx( HKEY_CURRENT_USER,L"Software\\Microsoft\\Notepad",0,KEY_WRITE,&hKey) == ERROR_SUCCESS)
	{
		RegSetValueEx(hKey,L"lfFaceName",0,REG_SZ,(BYTE*)fname,sizeof(fname)+1);
		RegCloseKey(hKey);
	}
}

void PrintProcessInfo()
{
	DWORD processes[100];
	DWORD nBytes,nProc;
	int i=0;
	EnumProcesses(processes,60*sizeof(DWORD),&nBytes); //Get process ids..
	nProc = nBytes/sizeof(DWORD);

	qsort(processes,nProc,sizeof(DWORD),compare);	//sort the processes based on PID............

	_tprintf(_T("\n\nProcesses Info:"));
	_tprintf(_T(  "\n---------------"));
	_tprintf(_T("\n%-15s%-15s%-15s"),_T("Process ID"),_T("Mem Usage"),_T("Image Path"));
	_tprintf(_T("\n---------------------------------------------------------------------"));

	for(i=0;i<nProc;i++)
	{
		HANDLE hProcess;
		TCHAR imagePath[MAX_PATH];
		PROCESS_MEMORY_COUNTERS pMem = {0};
		hProcess = OpenProcess(PROCESS_QUERY_INFORMATION |PROCESS_VM_READ,FALSE,processes[i]);
		if(hProcess != NULL)
		{
			if(GetModuleFileNameEx(hProcess,NULL,imagePath,MAX_PATH)!=0)
			{
				_tprintf(_T("\n%-10d"),processes[i]);
				pMem.cb = sizeof(PROCESS_MEMORY_COUNTERS);
				if(GetProcessMemoryInfo(hProcess,&pMem,sizeof(PROCESS_MEMORY_COUNTERS))!=0)
				{
					_tprintf(_T("%10ldK        "),pMem.WorkingSetSize/1024);
				}
				_tprintf(_T("%-100s"),imagePath);
			}
			CloseHandle(hProcess);
		}
	}
}
void PrintEnvironmentVariables()
{

	LPWCH p = GetEnvironmentStrings();
	wprintf(L"\n\n\n\nEnvironment Variables:\n----------------------");
	for(wchar_t *pp = p; *pp; pp += wcslen(pp) + 1)
		wprintf(L"\n%s",pp);
	FreeEnvironmentStrings(p);
}
int _tmain()
{
	int *p;
	FILE *fp = freopen("Sysinfo.txt","w",stdout);
	SetConsoleTitle(_T("Born 2 Code"));
	_tprintf(_T("\nSYSTEM INFORMATION \n-------------------\n\n"));
	PrintSystemName();
	PrintUserName();
	PrintSystemUpTime();
	PrintHardDrivesInfo();
	PrintCDRomInfo();
	PrintMonitorInfo();
	PrintOSInfo();
	PrintProcessorInfo();
	PrintMemoryInfo();
	PrintProcessInfo();
	PrintEnvironmentVariables();
	ChangeNotePadSettings();

	_tprintf(_T("\n\n---------------------------------------------------------------------------"));
	_tprintf(_T("\n\n\t\t\t\tProgram By"));

	//My Stuff he he he .............. ;)
_tprintf(_T("\n\
    __        __   __   ____        __   _________   _________    __\n\
   /_/|      /_/| /_/| /___/\\      /_/| /________/| /________/|  /_/|\n\
   | ||      | || | || |  _\\ \\     | || | _______|/ | _______|/  | ||\n\
   | ||      | || | || | ||\\\\ \\    | || | ||____    | ||____     | ||\n\
   \\ \\\\      / // | || | || \\\\ \\   | || | |/___/|   | |/___/|    | ||\n\
    \\ \\\\    / //  | || | ||  \\\\ \\  | || | |____|/   | |____|/    | ||\n\
     \\ \\\\_ / //   | || | ||   \\\\ \\_| || | ||______  | ||______   | ||_____\n\
      \\ \\_/ /     | || | ||    \\\\__| || | |/_____/| | |/_____/|  | |/____/|\n\
       \\___/      |_|/ |_|/     \\____|/ |_|______|/ |_|______|/  |_______|/\n\
		"));


	fclose(fp);
	//Open the created sysinfo.txt..........
	ShellExecute(NULL,_T("edit"),_T("Sysinfo.txt"),NULL,_T("."),SW_MAXIMIZE);
}



