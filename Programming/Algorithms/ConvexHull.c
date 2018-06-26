

#include<stdio.h>
#define MAX_POINTS 8

#define getsign(x) ((x) == 0? 0: (x) < 0? -1: 1)

typedef struct _Point{
	double x,y;
}Point;

int main()
{
	Point points[MAX_POINTS] = {{5,1},{6,4},{1,2},{4,3},{8,2},{7,6},{2,5},{3,4}};
	int i,j,k;
	
	for(i = 0;i < MAX_POINTS; i++){
		for(j = 0;j < MAX_POINTS; j++){		
			if(i != j){
				double m  = (points[j].y - points[i].y)/(points[j].x - points[i].x); //m = slope ; assumption m is not 0
				double sign = 0;	// 0 = on the line, +ve side means > 0 , -ve side means < 0 
				int sameSide = 1;
				for(k = 0;k < MAX_POINTS; k++){
					if(k != i && k != j){
						if(sign*((points[k].y - points[i].y) - m*(points[k].x - points[i].x)) < 0) {
							sameSide = 0;
							break; //points are on the oppsite sides of the line formed by points[i],points[j];
						}
						sign = getsign((points[k].y - points[i].y) - m*(points[k].x - points[i].x));
					}
				}
				if(sameSide){
					printf("\n%d(%.2f,%.2f)  %d(%.2f,%.2f)",i,points[i].x,points[i].y,j,points[j].x,points[j].y);
				}
			}
		}
	}
	
	
}
