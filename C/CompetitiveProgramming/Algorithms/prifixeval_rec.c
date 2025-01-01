#include<stdio.h>


char a[100]="* + 7 * * 4 6 + 8 9 5";
int i;
int eval()
{
	int x = 0;
	while(a[i] == ' ')i++;
	if(a[i] == '+'){
		i++;
		return	eval()+eval();
	}
	if(a[i] == '*'){
		i++;
		return	eval()*eval();
	}
	while(a[i] >= '0' && a[i] <= '9'){
		x = x*10 + (a[i++] - '0');
	}
	return x;
}

int main()
{
	printf("%d",eval());
}
