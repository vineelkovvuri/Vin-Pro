/* program to perform the length of the string */
#include<stdio.h>
int len(char[],int);
main()
{ char a[20];
  printf("\nEnter the string: ");scanf("%s",a);
  printf("\nThe string length is %d",len(a,0));
}

int len(char a[],int i)
{ if(a[i]=='\0') return i;
  else return len(a,++i);
}

