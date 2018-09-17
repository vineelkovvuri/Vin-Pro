

#include<stdio.h>


char stack[20];
int main()
{
	char *expr = "((5*9)+8)*((4*6)+7)";
	int i,top = 0;
	for(i=0;expr[i];i++){
		if(expr[i] >='0' && expr[i] <= '9') printf("%c ",expr[i]);
		else if(expr[i] == '*' || expr[i] == '+')stack[top++] = expr[i];
		else if(expr[i] == ')')	printf("%c ",stack[--top]);
	}
}
