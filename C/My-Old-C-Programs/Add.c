#include<stdio.h> 
int  check(int,int,int,int);
int a[5][3],b[5][3],c[2*5][3],t;
main()
{int i,j;
printf("\nEnter the first sparces matrix:");
for(i=0;i<3;i++)
 for(j=0;j<3;j++)
 scanf("%d",&a[i][j]);
printf("\nEnter the second sparces matrix:");
for(i=0;i<4;i++)
 for(j=0;j<3;j++)
 scanf("%d",&b[i][j]);
 if(a[0][0]==b[0][0]&&a[0][1]==b[0][1]){check(1,0,1,0);
				 c[0][0]=a[0][0];c[0][1]=a[0][1];c[0][2]=t;
				 for(i=0;i<=t;i++)
				  {for(j=0;j<3;j++)
				   printf("%d\t",c[i][j]);
				   printf("\n");
 				 }
				}
else printf("***Given sparce matrix cannot be added***");
}
int check(int i,int j,int k,int l)
{
 int x,y,m;
 if (i==a[0][0]&&k==b[0][1]){ printf("%d\n",t);return ;}
 else {
  if(a[i][j]<b[k][l]){c[++t][0]=a[i][0];c[t][1]=a[i][1];c[t][2]=a[i][2];
                          if(i!=a[0][1])check(++i,0,k,0);
                     }
 else if(a[i][j]>b[k][l]){c[++t][0]=b[k][0];c[t][1]=b[k][1];c[t][2]=b[k][2];
                          if(k!=b[0][1])check(i,0,++k,0);
                         }
 else if(a[i][j]==b[k][l]){for(m=1;m<t;m++)
                           if(c[m][0]==a[i][j]){x=0;m=t;}          
                          if(x==0)c[m][2]+=a[i][2]+b[k][2];
			  else {c[++t][0]=b[k][0];c[t][1]=b[k][1];c[t][2]=a[i][2]+b[k][2]; 
                          check(++i,0,++k,0);}
                          }
    }                  
}
