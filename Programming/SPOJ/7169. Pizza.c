#include<stdio.h>
#define min2(a, b) ((a) < (b) ? (a) : (b))

int main()
{
    int N, i, pizzas = 1;
	int s25 = 0, s50 = 0, s75 = 0; 
    scanf("%d", &N);
    for (i = 0; i < N; i++) {
        int n, d, c;
        scanf("%d%c%d", &n, &c, &d);
        if (n == 3 && d == 4) s75++;
        else if (n == 1 && d == 2) s50++;
        else if (n == 1 && d == 4) s25++;
    }
    
	pizzas += s50/2;
	if (s50%2 == 1) {
		if (s25 > 0) {
			s25 -= 2;
			if (s25 < 0)
				s25 = 0;
		}
		pizzas += 1;
	}

	pizzas += s75;
	s25 = s25 - min2(s75,s25);
	pizzas += (s25 + 3)/4;
	
    printf("%d\n", pizzas);

    return 0;
}

