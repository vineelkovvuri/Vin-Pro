/* program to find weather given number is palendrome are not*/
#include<stdio.h>
#include<string.h>
main()
{
char a[20],b[20];int i,j;
printf("\nEnter the string:");
scanf("%s",a);
for(i=0;a[i]!=0;i++)
j=i;
for(i=0;a[i]!=0;i++)
b[i]=a[j-i];
b[i]='\0';
if(strcmp(a,b)==0)printf("%s is palendrome",b);
else printf("%s is not palendrome",b);
getch();
}