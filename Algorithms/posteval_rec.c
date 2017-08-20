#include<stdio.h>
#include<string.h>

//char a[100]="* + 7 * * 4 6 + 8 9 5";
char a[100]="5 9 8 + 4 6 * * 7 + *";
int i;
int eval()
{
	int x = 0;
	while(a[i] == ' ')i--;
	if(a[i] == '+'){
		i--;
		return	eval()+eval();
	}
	if(a[i] == '*'){
		i--;
		return	eval()*eval();
	}
/*	while(i >= 0 && a[i] >= '0' && a[i] <= '9'){
		x = x*10 + (a[i--] - '0');
	}*/
	if(i >= 0 && a[i] >= '0' && a[i] <= '9')
		return a[i--] - '0';
}

int main()
{
	i = strlen(a) - 1;
	printf("%d",eval());
}

