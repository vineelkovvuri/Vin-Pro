#include<stdio.h>
#include<stdlib.h>

int comparer(const void * p1, const void * p2)
{
	return *(int*)p1 - *(int*)p2;
}
int main()
{
	int i = 0,size=0;
	int data[100];
	double	mean = 0,median,max,min;
	
	printf("\nEnter the size of array:");
	scanf("%d",&size);
	printf("\nEnter the numbers:");
	for(i=0;i<size;i++){
		scanf("%d",&data[i]);
		mean += data[i];
	}
	mean /= size;
	qsort(data,size,sizeof(int),comparer);
	min = data[0];
	max = data[size - 1];
	median = data[size/2];
	printf("Min = %d , Max = %d , Mean = %lf , Median = %lf",min,max,mean,median);
}



