 /*program to perform matrix multiplication 3-1-2005*/
 #include<stdio.h>
 main()
 {
 int x[10][10],y[10][10],z[10][10],i,j,k,a,b,c,d;
 printf("\nEnter the order of the matrices ");
 scanf("%d%d%d%d",&a,&b,&c,&d);
 printf("\nEnter the elements of the first matrix ");
 for(i=0;i<a;i++)
 for(j=0;j<b;j++)
 scanf("%d",&x[i][j]);
 printf("\nEnter the elements of the second matrix ");
 for(j=0;j<b;j++)
 for(k=0;k<d;k++)
 scanf("%d",&y[j][k]);
 printf("\nTHE MATRIX MULTIPLICATION IS\n ");
 for(i=0;i<a;i++)
 {
 for(k=0;k<d;k++)
 {z[i][k]=0;
 for(j=0;j<b;j++)
 z[i][k]+=x[i][j]*y[j][k];
 printf("\t%d",z[i][k]);}
 printf("\n");
 }}                       
 input:
 Enter the order of the matrices 3,3
 Enter the elements of the first matrix 1 2 3 4 5 6 7 8 9 
 Enter the elements of the second matrix 1 2 3 4 5 6 7 8 9
 output:
 THE MATRIX MULTIPLICATION IS
 	972	61	52
	24522	315	202
	2754	54	38
