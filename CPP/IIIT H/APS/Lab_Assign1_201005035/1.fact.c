#include<stdio.h>

int main()
{
	int no,res;
	int i,cnt=0,j;	

	printf("\nEnter the number whose factorial should be considered:"); 
	scanf("%d",&no)	;
	i=2;
	while(i<=a){
		if((i%5)==0){
			j=i;			
			while((j%5)==0){
				cnt++;
				j=j/5;			
			}
		}	
		i++;
	}	

	printf("The number of zeros in the given factorial are: %d",res);

}
