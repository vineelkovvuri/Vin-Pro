/*program to generate pascal triangle */
#include<stdio.h>
int main()
{
	int i,j,k,n,t=1;
	//printf("\nEnter n:");
	scanf("%d",&n);
	for(i=0;i<=n;i++)
	{
		t=1;
		for(j=n-i;j>=0;j--)
			printf("  ");
		for(k=0;k<=i;k++){
			if(k==0)printf("%4d",t);
			else {
				t=t*(i-k+1)/k;
				printf("%4d",t);
			}
		}
		printf("\n");
	}
}
