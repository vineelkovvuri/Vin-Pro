#if 0
	The idea is, Clearly its a DP problem.
	The maximum fun that can be at p[i]th party with jth budgets is given by d[i][j]
	d[i][j] = max{ adding p[i]th party + d[i-1/*previous parties*/][j-p[i]/*remaining budget*/],
				   d[i-1/*previous parties*/][j/*current budget*/] /* this araises when u donot have enough budget to include 
				   			current party, in that case we will just go to the best of previous parties with current budget */
				} 
				   
	more elobarately:
	d[i][j] = max{ {	if (j-p[i] < 0) no budget
							0
						else if (i-1 >= 0 && j-p[i] >= p[0]) /* there should be a party and also we should have just enouch money to go atleast least party*/
							p[i] + d[i-1][j-p[i]];
					},
					 { d[i-1][j] if i-1 >= 0
					 	0		 otherwise
					  }
				}
#endif

#include<stdio.h>
#include<string.h>
#include<stdlib.h>

struct pcf {
	int c; //party cost;
	int f; //party fun;
}p[110], d[510][510]; //max fun with in a given bugget

#define max2(a, b) ((a) > (b) ? (a) : (b))
#define min2(a, b) ((a) < (b) ? (a) : (b))

int compare(const void *p1, const void *p2)
{
	int x = ((struct pcf *)p1)->c - ((struct pcf *)p2)->c;
	return x == 0? ((struct pcf *)p1)->f - ((struct pcf *)p2)->f : x;
}

int main()
{
	while (1)
	 {
		int i, j, k, b, np;
		scanf("%d %d", &b, &np);
		if (b == 0 && np == 0) break;

		for (i = 0; i < np; i++)
			scanf("%d %d", &p[i].c, &p[i].f);
		qsort(p, np, sizeof(struct pcf), compare);

		for (i = 0; i < np; i++) { //veritically party
			for (j = p[0].c; j <= b; j++) { //horizontally budget
				//way1
				int xf = 0, xc = 0;
				if (j - p[i].c < 0) {
					xf = 0;
					xc = 0;
				} else {
					xf = p[i].f;
					xc = p[i].c;
					if (i-1 >= 0 && j - p[i].c >= p[0].c) {
						xf += d[i-1][j-p[i].c].f; 
						xc += d[i-1][j-p[i].c].c;
					}
				}
				//way2 
				int yf = 0, yc = 0;
				if (i - 1 >= 0) {
					yf = d[i-1][j].f;
					yc = d[i-1][j].c;
				}
				/* parties buggets are same via both ways, then go with least budget way - min2*/				
				if (xf == yf) {
					d[i][j].f = xf;
					d[i][j].c = min2(xc, yc);
	//				printf("i %d j %d xc %d yc %d\n", i, j, xc,yc);
				} else {
					d[i][j].f = max2(xf, yf);
					if (d[i][j].f == xf) 
						d[i][j].c = xc;
					else 
						d[i][j].c = yc;
				}
			}
		}
		printf("%d %d\n", d[np-1][b].c, d[np-1][b].f);
#if 0
		for (j = 0; j <= b; j++)
			printf("%2d/%-2d ", j,j);
		printf("\n");	
		for (i = 0; i < np; i++) { //veritically party
			for (j = 0; j <= b; j++) { //horizontally budget
				printf("%2d/%-2d ", d[i][j].f, d[i][j].c);
			}
			printf("\n");
		}

		for (i = 0; i < np; i++)
			printf("%d %d\n", p[i].c, p[i].f);
#endif				

	}
	return 0;
}

