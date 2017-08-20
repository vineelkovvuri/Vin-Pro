

/*
ref: http://msdn2.microsoft.com/en-us/library/y39145bk(vs.80).aspx

C language Tokens
token: 
keyword 
identifier 
constant 
string-literal 
operator 
punctuator


operator: one of 
[ ]   ( )   .   –> ++       &   *   +   –   ~   !   sizeof/   %   <<   >>   <>   <=   >=   ==   !=   ^   |   &&   !!?   :=   *=   /=   %=   +=   –=   <<=   >>=   &=   ^=   |=,   #   ##

assignment-operator: one of
=   *=   /=   %=   +=   –=   <<=   >>= &=   ^=   |=

punctuator: one of
[ ]   ( )   { }   *   ,   :   =   ;   ...   #




 * This is a generalized program working for any kind of input( input C program).
 * It fails to recognise stdio.h in "#include<stdio.h>" as one token.
 * Instead it identifies stdio as Identifier, . as dot operator , h as Identifier.
 * this is becoz i considered .(dot) as a separator b/w tokens of structure variables

ex:
struct book
{
int price;
}b1;

b1.price;  //here dot is used as seperator b/w b1 token and price token.........

This program is not exactly correct.......
It neither parses the comments nor the header files.....

At first time if u get an error saying "Abnormal program termination"
simply reduce the TableSize macro value. Becoz TC cannot allocated more global memory...
*/


#include<stdio.h>
#include<string.h>
#include<conio.h>

//===============================================================================================

#define true 1
#define false 0

//simple macros for moving back and front in the file
#define MoveFront(units)  fseek(fp,+(units),SEEK_CUR)
#define MoveBack(units)   fseek(fp,-(units),SEEK_CUR)

//Token Table size
#define TableSize 		9144

//===============================================================================================

//used to open the file
int FileOpen(const char * path);

//Core function which splits the given program in to tokens....
int CreateTokens();

//forms the token string based on the starting(start) of file pointer
//position and ending(end) of file pointer position of the token
void GetToken(int start,int end);

//recognises whether the formed token as keyword,identifier, numeric constant,.......
void IdentifyTokenType(int index);

int EOFReached();
//===============================================================================================
//Keywords are arranged in such a way that most frequently used onces come first.....
//So that the comparison b/w retrieved tokens and keywords become more efficient....
const char *keywords[]=
{
	"int",		"char",		"double",	"float",
	"if",		"else",		"for",		"while",
	"return",	"switch",	"case",		"break",
	"do",		"default",	"void",		"struct",
	"long",		"const",	"static",	"union",
	"enum",		"register",	"short",	"unsigned",
	"continue",	"goto",		"sizeof",	"signed",
	"auto",		"volatile",	"typedef",	"extern",
};
//===============================================================================================
const char *preprocess[]=
{
	"#define", "#include",   // here rest of the preprocessors can be included too.............
};

//===============================================================================================
struct TokenEntry
{
	int start,	//start contains starting of token's file pointer position....
		end;	//end contains one more than the ending of token's file pointer position....
	char * type;	//Type of the token ,whether it is identifier ,keyword,numeric constant....
}tokenTable[TableSize]; //TableSize is the TC limit of TokenArray  :(

//===============================================================================================
struct DelimEntry
{
	char * delim;	//delimiters .... 	"[","{"....
	char * type;	//delimiter's name ................"LSquare","LBrace"....
};

//===============================================================================================
//These are the delimiters in C language........(Not all of them are called as Delimiters...)
struct DelimEntry const DelimTable[]=
{
	//Single Character Delimiters   //Set 1
	{"[","LSquare"},				//0
	{"]","RSquare"},				//1
	{"(","LParen"},
	{")","RParen"},
	{"{","LBrace"},
	{"}","RBrace"},
	{",","Comma"},
	{";","SemiColon"},
	{":","Colon"},
	{"?","QuestionMark"},
	{"~","BitwiseNOT"},
	{".","Dot"},					//11

