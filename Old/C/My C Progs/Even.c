 /*program to print no.. of even and odd and sum of even and odd 2-11-2004*/
 #include<stdio.h>
 main()
 {
 int i,k=0,s=0,n,c;
 printf("\n1.no..of even no.. below a number");
 printf("\n2.sum of even no.. blow a number");
 printf("\n1.no..of odd no.. below a number");
 printf("\n2.sum of odd no.. blow a number");
 printf("\nEnter your choice");
 scanf("%d",&c);
 printf("\nEnter n");
  scanf("%d",&n);
 switch(c)
 { 
 case 1:
 for(i=1;i<=n;i++){ if(i%2==0)k++;}
  printf("%d",k); break;
 case 2:
 for(i=1;i<=n;i++) if(i%2==0)s+=i;
 printf("%d",s); break;
 case 3:
 for(i=1;i<=n;i++)if(i%2!=0)k++;
 printf("%d",k); break;
 case 4:
 for(i=1;i<=n;i++) if(i%2!=0)s+=i;
 printf("%d",s); break;
 }
 }
 input:
 1.no..of even no.. below a number
 2.sum of even no.. blow a number
 3.no..of odd no.. below a number
 4.sum of odd no.. blow a number
 Enter your choice3
 Enter n 3
 output:1
