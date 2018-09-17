
//This is auto generated C template by vim 
//To move to Body field press CTRL+j


#include<windows.h>
#include<tchar.h>
#include<stdio.h>

main()
{
	LPTCH lp = GetEnvironmentStrings();

	while(*lp)
	{
		printf("\n%s",lp);
		lp = lp + strlen(lp)+1;
	}
}



