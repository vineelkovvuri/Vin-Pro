/*                        TYPE TUTOUR PROGRAM
 *							       BY VINEEL */
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
/********************************************************************************/
/*USER DEFINED FUNCTIONS*/
void a(char *);
void design();
void  next_round();
void Graph(int );
void Game();
void help();
/**********************************************************************************/
/*EXTERNAL VARIABLES*/
int x[26]={0},count,lesson;
char y[]={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','\0'};
/*********************************************************************************/
void help()
{
	clrscr();
	printf("\n                              TYPE MASTER\n");
	printf("\n\n\n1.Enter a number in between 1 and 10 (including bounds) if you");
	printf("\n\n  want to get practiced with the keyboard.");
	printf("\n\n  The number entered by you indicates the lesson you wanted to");
	printf("\n\n  practice .The tufness of the lesson increases with the lesson");
	printf("\n\n  number.");
	printf("\n\n\n2.While you are typing the lesson if you do any misstakes there is");
	printf("\n\n  no need for you to use back space the program will automatically");
	printf("\n\n  shift's the cursor one step backward and it alert's you with a");
	printf("\n\n  beep sound.");
	printf("\n\n\n4.If you want to play a game with the alphabets then press 2 ");
	printf("\n\n  and enter key.While the alphabets are randomly generated you should");
	printf("\n\n  be able to press the exact alphabet from the keyboard and if the ");
	printf("\n\n  key pressed is equal to the alphabet generated at that instance");
	printf("\n\n  then you will here a beep sound.To quit from this game press ZERO");
	printf("\n\n\n5.After either of the above is over one graph will be displayed");
	printf("\n\n  and this tell you the misstakes  you committed.");
	printf("\n\n\nTO QUIT THIS HELP AND RETURN BACK PRESS ANY KEY");
	while(!kbhit());
}
/*********************************************************************************/
/*FUNCTION TO PREPARE THE VARIABLES TO NEXT ROUND*/
void  next_round()
{  int i;char c;
	flushall();
	for(i=0;i<26;i++)x[i]=0;count=0;
	if(++lesson!=11){printf("\n\nWould you like to continue(y/n):");
		c=getch();
		if(c=='y')main();
		else {a("hai my name is vineel.....");exit(0);}
	}
	else {a("hai my name is vineel.....");exit(0);}
}
/******************************************************************************/
/*FUNCTION TO DRAW THE GRAPH OF USER'S PROGRESS*/
void Graph(int ch)
{
	int i=0,k=0,j=0;
	flushall();
	for(i=0;i<25;i++)
		if(x[k]<x[i+1])k=i+1;
	if(ch==2||ch==3)clrscr();
	printf("\n\nPractice more on these alphabet(s)\n");
	printf("\n\n");
	for(j=x[k];j>0;j--)
	{for(i=0;i<26;i++)
		{if(x[i]==x[k]){printf("\"  ");if(i-k)x[i]--;}
			else printf("   ");}
			x[k]--;  printf("\n");
	}
	printf("\n----------------------------------------------------------------------------");
	printf("\na  b  c  d  e  f  g  h  i  j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z\n\n\n");
	for(i=1;i<5;i++)                  // total number of mistakes
	{
		delline();
		delay(400);
		printf("\rmisstakes=%d",count);
		delay(350);
	}
}
/***************************************************************************/
/* RANDOM ALPHABETS GAME- FUNCTION */
void Game()
{ char c;int k;
	count=0;
	clrscr();
	gotoxy(40,50);
	printf("\nPRESS ZERO TO QUIT");
	gotoxy(1,1);
	while(c!='0')
	{ while(!kbhit())
		{
			gotoxy(random(80),random(48));
			k=random(26);
			printf("%c",y[k]);
			sleep(1);
		}
		c=getch();
		fflush(stdin);
		if(c=='0')exit(0);
		else
		{if(y[k]==c){sound(420);delay(50);nosound();}
			else {x[(int)(y[k]-'a')]++;count++;}
		}
	}
	Graph(2);
}
/*******************************************************************************/
/* FUNCTION MAIN */
int main()
{
	char *p[11],c;int xx,yy,ch;
	// lessons
	p[1]="jjd fdfj djd jk jd k dd fk fd fk k jfkd dkkf fk dkd dd jkk lfg hgjk asd sdfg";
	p[2]="ll ld dss fld l sf dss ll jl kl ls slj kl ldf kl dss ls jss dlkk js kl js ls";
	p[3]="scn mk jnlg fls hcn klj zxk slnv lkj jkl sdk lmkj dkmjn dvnjk sc jv knn mjj";
	p[4]="ydj iko liu tuib poil ghu powe poiqw uasln ijlk lksd oermsa oekld poiek pkj";
	p[5]="dc dc dcd da dad dc cd dac cad all slacks fads fad flak scads flask jac";
	p[6]="jacks class lad scads sack alas lacks flak alfalfa calls clack alacks adds";
	p[7]="cantata talcs attack knack stalks tack tact scan scandals ats tad daft" ;
	p[8]="kind avant antacid finalist sills distaff did kicks tactics lifts jail";
	p[9]="tinkles metals satellite amends sees caffeine small declassified vales";
	p[10]="claim exalt explosive choir decrement witchcraft perception instruct consent";
	//
	do{
		clrscr();
		printf("\n                              TYPE MASTER\n");
		flushall();
		// asking the user to enter the lesson number
		printf("\n\n1.Lessons(1-10).\n\n2.Game.\n\n3.Help.\n\n4.Exit.\n\n\nEnter your choice:");
		scanf("%d",&ch);
		if(ch==1){
			printf("\n\nEnter the lesson number(1-10):");
			scanf("%d",&lesson);
			if(lesson<11&&lesson>0)
			{ clrscr();
				printf("\n                              TYPE MASTER\n");
				printf("\n\n\n%s\n\n",p[lesson]);     	//displaying the requested lesson
				/* getting character and core of the program */
				xx=wherex();
				yy=wherey();
				gotoxy(2,48);
				printf("PRESS ZERO TO QUIT");
				gotoxy(xx,yy);
				for(;*p[lesson]!='\0';)
				{
					xx=wherex();
					yy=wherey();
					gotoxy(45,4);
					printf("Letter to be typed is:%c",*p[lesson]);
					gotoxy(xx,yy);
					fflush(stdin);
					c=getch();
					if(c=='0')exit(0);
					if(c!='\b')printf("%c",c);
					if(c!='\b')if(c!=*p[lesson]++){sound(420);delay(100);nosound();printf("\b"); x[(int)(*p[lesson]-'a')]++;p[lesson]--;count++;}

				}
				Graph(1);next_round();
			}
			else {printf("IMPROPER ARGUMENT.....!");sleep(3);clrscr();main();}
		}
		else if(ch==2){Game();next_round();}
		else if(ch==3)help();
		else if(ch==4)exit(0);
		else {printf("IMPROPER ARGUMENT.....!");sleep(3);clrscr();}
	}while(lesson!=11);
	return 0;
}
/****************************************************************************/
/* TO DRAW THE NAME IN A DESIGN FORMAT */
void a(char *y)
{int i;
	printf("\n");
	for(i=1;i<=10;i++)
	{
		textcolor(i);
		design();
	}
	for(i=1;*y!='\0';i++)
	{
		textcolor(i%15+1);
		cprintf("%c",*y++);
		delay(35);
	}
	for(i=0;i<10;i++)
	{
		textcolor(i);
		design();
	}
}
/****************************************************************************/
/* TO GENERATE A SPINING  WHEEL */
void design()
{
	cprintf("|"); delay(35);
	cprintf("\b/");delay(35);
	cprintf("\b-");delay(35);
	cprintf("\b\\"); delay(35);
	cprintf("\b|");delay(35);
	cprintf("\b/"); delay(35);
	cprintf("\b-");delay(35);
	cprintf("\b\\");delay(35);
	cprintf("\b");
	cprintf("-");
}
/*****************************************************************************/
