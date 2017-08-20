//Program to implement Brute Force(Top Down) Parsing technique.
#include<stdio.h>
#include<string.h>
#include<conio.h>

char *gm[]={
	"ScAd",		// S ::= cAd
	"AabB",		// A ::= abB
	"Aed",		//    |  ed
	"Bac",		// B ::= ac
	"Bef",		//    |  ef
};
char stack[30], input[10];
int next=0,top=-1,error=0,n;
//first(alpha) implementation for Predictive Grammer
int first(char alpha)
{
	int i,n;
	n = sizeof(gm)/sizeof(int);
	for(i = 0 ;i < n;i++)
		if(gm[i][0] == alpha)
			if(gm[i][1] == input[next])return i;
	return -1;			//no production
}
//pushes the production on to the stack in the reverse order
void push(int index)
{
	int i;
	i = strlen(gm[index]) - 1 ;
	while(i > 0)
		stack[++top] = gm[index][i--];
}
//pops the tokens from the stack
void pop()
{
	int i=0;
	while(top!=-1 &&next < n && stack[top]>='a' && stack[top]<='z')
		if(stack[top] == input[next]){--top; ++next;}
		else {error = 1; return;}

	if(top == -1||next==n) return;

	i = first(stack[top--]);
	if(i == -1){error =1 ;return;}
	push(i);   //Asumming no  productions
}

main()
{
	clrscr();
	printf("\nEnter a string : ");
	scanf("%s",input);
	n = strlen(input);
	push(first('S'));//Asumming no  productions
	while(next!=n&&top != -1 && !error )pop();

	if(top == -1 && next == n)
		printf("\n%s is valid language for the Grammer",input);
	else
		printf("\n%s is not valid language for the Grammer",input);
	getch();
}

/*
Input: 
Enter a string : cabacd
Output:
cabacd is valid language for the Grammer
*/