	//Singles in triple character delimiters.... //Set 2
	//When ever u encounter a Set 2 character ....
	//U cannot confirm it as "Singles in triple character delimiters"
	//U need to check for its next character also.....
	//similarly When ever u encounter a Set 3 character ....
	//U need to check for its next character also.....
	//
	{"<","LessThan"},				//12
	{">","GreaterThan"},
	{"&","BitwiseAND"},
	{"|","BitwiseOR"},
	{"^","XOR"},
	{"=","Assignment"},
	{"!","Not"},
	{"%","Remainder"},
	{"-","Minus"},
	{"+","Plus"},
	{"*","Multiply"},
	{"/","DividedBy"},			//23

	//Doubles in triple character delimiters.... //Set 3
	{"<<","LeftShift"},			//24
	{"<=","LessThanOrEqual"},
	{">>","RightShift"},
	{">=","GreaterThanOrEqual"},
	{"&&","LogicalAND"},
	{"&=","BitwiseANDEqual"},
	{"||","LogicalOR"},
	{"|=","BitwiseOREqual"},
	{"^=","XOREqual"},
	{"==","LogicalEqual"},
	{"!=","LogicalNotEqual"},
	{"%=","RemainderEquals"},
	{"-=","MinusEquals"},
	{"->","PointerArrow"},
	{"--","DecrementOperator"},
	{"++","IncrementOperator"},
	{"+=","PlusEquals"},
	{"*=","MultiplyEquals"},
	{"/=","DividedByEquals"},		//42

	//Triples in triple character delimiters....  //Set 4
	{"<<=","LeftShiftEquals"},	//43
	{">>=","RightShiftEquals"},	//44

};
//===============================================================================================
FILE * fp = NULL;
int index;	      //Variable used to iterate over the tokenTable Array..........
char buf[200];	      //temporary variable to hold the token string........
//===============================================================================================
main(int argc , char *argv[] )
{
	int i;
	if(!FileOpen(argv[1])){
		printf("\nUnable to Open the File : %s",argv[1]);
		return;
	}
	if(!CreateTokens()){
		//It is the problem of TC ..... :(
		printf("\nUnable to Create Tokens - May be the given program contains tokens more than the maximum token table size");
		return;
	}

	//Printing the Created Tokens..........
	printf("\n%-5s %-16s %-18s %-8s %-8s\n","No","Token","Token Type","Begin","End");
	printf("============================================================");
	for(i=0 ; i<index;i++){
		GetToken(tokenTable[i].start,tokenTable[i].end);
		IdentifyTokenType(i);
		printf("\n%-5d %-16s %-18s %-6d %-6d",i,buf,tokenTable[i].type,tokenTable[i].start,tokenTable[i].end);
	}
}
//===============================================================================================
void IdentifyTokenType(int index)
{
	int no,i;
	if(strcmp(tokenTable[index].type ,"Unknown")==0)
	{
		//determining keywords present in tokens
		no = sizeof(keywords)/sizeof(int);
		for(i = 0;i<no;i++)
			if(strcmp(buf,keywords[i]) == 0){
				tokenTable[index].type = "Keyword";
				return;
			}

		//determining identifiers present in tokens
		if((buf[0]>='a'&&buf[0]<='z')||	(buf[0]>='A'&&buf[0]<='Z')||buf[0] == '_'){
			tokenTable[index].type = "Identifier";
			return;
		}


		//determining Preprocessor directives..
		no = sizeof(preprocess)/sizeof(int);
		for(i = 0;i<no;i++)
			if(strcmp(buf,preprocess[i]) == 0){
				tokenTable[index].type = "Preprocessor";
				return;
			}

		//Determining String Literals
		if(buf[0] == '"' && buf[strlen(buf)-1] == '"'){
			tokenTable[index].type = "String Literal";
			return;
		}
		//Determining Char Literals


		//Determining Numeric constants
		for(i=0;buf[i]!='\0';i++)
			if(!(buf[i]>='0'&&buf[i]<='9'))return;
		tokenTable[index].type = "Numeric Constant";
		return;
	}
}
//===============================================================================================
void GetToken(int start,int end)
{
	int i=0;
	fseek(fp,start,SEEK_SET);
	while(i<end-start)
		buf[i++] = fgetc(fp);

	buf[i] = '\0';
	//Trim trailing newline chars....
	for(i--;i>=0;i--)
		if(buf[i] == '\n')buf[i] = '\0';
}
//===============================================================================================
int EOFReached()
{
	return feof(fp) != 0;
}

