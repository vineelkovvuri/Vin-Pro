/*program to generate design triangle */
#include<stdio.h>
int main()
{
	int i,j,count=1,n;
	printf("\nEnter n:");
	scanf("%d",&n);
	for(i=1;i<=n;i++){
		for(j=1;j<=i;j++)
			printf("%d\t",count++);
		printf("\n");	
	}
}
