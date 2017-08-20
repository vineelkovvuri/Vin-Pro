#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>

#define max(a,b) ((a) > (b) ? (a) : (b))
#define min(a,b) ((a) < (b) ? (a) : (b))

int main()
{
	int n;
	int i, j, k, l, m, p, pp;
	char *exp, *expBackup, *res, *mul;
	int len, pos, n1len, n2len;
	int n1, n2, val, carry, borrow, firstNonZero;	
	exp = malloc(sizeof(char) * 1024);
	expBackup = malloc(sizeof(char) * 1024);
	mul = malloc(sizeof(char) * ((500 + 510) * 510)); //holding intermediate multiplication results
	res = malloc(sizeof(char) * 1024);
	scanf("%d", &n);
	for (i = 0; i < n; i++) {
		firstNonZero = borrow = carry = val = j = k = l = m = p = pp = 0;
		scanf("%s", exp);
		len = strlen(exp);
		for (pos = 0; pos < len && isdigit(exp[pos]); pos++);
		n1 = pos - 1;
		n2 = len - 1;
		n1len = pos;
		n2len = len - pos - 1;
				
		switch (exp[pos]) {
			case '+':
				while (n1 >= 0 || n2 > pos) {
					val = (n1 >= 0  ? (exp[n1--] - '0') : 0) + 
						  (n2 > pos ? (exp[n2--] - '0') : 0) + 
						  carry;
					carry = val > 9 ? 1 : 0; 
					res[j++] = (val % 10) + '0';
				}
				if (carry == 1) res[j++] = '1';
				res[j] = 0;
				//print
				
				p = max(j, max(n1len, n2len + 1));
				for (l = 0; l < p - n1len; l++)
					printf(" ");
				printf("%.*s\n", n1len, exp); //minimum width is required or else if exp is small then it wont get aligned to right

				for (l = 0; l < p - (n2len + 1); l++)
					printf(" ");
				printf("%c", exp[pos]);	
				printf("%.*s\n", n2len, exp + pos + 1); //minimum width is required or else if exp is small then it wont get aligned to right
				
				for (l = 0; l < p; l++)
					printf("-");
				printf("\n");
				
				for (l = 0; l < p - j; l++)
					printf(" ");
				for (k = j - 1; k >= 0; k--)
					printf("%c", res[k]);
				break;
			case '-':
				strcpy(expBackup, exp);
				while (n1 >= 0) {
					if (n2 <= pos) { //handles when num2 is exausted
						res[j++] = exp[n1]; //just copy down number 1 digits
					} else if (exp[n1] < exp[n2]) {
						borrow = 0;
						for (k = n1 - 1; k >= 0; k--) {
							if (exp[k] != '0') {
								exp[k]--;
								borrow = 10 + (exp[n1] - '0');
								break;
							} else {
								exp[k] = '9';
							}
						}
						res[j++] = borrow - (exp[n2] - '0') + '0';
					} else if (exp[n1] >= exp[n2]) {
						res[j++] = (exp[n1] - exp[n2]) + '0';
					} 		
					n1--;
					n2--;
				}
				
				res[j] = 0;
				//print
				p = max(j, max(n1len, n2len + 1));
				for (l = 0; l < p - n1len; l++)
					printf(" ");
				printf("%.*s\n", n1len, expBackup); //minimum width is required or else if exp is small then it wont get aligned to right
				
				for (l = 0; l < p - (n2len + 1); l++)
					printf(" ");
				printf("%c", exp[pos]);	
				printf("%.*s\n", n2len, exp + pos + 1); //minimum width is required or else if exp is small then it wont get aligned to right
				
				for (l = 0; l < p - j - 1; l++)
					printf(" ");
				for (; l < p; l++)
					printf("-");
				printf("\n");
				
				for (l = 0; l < p - j; l++)
					printf(" ");
				for (k = j - 1; k >= 0; k--) {
					if (res[k] != '0' && firstNonZero == 0)
						firstNonZero = 1;
					
					if (firstNonZero == 1) 	
						printf("%c", res[k]);
					else if (k == 0 && firstNonZero == 0) // No non zero encountered even at k = 0 implies the result itself is zero  
						printf("0");
					else 
						printf(" ");
				} 
				break;
			case '*': {
				j = 0;
				for (m = n2; m > pos; m--) {
					carry = 0;
					for (l = 0; l < n2 - m; l++)
						mul[j++] = 'X';
					for (k = n1; k >= 0; k--) {
						val = (exp[m] - '0') * (exp[k] - '0') + carry;
						carry = val / 10;
						mul[j++] = (val % 10) + '0';
						l++;
					}
					if (carry != 0) {
						mul[j++] = carry + '0';
						l++;
					}
					for (; l < n1len + n2len; l++) // max of n1 digits + n2 digits which will be total expression - the operator
						mul[j++] = 'X';

				}
				mul[j] = 0;
				m = 0;
				carry = 0;
				for (k = 0; k < n1len + n2len; k++) {  //columns = num of digits in n1 + n2
					val = carry;
					for (l = 0; l < n2len; l++) //rows = num of digits in second number	
						val += (mul[k + l * (n1len + n2len)] != 'X' ? mul[k + l * (n1len + n2len)] - '0' : 0);
					carry = val / 10;
					
					if (k + 1 == n1len + n2len && val == 0);
					else
						res[m++] = (val % 10) + '0';
				}
				while (carry != 0) {
					res[m++] = (carry % 10) + '0';
					carry /= 10;
				}
				res[m] = 0;
				
				p = max(m, max(n1len, n2len + 1));
				for (l = 0; l < p - n1len; l++)
					printf(" ");
				printf("%.*s\n", n1len, exp); //minimum width is required or else if exp is small then it wont get aligned to right

				for (l = 0; l < p - (n2len + 1); l++)
					printf(" ");
				printf("%c", exp[pos]);	
				printf("%s\n", exp + pos + 1); //minimum width is required or else if exp is small then it wont get aligned to right
				if (n2len != 1) {

					for (l = 0; l < p - max(n1len, n2len + 1); l++)
						printf(" ");
					for (; l < p; l++)
						printf("-");
					printf("\n");

					for (pp = 0, k = n1len + n2len - 1; k < (n1len + n2len) * n2len; pp = k + 1, k += n1len + n2len) {  //columns = num of digits in n1 + n2
						int AllAreZeros = 1;
						for (l = k - (n1len + n2len - m); l >= pp; l--)
								if (mul[l] != 'X' && mul[l] != '0') {
									AllAreZeros = 0;						
									break;
								}
						if (AllAreZeros == 1) {
							for (l = pp ; l <= k - (n1len + n2len - m); l++)
								if (mul[l] == '0') break;
							for (l = l + 1; l <= k - (n1len + n2len - m); l++)	 
								mul[l] = 'X';
						} 
						
						for (l = k - (n1len + n2len - m); l >= pp; l--)
							printf("%c", mul[l] == 'X' ? ' ' : mul[l]);
						
						printf("\n");	
					}
				}
				for (l = 0; l < p; l++)
					printf("-");
				printf("\n");

				for (l = p - 1; l >= 0; l--) {
					if (res[l] != '0' && firstNonZero == 0)
						firstNonZero = 1;
					
					if (firstNonZero == 1) 	
						printf("%c", res[l]);
					else if (l == 0 && firstNonZero == 0) // No non zero encountered even at k = 0 implies the result itself is zero  
						printf("0");
					else 
						printf(" ");
				} 

			}
				break;
		}
		printf("\n");	
	}
	free(exp);
	free(expBackup);
	free(mul);
	free(res);
	return 0;
}


