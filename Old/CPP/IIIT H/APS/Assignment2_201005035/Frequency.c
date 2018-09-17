#include<stdio.h>
#include<string.h>
#include<stdlib.h>

struct WordList
{
	char word[25];
	int frequency;
	int wordSize;
};

struct WordList *wordlist = NULL;
int capacity = 10, length = 0;  //capacity should be > 5 or else realloc will shrink the data....

int comparer(const void *p1, const void *p2)
{
	struct WordList *w1,*w2;
	w1 = (struct WordList*)p1;
	w2 = (struct WordList*)p2;
	return strcmp(w1->word,w2->word);
}

int main()
{
	char word[25];
	int i,j,Max = 0,WordSize = 0;
	FILE *fp = fopen("a.txt","r");
	wordlist = (struct WordList*) calloc(capacity,sizeof(struct WordList));

	if(fp != NULL){
		while(!feof(fp)){
			fscanf(fp,"%s",word);			  				  	 // read a word		
			for(i = 0; i < length; i++){
				if(strcmp(wordlist[i].word, strupr(word)) == 0){ // word exists then update frequency
					wordlist[i].frequency++; 
					if(Max < wordlist[i].frequency) Max = wordlist[i].frequency; //store local max
					break;
				}
			}
			if(i >= length){						// word doesnot exists	
				if(length > capacity){				// Make enough room for the list to accomidate new words
					capacity *= 2;					// double its capacity;
					wordlist = (struct WordList*)  realloc(wordlist,capacity*sizeof(struct WordList));
				}
				// copy the word
				strcpy(wordlist[length].word, strupr(word));
				wordlist[length].wordSize = strlen(word);
				if(WordSize < wordlist[length].wordSize) WordSize = wordlist[length].wordSize; //store local max
				wordlist[length].frequency = 1;
				length++;
			}
		}
		fclose(fp);

		qsort(wordlist,length,sizeof(struct WordList),comparer);

		for(i = 0; i < length; i++)
			printf("|%s|%d\n",wordlist[i].word,wordlist[i].frequency);
		
		for(j = Max ;j > 0; j--){
			printf("\n");
			for(i = 0; i < length; i++){
				if(wordlist[i].frequency == j) {
					printf("%3s","*");
					wordlist[i].frequency--;
				}
				else{
					printf("%3s"," ");
				}
			}
		}
		printf("\n-------------------------------------------");
		for(j = 0 ;j < WordSize; j++){
			printf("\n");
			for(i = 0; i < length; i++){
				if(wordlist[i].wordSize >= 0) {
					printf("%3c",wordlist[i].word[j]);
					wordlist[i].wordSize--;
				}
				else{
					printf("%3s"," ");
				}
			}
		}
	}
}