//===============================================================================================
//Implements the state machine for splitting the given program(input) in to tokens...............
int CreateTokens()
{
	int  i=0,j=0,k=0;
	char c[4]={'\0','\0','\0','\0'}; //Array holding temporary characters.....
	do{
		//state1
		c[0] = fgetc(fp);

		//--------													//Path A
		if(c[0] == ' ' || c[0] == '\t' || c[0] == '\n' || EOFReached()) goto End;

		/*
		//-------- Skipping the comments.....
		if(c[0] == '/')
		{
		c[1] = fgetc(fp);
		//Skipping // type of comments..............
		if(c[1] == '/')
		{
		do 
		c[2] = fgetc(fp);
		while(c[2]!='\n'&&!EOFReached());
		goto End;
		}
		//Skipping /* type of comments..............
		else if(c[1] == '*')
		{
		do{
		c[1] = fgetc(fp);
		c[2] = fgetc(fp);
		ungetc(c[2],fp);
		}while((c[1] != '*' || c[2] != '/')&&!EOFReached());
		goto End;
		}
		MoveBack(1);
		}
		*/
		MoveBack(1);
		tokenTable[index].start = ftell(fp);
		MoveFront(1);

		//String literals
		if(c[0] == '"'){
			do{
				c[1] = fgetc(fp);
				if(c[1] =='\\') { fgetc(fp); c[1] = fgetc(fp);}		//skip \" character in b/w a string literal
			}while(c[1] != '"'&&!EOFReached());
			tokenTable[index].type = "Unknown";
			tokenTable[index++].end = ftell(fp);
			goto End;
		}	
		//--------
		for(i=0;i<12;i++)
		{
			if(strcmp(DelimTable[i].delim,c) == 0)					//Path B
			{
				tokenTable[index].type = DelimTable[i].type;
				tokenTable[index++].end = ftell(fp);
				goto End;
			}
		}

		//--------
		for(i=12;i<24;i++)
		{
			//Checking for single char in triples
			if(strcmp(DelimTable[i].delim,c) == 0)					//Path C
			{
				c[1] = fgetc(fp);									//State	2
				for(j=24;j<43&&!EOFReached();j++)
				{
					//Checking for double char in triples
					if(strcmp(DelimTable[j].delim,c) == 0)			//Path E
					{
						c[2] = fgetc(fp);							//State 3
						for(k=43;k<45&& !EOFReached();k++)
						{	//Checking for triplets in triples
							if(strcmp(DelimTable[k].delim,c) == 0)	//Path G
							{
								tokenTable[index].type = DelimTable[k].type;
								tokenTable[index++].end = ftell(fp);
								goto End;
							}
						}
						//Path F
						if(!EOFReached())MoveBack(1);
						tokenTable[index].type = DelimTable[j].type;
						tokenTable[index++].end = ftell(fp);
						goto End;
					}
				}
				//Path D
				if(!EOFReached())MoveBack(1);
				tokenTable[index].type = DelimTable[i].type;
				tokenTable[index++].end = ftell(fp);
				goto End;
			}
		}
		//---------
		do{
			//Path H
			c[0] = fgetc(fp);										//State 4
			//Path I
			//Checking for White Spaces
			if(c[0] == ' ' || c[0] == '\t' || c[0] == '\n' ||EOFReached())
			{
				if(!EOFReached())	MoveBack(1);
				tokenTable[index].type = "Unknown";
				tokenTable[index++].end = ftell(fp);
				goto End;
			}
			//Checking for Single char Delims  //Checking for Single char Delims in triplets
			for(i=0;i<24;i++)
				if(strcmp(DelimTable[i].delim,c) == 0)
				{
					MoveBack(1);
					tokenTable[index].type = "Unknown";
					tokenTable[index++].end = ftell(fp);
					goto End;
				}

		}while(!feof(fp));

End:
		c[0] = c[1] = c[2] = c[3] = '\0';
	}while((!feof(fp))&&index<TableSize);

	//Tokens May(Not) be Ready
	return index < TableSize;
}

//===============================================================================================
int FileOpen(const char *path)
{
	fp = fopen(path,"r");
	if(fp == NULL) return false;
	return true;
}
//===============================================================================================
