/*program to combine two given strings in to the other */
#include<stdio.h>
main()
{
char a[20],b[20],c[40];int i,j;
printf("\nEnter first string:");
scanf("%s",a);
printf("\nEnter second string:");
scanf("%s",b);
for(i=0;a[i]!=0;i++)
c[i]=a[i];
c[i]=' ';
for(j=0;b[j]!=0;j++)
c[j+i+1]=b[j];
c[j+i+1]='\0';
printf("%s",c);
getch();
}