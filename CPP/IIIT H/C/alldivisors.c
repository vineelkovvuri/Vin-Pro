#include<stdio.h>

int main()
{
	int n = 7*3*5*13*2*2*2;

	while(n != 0){
		if(n%2 == 0){
			printf("2 ");
			n /= 2;
		}
		else{
			int i = 3;
			int squrt = (int)sqrt(n);
			for(i = 3; i <= squrt; i += 2){
				if(n%i == 0){
					printf("%d ",i);
					n /= i;
					break;
				}
			}
			if(i > squrt){
				printf("%d ",n);
				break;
			}
		}
	}
}




