#include<stdio.h>
char a [] = {'V','I','N','N','I','S'};

void perm( int k,int n)
{
	int i = 0;
	if(k == n){
		for(i=0;i<n;i++)
			printf("%c",a[i]);
		printf("\n");	
	}
	else{
		a[k] = tolower(a[k]);
		perm(k+1,n);
		a[k] = toupper(a[k]);
		perm(k+1,n);
	}	
}


main()
{
	perm(0,6);

}
