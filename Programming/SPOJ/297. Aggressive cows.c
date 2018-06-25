#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

int a[] = {1, 2, 8, 4, 9};
int n;

int compare(const void *p1, const void *p2)
{
	return *(int *)p1 - *(int *)p2;
}

int bfind(int s, int e, int key)
{
	int mid;
	if (s >= n || e < 0 || s > e) return -1;
	mid = (s + e) / 2;
	if (a[mid] == key) return mid;
	else if (a[mid] < key) return bfind(mid + 1, e, key);
	else if (a[mid] > key) return bfind(s, mid - 1, key);
}

int bfind_fuzzy(int s, int e, int key)
{
	int mid;
	
	if (s >= n || e < 0 || s > e) return -1;
	mid = (s + e) / 2;
	
	if (a[mid] == key) return mid;
	else if (a[mid] < key && mid + 1 < n && a[mid + 1] > key) {
	//printf("s = %d e = %d mid = %d %d\n",s , e, mid, __LINE__);
		if (key - a[mid] <= a[mid + 1] - key)
			return mid;
		else if (key - a[mid - 1] > a[mid + 1] - key)
			return mid + 1;
	} 
	else if (a[mid] < key) return bfind_fuzzy(mid + 1, e, key);
	else if (a[mid] > key) return bfind_fuzzy(s, mid - 1, key);
}



int main()
{
	int t, i;
	int c = 3;
	n = sizeof(a)/sizeof(a[0]);
	qsort(a, n, sizeof(int), compare);
	
	for (i = 0; i < n; i++) 
		printf("%d ", a[i]);
	printf("\n");
	//for (i = a[1]; i < a[n-1]; i += (a[n-2] + a[1])/(c - 2))
		printf("%d => %d\n", i , bfind_fuzzy(0, n - 1, (a[n-2] + a[1]) / 2));
	return 0;
}

