#include<stdio.h>
int a [] = {1,3,4};

void swap(int * a,int *b)
{
	int temp = *a;
	*a = *b;
	*b = temp;
}


void perm(int *a, int k,int n)
{
	int i = 0;
	if(k == n){
		for(i=0;i<n;i++)
			printf("%d",a[i]);
		printf("\n");	
	}
	else{
		for(i=k;i<n;i++){
			swap(&a[k],&a[i]);
			perm(a,k+1,n);
			swap(&a[k],&a[i]);
		}
	}	
}


main()
{
	perm(a,0,3);

}
