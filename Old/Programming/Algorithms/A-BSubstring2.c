
#include<stdio.h>
#include<string.h>

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
	for(i = 0;str[i];i++){
		if(str[i] == 'A'){
			for(j=i+1;str[j];j++)
				if(str[j] == 'B')print(i,j);
		}
	}

	for(i = 0;i < k;i++)
		printf("%3d",A[i]);
	printf("\n");
	for(i = 0;i < l;i++)
		printf("%3d",B[i]);

}
