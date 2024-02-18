/*program to display the number of vowels in the string*/
#include<stdio.h>
main()
{
char a[20]; int x,k=0;
printf("Enter a string\n");
scanf("%s",a);
for(x=0;a[x]!='\0';x++)
if(a[x]=='a'||a[x]=='e'||a[x]=='i'||a[x]=='o'||a[x]=='u')k++;
printf("%d",k);
getch();
}