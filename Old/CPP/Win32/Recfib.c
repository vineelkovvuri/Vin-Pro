
 #include<stdio.h>
 
 int main(int argc, char**argv)
 {
	 int n,i;
	 n = atoi(argv[1]);
	 for(i=0;i<=n;i++)
		printf("%d  ",fib(i));
 }
 int fib(int n)
 {
	if(n == 0 || n == 1) return n;
	else  return fib(n-1) + fib(n-2);
}