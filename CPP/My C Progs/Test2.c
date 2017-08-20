#include<stdio.h>
main()
{char x[10],c,s[]="suneeta";
FILE *fp;int g=10;
fp=fopen("gauss.c","r+");
printf("%ld\n",ftell(fp));
printf("%c\n",c=getc(fp));
//eek(fp,1,1);
 fgets(x,strlen(s)-1,fp);
printf("%c\n",c=getc(fp));

}            
