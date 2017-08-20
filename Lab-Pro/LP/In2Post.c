

#include<stdio.h>

#define true 1
#define false 0

char x[100];
char stack[100];
int index = -1;


int HighPri(char c)
{
	if(stack[index] == '(') return true;
	if(stack[index] == '+'||stack[index] == '-')return c == '*' || c == '/'||c == '^';
	if(stack[index] == '*'||stack[index] == '/'||stack[index] =='^')return false;
}

main()
{
	int i=0,n;

	printf("\nEnter the infix expression : ");
	scanf("%s",x);
	n = strlen(x);

	do{
		if(x[i] >='a'&&x[i]<='z')printf("%c ",x[i]);
		else {
			if(x[i] == ')'){
				while(stack[index]!='(')printf("%c ",stack[index--]);
				stack[index--];			//
			}
			else if(x[i] == '('||HighPri(x[i]))stack[++index] = x[i];
			else {
				printf("%c ",stack[index--]);	//POP
				stack[++index] = x[i];
			}
		}
	}while(x[i++]);

	while(index!=-1)
		if(stack[index]!= '(')printf("%c ",stack[index--]);
}

