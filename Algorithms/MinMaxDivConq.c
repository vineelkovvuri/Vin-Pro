//Divide and Conquer to find the min and max of an array

#include<stdio.h>

int num[] = {10,4,7,9,1,20,3,5,6,10};
void DivideAndReduce(int start, int end, int* min, int* max)
{
	if(end - start > 1){
		int min1, max1, min2, max2;
		DivideAndReduce(start, (start + end)/2, &min1, &max1);
		DivideAndReduce((start + end)/2 + 1, end, &min2, &max2);
		*min = min1 < min2 ? min1 : min2;
		*max = max1 > max2 ? max1 : max2;
	}
	else{
		*min = num[start] < num[end] ? num[start] : num[end] ;
		*max = num[start] > num[end] ? num[start] : num[end] ;
	}
}

int main()
{
	int min = 0,max = 0;
	DivideAndReduce(0,sizeof(num)/sizeof(int)-1,&min,&max);
	printf("%d %d",min,max);
	return 0;
}

