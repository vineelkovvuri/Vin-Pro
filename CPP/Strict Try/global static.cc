#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;



void add(double& x)
{
	cout<< x;
}

int isNumeric (const char * s)
{
	
    if (s == NULL) return 0;
	 for(;*s ;s++ )
		if(*s < '0' || *s > '9')return 0;
	return 1;
}
int main()
{
	char input[20]={0};
	
	printf("%d",isNumeric("1231aasa231"));
	
}
