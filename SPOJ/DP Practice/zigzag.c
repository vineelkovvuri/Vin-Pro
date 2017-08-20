#include<stdio.h>

void print(int *a, int n)
{
	int i = 0;
	for(i = 0;i < n; i++)
		printf("%3d", a[i]);
	printf("\n");
}



int main()
{
//	int a[] = { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 };
	int a[] = 
		{ 374, 40, 854, 203, 203, 156, 362, 279, 812, 955, 
		600, 947, 978, 46, 100, 953, 670, 862, 568, 188, 
		67, 669, 810, 704, 52, 861, 49, 640, 370, 908, 
		477, 245, 413, 109, 659, 401, 483, 308, 609, 120, 
		249, 22, 176, 279, 23, 22, 617, 462, 459, 244 };
	int n = sizeof(a)/sizeof(a[0]);
	int s[100] = {0};
	int d[100] = {0};

	int i, j;
	s[0] = 1;
	d[0] = a[1] - a[0] > 0 ? -1 : 1;
	for (i = 1; i < n; i++) {
		for (j = i - 1; j >= 0; j--) {
			if ((a[i] - a[j]) * d[j] < 0) {
				if (s[i] < s[j]) {
					s[i] = s[j];
					d[i] = (a[i] - a[j] < 0) ? -1 : 1;
				}	
			}
		}	
		s[i] = s[i] + 1;
	}

	print(s, n);
	print(d, n);
	printf("zigzag = %d\n", s[n - 1]);
	return 0;
}


