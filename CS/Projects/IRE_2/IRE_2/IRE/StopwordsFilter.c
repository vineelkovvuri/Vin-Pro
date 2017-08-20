/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Stopword removal module 
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#include "StopwordsFilter.h"

#include<hashit.h>


hash_t h;

int compare_hash_keys(void * key1, void *key2)
{
	char * _key1 = (char*)key1;
	char * _key2 = (char*)key2;

	return strcmp(_key1,_key2);
}
static void BuildStopwordsList()
{
	char stopword[25] = {0};
	FILE *stopwordsFile;
	char * dup;
	h = hashit_create(293,0,NULL,compare_hash_keys,CHAIN_H);
	stopwordsFile = fopen(STOPWORDS_FILE_PATH,"rS");
	while(!feof(stopwordsFile)){
		fscanf(stopwordsFile,"%[^\n]%*c",stopword);
		dup = _strdup(stopword);
		hashit_insert (h, dup,dup);
	}
	fclose(stopwordsFile);
}
/*
static int wordsCount = 0;
static char **wordsList;
static void __BuildStopwordsList()
{
	FILE *stopwordsFile;
	int initialSize = 200;
	stopwordsFile = fopen(STOPWORDS_FILE_PATH,"r");
	wordsList = (char **)malloc(initialSize*sizeof(char*));
	while(!feof(stopwordsFile)){
		if(wordsCount == initialSize)
			wordsList = realloc(wordsList,initialSize *= 2);
		wordsList[wordsCount] = malloc(sizeof(char*)*MAX_STOP_WORD_SIZE);
		fscanf(stopwordsFile,"%[^\n]%*c",wordsList[wordsCount]); //%*c to skip \n
		wordsCount++;
	}
	wordsCount--;
	fclose(stopwordsFile);
}
*/
int SF_InitializeStopWordsFilter()
{
	BuildStopwordsList();
		
	return 0;
}

//Yes, I know no english word have an alphabet repeated thrice - I am least borthered about acronymns
char *repeats[] = {"aaa","bbb","ccc","ddd","eee","fff","ggg","hhh","iii","jjj","kkk","lll","mmm","nnn","ooo","ppp","qqq","rrr","sss","ttt","uuu","vvv","www","xxx","yyy","zzz"};
int SF_IsStopword(char *token)
{
	int i = 0;
	if(strlen(token) <= 2) return 1;
	if(strlen(token) >  20) return 1;
	if(hashit_lookup (h, token) != NULL) return 1; // Yes given word is stop word
	for(i=0;i<26;i++)
		if(strstr(token,repeats[i]) != NULL) return 1; 
	
	return 0;
}


