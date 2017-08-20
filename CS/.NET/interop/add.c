#include<stdio.h>

extern "C" __declspec(dllexport)
   int add(int a,int b);
int main()
{
	return 0;
}
   
int add(int a,int b)
{
	return a+b;
}

