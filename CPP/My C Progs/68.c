/*program to perform lengh of the string by recursion*/
#include<stdio.h>
int len(char[],int);
main()
{
char a[15],i;
printf("\nEnter the string:");
scanf("%[^\n]s",a);
printf("%d",len(a,0));
getch();
}
int len(char a[],int i)
{
if(a[i]=='\0') return i;
else return len(a,++i);
}