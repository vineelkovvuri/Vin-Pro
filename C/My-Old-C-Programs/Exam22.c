#include<stdio.h>
struct std{char name[10];int m1;int m2;int m3;int total;}s[4];
main()
{
int i;
printf("\nEnter stduent details(name,m1,m2,m3):");
for(i=0;i<4;i++)
{scanf("%s%d%d%d",s[i].name,&s[i].m1,&s[i].m2,&s[i].m3);
 s[i].total=(s[i].m1+s[i].m2+s[i].m3);}
printf("\nThe student marks memo is:\n");
for(i=0;i<4;i++)
printf("name:%s\nm1=%d\nm2=%d\nm3=%d\ntotal=%d\n",s[i].name,s[i].m1,s[i].m2,s[i].m3,s[i].total);
getch();
return 0;
}