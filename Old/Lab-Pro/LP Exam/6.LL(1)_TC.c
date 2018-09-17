//Implementation of LL(1) Parser and its First and Follow routines
#include<stdio.h>
#include<string.h>
#include<conio.h>
struct Rule{
	char NonTer,*Prod;
}Grammer[]={
	{'E',"TX"},		//E  -> TE'
	{'X',"+TX"},		//E' -> +TE'
	{'X',"#"},		//   | epsilon
	{'T',"FY"},		//T  -> FT'
	{'Y',"*FY"},		//T' -> *FT'
	{'Y',"#"},		//   | epsilon
	{'F',"(E)"},		//F  -> (E)
	{'F',"i"},		//    | id
};
//Structure for an Entry in First Follow Table .....
struct FFTableEntry{
	char NonTer;
	int nFirst,nFollow;
	struct {
		char c;
		int prodID;	//prodID contains the production number
   				//whose First and Follow lead to the terminal c
	}First[10],Follow[10];
}FFTable[]={{'E'},{'X'},{'T'},{'Y'},{'F'}};
//Structure for an Entry in Stack .....
char Stack[100];
char ParseTable[10][10],t[10];
int nRules,nFFTable,index,top=-1;
int GetIndex(char _char,int flag)
{
	int i;
	if(flag == 0){	//Returns the index of the Non Terminal _char in FFTable.
		for(i = 0;i < nFFTable; i++)
			if(FFTable[i].NonTer == _char)return i;
	}
	else if(flag == 1){//Returns the index of the Non Terminal _char in Grammer.
		for(i = 0;i < nRules; i++)
			if(Grammer[i].NonTer == _char)return i;
	}
	else {			   //Returns the index of the Terminal _char in ParseTable.
		for(i = 0 ;ParseTable[0][i] != '\0';i++)
			if(ParseTable[0][i] == _char) return i;
	}
	return -1;
}
void First(int i)
{
	//If Grammer[i].Prod[0] is Non Terminal, call First(index) recursively
	//with index as the Grammer[i].Prod[0]'s ID.....
	if(Grammer[i].Prod[0] >= 'A' && Grammer[i].Prod[0] <= 'Z'){
		int temp;
		temp = GetIndex(Grammer[i].Prod[0],1);
		do
			First(temp++);
		while( temp < nRules && Grammer[temp].NonTer == Grammer[i].Prod[0]);
	}
	//Else update the terminals in FFTable..............
	else {
		int idx;
		idx = GetIndex(Grammer[index].NonTer,0);
		FFTable[idx].First[FFTable[idx].nFirst].c = Grammer[i].Prod[0];
		FFTable[idx].First[FFTable[idx].nFirst++].prodID = index;
	}
}

int IsEpsilon(int temp)
{
	int i;
	for(i = 0;i < FFTable[temp].nFirst;i++)
		if(FFTable[temp].First[i].c == '#')return 1;
	return 0;
}

void CreateParseTable()
{
	int i,j,k;
	for(i = 0;i < nFFTable;i++)
		for(j = 0; FFTable[i].First[j].c != '\0' ; j++)
			if(FFTable[i].First[j].c != '#'){
				int idx = GetIndex(FFTable[i].First[j].c,2);
				ParseTable[i+1][idx] = FFTable[i].First[j].prodID;
			}
			else for(k = 0;FFTable[i].Follow[k].c != '\0';k++){
				int idx = GetIndex(FFTable[i].Follow[k].c,2);
				ParseTable[i+1][idx] = FFTable[i].First[j].prodID;
			}
}

