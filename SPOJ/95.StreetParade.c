#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int *s;
int top = -1;

void push (int ele)
{
	s[++top] = ele;
}
int pop()
{
	return s[top--];
}
int peek()
{
	if (top >= 0)
		return s[top];
	else
		return -1;
}


int main()
{
	int n;
	s = malloc(sizeof(int) * 1010);
	while (1) {
		int count = 1;
		int i = 0, k = 0;
		scanf("%d", &n);
		if (n == 0) break;
		top = -1;
		
		for (i = 0; i < n; i++) {
			scanf("%d", &k);
			//printf("peek = %d k = %d count = %d\n", peek(), k, count);
			if (k == count) count++;
			else if (peek() == count) {
				do {
					pop();
					count++;
				} while (peek() == count);
				push(k);
			} else {
				push(k);
			}
			
		}
		if (peek() == -1 && count == n + 1) {
			printf("yes\n");
			break;
		}
		while (peek() != -1) {
			//printf("peek = %d k = %d count = %d\n", peek(), k, count);
			if (count == peek()) {
				if (count == n) {
					printf("yes\n");
					break;
				}
				pop();
				count++;
			} else {
				printf("no\n");
				break;
			}
		}
	}
	free(s);
	return 0;
}

