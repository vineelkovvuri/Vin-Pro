/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Parser base header file - inherited by wikiparser.h
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#ifndef __PARSER_H__
#define __PARSER_H__

#include "IRECommon.h"

void Parser(FILE * fp, void ( *TokenizerCallback )( void * ));

#endif