void Follow(char X)
{
	int i,j,k,idx,temp;
	char *c;
	idx = GetIndex(X,0);
	for(i = 0; i < nRules; i++)
		//c gets a pointer to the NonTerminial X
		if((c = strchr(Grammer[i].Prod,X))!=NULL){
			++c;	//move c to the next character of X
			if(*c >= 'A' && *c <= 'Z'){
				//If A -> aBC , then First(C) is added to Follow(B)
				//First of b in A -> aBb
				if(strchr(t,*c) == NULL){ //Avoids duplication.....
					temp = GetIndex(*c,0);
					for(j = 0;FFTable[temp].First[j].c != '\0';j++)
						if(FFTable[temp].First[j].c != '#'){
							FFTable[idx].Follow[FFTable[idx].nFollow].c =
							   	FFTable[temp].First[j].c;
							FFTable[idx].Follow[FFTable[idx].nFollow++].prodID =
							   	FFTable[temp].First[j].prodID;
						}
					//If C -> # i.e., first(C) contains epsilon, 
					//then effectively(A is) A -> aB so we add Follow(A) to Follow(B)
					if(IsEpsilon(temp)){
						if(Grammer[i].NonTer != X){
							temp = GetIndex(Grammer[i].NonTer,0);
							//Copying Follow(A) to Follow(B)
							for(k = 0 ;k < FFTable[temp].nFollow;k++){
								FFTable[idx].Follow[FFTable[idx].nFollow].c = 
									FFTable[temp].Follow[k].c;
								FFTable[idx].Follow[FFTable[idx].nFollow++].prodID = 
									FFTable[temp].Follow[k].prodID;
							}
						}
						t[strlen(t)+1] = '\0';
						t[strlen(t)] = *c;
					}
				}
			}
			else if(*c != '\0'){
				//Terminal..i.e., A -> aBb , so b itself is the follow of B
				FFTable[idx].Follow[FFTable[idx].nFollow].c = *c;
				FFTable[idx].Follow[FFTable[idx].nFollow++].prodID = i;
			}
			else 	//*c is \0 i.e., A -> aB , so Follow(A) is added to Follow(B)
				if(Grammer[i].NonTer != X){
					temp = GetIndex(Grammer[i].NonTer,0);
					for(k = 0;k < FFTable[temp].nFollow;k++){
						FFTable[idx].Follow[FFTable[idx].nFollow].c =
						   	FFTable[temp].Follow[k].c;
						FFTable[idx].Follow[FFTable[idx].nFollow++].prodID = 
							FFTable[temp].Follow[k].prodID;
					}
				}
		}
}
//Function to print the elements present on the stack.......
void PrintStack()
{
	int i;
	printf("\n");
	for(i = 0;i <= top;i++)
		printf("%c",Stack[i]);
	printf("\t|");
}
int main()
{
	int i,j,k;
	char buf[100]; //Contains the Input Language.....
	//Calculate number of rules in the Grammer and number of FFTable entries...
	clrscr();
	nRules = sizeof(Grammer)/sizeof(struct Rule);
	nFFTable = sizeof(FFTable)/sizeof(struct FFTableEntry);
	//Construct First(alpha)
	for( i = 0; i <	nRules; i++)
		First(index = i);
	printf("\nEnter the language : ");
	scanf("%s",buf);
	//Construct Follow(X)
	//$
	FFTable[0].Follow[0].c = '$';
	FFTable[0].Follow[0].prodID = -1;
	FFTable[0].nFollow++;
	for( i = 0; i <	nFFTable; i++){
		strcpy(t,"");
		Follow(FFTable[i].NonTer);
	}
	//Finding the Terminals present in the given Grammer....
	for(i = 0;i < nRules;i++)
		for(j = strlen(Grammer[i].Prod) - 1;j >= 0; j--)
			if((!isupper(Grammer[i].Prod[j])) && Grammer[i].Prod[j] != '#')
				if(strchr(ParseTable[0] , Grammer[i].Prod[j] ) == NULL){
					ParseTable[0][strlen(ParseTable[0])+1] = '\0';
					ParseTable[0][strlen(ParseTable[0])] = Grammer[i].Prod[j];
				}
	ParseTable[0][strlen(ParseTable[0])+1] = '\0';
	ParseTable[0][strlen(ParseTable[0])] = '$';
	for(i = 1;i < 10;i++)
		for(j = 0;j < 10;j++)
			ParseTable[i][j] = -2;
	//Prepare Parse Table.....
	CreateParseTable();
	//Printing Header of the First and Follow Table
	printf("\n%6s|%6s|%7s","NonTer","First","Follow");
	printf("\n==============================================");
	//Printing First and Follow FFTable
	for( i = 0; i <	nFFTable; i++){
		printf("\n%5c | ",FFTable[i].NonTer);
		for(j=0;j<FFTable[i].nFirst;j++)
			printf("%c ",FFTable[i].First[j].c);
		printf(" | ");
		for(k = 0;k < FFTable[i].nFollow;k++)
			printf("%c ",FFTable[i].Follow[k].c);
	}
	//Printing Header of the ParseTable
	printf("\n\n\n\t");
	for(j = 0;ParseTable[0][j] != '\0' ; j++)
		printf("%5c | ",ParseTable[0][j]);
	printf("\n=======================================================\n");
	//Printing the ParseTable
	for(i = 1;i <= nFFTable;i++){
		printf("%-5c | ",FFTable[i-1].NonTer);
		for(j = 0;ParseTable[0][j] != '\0'; j++)
			if(ParseTable[i][j] != -2)
				printf("%5s | ",Grammer[(int)ParseTable[i][j]].Prod);
			else printf("%5s | ","");
		printf("\n");
	}
	//Implementation of Stack........
	printf("\n\n%7s |%10s |%7s","STACK","INPUT","OUTPUT");
	printf("\n========================================");
	Stack[++top] = '$';
	Stack[++top] = Grammer[0].NonTer;
	PrintStack();
	printf("%10s | ",buf);
	i=0;//To refer the input string...
	while(Stack[top] != '$')
	{
		if(!(Stack[top]>='A' &&Stack[top]<='Z')){
			if(buf[i] == Stack[top]){
				i++;top--;
				PrintStack();
				printf("%10s | ",&buf[i]);
			}
		}
		else {	//if the top points to a Non terminal........
			int idx,idx2;
			idx2 = GetIndex(buf[i],2); // Is input symbol valid....
			if(idx2 == -1) {	//Invalid symbol found in the input......
				printf("\n%s is not a valid input....",buf);
				exit(0);
			}
			//Valid symbol found in the input.....
			//Push the production of that input symbol on to the stack.....
			idx = ParseTable[GetIndex(Stack[top],0)+1][idx2];
			if(idx != -2){	//Found a valid Terminal.....
				char temp;
				temp = Stack[top--];
				//Push the production on the stack
				if(Grammer[idx].Prod[0] != '#')				
					for(j = strlen(Grammer[idx].Prod) - 1;j>=0;j--)
						Stack[++top] = Grammer[idx].Prod[j];
				PrintStack();
				printf("%10s | %c -> %s ",&buf[i],temp , Grammer[idx].Prod);
			}
			else {//No prod.. exists in the parse table for the given input symbol
				printf("\n\n%s is Not a valid language for the given grammer",buf );
				getch();
				exit(1);
			}
		}
	}
	printf("\n\n%s is %s a valid language for the given grammer",
			buf, buf[i] != '$' ? "Not" : "");
	getch();
}
/* Input:
   Enter the language string : i+i*i$
   Output:   
   NonTer|  First |  Follow
   ==============================================
   E     | ( i    | $ )
   X     | + #    | $ )
   T     | ( i    | + $ )
   Y     | * #    | + $ )
   F     | ( i    | * + $ )

	 |     + |     * |     ) |     ( |     i |     $ |
   ================================================================
   E     |       |       |       |    TX |    TX |       |
   X     |   +TX |       |     # |       |       |     # |
   T     |       |       |       |    FY |    FY |       |
   Y     |     # |   *FY |     # |       |       |     # |
   F     |       |       |       |   (E) |     i |       |

   STACK|     INPUT |    OUTPUT
   =========================================================
   $E	|    i+i*i$ |
   $XT	|    i+i*i$ | E -> TX
   $XYF	|    i+i*i$ | T -> FY
   $XYi	|    i+i*i$ | F -> i
   $XY	|     +i*i$ |
   $X	|     +i*i$ | Y -> #
   $XT+	|     +i*i$ | X -> +TX
   $XT	|      i*i$ |
   $XYF	|      i*i$ | T -> FY
   $XYi	|      i*i$ | F -> i
   $XY	|       *i$ |
   $XYF*|       *i$ | Y -> *FY
   $XYF	|        i$ |
   $XYi	|        i$ | F -> i
   $XY	|         $ |
   $X	|         $ | Y -> #
   $	|         $ | X -> #

   i+i*i$ is  a valid language for the given grammer

*/

