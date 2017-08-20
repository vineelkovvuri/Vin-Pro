%option noyywrap nodefault yylineno
%{
	#include "f1_tab.h"
	
	int yynumval=0;
%}
string						\"([^\"]|\\.)*\"
char						\'.{1}\'
arthopt						[\+|\*|\-|\/]
relopt						(\<=|\>=|\<|\>)
eqopt						(==|!=)
condopt						(&&|\|\|)
alpha						[a-zA-Z_]
digit						[0-9]
decimalliteral				[-]?{digit}{digit}*
hexdigit					({digit}|a|b|c|d|e|f|A|B|C|D|E|F)
hexliteral					0x{hexdigit}{hexdigit}*
intliteral					{decimalliteral}|{hexliteral}
boolliteral					true|false
semicolon					[;]
openbrace					\{
closebrace					\}
openparentheses				\(
closeparentheses			\)
openbracket					\[
closebracket				\]
identifier					[a-zA-Z_][[a-zA-Z0-9_]*
spaces						[ \t\n]+
comma						[,]
equal						=
dot 						\.
%%
dot 								{return DOT ;}
equal								{return EQUAL ;}
class	    						{return CLASS	;}		
extends	    						{return EXTENDS;}			
void	    						{return VOID	;}		
int		    						{return INT	;}			
boolean	    						{return BOOLEAN;}			
if		    						{return IF		;}		
else	    						{return ELSE	;}		
while 	    						{return WHILE 	;}		
return	    						{return RETURN	;}		
callout	    						{return CALLOUT;}			
new 	    						{return NEW 	;}		
this	    						{return THIS	;}		
nul		    						{return NUL	;}			
{openbrace}							{return OPENBRACE		 ;}
{closebrace}						{return CLOSEBRACE		 ;}
{openparentheses}					{return OPENPARENTHESES	 ;}
{closeparentheses}					{return CLOSEPARENTHESES ;}
{openbracket}						{return OPENBRACKET		 ;}
{closebracket}						{return CLOSEBRACKET	 ;}
{boolliteral}						{ return BOOLLITERAL;}
{string}				 			{ return STRING;}
{char}	 		 					{ return CHAR;}
{decimalliteral}					{ yynumval = atoi(yytext); return DECIMALLITERAL;}
{hexliteral}						{ yynumval = strtol(yytext,NULL,0); return HEXLITERAL;}
{identifier}						{ return IDENTIFIER;}
{arthopt}	 						{ return ARTHOPT;}
{relopt}	 						{ return RELOPT;}
{eqopt}		 						{ return EQOPT;}
{condopt}	 						{ return CONDOPT;}
{spaces}						
{semicolon}							{ return SEMICOLON;}
{comma}								{ return COMMA;}

%%

/*
main(int argc, char **argv)
{
	int tok;
	FILE *infile = fopen(argv[1], "r");
	yyrestart(infile);
	while(tok = yylex()) {
		printf("line no=%d, %d",yylineno, tok);
		switch(tok){
			case DECIMALLITERAL:
			case HEXLITERAL:
				printf(" = %d\n", yynumval);
				break;
			case STRING:
			case CHAR:
			case ARTHOPT:
			case RELOPT:
			case EQOPT:
			case CONDOPT:
			case KEYWORD:
			case SEMICOLON:
			case IDENTIFIER:
			case BOOLLITERAL:
				printf(" = %s\n", yytext);
				break;
			default:
				printf(" = %s\n", yytext);
				break;
		}
	}
	fclose(infile);
}

*/