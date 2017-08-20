#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>


/* 
To find the number of zeros at the end of a given factorial 
it is sufficient if we can find the total number of factors of 5 
example: number of zeros in 125! can be found in 
				1*2*3*4*5.................*125
	 =>			5*10*15*20*25*...*50*.......*75*........*125  ignoring non multiples of 5
	 			1  1  1  1  1 .... 1 ......  1 ...........1   exact multiples of 5^1  number of such multiples account for 125/5^1 
				            1......1.........1............1   exact mulitples of 5^2  number of such multiples account for 125/5^2
							                              1   exact multiples of 5^3  number of such multiples account for 125/5^3
*/

int main()
{
	int t;
	unsigned long n;
	int i;
	
	scanf("%d", &t);
	for (i = 0; i < t; i++) {
		scanf("%lu", &n);
		
		if (n < 5)
			printf("0\n");
		else {	
			unsigned long temp = 0;	
			unsigned long fives = 0;
			for (temp = 5; temp <= n; temp *= 5)
				fives += n / temp;
			printf("%lu\n", fives);
		}
	}
	
	return 0;
}


