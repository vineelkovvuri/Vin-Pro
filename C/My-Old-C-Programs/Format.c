/*program displaying format*/
#include<stdio.h>
void vineel(char []);
main()
{ char a[20];
 printf("Enter the string:");
 scanf("%[^\n]s",a);
 vineel(a);
}
void vineel(char a[])
{int i,j;
for(i=0;a[i]!='\0';i++)
  {for(j=0;j<=i;j++)
    printf("%c",a[j]);
    printf("\n");
  }
}
