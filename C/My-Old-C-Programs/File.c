#include<stdio.h>
main()
{FILE *fp;char c;long int l;
 fp=fopen("gauss.c","r+");
 if(fp==NULL)printf("\nproblem"); 
else  //while((c=getc(fp))!=EOF)
{l=ftell(fp);
 fseek(fp,0,2);
  putc(c,fp);
 //fseek(fp,0,0);
// while(l!=fseek(fp))
  fseek(fp,l,0);
 
}
fclose(fp);
fp=fopen("gauss.c","r");
  if(fp==NULL)printf("\nproblem");
else   while((c=getc(fp))!=EOF)
   printf("%c",c);
fclose(fp);
}
