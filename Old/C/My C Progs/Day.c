/*******************************************************
                   CALENDER          7 MAY 2005
*******************************************************/
#include<stdio.h>       
int mm,dd,yyyy,p,b[]={0,31,28,31,30,31,30,31,31,30,31,30,31};
year()
{int k=0,i;
  for(i=1901;i<=yyyy;i++)
   {if(k==4) {
              if(p==7)p=1;
              else p++;
              k=0;
             }
    if(p>=7)p=0;
  p++;k++;
}
return; 
}  
month()
{int i,j;
  for(i=1;i<mm;i++)
   { if(i==2){if(yyyy%4==0)b[i]=29;
               else b[i]=28;
             }
     if(i==1)j=2;
     else j=1; 
    for(;j<=b[i];j++)
     { if(p>=7)p=0;
         p++; 
     }    
   }
   for(i=1;i<=dd;i++)
   {if(p>=7)p=0;
    p++;
   }
}
main()
{ 
	char a[][15]={"","TUESDAY","WEDNESSDAY","THRUSDAY","FRIDAY","SATURDAY","SUNDAY","MONDAY"};
	printf("\n                      ***PROGRAM TO GENERATE THE DAY OF A GIVEN DATE***   ");
	printf("\n                                  ENTER THE DATE(mm dd yyyy):");
	scanf("%d%d%d",&mm,&dd,&yyyy);
	if(yyyy>=1901&&dd<32&&mm<13)
	{
		year();
		month();
		printf("                                   THE DAY OF %d %d %d IS %s\n",mm,dd,yyyy,a[p]);
	}
	if(yyyy<1901) 
		printf("                  THE ENTERED YEAR IS NOT IN MY CALENDER RANGE SORRY TRY SOME OTHER DAY.....!\n");
	if(dd>31)printf("                          THE ENTERED DAY IS NOT A VALID DAY....!\n");  
	if(mm>12)printf("                          THE ENTERED MONTH IS NOT A VALID MONTH...!\n"); 
}
