#include<stdio.h>
#include<ctype.h>
#include<stdlib.h>
#include<math.h>

int main()
{
	int a[] = { 1,2,5,8,9,13,45,50,69,78,90};
	inter(a,0,10,13);
}



void inter(int a[],int l,int h,int v)
{
	int x;
	x = h + floor((v-a[h])*(l-h)/(a[l]-a[h]));
	//printf("\n%d %d", x,a[x]);
	if(l<=h){
		if( a[x] < v ){
			inter(a,x+1,h,v);
		}
		else if(a[x] > v){
			inter(a,l,x-1,v);
		}
		else{
			printf("%d", x);
		}
	}	
}
	
	