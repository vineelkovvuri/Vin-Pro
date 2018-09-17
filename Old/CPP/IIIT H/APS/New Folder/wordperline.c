//Program to print each word on a separate line..
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
				case '\n':
					if(s != 1){  // not aleady at a spaces
						s = 1;   // flip the flag to indicate you are at a space
						printf("\n");
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

