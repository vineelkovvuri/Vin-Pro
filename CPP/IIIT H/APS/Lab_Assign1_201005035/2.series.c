#include<stdio.h>
#include<string.h>

int main()
{
	char a[100]={1,2,0},b[100]={0};
	int i=0,n,j,k=0;
	printf("Enter the number of terms requried:");
	scanf("%d",&n);
	printf("Intermediate terms:");
	for(i=1;i<n;i++){
		k=0;
		b[k++]=a[0];
		b[k]='1';
		j=0;
		while(a[j+1]!='\0')	{
			if(a[j]==a[j+1])b[k]=b[k]+1;
			else{
				k++;
				b[k++]=a[j+1];
				b[k]='1';
			}
			j++;
		}
		b[k+1]='\0';
		printf("%s\n",b);
		strcpy(a,b);
	}
	printf("Final term:%s",a);
}
