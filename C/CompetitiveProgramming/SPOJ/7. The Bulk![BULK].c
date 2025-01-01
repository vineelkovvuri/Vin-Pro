#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>

#define MAX_FACES 260
#define MAX_POINTS 210

#define min2(a, b) (a) <= (b) ? (a) : (b)
#define max2(a, b) (a) >= (b) ? (a) : (b)

#define min(a, b, c) min2(a, min2(b, c))
#define max(a, b, c) max2(a, max2(b, c))

#define exactfit(min1, max1, min2, max2) ((min2 != max2 && (min1 == min2 && max1 == max2)) || \
 				(min2 == max2 && (min1 == min2 || max1 == min2)))


void print(int *q)
{
	int i = 0;
	for (i = 0; q[i] != -2; i += 6)
		printf("%-4d X = [%-4d, %4d]  Y = [%-4d, %4d]  Z = [%-4d, %4d]\n", i / 6, q[i], q[i + 1], q[i + 2], q[i + 3], q[i + 4], q[i + 5]); 
	
	printf("\n");
}

int faceTraped(int *f1, int *f2) 
{
	int df[6];
	int i, I = 0;
		
	for (i = 0; i < 6; i++)
		df[i] = f2[i] - f1[i];
		
	int count = 0;
	//exactly 2 pairs must be zero [0, 0]  => 2 of the dimension of f1 is same as f2
	for (i = 0; i < 6; i += 2)
		if (df[i] == 0 && df[i + 1] == 0)
			count++;
		else 
			I = i;	//get the 3rd dimension
	if (count != 2)
		return 0;
	
	if (f2[I] != f2[I + 1])   //not a face vector
		return 0;
	else {
		if (f1[I] <= f2[I] && f2[I + 1] <= f1[I + 1])  //face falling in between
			return 1;
		else 
			return 0;
	}
}
	
	

int _remove(int *q)
{
	int i = 0, j = 0;
	for (i = 0; q[i] != -2; i += 6) {
		if (q[i] != -1) {
			int *minX1 = &q[i + 0];
			int *maxX1 = &q[i + 1];
			int *minY1 = &q[i + 2]; 
			int *maxY1 = &q[i + 3]; 
			int *minZ1 = &q[i + 4]; 
			int *maxZ1 = &q[i + 5]; 
			
			if (*minX1 == *maxX1 || *minY1 == *maxY1 || *minZ1 == *maxZ1)
				*minX1 = *maxX1 = *minY1 = *maxY1 = *minZ1 = *maxZ1 = -1;
		}
	}
	
	for (i = 0; q[i] != -2; i += 6) {
		if (q[i] != -1) {
			for (j = 6 + i; q[j] != -2; j += 6) {
				if (q[j] != -1) {
					if (q[i + 0] == q[j + 0] && q[i + 1] == q[j + 1] && 
						q[i + 2] == q[j + 2] && q[i + 3] == q[j + 3] && 
						q[i + 4] == q[j + 4] && q[i + 5] == q[j + 5])
						q[j + 0] = q[j + 1] = q[j + 2] = q[j + 3] = q[j + 4] = q[j + 5] = -1;
				}
			}
		}
	}
}

