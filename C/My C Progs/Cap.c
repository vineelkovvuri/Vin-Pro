#include<stdio.h>
#include<ctype.h>
main()
{FILE *fp;char c;
  fp=fopen("gauss.c","r+");
  while((c=getc(fp))!=EOF)
    {fseek(fp,-1,1);
     if(c<123&&c>94){c=toupper(c);}
        putc(c,fp);
     //fseek(fp,-1,1);
     }
 fclose(fp);
  fp=fopen("gauss.c","r");
  while((c=getc(fp))!=EOF)
   printf("%c",c);
 fclose(fp);
}  
     
