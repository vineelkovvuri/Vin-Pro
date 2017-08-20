
#include<stdio.h>
#include<conio.h>
#include<string.h>

//#define isTerminal(x) ( First(x) == -1 )

struct Rule{
	char NonTer;
	char *produc;
};

struct Rule grammer[]={
	{'S',"cAd"},		// S ::= aAd
	{'A',"abB"},		// A ::= abB
	{'A',"ed"},			// 	  |  ed
	{'B',"ac"},			// B ::= ac
	{'B',"ef"},			//	  |  ef
};


struct token
{
	char token;
	int  terminal;		//1 if token is terminal else otherwise
}stack[10];

char input[10];
int lookahead=0;
int top = -1;
int error = 0;
int t,n;
int isTerminal(char c)
{
	int i , n ;
	n = sizeof(grammer)/sizeof(struct Rule);
	for(i = 0 ;i < n;i++)
	  if(grammer[i].NonTer == c) return -1;
      return 1;
}

//implement for grammers have two similar productions
int First(char alpha)
{
	int i , n ;
	n = sizeof(grammer)/sizeof(struct Rule);
	for(i = 0 ;i < n;i++)
	{
		if(grammer[i].NonTer == alpha)
					if(grammer[i].produc[0] == input[lookahead])return i;
	}

	return -1;			//epsilon production
}
//Pushes the production on to the stack in the reverse order
void Push(int index)
{
	int i;
	i = strlen(grammer[index].produc) - 1;
	while(i >= 0)
	{
		++top;
		if(isTerminal(grammer[index].produc[i]) == 1)stack[top].terminal = 1;
		else stack[top].terminal = 0;
		stack[top].token = grammer[index].produc[i];
		i--;
	}
}

//Pops the tokens from the stack
void Pop()
{
	while(top!=-1 &&lookahead < n && stack[top].terminal == 1){
		if(stack[top].token == input[lookahead]){--top; ++lookahead;}
		else {error = 1; return;}
	}
	if(top == -1) return;
	Push(First(stack[top--].token));   //Asumming no  productions
}

main()
{
	printf("\nEnter a string : ");
	scanf("%s",input);

	n = strlen(input);

	Push(First('S'));//Asumming no  productions

	while(top != -1 && !error )
		Pop();
	
	if(top == -1 && lookahead == n)printf("\n%s Valid",input);
	else printf("\n%s Not Valid",input);
}

