//Program to check whether the given grammer is context free grammer or not..........
#include<stdio.h>
#include<string.h>
#include<ctype.h>
struct rule
{
	char *lhs,*rhs;
} gm[]={
	{"S","cAd"},		// S ::= cAd
	{"A","abB"},		// A ::= abB
	{"A","ed"},		    //    |  ed
	{"B","ac"},		    // B ::= ac
	{"B","ef"},		    //    |  ef
};
int nrules;
//rule 1 : Left side should contain only one Non Terminal symbol.....
int Rule1()
{
	int i;
	for(i=0;i<nrules;i++)
		if(!(gm[i].lhs[1] == '\0' && isupper(gm[i].lhs[0]) ))return 0;
	return 1;
}
//rule 2: Every Non Terminal that is present to the right side should have a production....
int Rule2()
{
	int i,j;
	for(i=0;i<nrules;i++)		  //for each and every rule.....
		for(j=0;gm[i].rhs[j];j++)  //for each and every character to the right side of a production....
			if(isupper(gm[i].rhs[j])) //if it is a non terminal....
				if(strchr("SAB",gm[i].rhs[j]) == NULL)//see whether that non terminal has a production....
					return 0;	  //if no production found implies the grammer is not context free.......so return 0
	return 1;
}
main()
{
	nrules = sizeof(gm)/sizeof(struct rule);

	if(Rule1()&&Rule2())printf("\nGiven Grammer is Context Free Grammer");
	else printf("\nGiven Grammer is Not Context Free Grammer");
}

