/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Header for stopword removal filter - inherits from filter.h
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#ifndef __STOPWORDSFILTER_H__
#define __STOPWORDSFILTER_H__

#include "Filter.h"

int SF_InitializeStopWordsFilter();
int SF_IsStopword(char *token);

#endif
