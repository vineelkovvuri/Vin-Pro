/*program to find numbers like 1729*/
#include<stdio.h>
#include<conio.h>
main()
{
double i,j,x,k=0,i1,j1;
 for(x=1;x<=10000;x++) //we are finding the number in the range of 1<x<10000
 {
	 k=0;
	 for(i=1;i<=20;i++)
		 for(j=1;j<=i;j++){
			 if(i*i*i+j*j*j==x){if(k==0){i1=i;j1=j;}k++;}
			 if(k==2){ 
				 printf("\n%lf %lf %lf",i1,j1,x);
				 printf("\n%lf %lf %lf",i,j,x);
				 k=0;
			 }
		 }
 }
getch();
}
