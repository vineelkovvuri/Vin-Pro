//spoj id: 3375


#include<stdio.h>
#include<stdlib.h>
#include<string.h>


int compare(const void *p1, const void *p2)
{
	return *(int *)p2 - *(int *)p1;
}

int main()
{
	int *a;
	int t,f,n,i,x,j;
	scanf("%d", &t);
	a = malloc(sizeof(int) * 1010);
	for (j = 0; j < t; j++) {
		scanf("%d%d",&f,&n);
		for (i = 0; i < n; i++) 
			scanf("%d", &a[i]);
		qsort(a, n, sizeof(int), compare);
		x = 0;
		for (i = 0; i < n; i++) {
			x += a[i];
			if (x >= f) break;
		}
		printf("Scenario #%d:\n", j+1);
		if (i >= n)
			printf("impossible\n");
		else
			printf("%d\n", i+1);
		if (j != t-1)
			printf("\n");
	}
	free(a);
	return 0;
}

