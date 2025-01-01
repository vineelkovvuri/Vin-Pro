  /*program to genarate fibbnoci sequence 3-1-2005*/
  #include<stdio.h>
  #include<conio.h>
   main()
  { 
  int n,x=1,y=1,z=0;
  printf("\nEnter n:");
  scanf("%d",&n);
  printf("%d\t",x);
  while(--n!=0) 
  {
  z=y+x;
  x=y;
  y=z;
  printf("%d\t",x);
  }
   getch();
  }
 
