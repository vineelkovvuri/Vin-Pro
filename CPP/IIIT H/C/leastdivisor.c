#include<stdio.h>

int main()
{
	int n = 54;

	if(n%2 == 0)printf("2 is the smallest divisor");
	else{
		int i=0;
		int squrt = (int)sqrt(n);
		for(i=3;i<=squrt;i+=2){
			if(n%i == 0){
				printf("%d is the smallest divisor",i);
				break;
			}
		}
		if(i > squrt){
			printf("Has no smallest divisor. Hence %d is prime",n);
		}
	}
}


