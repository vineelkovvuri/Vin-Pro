/*

	Idea here is to find the number of new operation needed to make 
	a prefix of src string to be *part*(not ends) of every prefix of des string
	This araises below cases. 
		1. a character can be deleted from the end of src prefix
		2. a character can be added to the end of src prefix
		3. a character can be replaced(substituted) at the end of src to des prefix
	

	My worst choice of j <-> i 
	j index Source String(a)
	i index Destination String(b)


Example: 
a = FOOD
b = MONEY

---------------------------------------------------
a(j)\b(i) | M     | MO    | MON   | MONE  | MONEY | 
---------------------------------------------------
F         |   1   |  2    |  1    |   1   |   1   | 
FO        |   2   |  1    |  2    |   2   |   2   | 
FOO       |   3   |  2    |  2    |   3   |   3   | 
FOOD      |   2   |  3    |  3    |   3   |  *4*  | 
---------------------------------------------------

*/

#include<stdio.h>

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define min3(a, b, c) min2(a, min2(b, c))
char a[2010], b[2010];
int d[2010][2010];
int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		int i, j;
		scanf("%s%s", a,b);
		for (j = 0; a[j]; j++) {
			for (i = 0; b[i]; i++) {
				if (i - 1 < 0 && j - 1 < 0) {
					if (a[j] == b[i]) d[j][i] = 0; //no substitution required
					else d[j][i] = 1; // substitute a[0] as b[0] we are done
				} else if (i - 1 < 0) { //deletions to make src to des
					if (a[j] == b[i]) d[j][i] = j; //deletions; a[j] = FO , b[i] = O
					else d[j][i] = d[j-1][i] + 1; //deletions; a[j] = FO, b[i] = M
				} else if (j - 1 < 0) { //insertions to make src to des
					if (a[j] == b[i]) d[j][i] = i; //insertions; a[j] = F, b[i] = XF
					else d[j][i] = d[j][i-1] + 1; //insertions; a[j] = F, b[i] = XY
				} else if (i - 1 >= 0 && j - 1 >= 0) {
					if (a[j] == b[i]) d[j][i] = d[j-1][i-1]; //just carry previous operations a[j] = ABC , b[i] = XYZC
					else {
						//let a[j] = ABC, b[i] = XYZK. Here j < i
						//Now a[j] can be made to b[i] from any of the following three operations
						//d[j-1][i-1] i.e., a[j-1] = AB, b[i-1] = XYZ and C -> K (substitution)
						//d[j][i-1] i.e., a[j] = ABC, b[i-1] = XYZ and Insert K to a[j] (insertion)

						//let a[j] = ABCK, b[i] = XYZ. Here j > i
						//d[j-1][i-1] i.e., a[j-1] = ABC, b[i-1] = XY and K -> Z (substitution)
						//d[j-1][i] i.e., a[j-1] = ABC, b[i] = XYZ and delete K (deletion)

						//let a[j] = ABC, b[i] = XYZ. Here j == i
						//d[j-1][i-1] i.e., a[j-1] = AB, b[i-1] = XY and C -> Z (substitution)
						//d[j][i-1] i.e., a[j] = ABC, b[i-1] = XY and addition of Z to a[j] (addition)
						//d[j-1][i] i.e., a[j-1] = AB, b[i] = XYZ and delete C from a[j] (deletion)
						d[j][i] = min3(d[j-1][i-1], d[j][i-1], d[j-1][i]) + 1;
			 		}
				}
			}
		}
		printf("%d\n", d[j-1][i-1]);
#if 0
		for (j = 0; a[j]; j++) {
			for (i = 0; b[i]; i++) {
				printf("%6d", d[j][i]);
			}
			printf("\n");
		}
#endif
	}
	return 0;
}






