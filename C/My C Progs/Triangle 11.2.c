  /* program for the arrangement of numbers 11.2  18 nov 2004*/
  #include<stdio.h>
  #include<conio.h>
  main()
  {
  int i,j,n,k;
  printf("\nEnter n:");
  scanf("%d",&n);
  for(i=1;i<=n;i++)
  {
  for(j=1;j<=n-i;j++)
  printf("  ");
  for(k=1;k<=i;k++)
  printf("%4d",i);
  printf("\n");
  }
 getch(); }
