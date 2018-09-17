#include<stdio.h>
#include<string.h>
main()
{ FILE *fp;char c;
fp=fopen("gauss.c","r");
fseek(fp,-1,2);
while(ftell(fp)!=0)
{printf("%c",getc(fp));
fseek(fp,-2,1);
}
printf("%c",getc(fp));
}
