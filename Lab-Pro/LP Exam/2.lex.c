//PRogram for lexical analysis(simplified)....
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
#include<conio.h>

#define isDelim(c) strchr(delims,c)

//When u r adding a new delimiter to delims[30]
//plz add a case statement to that delimiter in printDelimType function....
char delims[30]=" ,+-*/={}();\t\n";
char *keywords[]={"int","if","char",};//rest of the keywords can be included.....
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
	if(c[0]>='0' &&c[0]<='9'){printf("Number");return;} //number
	n = sizeof(keywords)/sizeof(int);
	for(;i<n;i++)						//keyword
		if(strcmp(c,keywords[i]) == 0){printf("Keyword");return;}
	printf("Identifier");					//Identifier
}
main()
{
	int c,i;
	char iden[400];
	FILE *fp = fopen("test.c","r");
	clrscr();
	//freopen("output.txt","w",stdout);
	if(fp!=NULL){
		while((c = fgetc(fp))!=EOF)
		{
			if(!isDelim(c)){  // if c is not a delimiter. 
				i=0;	  //then c may be either identifier or a keyword..... 	
				do
					iden[i++] = c;
				while(!isDelim(c = fgetc(fp))&&c!=EOF);
				iden[i] = 0;
				printf("\n%-10s",iden);
				printIdenType(iden);
				ungetc(c,fp);
			}
			else{
				if(c!=' '&&c!='\n'&&c!='\t'){
					printf("\n%-10c",c);
					printDelimType(c);
				}
			}
		}
		fclose(fp);	
	}
	getch();
}

/*
OUTPUT:
main      Identifier
(         LParen
)         RParen
{         LBrace
int       Keyword
a         Identifier
,         Comma
b         Identifier
,         Comma
c         Identifier
;         Semicolon
c         Identifier
=         Equal
a         Identifier
+         Plus
b         Identifier
;         Semicolon
}         RBrace
*/
