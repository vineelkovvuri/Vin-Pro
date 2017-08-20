#include<stdio.h>
main()
{
int i;
struct date{int mm;int dd;int yy;};
struct emp{char name[10];int num;float b;struct date d;}x[2];
printf("\nEnter the employee details(name,num,date(mm,dd,yy),B.S):");
for(i=0;i<2;i++)
scanf("%s%d%d%d%d%f",x[i].name,&x[i].num,&x[i].d.mm,&x[i].d.dd,&x[i].d.yy,&x[i].b);
for(i=0;i<2;i++)
{if(x[i].b<=8000)printf("%s\n%d\n%d\n%d\n%d\nnet salary %f",x[i].name,x[i].num,x[i].d.mm,x[i].d.dd,x[i].d.yy,21.*x[i].b/100.);
else if(x[i].b>8000&&x[i].b<=10000)printf("%s\n%d\n%d\n%d\n%d\nnet salary %f",x[i].name,x[i].num,x[i].d.mm,x[i].d.dd,x[i].d.yy,30.5*x[i].b/100.);
else printf("%s\n%d\n%d\n%d\n%d\nnet salary %f",x[i].name,x[i].num,x[i].d.mm,x[i].d.dd,x[i].d.yy,40.75*x[i].b/100.);
}
return 0;
}
