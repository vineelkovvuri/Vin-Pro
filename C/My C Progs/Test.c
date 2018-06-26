#include<stdio.h>
#include<stdlib.h>
int compare(const void * x, const void * y)
{
	return *(int*)x-*(int*)y;
}
main()
{
	int a[] = {2,4,45,61,12,3,5,7},i;
	qsort(a,sizeof(int),8,compare);
	for(i=0;i<8;i++)
		printf("%d\t",a[i]);
}


