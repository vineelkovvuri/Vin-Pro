//Program to eliminate Left Recursion(Immediate) in a given Grammer. 
//Formula
//A->Aa|b        Left Recursive Grammer
//A->bA'         Converted Grammer
//A'->aA'|eps    

//Enter input E->E+T|T as EE+T|T 
//similarly   F->(E)|i should be entered as F(E)|i 

#include<stdio.h>
#include<string.h>
#include<conio.h>
main()
{
	int i=0,j,n;
	char gm[10]={0};
	clrscr();
	printf("\nEnter a rule(ex: E->E+T|T should be entered as EE+T|T ) :");
	scanf("%s",gm);

	if(gm[0] == gm[1])  //Left Recursive Grammer....
	{
		printf("\nGrammer after eliminating left recursion is:");
		//printing A -> bA'   A'-> 
		printf("\n%c->%s%c'\n%c'->",gm[0],strchr(gm,'|')+1,gm[0],gm[0]);
		//printing text up to |
		i=2;
		while(gm[i]!='|')printf("%c",gm[i++]);
		//printing A'|eps
		printf("%c'|eps",gm[0]);
	}
	else
	{
		printf("\nGiven grammer is not left recursive:");
		//Not a Left Recursive Grammer.....
		printf("\n%c->%s",gm[0],&gm[1]);//printing F->(E)|i
	}
	getch();
}

/*
INPUT:	
Enter a rule(ex: E->E+T|T should be entered as EE+T|T ) : EE+T|T

OUTPUT:
Grammer after eliminating left recursion is:
E->TE'
E'->+TE'|eps
*/

