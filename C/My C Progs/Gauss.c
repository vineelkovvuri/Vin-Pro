#include<stdio.h>
main()
{
int i,j,k,n,x=-1;float a[30][30],r;
printf("\nEnter the order of the matrix(i.e., m,n):");
scanf("%d%d",&n,&n);
printf("\nEnter the coefficients(assuming equation is of the form ax+by=c):");
for(i=0;i<n;i++)
 for(j=0;j<n+1;j++)
  scanf("%f",&a[i][j]);
for(k=0;k<n;k++)
{++x;
 for(i=0;i<n;i++)
 {if(i!=x){r=a[i][x]/a[x][x];
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
 printf("\nx%d=%.38f",i+1,a[i][n]);
getch();
return 0;
}