int splitfaces(int *f1, int *f2, int *q) 
{
	int df[6];
	int nf[6];
	int nf1[6];
	int i = 0, j = 0, I = 0, J = 0; 
	
	//both faces should not be on same plane
	for (i = 0; i < 6; i += 2)
		if (f1[i] == f1[i + 1] && f2[i] == f2[i + 1] && f1[i] == f2[i])
			return 0;
		
	for (i = 0; i < 6; i++)
		df[i] = f2[i] - f1[i];
		
	int count = 0;
	//exactly 1 pair must be zero [0, 0]  => 1 of the dimension of f1 is same as f2
	for (i = 0; i < 6; i += 2)
		if (df[i] == 0 && df[i + 1] == 0) {
			count++;
			I = i;
		}
	if (count != 1)
		return 0;
	
	nf1[I] = nf[I] = f1[I];
	nf1[I + 1] = nf[I + 1] = f1[I + 1];
	
	
	//exactly 1 pair must have same differences [a, a] && a != 0 => f1 and f2 are parallel to each other
	// avoids faces do not fall on one another
	count = 0;
	for (i = 0; i < 6; i += 2) {
		if (df[i] == df[i + 1] && df[i] > 0) { //[10, 20] [10, 40] [20, 20] | [30, 40] [10, 40] [30, 30] example where two pairs will be same [a,a] and [b,b]
			count++;
			I = i;
		} /* else if (df[i] == df[i + 1] && df[i] < 0) {
			for(j = 0; j < 6; j++)
				df[j] = -df[j];
		}*/
	}
	if (count != 1)
		return 0;

	nf[I] = min2(f1[I], f2[I]);
	nf[I + 1] = max2(f1[I + 1], f2[I + 1]);
	J = I;
	
	//1 pair must have one coordinate zero and other non-zero [l, m] where l = 0 and m != 0 or l != 0 and m == 0
	count = 0;
	for (i = 0; i < 6; i += 2)
		if (df[i] == 0 && df[i + 1] != 0 ||
			df[i] != 0 && df[i + 1] == 0) {
			count++;
			I = i;
		}
	if (count != 1)
		return 0;

	i = I;	
	int a, b, c, d;
	if (df[i] == 0 && df[i + 1] != 0) {
		if (df[i + 1] >= 0) {  //f1 = (f1min, f1max); f2 = (f1max, f2max)
			nf[i] = f1[i + 1];
			nf[i + 1] = f1[i + 1];
			nf1[J] = f2[J];
			nf1[J + 1] = f2[J + 1];
	
			a = f1[i + 0];
			b = f1[i + 1];
			c = f1[i + 1];
			d = f2[i + 1]; 
			if (f1[i + 0] == a && f1[i + 1] == b && f2[i + 0] == c && f2[i + 1] == d) return 0;
			nf1[i + 0] = b;
			nf1[i + 1] = d;
			f2[i + 0] = a;
			f2[i + 1] = b;
	
		} else if (df[i + 1] < 0) {	//f1 = (f1min, f2max); f2 = (f2max, f1max)
			nf[i] = f2[i + 1];
			nf[i + 1] = f2[i + 1];
			nf1[J] = f1[J];
			nf1[J + 1] = f1[J + 1];

			a = f1[i + 0];
			b = f2[i + 1];
			c = f2[i + 1];
			d = f1[i + 1];
			if (f1[i + 0] == a && f1[i + 1] == b && f2[i + 0] == c && f2[i + 1] == d) return 0;
			f1[i + 0] = a;
			f1[i + 1] = b;
			nf1[i + 0] = b;
			nf1[i + 1] = d;
		}
	} else if (df[i] != 0 && df[i + 1] == 0) {
		if (df[i] >= 0) {  //f1 = (f1min, f2min); f2 = (f2min, f2max)
			nf[i] = f2[i];
			nf[i + 1] = f2[i];
			nf1[J] = f1[J];
			nf1[J + 1] = f1[J + 1];

			a = f1[i + 0];
			b = f2[i + 0];
			c = f2[i + 0];
			d = f2[i + 1];
			if (f1[i + 0] == a && f1[i + 1] == b && f2[i + 0] == c && f2[i + 1] == d) return 0;
			f1[i + 0] = a;
			f1[i + 1] = b;
			nf1[i + 0] = b;
			nf1[i + 1] = d;

		} else if (df[i] < 0) {	//f1 = (f2min, f1min); f2 = (f1min, f1max)
			nf[i] = f1[i];
			nf[i + 1] = f1[i];
			nf1[J] = f2[J];
			nf1[J + 1] = f2[J + 1];

			a = f2[i + 0];
			b = f1[i + 0];
			c = f1[i + 0];
			d = f1[i + 1];
			if (f1[i + 0] == a && f1[i + 1] == b && f2[i + 0] == c && f2[i + 1] == d) return 0;
			nf1[i + 0] = a;
			nf1[i + 1] = c;
			f2[i + 0] = c;
			f2[i + 1] = d;
		}
	}
	
	for (i = 0; q[i] != -2; i++);
	for (j = 0; j < 6; j++)
		q[i++] = nf[j];
	for (j = 0; j < 6; j++)
		q[i++] = nf1[j];
	
	q[i] = -2;
	
	return 1; 
}

int split(int *q)
{
	int i = 0, j = 0;
	int splitDone = 0;		
	printf("Spliting ---------------------------------\n");
	for (i = 0; q[i] != -2; i += 6) {
		if (q[i] != -1) {
			int *f1 = &q[i];
			for (j = 6 + i; q[j] != -2; j += 6) {
				if (q[j] != -1) {		
					int *f2 = &q[j];
					if (splitfaces(f1, f2, q)) {
						splitDone = 1;
						printf("%d %d\n", i / 6, j / 6);
						print(q);	
						//return 1;
					}
		
				}
			}
		}
	}
	return splitDone;
}

