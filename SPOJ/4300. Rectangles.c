//spoj id: 4300
#include<stdio.h>
#include<math.h>


int f(int n)
{
	int count = 0, i, k;
	if (n == 1) return 1;
	k = (int)sqrt(n);
	for (i = 1; i <= k; i++)
		if (n % i == 0) count++;
	return f(n - 1) + count;
}

int main()
{
	int n;
	//while(1) {
	scanf("%d", &n); 
	printf("%d\n", f(n));
//}
	return 0;
}
