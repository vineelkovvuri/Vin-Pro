
//program to remove comments in a given C program
//ONLY for /**/  not for // as this is considered as C++ Comment lines 
#include<stdio.h>

main()
{
	FILE *fp = fopen("a.c","r");
	int c1 = 0,c2 = 0,k=0;

	while(!feof(fp))
	{
		c1 = fgetc(fp);
		if(c1=='/'){
			if(fgetc(fp) == '*')k=1;
			fseek(fp,-1,SEEK_CUR);
		}
		else if(c1=='*'){
			if(fgetc(fp) == '/'){k=0;c1 = fgetc(fp);}
		    fseek(fp,-1,SEEK_CUR);
		}
		if(k == 0)printf("%c",c1);
	}

	fclose(fp);
}
