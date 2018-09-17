/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Wikiparser header file - Contains WikiArticle structure defination
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#ifndef __WIKIPARSER_H__
#define __WIKIPARSER_H__

#include "Parser.h"

#define MAX_TAG_LEN 50

struct WikiArticle{
	unsigned char title[512]; //CHECK: buffer may overrun if title > 512 - I am not responsible for such a long wiki title
	int titleLength;
	unsigned char id[20];
	unsigned char *infobox;
	int infoboxLength;
	unsigned char *category;
	int categoryLength;
	unsigned char *outlinks;
	int outlinksLength;
	unsigned char *content;
	int contentLength;
};

#endif
