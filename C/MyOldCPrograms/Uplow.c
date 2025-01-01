 /*program to convert lower touppercase letter 17-1-2005*/
 #include<stdio.h>
 #include<string.h>
 main()
 {
 char x[20];int i;
 printf("\nEnter the string");
 scanf("%s",x);
  for(i=0;i<strlen(x);i++)
 printf("%c",x[i]-32);
 }
 input:
 Enter the string:vineel
 output:VINEEL
