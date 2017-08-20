
#include<stdio.h>

char str[]="CABAAXBYA";

void print(int start,int end)
{
	int i=0;
	for(i = start;i<=end;i++)
		printf("%c",str[i]);
	printf("\n");
}

int main()
{

	int A[10];
	int B[10];
	int i,j,k=0,l=0;
	for(i = 0;str[i] != 0;i++){
		if(str[i] == 'A')A[k++] = i;
		if(str[i] == 'B')B[l++] = i;
	}
	int flag = 0;
	for(i=0;i<k;i++){
		flag = 0;
		for(j=0;j<l;j++){
			if(A[i] < B[j]){
				print(A[i],B[j]);
				flag = 1;
			}
		}
		if(flag == 0)break;
	}

}
