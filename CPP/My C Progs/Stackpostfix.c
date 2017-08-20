#include<stdio.h>
main()
{
char x[10];
printf("\nEnter the postfix string:");
scanf("%s",x);
printf("%lf",send(x));
}
send(char y[])
{int i,k;double x[10];
 for(i=0;y[i];i++)
  if(y[i]>='0'&&y[i]<='9'){x[k++]=y[i]-'0';}
  else switch (y[i])
          {
           case '+':x[i]=x[i-1]+x[i-2];
           case '-':x[i]=x[i-2]-x[i-2];
           case '*':x[i]=x[i-1]*x[i-2];
           case '/':x[i]=x[i-2]/x[i-1];
          }
return x[i-1];
}
