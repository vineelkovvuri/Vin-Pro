#include<stdio.h>
main()
{int i,j,n,k,x=-1;float a[10][10],b[10][10],r;
printf("\nEnter the order :");
scanf("%d%d",&n,&n);
printf("\nEnter the elements:");
	for(i=0;i<n;i++)
	for(j=0;j<n;j++)
	{scanf("%f",&a[i][j]);if(j==i)b[i][j]=1;else b[i][j]=0;}
	for(k=0;k<n;k++)
	 {++x;
	  for(i=0;i<n;i++)
	    if(i!=x){r=a[i][x]/a[x][x];
          	     for(j=0;j<n;j++)
	             {a[i][j]-=r*a[x][j];b[i][j]-=r*b[x][j];}
         	    }
         }
for(i=0;i<n;i++)
for(j=0;j<n;j++)
b[i][j]/=a[i][i];
	printf("\nEnter the contant's matrix:");
	for(i=0;i<n;i++)
	scanf("%f",&a[i][0]);
	for(i=0;i<n;i++)
	{r=0;
	  for(j=0;j<n;j++)
	   r+=b[i][j]*a[j][0];
	 printf("\t%f",r);
	 printf("\n");
	}
}






