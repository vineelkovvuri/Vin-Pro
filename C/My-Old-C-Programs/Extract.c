 /*program to extract required part of the given string  3-1-2005*/
 #include<stdio.h>
 main()
 {
 char a[25];
 int m,n,i;
 printf("\nEnter the string:");
 scanf("%s",a);
 printf("\nEnter n,m:");
 scanf("%d%d",&n,&m);
 for(i=n-1;i<n+m-1;i++)
 printf("%c",a[i]);
 }
 input:
 Enter the string:vineelkumar
 output:
 Enter n,m:neelk
