#include<stdio.h>
#include<string.h>
main()
{
int i;char x[20];
printf("\nEnter the string");
scanf("%s",x);
for(i=0;i<strlen(x);i++)
printf("%c",x[i]-32);
}

