#include<stdio.h>
main()
{char a[15],t;int i,j,m;
 printf("\nEnter the infix string:");
 scanf("%s",a);
 for(i=1;a[i]!='\0';i+=2)
 if(a[i]=='*'||a[i]=='/'){t=a[i];a[i]=a[i+1];a[i+1]=t;}
 for(i=1;a[i]!='\0';i++)
 {if(a[i]=='+'||a[i]=='-'){for(j=i+1;(a[j]!='+'&&a[j]!='-')&&a[j]!='\0';j++)
				{t=a[j];a[j]=a[j-1];a[j-1]=t;
                                  /*for(m=0;a[m]!='\0';m++)                   
                                   printf("%c",a[m]);
                                   printf("\n");*/   }
                          }
  i=j-1;
 }
for(i=0;a[i]!='\0';i++)
 printf("%c",a[i]);
}
 
