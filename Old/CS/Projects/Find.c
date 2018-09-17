

/*
 * File searching program in C using WIN32 API.
 * This program mimics some(very few) of the options of 
 * Linux find command.
 * -It lacks in Regular Expression Support. 
 *	 							 	 By
 *                          K.Vineel Kumar Reddy. B.Tech III/IV IT
 *                          Gayatri Vidya Parishad College of Engg.
 *                          Vishakapatnam,Andhra Pradesh.
 *	                                  INDIA. 
 */

//=====================================HEADERS=========================================
#include<windows.h>
#include<tchar.h>
//=====================================MACROS==========================================
#define WIN32_LEAN_AND_MEAN
#define IsDir(data) (data.dwFileAttributes&FILE_ATTRIBUTE_DIRECTORY) \
											==  FILE_ATTRIBUTE_DIRECTORY
#define IsArchive(data) (data.dwFileAttributes&FILE_ATTRIBUTE_ARCHIVE)\
											==	FILE_ATTRIBUTE_ARCHIVE
#define IsCompressed(data) (data.dwFileAttributes&FILE_ATTRIBUTE_COMPRESSED)\
											==	FILE_ATTRIBUTE_COMPRESSED
#define IsEncrypted(data) (data.dwFileAttributes&FILE_ATTRIBUTE_ENCRYPTED)\
											==	FILE_ATTRIBUTE_ENCRYPTED
#define IsHidden(data) (data.dwFileAttributes&FILE_ATTRIBUTE_HIDDEN)\
											==	FILE_ATTRIBUTE_HIDDEN
#define IsReadOnly(data) (data.dwFileAttributes&FILE_ATTRIBUTE_READONLY)\
											== 	FILE_ATTRIBUTE_READONLY
#define IsSystem(data)  (data.dwFileAttributes&FILE_ATTRIBUTE_SYSTEM)\
											== 	FILE_ATTRIBUTE_SYSTEM
#define IsTemporary(data) (data.dwFileAttributes&FILE_ATTRIBUTE_TEMPORARY)\
											== 	FILE_ATTRIBUTE_TEMPORARY
#define ValidDir(data) lstrcmpi(data.cFileName,".")&&lstrcmpi(data.cFileName,"..")
#define IsDateBefore()	 St.wYear<yy||	\
		  				 St.wYear==yy&&St.wMonth<mm||\
	 		  			 St.wYear==yy&&St.wMonth==mm&&St.wDay<dd
#define IsDateAfter() 	 St.wYear>yy||	\
		 				 St.wYear==yy&&St.wMonth>mm||\
						 St.wYear==yy&&St.wMonth==mm&&St.wDay>dd	