int mergefaces(int *f1, int *f2, int *q) 
{

	int df[6];
	int i = 0, I = 0; 
	
	//both faces should not be on same plane
	for (i = 0; i < 6; i += 2)
		if (f1[i] == f1[i + 1] && f2[i] == f2[i + 1] && f1[i] == f2[i])
			return 0;
		
	for (i = 0; i < 6; i++)
		df[i] = f2[i] - f1[i];
		
	int count = 0;
	//exactly 2 pairs must be zero [0, 0]  => 2 of the dimension of f1 is same as f2
	for (i = 0; i < 6; i += 2)
		if (df[i] == 0 && df[i + 1] == 0)
			count++;
	if (count != 2)
		return 0;
	
	//exactly 1 pair must have same differences [a, a] where a != 0 => f1 and f2 are parallel to each other
	// avoids faces do not fall on one another
	count = 0;
	for (i = 0; i < 6; i += 2)
		if (df[i] == df[i + 1] && df[i] != 0) { //[10, 20] [10, 40] [20, 20] | [30, 40] [10, 40] [30, 30] example where two pairs will be same [a,a] and [b,b]
			count++;
			I = i;
		}
	if (count != 1)
		return 0;

	f1[I + 0] = min2(f1[I + 0], f2[I + 0]);
	f1[I + 1] = max2(f1[I + 1], f2[I + 1]);
	
	for (i = 0; q[i] != -2; i += 6)
		if (q[i] != -1 && &q[i] != f1) {	// exclude the f1 itself from nullyfying
			if (exactfit(f1[0], f1[1], q[i + 0], q[i + 1]) && //x exact match
				exactfit(f1[2], f1[3], q[i + 2], q[i + 3]) && //y exact match
				exactfit(f1[4], f1[5], q[i + 4], q[i + 5])) //z exact match							
					q[i + 0] = q[i + 1] = q[i + 2] = q[i + 3] = q[i + 4] = q[i + 5] = -1;
			if (faceTraped(f1, &q[i]))
					q[i + 0] = q[i + 1] = q[i + 2] = q[i + 3] = q[i + 4] = q[i + 5] = -1;
		}
	return 1;
}
			
int merge(int *q) 
{
	int i = 0, j = 0;
	int mergeDone = 0;	
	printf("Merging ---------------------------------\n");
	for (i = 0; q[i] != -2; i += 6) {
		if (q[i] != -1) {
			int *f1 = &q[i];
			for (j = 6 + i; q[j] != -2; j += 6) {
				if (q[j] != -1) {		
					int *f2 = &q[j];
					if (mergefaces(f1, f2, q)) {
						mergeDone = 1;
						printf("%d %d\n", i / 6, j / 6);
						print(q);	
					}
				}
			}
		}
	}
	return mergeDone;
} 
  
  
int main()
{
	int n;
	int *p, *q;

	p = malloc(sizeof(int) * (3 * MAX_POINTS));
	q = malloc(sizeof(int) * (3 * MAX_POINTS * MAX_FACES));
	
	//for (t = 0; t < ntest; t++)
	{	
		int nf;
		int i, j;
		int k = 0;

		scanf("%d", &nf);
		for (i = 0; i < nf; i++) {
			int np;

			scanf("%d", &np);
			for (j = 0; j < 3 * np; j++)
				scanf("%d", &p[j]);

			#if 0  //assuming minimum x + y starts first
			int minCord = 0;
			for (j = 3; j <  np; j += 3) {
				if ( p[j] +  p[j + 1] +  p[j + 2] <
						 p[minCord] +  p[minCord + 1] +  p[minCord + 2]) {
					minCord = j;
				}
			}
			int count =  np ;
			for (j = minCord; count > 0; j = (j + 9) %  np, count -= 9) {
			#else 
			for (j = 0; j + 6 < 3 * np; j += 9) {
			#endif
				int minX = min(p[j + 0], p[j + 3], p[j + 6]);
				int maxX = max(p[j + 0], p[j + 3], p[j + 6]);
				int minY = min(p[j + 1], p[j + 4], p[j + 7]);
				int maxY = max(p[j + 1], p[j + 4], p[j + 7]);
				int minZ = min(p[j + 2], p[j + 5], p[j + 8]);
				int maxZ = max(p[j + 2], p[j + 5], p[j + 8]);

				q[k++] = minX;
				q[k++] = maxX;
				q[k++] = minY;
				q[k++] = maxY;				
				q[k++] = minZ;
				q[k++] = maxZ;
			}
		}
		q[k] = -2;
		
	//	printf("Before merge\n");
		print(q);	
		do {
			merge(q);
		}while(split(q));
		
		_remove(q);
		print(q);
	}
	
	free(q);
	free(p);
	return 0;
}


