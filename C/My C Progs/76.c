/* program to generate the procedure to transfer given number of rings in to other pole */
#include<stdio.h>
#include<math.h>
#include<conio.h>
char abc(char[],int[],int,int);
main()
{
int i,j,n,x,s[50];char y[4]={'a','b','c','\0'};
clrscr();
printf("ENTER THE NUMBER OF RINGS:");
scanf("%d",&n);
for(i=0;i<n;i++)
s[i]=i+1;
  for(i=1;i<pow(2,n);i++)
 { x=i;
   for(j=0;j<n&&x==i;j++)
   if(i%(2*(int)pow(2,j))==pow(2,j)){printf("%d%c ",j+1,abc(y,s,j,n));x=0;}
 }
getch();
}
char abc(char y[],int s[],int j,int n)
{
int i,k=0,l=0;
if(n%2==0){ for(i=1;i<=n&&k==0;i+=2)
	      if(j+1==i){if(s[i-1]%3==1){s[i-1]++;return y[1];}
			 else if(s[i-1]%3==2){s[i-1]++;return y[2];}
			 else if(s[i-1]%3==0){s[i-1]++;return y[0];}
			 k++;
			 }
	     for(i=2;i<=n&&l==0;i+=2)
	       if(j+1==i){if(s[i-1]%3==2){s[i-1]++;return y[2];}
		       else if(s[i-1]%3==0){s[i-1]++;return y[1];}
		       else if(s[i-1]%3==1){s[i-1]++;return y[0];}
		       l++;
		       }
	   }
}