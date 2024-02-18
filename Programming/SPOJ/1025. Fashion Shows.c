//spoj id:1025
#include<stdio.h>
#include<stdlib.h>

int compare(const void *p1, const void *p2)
{
	return *(int *)p1 - * (int *)p2;
}
int *men, *women;
void f()
{
	int n;
	int i, j, s = 0;
	scanf("%d", &n);
	
	for (i = 0; i < n; i++)
		scanf("%d", &men[i]);
		
	for (i = 0; i < n; i++)
		scanf("%d", &women[i]);
	
	qsort(men, n, sizeof(int), compare);	
	qsort(women, n, sizeof(int), compare);				
	
	for (i = 0; i < n; i++)
		s += men[i] * women[i];
	
	printf("%d\n", s);
	
}

int main()
{
	int t;
	int i;
	men = malloc(1010 * sizeof(int));
	women = malloc(1010 * sizeof(int));
	scanf("%d", &t);
	for (i = 0; i < t; i++)
		f();
		
	free(men);
	free(women);	
	return 0;
}
