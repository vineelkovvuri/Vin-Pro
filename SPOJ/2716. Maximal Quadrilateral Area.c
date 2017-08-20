//http://blog.adilakhter.com/2012/12/22/f-spoj-2716-maximal-quadrilateral-area/
//http://en.wikipedia.org/wiki/Brahmagupta's_formula


#include <stdio.h>
#include <math.h>

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		double a, b, c, d, s;
		scanf("%lf%lf%lf%lf", &a, &b, &c, &d);
		s = (a + b + c + d) / 2.0;
		printf("%.2lf\n", sqrt((s-a)*(s-b)*(s-c)*(s-d)));
	}
	return 0;
}