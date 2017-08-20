#include<stdio.h>
#include<stdlib.h>
#include<math.h>

int main()
{
	int n;
	int i, j;
	char exp[410], stack[400];

	scanf("%d", &n);

	for (i = 0; i < n; i++) {
		int top = -1;
		scanf("%s", exp);
		for (j = 0; exp[j]; j++) {
			if (isalpha(exp[j])) printf("%c", exp[j]);
			else if (exp[j] == '(') stack[++top] = exp[j];
			else if (exp[j] == '+' || exp[j] == '-' || exp[j] == '*' || exp[j] == '/' || exp[j] == '^' || exp[j] == ')') {
				if (top == -1) stack[++top] = exp[j]; //push first symbol : Assuming expressions wont begin with ')'
				else { //stack has some symbols
					if (exp[j] == ')') {
						while (top != -1) {
							if (stack[top] == '(') {
								top--;
								break;
							}
							else 
								printf("%c", stack[top--]);
						}
					}
					else {
						if (stack[top] == '(') stack[++top] = exp[j];
						else if(stack[top] == '+' && (exp[j] == '-' || exp[j] == '*' || exp[j] == '/' || exp[j] == '^'))
							stack[++top] = exp[j];
						else if(stack[top] == '-' && (exp[j] == '*' || exp[j] == '/' || exp[j] == '^'))
							stack[++top] = exp[j];
						else if(stack[top] == '*' && (exp[j] == '/' || exp[j] == '^'))
							stack[++top] = exp[j];
						else if(stack[top] == '/' && (exp[j] == '^'))
							stack[++top] = exp[j];
						else { //stack top could also be '^' or any thing that need to be popped
							while (top != -1) {
								if (stack[top] == '(') {
									top--;
									break;
								}
								else 
									printf("%c", stack[top--]);
							}
						}
					}
				}
			}
		}
		printf("\n");
	}
	return 0;
}
