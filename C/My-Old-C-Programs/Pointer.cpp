#include<stdio.h>
#include<conio.h>
main()
{
int i;
char *p[5];
char x[5][8]={"vineel","suneeta","satya","mohan","savi"};
for(i=0;i<5;i++)
p[i]=x[i];
for(i=0;i<5;i++)
printf("%s\n",p[i]);
getch();
return(0);
}
