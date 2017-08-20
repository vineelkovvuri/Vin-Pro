
/*  
	Program to calculate fibonacci series upto 46 terms
	using dynamic programming and 
	without using dynamic programming
*/

#include<stdio.h>
#include<string.h>

/*	using dynamic programming   */
long long fib[100];
long long DynFib(int n)
{
	if(fib[n] != -1) return fib[n];
	if(n == 1 || n == 0){
		fib[n] = n; 
		return n;
	}
	else {
		fib[n] = (long long)((long long)DynFib(n-1) + (long long)DynFib(n-2));
		return fib[n];
	}
}

/*	without using dynamic programming   */
long long NonDynFib(int n)
{
	if(n == 1 || n == 0) return n;
	return NonDynFib(n - 1) + NonDynFib(n - 2);
}

int main()
{

	printf("%lld",  1134903170LL   +   1836311903LL);
/*
	int i = 0;
	memset(fib, -1, 100*sizeof(long long));

	printf("\nDynamic version\n");		
	for(i = 1 ;i < 50; i++)
		printf("%lld\t",DynFib(i)); 
*/
//	printf("\n===================================================\n");	
//	printf("\nNormal version\n");		
//	for(i = 1 ;i <= 46; i++)
	//	printf("%d\t",NonDynFib(i)); 
}
