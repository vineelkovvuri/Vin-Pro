

#include<stdio.h>
#include<string.h>
#include<stdlib.h>

void Merge(int a[],int na, int b[], int nb,int *c)
{
	int i=0,j=0,k=0;
	while(i < na && j < nb){
		if(a[i] < b[j]) c[k++] = a[i++];
		else c[k++] = b[j++];
	}

	if(i == na){
		memcpy(&c[k],&b[j],(nb - j)*sizeof(int));
		k += nb - j ;
	}
	else if(j == nb){
		memcpy(&c[k],&a[i],(na - i)*sizeof(int));
		k += na - i ;
	}
	//*nc = k;
}

void MergeSort(int *c,int nc)
{
	if(nc > 1){
		int *a = malloc((nc/2)*sizeof(int));
		int *b = malloc((nc - nc/2)*sizeof(int));
		memcpy(a,&c[0],(nc/2)*sizeof(int));
		memcpy(b,&c[nc/2],(nc - nc/2)*sizeof(int));	
		MergeSort(a,nc/2);
		MergeSort(b,nc - nc/2);
		Merge(a,nc/2,b,nc-nc/2,c);
		free(a);
		free(b);
	}
}

int main()
{
	int a[]={1,4,7,9,2,3,5,6},i;
	MergeSort(a,8);
	for(i=0;i<8;i++)
		printf("%d ",a[i]);
}
