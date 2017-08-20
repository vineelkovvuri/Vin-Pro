#include<stdio.h>
#include<math.h>
main()
{
int i,j,k,n,x=-1,y=-1;float a[100][100],r;
printf("\nEnter the order of the matrix:");
scanf("%d%d",&n,&n);
printf("\nEnter the elements:");
for(i=0;i<n;i++)
 for(j=0;j<n+1;j++)
   a[i][j]=rand(n*(n+1)+1);                    // scanf("%f",&a[i][j]);
for(k=0;k<n;k++)
{++x;++y;
 for(i=0;i<n;i++)
 {j=x;
  if(i!=x){r=a[i][j]/a[x][y];
	   for(j=0;j<n+1;j++)
	   a[i][j]-=r*a[x][j];
	  }
 }
}
for(i=0;i<n;i++)
{if(a[i][i]==0&&a[i][n]==0){printf("\nINFINITE ROOTS");getch();exit(0);}
 if(a[i][j]==0&&a[i][n]!=0){printf("\nNO SOLUTION");getch();exit(0);}
 else a[i][n]/=a[i][i];}
for(i=0;i<n;i++)
 printf("\nx%d=%.18f",i+1,a[i][n]);
getch();
return 0;
}