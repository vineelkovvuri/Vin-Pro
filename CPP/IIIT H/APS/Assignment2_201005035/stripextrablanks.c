//Program to strip away extra blanks..
#include<stdio.h>
main()
{
	//s is the flag for spaces
	int c=0,s=0;		
	FILE *fp = fopen("in.txt","r");
	if(fp!=NULL){
		do{
			c = fgetc(fp);
			switch(c){
				case ' ':
				case '\t':
					if(s != 1){  // not aleady at a spaces
						s = 1;   // flip the flag to indicate you are at a space
						printf(" ");
					}
					break;
				default:
					s = 0;		// flip the flag to indicate you are not at a space
					printf("%c",c);
					break;
			}	
		}while(!feof(fp));
	}
}

