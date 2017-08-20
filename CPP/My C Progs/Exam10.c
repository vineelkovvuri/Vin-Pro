#include<stdio.h>
struct std{char name[10];int m1;int m2;int m3;float av;}s[4];
main()
{
int i;
printf("\nEnter stduent details(name,m1,m2,m3):");
for(i=0;i<4;i++)
{scanf("%s%d%d%d",s[i].name,&s[i].m1,&s[i].m2,&s[i].m3);
 s[i].av=(s[i].m1+s[i].m2+s[i].m3)/3.;}
printf("\n\t\tThe student marks memo is:\n");
printf("\nNAME\tM1\tM2\tM3\n");
for(i=0;i<4;i++)
printf("name:%s\tm1=%d\tm2=%d\tm3=%d\taverage=%f\n",s[i].name,s[i].m1,s[i].m2,s[i].m3,s[i].av);
getch();
return 0;
}