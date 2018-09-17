#include<stdio.h>
#include<stdlib.h>

int main()
{
	int c;		
	FILE * out,*in = fopen("in.txt","r");
	out = fopen("out.txt","w");

	while((c = fgetc(in))!= EOF)
		fputc(c,out);

	fclose(in);
	fclose(out);
}

