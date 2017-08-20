//Program to find the number of characters,lines,words,spaces in a file.. 
#include<stdio.h>

struct WordList
{
	char word[40];
};

main()
{
	//w is the flag for word
	int BOW = 0,c = 0;
	struct WordList words[10];
	char word[20];
	FILE *fp = fopen(__FILE__,"r");//opening the current file....
	if(fp!=NULL){
		do{
			c = fgetc(fp);
			if(c == ' ' || c == 10 || c == -1){	//Check for spaces...
				if(BOW == 1){
					//words++;
						
					BOW = 0;

				}
			}
			else {
				
				BOW = 1;	//then c may be a character i.e., Word 
			}
		}while(!feof(fp));
		printf("\nChars = %d\nWords = %d\nLines = %d\nSpaces = %d"
				,chars,words,lines,spaces);
		fclose(fp);
	}

}

