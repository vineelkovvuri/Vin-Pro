#include<stdio.h>





int main()
{
	int a[] = {5, 2, 3, 1, 4};
	int min = 0,max = 0;
	int sum=0;
	int i;
	for(i = 0;i < sizeof(a)/sizeof(int);i++){
		if(a[min] > a[i]) min = i;
		if(a[max] < a[i]) max = i;
		sum += a[i];
	}
	
	if(sum == a[max]*(a[max]+1)/2 - a[min]*(a[min]-1)/2) printf("true");
	else printf("false");
	
}
	