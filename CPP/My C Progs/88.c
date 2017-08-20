/*program to convert given number into words*/
#include<stdio.h>
main()
{
char x[][10]={"zero","one","two","three","four","five","six","seven","eight","nine","ten",
"eleven","tweleve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};
char z[][10]={"twenty","thirty","fourty","fifty","sixty","seventy","eighty","ninety"};
unsigned long int n;int a[10],i,k,j,l=0;
printf("\nEnter n:");
scanf("%lu",&n);   if(n==0)printf("Zero ");
a[0]=n%1000;n=n/1000;k=1;
for(i=1;n!=0;i++)
{a[i]=n%100;n=n/100;}
k=i;
for(j=k-1;j>0;j--)
{ l=0;
for(i=10;i<20;i++)
   if(a[j]==i){printf("%s ",x[i]);++l;}
if(l==0){ for(i=1;i<10;i++)
	    if(a[j]/10==i)printf("%s ",z[i-2]);
	  for(i=1;i<10;i++)
	    if(a[j]%10==i)printf("%s ",x[i]);
	}
	   if(j==1&&a[j]!=0)printf("thousand ");
	   else if(j==2&&a[j]!=0)printf("lakhs ");
	   else if(j==3&&a[j]!=0)printf("crores ");
}
for(i=1;i<10;i++)
  if(a[0]/100==i){printf("%s hundred and ",x[i]);a[0]%=100;}
  l=0;
for(i=10;i<20;i++)
  if(a[0]==i){printf("%s",x[i]);++l;}
  if(l==0){
	    for(i=1;i<10;i++)
	    if(a[0]/10==i)printf("%s ",z[i-2]);
	    for(i=1;i<10;i++)
	    if(a[0]%10==i)printf("%s",x[i]);
	  }
getch();
}