#define IsDateEqual()	 St.wYear==yy&&St.wMonth==mm&&St.wDay==dd		
//=============================USER  DEFINED FUNCTIONS=================================
void Help();
void SetLtGtEq(char * argv);//set less than,greater than,equal to flags
void SearchByName(LPTSTR path);
void SearchBySize(LPTSTR path);
void SearchByText(LPTSTR path);
void SearchByTime(LPTSTR path);
void Split(LPCTSTR s,LPCTSTR pat);
int IndexOf(LPCTSTR str,LPCTSTR pat,int start);
LPTSTR SubString(LPCTSTR s,int st,int len);
BOOL EndsWith(LPCTSTR s1,LPCTSTR pat);
BOOL Contains(LPCTSTR s,LPCTSTR pat);
BOOL PathExist(LPTSTR path);
BOOL ValidExtension(LPCTSTR name);
//=============================USER DEFINED VARIABLES==================================
TCHAR name[MAX_PATH],text[MAX_PATH],temp[MAX_PATH],ext[10],x[3][6],attr[2];	
BOOL _name,_path,_size,_text,_ext,_mt,_at,_ct,lt,gt,eq,_maxdepth,_attr;
DWORD size=1,at,ct,mt,mm,dd,yy,maxdepth,depth_count;
WIN32_FIND_DATA data;
FILETIME Ct,Mt,At;
SYSTEMTIME St;
//=====================================================================================
void Help()
{
	_tprintf("\nFind 1.0 - File Searching Program.");
	_tprintf("\nCopyright (C) 2007-2008 K.Vineel Kumar Reddy. ;)");
	_tprintf("\nCompiled On %s - vineelkumarreddy.googlepages.com\n",__DATE__);
	_tprintf("\nLICENSED TO EVERYBODY ... :)\n");

	_tprintf("\nfind -path <path> <options> ");
 	_tprintf("\n<options> -> all options are mutually exclusive unless specified otherwise\n\
	 -name <file name>\n\
  	 -size <size> example if size is\n\
	 		   -10b  means less than 10 bytes\n\
			   +10k  means greater than 10 kilo bytes\n\
			   =10m  means equal to 10 Mega bytes\n\
	 -text <text> [-ext <ext>] example if text is vineel \n\
			   the find command searches for files that contains \n\
			   text string vineel.If extension is specified files\n\
			   with <ext> extension are searched else\n\
			   files with default extensions are searched.\n\
			   -ext is used only with -t option...!\n\
	 -mtime <time> -mtime implies modified time\n\
			   use -ctime for created  time\n\
			   use -atime for access time\n\
			   example if <time> is\n\
			   -mm/dd/yyyy implies files created before mm/dd/yyyy\n\
			   +mm/dd/yyyy implies files created after mm/dd/yyyy\n\
			   =mm/dd/yyyy implies files created on mm/dd/yyyy\n\
	 -maxdepth <levels> this specifies how many directory levels\n\
			   the find should traverse.By default maxdepth = 0 .\n\
			   This is used in combination of above options...!\n\
	 -attr <attr> attr can take any one of the following\n\
			   A indicates Archived file\n\
		  	   C indicates Compressed file (NTFS drives only)\n\
			   E indicates Encrypted file  (NTFS drives only)\n\
			   H indicates Hidden file 	\n\
			   R indicates Read only file\n\
			   S indicates System file\n\
			   T indicates Temporary file\n\
			   This option applies only to files not directories\n\
			   This is used in combination of above options...!\n\
			");
}
//=====================================================================================
BOOL PathExist(LPTSTR path)
{
	HANDLE h = CreateFile(
			path,
			GENERIC_READ,
			FILE_SHARE_READ|FILE_SHARE_WRITE|FILE_SHARE_DELETE,
			NULL,
			OPEN_EXISTING,
			FILE_FLAG_BACKUP_SEMANTICS,
			NULL);
	return h!=INVALID_HANDLE_VALUE;
}
//=====================================================================================
void SearchBySize(LPTSTR path)
{
	HANDLE h;
	TCHAR temp1[MAX_PATH];
	sprintf(temp,"%s%s",path,"*.*");//path = c:\windows name = *.*
	h = FindFirstFile(temp,&data);	//temp = c:\windows\*.*
	if(h!=INVALID_HANDLE_VALUE){ 	//Check whether we got valid handle or not 
		do{
			if(IsDir(data)){
				if(ValidDir(data)){
					sprintf(temp1,"%s%s\\",path,data.cFileName); 
					if(!_maxdepth)SearchBySize(temp1);
					else if(depth_count++<=maxdepth){		
						SearchBySize(temp1);
						--depth_count;
					}
				}
			}			
			else if((lt&&data.nFileSizeLow<size)||
					(gt&&data.nFileSizeLow>size)||
					(eq&&data.nFileSizeLow==size)){
					if((!_attr&&!(IsHidden(data))&&!(IsSystem(data)))||
						(attr[0]=='A'&&IsArchive(data))||
						(attr[0]=='C'&&IsCompressed(data))||		
						(attr[0]=='E'&&IsEncrypted(data))||
						(attr[0]=='H'&&IsHidden(data))||
						(attr[0]=='R'&&IsReadOnly(data))||
						(attr[0]=='S'&&IsSystem(data))||
						(attr[0]=='T'&&IsTemporary(data)))
				_tprintf("\n%s%s-->%d",path,data.cFileName,data.nFileSizeLow);
			}
		}while(FindNextFile(h,&data));
		FindClose(h);
	}	
}
//=====================================================================================
void SearchByName(LPTSTR path)
{
	HANDLE h;
	TCHAR temp1[MAX_PATH];
	sprintf(temp,"%s%s",path,"*.*");//path = c:\windows name = *.*
	h = FindFirstFile(temp,&data);//temp = c:\windows\*.*
	if(h!=INVALID_HANDLE_VALUE){  //Check whether we got valid handle or not 
		do{
			if(IsDir(data)){
				if(ValidDir(data)){
					sprintf(temp1,"%s%s\\",path,data.cFileName); 
					if(!_maxdepth)SearchByName(temp1);
					else if(depth_count++<=maxdepth){
						SearchByName(temp1);
						--depth_count;		
					}
				}
			}			
			else if(!lstrcmpi(data.cFileName,name)){
					if((!_attr&&!(IsHidden(data))&&!(IsSystem(data)))||
						(attr[0]=='A'&&IsArchive(data))||
						(attr[0]=='C'&&IsCompressed(data))||		
						(attr[0]=='E'&&IsEncrypted(data))||
						(attr[0]=='H'&&IsHidden(data))||
						(attr[0]=='R'&&IsReadOnly(data))||
						(attr[0]=='S'&&IsSystem(data))||
						(attr[0]=='T'&&IsTemporary(data)))
						_tprintf("\n%s%s",path,name);
			}
		}while(FindNextFile(h,&data));
		FindClose(h);
	}
}
//=====================================================================================
void SearchByText(LPTSTR path)
{
	HANDLE h;
	TCHAR temp1[MAX_PATH];
	sprintf(temp,"%s%s",path,"*.*");//path = c:\windows name = *.*
	h = FindFirstFile(temp,&data);//temp = c:\windows\*.*
	if(h!=INVALID_HANDLE_VALUE){  //Check whether we got valid handle or not 
		do{
			if(IsDir(data)){
				if(ValidDir(data)){//Checks whether the Dir is . or ..
					sprintf(temp1,"%s%s\\",path,data.cFileName); 
					if(!_maxdepth)SearchByText(temp1);
					else if(depth_count++<=maxdepth){		
							SearchByText(temp1);
							--depth_count;
					}
				}
			}
			else if(ValidExtension(data.cFileName)){
					if((!_attr&&!(IsHidden(data))&&!(IsSystem(data)))||
						(attr[0]=='A'&&IsArchive(data))||
						(attr[0]=='C'&&IsCompressed(data))||		
						(attr[0]=='E'&&IsEncrypted(data))||
						(attr[0]=='H'&&IsHidden(data))||
						(attr[0]=='R'&&IsReadOnly(data))||
						(attr[0]=='S'&&IsSystem(data))||
						(attr[0]=='T'&&IsTemporary(data))){
						sprintf(temp1,"%s%s",path,data.cFileName); 
						if(FileContainsText(temp1))_tprintf("\n%s%s",path,data.cFileName);
					}
			}
		}while(FindNextFile(h,&data));
		FindClose(h);
	}
}
//=====================================================================================
BOOL FileContainsText(LPCTSTR file_path)
{
	static TCHAR buf[1025];
	static HANDLE h;
	static int read=0;
	h = CreateFile(file_path,
			GENERIC_READ,
			FILE_SHARE_READ,
			NULL,
			OPEN_EXISTING,
			FILE_ATTRIBUTE_READONLY,
			NULL);
	if(h!=INVALID_HANDLE_VALUE){
		while(ReadFile(h,buf,1024,&read,NULL)&&read>0){
			buf[read]='\0';
			if(Contains(buf,text)){
				CloseHandle(h)	;
				return TRUE;
			}
		}
		CloseHandle(h);
	}
	return FALSE;
}
//=====================================================================================
BOOL ValidExtension(LPCTSTR name)
{
	return _ext?EndsWith(name,ext):
		   (EndsWith(name,".txt")||EndsWith(name,".cpp")||EndsWith(name,".log")||
		   EndsWith(name,".c")||EndsWith(name,".h")||EndsWith(name,".x")||
	       EndsWith(name,".rtf")||EndsWith(name,".xml")||EndsWith(name,".java")||
		   EndsWith(name,".cc")||EndsWith(name,".cs")||EndsWith(name,".js")||
		   EndsWith(name,".pl")||EndsWith(name,".rc")||EndsWith(name,".vb")||
		   EndsWith(name,".asm")||EndsWith(name,".asp")||EndsWith(name,".bat")||
		   EndsWith(name,".cmd")||EndsWith(name,".ini")||EndsWith(name,".css")||
		   EndsWith(name,".reg")||EndsWith(name,".css")||EndsWith(name,".def")||
		   EndsWith(name,".html")||EndsWith(name,".htm")||EndsWith(name,".inf")||
   		   EndsWith(name,".py"));
}
//=====================================================================================
void SearchByTime(LPTSTR path)
{
	HANDLE h;
	TCHAR temp1[MAX_PATH];
	sprintf(temp,"%s%s",path,"*.*");//path = c:\windows name = *.*
	h = FindFirstFile(temp,&data);//temp = c:\windows\*.*
	if(h!=INVALID_HANDLE_VALUE){  //Check whether we got valid handle or not 
		do{
			if(IsDir(data)){
				if(ValidDir(data)){
					sprintf(temp1,"%s%s\\",path,data.cFileName); 
					if(!_maxdepth)SearchByTime(temp1);
					else if(depth_count++<=maxdepth){			
						SearchByTime(temp1);
						--depth_count;
					}
				}
			}
			else {		
				//printf("\n%s%s %d",path,data.cFileName,GetLastError());
				if((!_attr&&!(IsHidden(data))&&!(IsSystem(data)))||
						(attr[0]=='A'&&IsArchive(data))||
						(attr[0]=='C'&&IsCompressed(data))||		
						(attr[0]=='E'&&IsEncrypted(data))||
						(attr[0]=='H'&&IsHidden(data))||
						(attr[0]=='R'&&IsReadOnly(data))||
						(attr[0]=='S'&&IsSystem(data))||
						(attr[0]=='T'&&IsTemporary(data))){
					if(_at)FileTimeToSystemTime(&data.ftLastAccessTime,&St);
					else if(_mt)FileTimeToSystemTime(&data.ftLastWriteTime,&St);	
					else if(_ct)FileTimeToSystemTime(&data.ftCreationTime,&St);
					if((lt&&IsDateBefore())||(gt&&IsDateAfter())||(eq&&IsDateEqual()))
				_tprintf("\n%s%s\t%d/%d/%d",path,data.cFileName,St.wMonth,St.wDay,St.wYear);
				}
			}
		}while(FindNextFile(h,&data));
		FindClose(h);
	}
}
//=====================================================================================
_tmain(int argc,LPTSTR *argv)
{
	int i=0,n;
	static TCHAR path[MAX_PATH];
	if(argc<5)return Help();//Help();return;
	//Parse Command Line Arguments 
	for(i=1;i< argc;i++){
		if(lstrcmpi(argv[i],_T("-path"))==0){
			_path=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			lstrcpy(path,argv[i]);
			if(!EndsWith(path,"\\"))lstrcat(path,"\\");
			if(!PathExist(path)){
				_tprintf("\n%s path does not exists ",path);
				return ;
			}
		}
		else if(lstrcmpi(argv[i],_T("-name"))==0){
			_name=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			lstrcpy(name,argv[i]);
		}
		else if(lstrcmpi(argv[i],_T("-size"))==0){
			_size=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			lt = argv[i][0]=='-';
			gt = argv[i][0]=='+';			
			eq = argv[i][0]=='=';
			n = lstrlen(argv[i]);			
			size = argv[i][n-1]=='K'||argv[i][n-1]=='k'?1024:
				   argv[i][n-1]=='M'||argv[i][n-1]=='m'?1024*1024:
				   1;
			size*=atoi(SubString(argv[i],1,n-2));
			//if given size is not a number then atoi returns zero so size
			//become zero and we should terminate the program
			if(size==0){
			_tprintf("\nGiven Size(%s) is not in correct format.. Check find /?",argv[i]);
			return;
			}
		}
		else if(lstrcmpi(argv[i],_T("-text"))==0){
			_text=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			lstrcpy(text,argv[i]);
		}
		else if(lstrcmpi(argv[i],_T("-ext"))==0){
			_ext=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			sprintf(ext,"%s%s",argv[i][0]=='.'?"":".",argv[i]);
		}
		else if(lstrcmpi(argv[i],_T("-atime"))==0){
			_at=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			SetLtGtEq(argv[i]);
			//Check whether we got date in right format
			if((lt==0||gt==0||eq==0)||(mm==0||dd==0||yy==0)){
			_tprintf("\nGiven Date(%s) is not in correct format.. Check find /?",argv[i]);
				return;
			}
		}
		else if(lstrcmpi(argv[i],_T("-mtime"))==0){
			_mt=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			SetLtGtEq(argv[i]);
			//Check whether we got date in right format
			if((lt==0||gt==0||eq==0)||(mm==0||dd==0||yy==0)){
			_tprintf("\nGiven Date(%s) is not in correct format.. Check find /?",argv[i]);
				return;
			}
		}
		else if(lstrcmpi(argv[i],_T("-ctime"))==0){
			_ct=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			SetLtGtEq(argv[i]);
			//Check whether we got date in right format
			if((lt==0||gt==0||eq==0)||(mm==0||dd==0||yy==0)){
			_tprintf("\nGiven Date(%s) is not in correct format.. Check find /?",argv[i]);
				return;
			}
		}
		else if(lstrcmpi(argv[i],_T("-maxdepth"))==0){
			_maxdepth=TRUE;
			i+=(i<argc-1);//If last arg is option what to do *(~_~)*  ....!!!
			maxdepth=atoi(argv[i]);//if atoi fails it returns 0
			_maxdepth=maxdepth;	//Incase maxdepth is 0 go for normal complete
								//search so make _maxdepth false;
								//if(maxdepth==0)_maxdepth=0;
								//so _maxdepth=maxdepth;		
		}
		else if(lstrcmpi(argv[i],_T("-attr"))==0){
			_attr=TRUE;
			i+=(i<argc-1);
			lstrcpy(attr,argv[i]);
			if(attr[0]>='a'&&attr[0]<='z')attr[0]-=32;
			if(!(attr[0]=='A'||attr[0]=='C'||attr[0]=='E'||attr[0]=='H'||attr[0]=='R'||
				attr[0]=='S'||attr[0]=='T')){
			_tprintf("\nGiven Attribute(%s) is not correct . Check find /?",argv[i]);
				return;
			}
		}
		else if(lstrcmpi(argv[i],_T("/?"))==0)return Help();
		else return Help();
	}

	//		_tprintf("\npath = %s file=%s size=%d text=%s",path,name,size,text);
	//		_tprintf("\npath = %d file=%d size=%d",lt,eq,gt);
	//		_tprintf("\npath = %d file=%d size=%d",_at,_ct,_mt);
	//		_tprintf("\npath = %d file=%d size=%d",mm,dd,yy);
	if(_name)SearchByName(path);
	else if(_size)SearchBySize(path);
	else if(_text)SearchByText(path);
	else if(_at||_ct||_mt)SearchByTime(path);
	else return Help();

}
//=====================================================================================
void  SetLtGtEq(char * p)
{
	//Set lt,gt,eq accordingly by examing p[0], which indicates first char of 
	//Entered Date 
	lt = p[0]=='-';
	gt = p[0]=='+';			
	eq = p[0]=='=';
	//Split the Date in to substrings when ever '/' encountered
	Split(p,"/");	//Splited substrings are stored globally in char x[3][6] array	
	//Convert the Individual substrings in to integers
	mm = atoi(&x[0][1]); //eliminate -,+,= character from date
	dd = atoi(x[1]);
	yy = atoi(x[2]);

//	printf("\n%d  %d  %d  %d  %d  %d  ",lt,gt,eq,mm,dd,yy);
}
//=====================================================================================

