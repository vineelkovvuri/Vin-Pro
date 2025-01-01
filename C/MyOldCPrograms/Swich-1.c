 /*program to perfrm basic arthimatic operation 13-12-2004*/
 #include<stdio.h>
#include<stdlib.h>
 main()
 {
 float a,b;int c;
 printf("\n1.addition\n2.subtracton\n3.multiplication\n4.division\nEnter your choice:");
 scanf("%d",&c);
 printf("\nEnter two numbers:");
 scanf("%f%f",&a,&b);
 switch(c)
 {case 1:printf("%f\n",a+b);break;
  case 2:printf("%f\n",a-b);break;
  case 3:printf("%f\n",a*b);break;
  case 4:printf("%f\n",a/b);break;
  default:printf("IMPROPER CHOICE....\n");
  }
 system("pause");
 }
