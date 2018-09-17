//Program to find the number of characters,lines,words,spaces in a file.. 
#include<stdio.h>
#include<conio.h>
main()
{
	//w is the flag for word
	int words=0,spaces=0,lines=0,chars=0,c=0,w=0;		
	FILE *fp = fopen(__FILE__,"r");//opening the current file....
	clrscr();
	if(fp!=NULL){
		do{
			c = fgetc(fp);
			if(c == ' '){	//Check for spaces...
				spaces++;
				if(w == 1){
					words++;
					w = 0;
				}
			}
			else if(c == 10){ //Check for \n
				lines++;
				if(w == 1){
					words++;
					w = 0;
				}
			}
			else if(c == -1){ //EOF
				if(w == 1){
					words++;
					w = 0;
				}
			}
			else w = 1;	//then c may be a character i.e., Word 

			if(c!=-1)chars++; //do not count EOF as character.
		}while(!feof(fp));
		printf("\nChars = %d\nWords = %d\nLines = %d\nSpaces = %d"
				,chars,words,lines,spaces);
		fclose(fp);
	}
	getch();
}

/*
OUTPUT:
Chars = 691
Words = 96
Lines = 38
Spaces = 60
*/
