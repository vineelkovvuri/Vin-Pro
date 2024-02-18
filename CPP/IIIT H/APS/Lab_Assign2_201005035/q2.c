//Program to find the number of characters,lines,words in a file..
#include<stdio.h>
main()
{
	//w is the flag for word
	int words=0,spaces=0,lines=0,chars=0,tabs=0,c=0,w=0;		
	FILE *fp;	
	char filename[100];
	scanf("%s",filename);
	fp = fopen(filename, "r");
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
			else if(c == '\t'){	//Check for tabs...
				tabs++;
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
			else w = 1;
			if(c!=-1)chars++; //NOT EOF
		}while(!feof(fp));
		printf("%d %d %d",spaces,tabs,lines);
	}
}


