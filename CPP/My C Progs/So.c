 /*
  Name: program to genarate fibbnoci sequence 3-1-2005
  Copyright: 
  Author:suneeta 
  Date: 28/05/05 13:42
  Description: 
*/

  #include<stdio.h>
  #include<conio.h>
   main()
  { 
  int n,x=0,y=1;
  printf("\nEnter n:");
  scanf("%d",&n);
  printf("%d\t",x);
  while(--n!=0) 
  {
  x=x+y;
  printf("%d\t",x);
  }
   getch();
  }
 
