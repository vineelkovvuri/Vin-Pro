//Program to convert an Infix expression to a Postfix expression
#include<stdio.h>
#include<string.h>
#include<conio.h>
char in[100],stack[100];
int top = -1;
int HighPri(char c)
{
	if(top == -1||stack[top] == '(') return 1;
	if(stack[top] == '+'||stack[top] == '-')return c == '*' || c == '/'||c == '^';
	if(stack[top] == '*'||stack[top] == '/'||stack[top] =='^')return 0;
}
main()
{
	int i=0,n;
	clrscr();
	printf("\nEnter the infix expression : ");
	scanf("%s",in);
	printf("\npostfix expression is : ");
	for(i=0;in[i];i++){
		if(in[i] >='a'&&in[i]<='z')printf("%c",in[i]);
		else {
			if(in[i] == ')')		//)
			{
				while(stack[top]!='(')printf("%c",stack[top--]);
				stack[top--];		//(	
			}
			else					//*/^-+
			{
				if(HighPri(in[i])||in[i]=='(')stack[++top] = in[i];
				else {				//Popping
					do
						printf("%c",stack[top--]);
					while(!HighPri(in[i])&&top>=0);
					stack[++top] = in[i];
				}
			}
		}
	}

	while(top!=-1)
		printf("%c",stack[top--]);
	getch();
}

/*
INPUT:
Enter the infix expression : a+b*c
OUTPUT:	
a b c * + 
*/

