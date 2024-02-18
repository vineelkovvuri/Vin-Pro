 /*program to calculate the distance covered 17-1-2005*/ 
 #include<stdio.h>
 main()
 {
 float s,u,t,a;
 printf("\nEnter u,t,a:");
 scanf("%f%f%f",&u,&t,&a);
 s=u*t+.5*a*t*t;
 printf("\ndistance covered:%f",s);
 }
 input:
 Enter u,t,a:2 3 6
 output:
 distance covered:28.500000
