  /* program to produce fibbnacci numbers by recursion 3-1-2005*/
 #include<stdio.h>
 int fib(int,int,int);
 main()
 {int y=0,z=1,n;
 printf("Enter n");
 scanf("%d",&n);
 printf("%d ",z);
 fib(n-1,y,z);
 }
 int fib(int n,int y,int z)
 {
 int x;
 if(n==0)return(0);
 else {
 x=y+z;      
 y=z;
      z=x;
      printf("%d ",x);
      return(fib(--n,y,z));
     }
 }
 input:Enter n =6
 output:1 1 2 3 5 8 
