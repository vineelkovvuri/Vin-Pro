//spoj id: 394

/*
	start with the starting of the string.
	if s[0] and s[1] forms an alphabet (i.e., <= 26) then
		number of decodings in the string pointed by n : f(n) = 
					number of decondings in the string pointed by f(n+1) + 
					number of decodings in the string pointed by f(n+2)  
	else 
		number of decodings in the string pointed by n : f(n) = 
					number of decondings in the string pointed by f(n+1)				
	
	if no string is present at n the it means we have a decoding so return 1

*/

#include<stdio.h>
#include<string.h>
#include<stdlib.h>

unsigned long long *ff;
char *p;
unsigned long long f(char *n)
{
	int idx = (n - p) / sizeof(char); 
	if (ff[idx] != -1) return ff[idx];
	if (!*n) return ff[idx] = 1;
	if (*n == '0') return ff[idx] = 0; /* if a number starts with zero then its invalid return 0 */
	if (*(n+1)){
		int x = 10*(*n - '0') + (*(n+1) - '0'); /* before going for f(n+2) make *n and *(n+1) is well within the range: this eleminates cases like 301 */ 
		if (x <= 26 && x >= 1) { /* 20 has only one decoding 0 is not considered */
			ff[idx] = f(n+1) + f(n+2);
			return ff[idx];
		}
	}
	ff[idx] = f(n+1);
	return ff[idx];
}

int main()
{
	char *n;
	int i,t;
	ff = malloc(sizeof(unsigned long long) * 5010);
	n = malloc(sizeof(char) * 5010);
	while (1) {
		scanf("%s", n);
		if (n[0] == '0') break;
		for (i = 0; i < 5010; i++)
			ff[i] = -1;
		p = n;
		printf("%llu\n", f(n));
	}
	free(n);
	free(ff);
	return 0;
}

