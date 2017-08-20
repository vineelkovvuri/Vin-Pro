#include<stdio.h>
main()
{
int i,f=0,g=0,h=0;
char x[][10]={"vineel","january","february","march","april","may","june","july","august","september","october","november","december"};
struct date {int mm;int dd;}d[2];
printf("\nEnter the 1st date(mm dd format)");
scanf("%d%d",&d[0].mm,&d[0].dd);
printf("\nEnter the 2nd date(mm dd format)");
scanf("%d%d",&d[1].mm,&d[1].dd);
for(i=1;i<13&&h==0;i++)
{if(d[0].mm==i&&f==0){printf("\n%s",x[i]);f=1;}
 if(d[1].mm==i&&g==0){printf("\n%s",x[i]);g=1;}
 if(f==1&&g==1)h=1;
}
getch();
return 0;
}