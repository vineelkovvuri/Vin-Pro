 #include<stdio.h>
 #include<math.h>
 main()
 {int l=0,i,h,r,d,a[20];
  printf("\nHow many numbers are you willing to enter....:");
  scanf("%d",&h);
  printf("\nEnter the elements:");
  for(i=0;i<h;i++)
   scanf("%d",&a[i]);
  printf("\nEnter the element you want to search:");
  scanf("%d",&d);
  r=(l+h)/2;
  for(;a[r]!=d;)
  {if(a[r]<d){l=r;r=(l+h)/2;}
   else if(a[r]>d){h=r;r=(l+h)/2;}
  }
  printf("\nposition =%d",r+1);
 }
 INPUT:
 How many numbers are you willing to enter....:10
 Enter the elements: 1 2 3 4 5 6 7 8 9 10
 Enter the element you want to search:4
 OUTPUT:
 position =4
