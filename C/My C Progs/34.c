/*program to find the length of the string */
#include<stdio.h>
main()
{
char a[50];int i;
printf("\nEnter the string:");
scanf("%s",a);
for(i=1;a[i]!=0;i++);
printf("%d",i);
getch();
}

