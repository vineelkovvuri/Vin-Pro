%{ 
#include "date_tab.h" 
%} 
 
%% 
[0-9]+ {printf("\n%s\n",yytext); return NUMBER; }
\/	   {printf("\n%s\n",yytext); return SLASH; }
\n 	{printf("\n%s\n",yytext); return NL;}

%% 

