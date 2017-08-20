#include<stdio.h>
#include<string.h>
main()
{
    int i=0,j=0,a=-1,b=-1;char s[100];
    clrscr();
     printf("\nEnter an Valid C Expression:");
     scanf("%s",s);
     s[strlen(s)] = '#';
     for(i=0;i<strlen(s);i++)
     {
	if(s[i]>='a'&&s[i]<='z'||
	   s[i]>='A'&&s[i]<='Z'||
	   s[i]>='0'&&s[i]<='9'||
	   s[i]=='_'){if(a==-1)a=i;}
	 else { if(a!=-1)
		b= i;
		if(a!=-1&&b!=-1)
		{
		for(j = a ;j<b;j++)
		printf("%c",s[j]);
		printf("\t");
		a = -1;
		b = -1;
		}
	      }
     }
     getch();
}