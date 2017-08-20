//PRogram for lexical analysis(simplified and cutshorted)....
//Please create a file 'test.c' in 'bin' directory of TC folder 
//which contain some sample c code like
// main()
// {
// int a , b,c;
// c = a+b;
// }
//Make sure test.c contain simple statements.....
//doesnot include header files and operators other than delim[30] array(see below) 

#include<stdio.h>
#include<string.h>
//When u r adding a new delimiter to delims[30]
//plz add a case statement to that delimiter in printDelimType function....
char delims[30]=" ,+-*/={}();";
char *keywords[]={"int","if","char",};//rest of the keywords can be included.....
int isDelim(char c)
{
	int i=0;
	for(;delims[i];i++)
		if(c == delims[i])return 1;
	return 0;
}
void printDelimType(int c)
{
	switch(c)
	{
		case ',' : printf("Comma");break;
		case '+' : printf("Plus");break;
		case '-' : printf("Minus");break;
		case '*' : printf("Multiply");break;
		case '/' : printf("Divide");break;
		case '{' : printf("LBrace");break;
		case '}' : printf("RBrace");break;
		case '(' : printf("LParen");break;
		case ')' : printf("RParen");break;
		case '=' : printf("Equal");break;
		case ';' : printf("Semicolon");break;
	}
}
void printIdenType(char *c)
{
	int i=0,n;
	n = sizeof(keywords)/sizeof(int);
	for(;i<n;i++)
		if(strcmp(c,keywords[i]) == 0){printf("Keyword");return;}
	printf("Identifier");
}
main()
{
	int c,i;
	char iden[400];
	FILE *fp = fopen("test.c","r");
	if(fp!=NULL){
		while((c = fgetc(fp))!=EOF)
		{
			if(c == '\t' || c == '\n')continue;
			if(!isDelim(c)){
				i=0;
				do{
					iden[i++] = c;
					c = fgetc(fp);
				}while(!isDelim(c)&&c!=EOF);
				ungetc(c,fp);
				iden[i] = 0;
				printf("\n%s    ",iden);
				printIdenType(iden);
			}
			else{
				if(c!=' '){
					printf("\n%c     ",c);
					printDelimType(c);
				}
			}
		}
		fclose(fp);	
	}
}

/*
OUTPUT:
main    Identifier
(     LParen
)     RParen
{     LBrace
int    Keyword
a    Identifier
,     Comma
b    Identifier
,     Comma
c    Identifier
;     Semicolon
c    Identifier
=     Equal
a    Identifier
+     Plus
b    Identifier
;     Semicolon
}     RBrace
*/
