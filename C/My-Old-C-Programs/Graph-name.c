#include<stdio.h>
#include<math.h>
#include<conio.h>
float f(float );
main()
{
float x,y; int k,j,i,b=0;
char a[]= "k*vineel kumar reddy";
for(x=0.1;x<4;x+=.08)
{if(b==22)b=0;
  y=f(x);k=(int)(y/.03);
 if(y>0){if(k>100)printf("\ngraph is x=%f\n",x);
	 else {for(j=1;j<38;j++)
		printf(" ");
		printf("|");
		for(j=39;j<39+k;j++)
		printf(".");
		printf("%c",a[b]);b++;
		printf("\n");
	      }
	 }
  if(y<0){if(k<-38)printf("\ngraph y at x=%f\n",x);
	  else {for(j=1;j<37+k;j++)
		printf(" ");
		printf("%c",a[b]);b++;
		for(i=38+k;i<38;i++)
		printf(".");
		printf("|");
		printf("\n");
	       }
	 }
}
getch();
}
float f(float x)
{
return(sin(x));
}
