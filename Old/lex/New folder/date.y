%{
#include<stdio.h>
#include<stdlib.h>

%}
%token NUMBER  SLASH  NL 

%% 
stat : date;
date: NUMBER SLASH NUMBER SLASH NUMBER  {printf("OK"); } 
 ; 
 
%% 

void yyerror(char *s)
{
	printf("\n%s",s);
}

int main()
{
	yyparse();
}

