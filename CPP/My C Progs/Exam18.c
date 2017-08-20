#include<stdio.h>
main()
{
struct date{int mm;int dd;int yy;};
struct emp{char name[10];int salary;struct date birth;};
struct emp n1;
printf("\nEnter the details of the employee(name, salary,date mm dd yy)");
scanf("%s%d%d%d%d",n1.name,&n1.salary,&n1.birth.mm,&n1.birth.dd,&n1.birth.yy);
printf("\nThe employee details are:\n");
printf("name=%s\nsalary=%d\nmonth=%d\ndate=%d\nyear=%d\n",n1.name,n1.salary,n1.birth.mm,n1.birth.dd,n1.birth.yy);
getch();
return 0;
}