#include<stdio.h>
#include<conio.h>
#include<string.h>

char gram[10][10]={ {'E','+','E','\0'},{'E','-','E','\0'},{'E','*','E','\0'},
	{'E','/','E','\0'},{'E','^','E','\0'},{'(','E',')','\0'},
	{'-','E','\0'},{'i','\0'} };

char tab[10][10]={ {'>','>','<','<','<','<','<','>','>','\0'},
	{'>','>','<','<','<','<','<','>','>','\0'},
	{'>','>','>','>','<','<','<','>','>','\0'},
	{'>','>','>','>','<','<','<','>','>','\0'},
	{'>','>','>','>','<','<','<','>','>','\0'},
	{'>','>','>','>','>',' ',' ','>','>','\0'},
	{'<','<','<','<','<','<','<','=',' ','\0'},
	{'>','>','>','>','>',' ',' ','>','>','\0'},
	{'<','<','<','<','<','<','<',' ',' ','\0'} };

char op[]={'+','-','*','/','^','i','(',')','$','\0'};
char prod[]={'E','E','E','E','E','E','E','E','\0'};
char str[20],midstr[20],fstr[20],str3[20],str2[20],temp[20];

void insert(char *s,char *ns)
{
	int a,b,i,p=-1;
	for(i=0;s[i+1]!='\0';i++)
	{
		a=value(s[i]);
		b=value(s[i+1]);
		ns[++p]=s[i];
		ns[++p]=tab[a][b];
	}
	ns[++p]='$';
	ns[++p]='\0';
}

void replace()
{
	char c;
	int i,j,k,r=-1,p=-1,s=-1;
	for(i=0;midstr[i]!='\0';i++)
	{
		if(midstr[i]=='>')
		{
			k=i-1;
			while(midstr[k]!='<') temp[++p]=midstr[k--];
			for(j=0;j<9;j++) if(strcmp(gram[j],temp)==0) fstr[++r]='E';
			for(j=0;j<20;j++) temp[j]='\0';
		}
		else if(midstr[i]=='/'|| midstr[i]=='^'|| midstr[i]=='+' ||
				midstr[i]=='*' || midstr[i]=='$'|| midstr[i]=='-') fstr[++r]=midstr[i];
	}
	fstr[++r]='\0';
	for(i=0;fstr[i]!='\0';i++) if(fstr[i]!='E') str2[++s]=fstr[i];
}

int value(char ch)
{
	switch(ch)
	{
		case '+': return 0;
		case '-': return 1;
		case '*': return 2;
		case '/': return 3;
		case '^': return 4;
		case 'i': return 5;
		case '(': return 6;
		case ')': return 7;
		case '$': return 8;
		default: return;
	}
}

main()
{
	int i;
	clrscr();
//	printf("\nProductions");
//	printf("\n---------------");
//	for(i=0;i<8;i++) printf("\n%c->%s",prod[i],gram[i]);
	printf("\nEnter the string with $ at start and end(ex: $i+i*i$) :");
	scanf("%s",str);
	insert(str,midstr);
	printf("\nThe string after insert: %s",midstr);
	replace();
	printf("\nThe string after replace: %s",fstr);
	printf("\nThe string after removing: %s",str2);
	insert(str2,str3);
	printf("\nThe string after inserting: %s",str3);
	for(i=0;str3[i]!='>';i++);
	printf("\n\nThe operator having the highest precedence is: %c",str3[i-1]);
	getch();
}


/*
INPUT
-----
Enter the string with $ at start and end(ex: $i+i*i$) : $i+i*i$

OUTPUT
------
The string after insert: $<i>+<i>*<i>$
The string after replace: $E+E*E$
The string after removing: $+*$
The string after inserting: $<+<*>$

The operator having the highest precedence is: *
*/


