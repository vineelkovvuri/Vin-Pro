#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>
/*
V = abc * (sqrt(1 + 2cos(alpha)cos(beta)cos(gamma) - cos(alpha)^2 - cos(beta)^2 - cos(gamma)^2)) / 6.0

where alpha, beta, gamma are the plane angles occurring with vertex D. 
The angle alpha, is the angle between the two edges connecting the vertex D to the vertices B and C. 
The angle beta, does so for the vertices A and C, while gamma, is defined by the position of the vertices A and B.

where a, b, c are the edges coming out of DA, DB, DC edges respectively
*/

int main()
{
	int t;
	scanf("%d", &t);
	while (t--) {
		double AB, AC, AD, BC, BD, CD;
		double cos1, cos2, cos3, vol;
		scanf("%lf%lf%lf%lf%lf%lf", &AB, &AC, &AD, &BC, &BD, &CD);
		cos1 = (AD*AD + BD*BD - AB*AB)/(2.0 * AD * BD);
		cos2 = (AD*AD + CD*CD - AC*AC)/(2.0 * AD * CD);
		cos3 = (CD*CD + BD*BD - BC*BC)/(2.0 * CD * BD);
		vol = (AD*CD*BD)*sqrt(1.0 + 2.0*cos1*cos2*cos3 - cos1*cos1 - cos2*cos2 - cos3*cos3)/6.0;
		printf("%.4lf\n", vol);
	}
	return 0;
}

