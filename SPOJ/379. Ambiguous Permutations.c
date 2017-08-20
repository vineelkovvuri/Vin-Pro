//spoj id: 379

#include<stdio.h>
#include<stdlib.h>
#include<string.h> //needed if malloc is used or else u will get a compilation error

int main()
{
	int n, ambigous = 1;
	int *a, i;
	
	a = malloc(sizeof(int) * 100010);
	while (1) {
		scanf("%d", &n);
		if (n == 0) break;
		for (i = 0; i < n; i++) {
			scanf("%d", &a[i]);
			a[i]--;
		}
		ambigous = 1;	
		for (i = 0; i < n; i++)
			if (a[a[i]] != i) {
				ambigous = 0;	
				break;
			}
		if (ambigous) 
			printf("ambiguous\n");
		else
			printf("not ambiguous\n");		
	}
	free(a);
	return 0;
}

