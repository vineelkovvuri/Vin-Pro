/*program to check weather the given string is pallendrome or not without using string functions*/
#include<stdio.h>
main()
{
int i,j,n=0;char x[10];
printf("\nEnter the string:");
scanf("%s",x);
for(i=0;x[i]!='\0';i++)
j=i;
for(i=0;i<j/2;i++)
if(x[i]!=x[j-i])++n;
if(n==0)printf("\nThe string is a palendrome");
else printf("\nThe string is not a palendrome");
getch();
}