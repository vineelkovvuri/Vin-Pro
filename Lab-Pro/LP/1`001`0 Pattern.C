#include<stdio.h>
#include<string.h>
#include<conio.h>
main()
{
	int flag=0,i=0;
	char c[100];
	clrscr();
	printf("\nEnter the string :");
	scanf("%s",c);
	do{
		if(c[i] == '1') continue;
		else if(c[i] == '0') goto state2;
		else {flag = 1; goto End;}
	}while(c[i++] != '\0');
	{flag = 1; goto End;}
state2:
	i++;
	if(c[i] == '0') goto state3;
	else {flag = 1; goto End;}
state3:
	do{
		i++;
		if(c[i] == '1') continue;
		else if(c[i] == '0'&&c[i+1]=='\0') goto End;
		else {flag = 1; goto End;}
	}while(c[i] != '\0');
	{flag = 1; goto End;}
End:
	if(flag == 0)printf("\nValid Pattern");
	else printf("\nNot a Valid Pattern");
	getch();
	return 0;
}
