#include<stdio.h>

#define STACK_SIZE 10
struct Stack{
	int top;
	int items[STACK_SIZE];
};


int empty(struct Stack *stack)
{
	if (stack->top == -1) return 1;
	else return 0;
}
int full(struct Stack *stack)
{
	if(stack->top == STACK_SIZE) return 1;
	else return 0;
}

void push(struct Stack *stack , int ele)
{
	if(!full(stack))
	{
		stack->items[++stack->top] = ele;
		printf("\nPushed %d:",ele);
	}
}
int pop(struct Stack *stack)
{
	int popele = 0xfffffff;
	if(!empty(stack))
	{
		popele = stack->items[stack->top];
		stack->top--;
	}
	return popele;
}

int main()
{
	struct Stack stack = {0,0};
	push(&stack,1);
	push(&stack,2);
	push(&stack,3);
	push(&stack,4);
	push(&stack,5);
	push(&stack,6);
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
	printf("\nPopped %d:",pop(&stack));
}






