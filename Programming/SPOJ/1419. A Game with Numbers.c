#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

/*
	first player will only win if the number is not a mulitple of 10
	for example: if its 10 he is forced to subtract some digit(1-9) 
	which will leave the remainder in 2nd player hands and 2nd player 
	can will win
*/

int main()
{
	unsigned long long n;
	scanf("%llu", &n);
	if (n % 10 == 0)
		printf("2\n");
	else
		printf("1\n%llu\n", n % 10);

	return 0;
}

