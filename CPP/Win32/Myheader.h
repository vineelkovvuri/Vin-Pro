//This file contains some simple string handling routines
//=====================================================================================
#include<windows.h>
#include<tchar.h>
//=====================================================================================
#define WIN32_LEAN_AND_MEAN
//=====================================================================================
int IndexOf(LPCTSTR str,LPCTSTR pat,int start);
void Split(LPCTSTR s,LPCTSTR pat);
int LastIndexOf(LPCTSTR str,LPCTSTR pat);
BOOL Equals(LPCTSTR s1,LPCTSTR s2);
BOOL EqualsIgnoreCase(LPCTSTR s1,LPCTSTR s2);
BOOL StartsWith(LPCTSTR s1,LPCTSTR pat);
BOOL EndsWith(LPCTSTR s1,LPCTSTR pat);
LPTSTR SubString(LPCTSTR s,int st,int len);
LPTSTR RTrim(LPTSTR s,TCHAR c);
LPTSTR LTrim(LPTSTR s,TCHAR c);	
LPTSTR Trim(LPTSTR s,TCHAR c);
BOOL Contains(LPCTSTR s,LPCTSTR pat);
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
TCHAR x[3][6];	
void  Split(LPCTSTR s,LPCTSTR pat)
{
	int t=0,i=0,j=0;

	t = IndexOf(s,pat,0);
	sprintf(x[0],"%s",SubString(s,0,t));
//	printf("\n%s",&x[0][1]);
	i=t+1;
	t = IndexOf(s,pat,i);
	sprintf(x[1],"%s",SubString(s,i,t-i));
//	printf("\n%s",&x[0][1]);

	i=t+1;
	t=lstrlen(&s[i]);
	sprintf(x[2],"%s",SubString(s,i,t));
//	printf("\n%s",&x[0][1]);

}
//=====================================================================================
int LastIndexOf(LPCTSTR str,LPCTSTR pat)
{
	int i=0,j=0;
	int n2,n1 = lstrlen(str);
	n2 = lstrlen(pat);
	for(i=n1-1;i>=0;i--)
	{
		for(j=n2-1;j>=0;j--)
			if(pat[j]!=str[i-(n2-j-1)])break;
		if(j==-1)return i-(n2-1);
	}
	return -1;
}
//=====================================================================================
BOOL Equals(LPCTSTR s1,LPCTSTR s2)
{
	return lstrcmp(s1,s2)==0?TRUE:FALSE;
}
//=====================================================================================
BOOL EqualsIgnoreCase(LPCTSTR s1,LPCTSTR s2)
{
	return lstrcmpi(s1,s2)==0?TRUE:FALSE;
}
//=====================================================================================
BOOL StartsWith(LPCTSTR s1,LPCTSTR pat)
{
	int i=0;
	while(pat[i]!='\0')
		if(pat[i]!=s1[i++])return FALSE;
	return TRUE;
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
LPTSTR SubString(LPCTSTR s,int st,int len)
{
	static TCHAR buf[1024];
	int i=0,j=0;
	while(i<len)
	{
		buf[i]=s[i+st];
		i++;
	}
	buf[i]='\0';
	return buf;
}
//=====================================================================================
LPTSTR RTrim(LPTSTR s,TCHAR c)
{
	int i=0,end=0;
	int n =lstrlen(s);
	for(i=n-1;i>=0;i--)
		if(s[i]!=c){end=i+1;break;}
	return SubString(s,0,end);
}
//=====================================================================================
LPTSTR LTrim(LPTSTR s,TCHAR c)
{
	int i=0;
	for(;s[i]!='\0';i++)
		if(s[i]!=c)break;
	return SubString(s,i,lstrlen(s)-i);
}
//=====================================================================================
LPTSTR Trim(LPTSTR s,TCHAR c)
{
	return LTrim(RTrim(s,c),c);
}
//=====================================================================================
BOOL Contains(LPCTSTR s,LPCTSTR pat)
{
	return IndexOf(s,pat,0)>-1;
}
//=====================================================================================
/*
LPTSTR Replace(LPTSTR s,LPCTSTR old,LPCTSTR _new)
{
	int i=0,t=0;
	for(i=0;s[i]!='\0';)
	{
		t = IndexOf(s,old);
		if(t == -1)return s;
		for(j=0;_new[i]!='\0';j++)
			s[t+j]=_new[j];
		i=t+j;
	}
	s[i]= '\0';
}
*/
//=====================================================================================

