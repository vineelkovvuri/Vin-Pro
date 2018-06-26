#include<stdio.h>


int i;

char a[] = "((5*9)+8)*((4*6)+7)";

int eval()
{
	int x = 0;
	if(a[i] == '*'){ return eval()*eval();}
	if(a[i] == '+'){ return eval()+eval();}
	if(a[i] == '('){i+=1; return eval();}	
	if(a[i] == ')'){i+=1;}	
	if(a[i] >= '0' && a[i] <= '9')
		x = 10*x + (a[i++] - '0');
	return x;
}


int main()
{
}
