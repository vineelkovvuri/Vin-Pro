/*program to print a string in a format*/
#include<stdio.h>
main()
{
int i,j;char a[20];
  printf("enter the string ");
  scanf("%s",a);
for(i=0;a[i]!=0;i++)
 { for(j=0;j<=i;j++)
    printf("%c",a[j]);
    printf("\n");
 } getch();
}

