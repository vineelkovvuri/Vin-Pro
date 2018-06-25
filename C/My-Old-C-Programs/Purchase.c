 /*program to calculate dscount in cloth show room 16-12-2004*/
  #include<stdio.h>
 main()
 {
 float x,y,z;int c;
  printf("\n1.Is your purchase is in between 1-100 ?");
  printf("\n2.Is your purchase is in between 101-200 ?");
  printf("\n3.Is your purchase is in between 201-300 ?");
  printf("\n4.Is your purchase is above 300 ?");
  printf("\nENTER THE APPROPRIATE CHOICE");
  scanf("%d",&c);
  printf("\nENTER THE PURCHASE ON MILL CLOTH AND HANDLOOM ITEMS");
  scanf("%f%f",&x,&y);
 switch(c)
 {
  case 1:
   {z=x+(19.0/20)*y;
    printf("\nTHE TOTAL AMOUNT TO BE PAID IS %f",z);} break;
  case 2:
   {z=(19.0/20)*x+(3.0/40)*y;
    printf("\nTHE TOTAL AMOUNT TO BE PAID IS %f",z);} break;
  case 3:
   {z=(3.0/40)*x+(9.0/10)*y;
    printf("\nTHE TOTAL AMOUNT TO BE PAID IS %f",z);} break;
  case 4:
   {z=(9.0/10)*x+(17.0/20)*y;
    printf("\nTHE TOTAL AMOUNT TO BE PAID IS %f",z);} break;
 }
 }
 input:
 1.Is your purchase is in between 1-100 ?
 2.Is your purchase is in between 101-200 ?
 3.Is your purchase is in between 201-300 ?
 4.Is your purchase is above 300 ?
 ENTER THE APPROPRIATE CHOICE 1
 ENTER THE PURCHASE ON MILL CLOTH AND HANDLOOM ITEMS 5.2
 output:
 THE TOTAL AMOUNT TO BE PAID IS 3.300000
