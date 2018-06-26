/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Base header file for Querying
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#ifndef __QUERY_H__
#define __QUERY_H__

#include "IRECommon.h"
#include <AVL.h>

void Search();

typedef struct _QueryToken{
	int DocId;
	int Frequency;
	int TokenCount;
	PH_AVL_LINKS Link;	// reference to AVL node - mind blowing technique copied from PROCESS HACKER SOURCES
}QueryToken;


#endif