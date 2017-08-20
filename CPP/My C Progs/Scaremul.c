#include<stdio.h>
#define m 55
#define n 55
int a[m][3],b[n][3],c[m*n][3]={-1};
main()
{ int i,j,t=0,x=1,g=1,k=0;
 printf("\nEnter the first three elements:");
 scanf("%d%d%d",&a[0][0],&a[0][1],&a[0][2]);
 printf("\nEnter the first sparce matrix:");
 for(i=1;i<=a[0][2];i++)
 for(j=0;j<3;j++)
 scanf("%d",&a[i][j]);
 printf("\nEnter the first three elements:");
 scanf("%d%d%d",&b[0][0],&b[0][1],&b[0][2]);
 printf("\nEnter the second sparce matrix:");
 for(i=1;i<=b[0][2];i++)
 for(j=0;j<3;j++)
 scanf("%d",&b[i][j]);
for(i=1;i<=a[0][2];i++)
 for(j=1;j<=b[0][2];j++)  
 if(a[i][1]==b[j][0]){for(k=1;k<=t&&g!=0;k++)
		       if(c[k][1]==b[j][1]&&c[k][0]==a[i][0]){x=0;g=0;}
                        if(x==0)c[--k][2]+=a[i][2]*b[j][2];
                	else {c[++t][0]=a[i][0];
				 c[t][1]=b[j][1];
				 c[t][2]=a[i][2]*b[j][2];
		             }
                        x=1;g=1;
                     }
c[0][0]=a[0][0];
c[0][1]=b[0][1];
c[0][2]=t;
 printf("\n");
for(i=0;i<=t;i++)
 {for(j=0;j<3;j++)
  printf("%d\t",c[i][j]);
  printf("\n");
 }
}  				
