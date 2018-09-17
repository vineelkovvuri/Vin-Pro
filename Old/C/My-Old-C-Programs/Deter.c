#include<stdio.h>
#include<stdlib.h>

main()
{
	int i,j,k,m,n; double a[30][30],r;
	clrscr();
	printf("\nEnter the order(i.e.,m,n):");
	scanf("%d%d",&n,&n);
	printf("\nEnter the elements:");
//	randomize();
	for(i=0;i<n;i++)
		for(j=0;j<n;j++)
		       //	 a[i][j]=random(n*n+1);
			   scanf("%lf",&a[i][j]);
	for(m=0;m<n-1;m++)
	{
		for(k=m;k<n-1;k++)
		{
			r=a[m][k+1]/a[m][m];
			for(i=m;i<n;i++)
				a[i][k+1]-=r*a[i][m];
		}
		a[0][0]*=a[m+1][m+1];
	}
	printf("\n%lf",a[0][0]);
//	scanf("%d",&m);
	getch();
}
