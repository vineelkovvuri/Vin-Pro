/*
			[(log(2πn)/2+n(logn−loge))/log10]+1] for n >= 3 here [] means integer part
http://mathoverflow.net/questions/19170/how-good-is-kamenetskys-formula-for-the-number-of-digits-in-n-factorial

*/

#include <stdio.h>
#include <math.h>

int main()
{
    double n, pi = acos(-1.0);
    int t;
    scanf("%d", &t);
    while (t--) {
        scanf("%lf", &n);
		printf("%.0lf\n", n<3.0? 1.0 : floor((n*log(n)-n+(log(2.0*pi*n))/2.0)/log(10.0))+1.0 );
	}
    return 0;
}