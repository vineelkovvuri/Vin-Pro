#include<stdio.h>
#include<stdlib.h>
int a[500],count=0;
int check(int pos)
{
	int i;
	for(i=1;i<pos;i++)
		if((a[i]==a[pos])||((abs(a[i]-a[pos])==abs(i-pos))))
			return 0;
	return 1;
}
void prints(int n)
{
	int i;
	count++;
	for(i=1;i<=n;i++)
		printf("%d ",a[i]);
	printf("\n");
	return;
}
void queen(int n)
{
	int k=1;
	a[k]=0;
	while(k!=0)
	{
		a[k]=a[k]+1;
		while((a[k]<=n) && !check(k))
			a[k]++;
		if(a[k]<=n)
		{
			if(k==n)
			{
				prints(n);
				return ;
			}
			else
			{
				k++;
				a[k]=0;
			}
		}
		else
			k--;
	}
	return ;
}
int main()
{
	int i=-1,n[100],j;
	n[-1]=1;
	while(n[i] != 0)
	{
		i++;
		scanf("%d",&n[i]);
	}
	for(j=0; j<i; j++)
		queen(n[j]);
	return 0;
}

