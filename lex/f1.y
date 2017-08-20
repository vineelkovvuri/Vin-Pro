%{

		#include<stdio.h>

		#include<stdlib.h>

%}



%token ALPHA ARTHOPT   BOOLEAN   BOOLLITERAL  CALLOUT   CHAR CLASS   CLOSEBRACE  CLOSEBRACKET CLOSEPARENTHESES   CONDOPT   DECIMALLITERAL  DIGIT ELSE   EQOPT EXTENDS   HEXLITERAL   IDENTIFIER   IF INT KEYWORD   NEW NUL OPENBRACE  OPENBRACKET  OPENPARENTHESES PUNCUTATION  RELOPT RETURN   SPACES STRING THIS   VOID   WHILE      SEMICOLON COLON EQUAL DOT COMMA



%% 

program : classdecl_list

		;

classdecl_list : classdecl

				| classdecl_list classdecl 

				;



classdecl : CLASS IDENTIFIER extenddecl OPENBRACE  body CLOSEBRACE { printf("OK");} 

		;	

body : empty
	 | vardecl_list methoddecl_list
	;
	
extenddecl : empty 

			| EXTENDS IDENTIFIER

			;



vardecl_list:
		
			 vardecl

			| vardecl_list vardecl

			;

				

vardecl : typedecl initializer_list  varparamdecl_sufix



varparamdecl_sufix: empty

				| SEMICOLON;





returntypedecl :

			 SPACES typedecl

			 |VOID 

			 ;


		


initializer_list : initializer 

				 |initializer_list COMMA initializer 

				 ;



typedecl : INT 

		 | BOOLEAN 

		 | IDENTIFIER

		 ;



initializer : 	IDENTIFIER  initializer_end ;



initializer_end : empty

				| OPENBRACKET optional_int_size CLOSEBRACKET 

				;

methoddecl_list: 

				 methoddecl

				| methoddecl_list methoddecl

				;

methoddecl:

			returntypedecl IDENTIFIER OPENPARENTHESES paramdecl_list CLOSEPARENTHESES block

			;

			



			 

paramdecl_list:

			vardecl

			| paramdecl_list vardecl

			;

			







block :

		OPENBRACE vardecl_list statement_list CLOSEBRACE ;



statement_list:

			IDENTIFIER EQUAL expr SEMICOLON 

			| method_call SEMICOLON 

			| IF OPENPARENTHESES expr CLOSEPARENTHESES block else_block

			| WHILE OPENPARENTHESES expr CLOSEPARENTHESES block

			| RETURN expr_opt SEMICOLON

			| block

			;



else_block : empty

			| ELSE block

			;

expr_opt : empty

		   | expr

		   ;



method_call :

			CALLOUT  OPENPARENTHESES STRING call_args_list_or_empty CLOSEPARENTHESES

			;

call_args_list_or_empty: empty

				| call_args_list 

				;			

call_args_list : call_arg

				| call_args_list COMMA call_arg 

				;

call_arg :

			expr

			|STRING

			;

				

expr :

	  NEW 	IDENTIFIER OPENPARENTHESES  CLOSEPARENTHESES

	 | literal

	 | expr binopt term

	 | OPENPARENTHESES  expr CLOSEPARENTHESES

	 ;

term :
	 |IDENTIFIER

	 |literal
	 ;

binopt : 

		ARTHOPT

		| RELOPT

		|EQOPT

		|CONDOPT

		;

	 

	 

literal :

		intliteral

		| CHAR 

		| BOOLLITERAL

		| NUL

		;

optional_int_size : empty

				| intliteral

				;

				

intliteral:  DECIMALLITERAL

			| HEXLITERAL

			;	

			

empty : ;

%% 





void yyerror(char *s) 

{ 

  printf("Error %s",s); 

}



int main() {

	yyparse();

} 