void  Split(LPCTSTR s,LPCTSTR pat)
{
	int t=0,i=0;
	//extracts +12 part of +12/25/2007
	t = IndexOf(s,pat,0);
	sprintf(x[0],"%s",SubString(s,0,t));

	//extracts 25 part of +12/25/2007
	i=t+1;
	t = IndexOf(s,pat,i);
	sprintf(x[1],"%s",SubString(s,i,t-i));

	//extracts 2007 part of +12/25/2007
	i=t+1;
	t=lstrlen(&s[i]);
	sprintf(x[2],"%s",SubString(s,i,t));
}
//=====================================================================================
int IndexOf(LPCTSTR str,LPCTSTR pat,int start)
{
	int i=0,j=0;
	for(i=start;str[i]!='\0';i++)
	{
		for(j=0;pat[j]!='\0';j++)
			if(pat[j]!=str[i+j])break;
		if(pat[j]=='\0')return i;
	}
	return -1;
}
//=====================================================================================
BOOL Contains(LPCTSTR s,LPCTSTR pat)
{
	return IndexOf(s,pat,0)>-1;
}
//=====================================================================================
LPTSTR SubString(LPCTSTR s,int st,int len)
{
	static TCHAR buf[1024];
	int i=0;
	while(i<len)
	{
		buf[i]=s[i+st];
		i++;
	}
	buf[i]='\0';
	return buf;
}
//=====================================================================================
BOOL EndsWith(LPCTSTR s1,LPCTSTR pat)
{
	int i=0;
	int n=lstrlen(pat);
	int sn = lstrlen(s1);
	for(i=n-1;i>=0;i--)
		if(pat[i]!=s1[--sn])return FALSE;
	return TRUE;
}
//=====================================================================================


