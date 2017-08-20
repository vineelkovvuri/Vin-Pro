#include<stdio.h>
main()
{
int k,i,m;
struct std{char x[10];int m1;int m2;int m3;}s[3];
printf("\nEnter the student name and marks:");
for(i=0;i<3;i++)
scanf("%s%d%d%d",s[i].x,&s[i].m1,&s[i].m2,&s[i].m3);
k=s[0].m1;
 for(i=0;i<2;i++)
 if(k<s[i+1].m1){k=s[i+1].m1;m=i+1;}
 printf("\n%s%d",s[m].x,s[m].m1);
k=s[0].m2;
 for(i=0;i<2;i++)
 if(k<s[i+1].m2){k=s[i+1].m2;m=i+1;}
 printf("\n%s%d",s[m].x,s[m].m2);
 k=s[0].m3;
 for(i=0;i<2;i++)
 if(k<s[i+1].m3){k=s[i+1].m3;m=i+1;}
 printf("\n%s%d\n",s[m].x,s[m].m3);
getch();
return 0;
}