#include<stdio.h>
#include<stddef.h>
#include<limits.h>
#include<stdlib.h>

char a[] = "abcde";
char arr[10]={0};
int n = 5;

void combinations(int start, int r , int k)
{
	if(start <= n){
		if(k == r){
			printf("\n%s",arr);
		}
		else{
			int i = 0;
			for(i = start; i < start+r; i++){
				arr[k] = a[i];
				combinations(i+1,r,k+1);
			}
		}	
	}
}	

int  main() {
  combinations(0,3,0);
}
