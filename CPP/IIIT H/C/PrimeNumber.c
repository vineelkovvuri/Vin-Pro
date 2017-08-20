#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#include<limits.h>



int main()
{
    long int n,
	 count = 0;
//	printf("%d",LONG_MAX);

	
	for(n=LONG_MAX;n>2;n--)
	{
		
		int notprime = 0;
	    long int i = 0;
		long int ulimit = n/2;
//		printf("%ld",n/2);

		
	    for(i=2;i<=ulimit;i++)
    	{
			if(n%i == 0){
				notprime = 1;
			   	break;
			}
		}		
	    if(notprime == 0){
			count++;   
			printf("%d\t",n);
		}
		
	}

	printf("\nNumber of primes = %d",count);

    
}
