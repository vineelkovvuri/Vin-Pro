/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Implementation Tokeniser
 *
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#include "Tokenizer.h"
#include "PorterStemmer.h"
#include "StopwordsFilter.h"

// take a document and return(3rd param) a tree containing unique words from it
// this implementation make use of a efficient space time trade off for checking the delimiter
// refer comments for ascii_map in Tokenizer.h
void StringTokenizer(const unsigned char * string, size_t size, PPH_AVL_TREE ptree)
{
	unsigned char ch;
	char buff[MAX_TOKEN_SIZE],token[MAX_TOKEN_SIZE];
	unsigned int i=0,j;
	Token *token1;
	//struct stemmer * z = create_stemmer();
	for(j = 0;j <= size; j++){
		if( i < MAX_TOKEN_SIZE ){ // make sure no buffer overrun will be done
			ch = j < size ? string[j] : 0;
			if(ascii_map[ch]!=0) // if not a delimiter then copy the conten
				buff[i++] = ascii_map[ch];
			else{					  // if delimiter is reached add it to list	
				if(i > 0){			  // implies empty strings are excluded
					int k=0,rejected = FALSE;
					buff[i] = 0;
					strcpy(token,buff);  // include \0 
				/*	token[stem(z,token,strlen(token) - 1) + 1] = 0; */
					
					if(!SF_IsStopword(token)) // if word is not rejected add it to avl tree.
					{
						PPH_AVL_LINKS node;
						token1 = malloc(sizeof(Token));
						token1->Key = malloc(sizeof(char)*(strlen(token)+1));
						strcpy(token1->Key,token);
						token1->Frequency = 1;
						if((node = PhFindElementAvlTree(ptree,&token1->Link)) == NULL){
							PhAddElementAvlTree(ptree,&token1->Link);
						}
						else{ // if node already existing free the allocated buffer
							Token *existingToken = CONTAINING_RECORD(node,Token ,Link);
							existingToken->Frequency++;
							free(token1->Key);
							free(token1);
						}
					}
					i = 0;
				}
			}
		}else{
			buff[i-1] = 0;
		}
	}
//	free_stemmer(z);
}
