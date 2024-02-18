/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Base header file for Tokenizing - contains ascii_map and function prototypes
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#ifndef __TOKENIZER_H__
#define __TOKENIZER_H__

#include"IRECommon.h"
#include<AVL.h>
#define MAX_TOKEN_SIZE 300

// This map is a space time trade-off 
// it helps me to easily map how each character from the input should be transformed in to output
// it helps using delimiters much easier. Any time I can change the delimiters
// conversion from upper case letter to lower case is done in constant time
// every delimiter is mapped to 0 (numeric)
static int ascii_map[256] = {
	/* 00 - 0F */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* 10 - 1F */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	//			   ' ' ,  '!' ,  '"' ,  '#' ,  '$' ,  '%' ,  '&' ,  '\'',  '(' ,  ')' ,  '*' ,  '+' ,  ',' ,  '-' ,  '.' ,  '/' ,  
	/* 20 - 2F */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	//			   '0' ,  '1' ,  '2' ,  '3' ,  '4' ,  '5' ,  '6' ,  '7' ,  '8' ,  '9' ,  ':' ,  ';' ,  '<' ,  '=' ,  '>' ,  '?' ,   
	/* 30 - 3F */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   
	//			   '@' ,  'A' ,  'B' ,  'C' ,  'D' ,  'E' ,  'F' ,  'G' ,  'H' ,  'I' ,  'J' ,  'K' ,  'L' ,  'M' ,  'N' ,  'O' , 
	/* 40 - 4F */   0  ,  'a' ,  'b' ,  'c' ,  'd' ,  'e' ,  'f' ,  'g' ,  'h' ,  'i' ,  'j' ,  'k' ,  'l' ,  'm' ,  'n' ,  'o' , 
	//			   'P' ,  'Q' ,  'R' ,  'S' ,  'T' ,  'U' ,  'V' ,  'W' ,  'X' ,  'Y' ,  'Z' ,  '[' ,  '\\',  ']' ,  '^' ,  '_' ,
	/* 50 - 5F */  'p' ,  'q' ,  'r' ,  's' ,  't' ,  'u' ,  'v' ,  'w' ,  'x' ,  'y' ,  'z' ,   0  ,   0  ,   0  ,   0  ,   0  ,
	//			   '`' ,  'a' ,  'b' ,  'c' ,  'd' ,  'e' ,  'f' ,  'g' ,  'h' ,  'i' ,  'j' ,  'k' ,  'l' ,  'm' ,  'n' ,  'o' ,
	/* 60 - 6F */   0  ,  'a' ,  'b' ,  'c' ,  'd' ,  'e' ,  'f' ,  'g' ,  'h' ,  'i' ,  'j' ,  'k' ,  'l' ,  'm' ,  'n' ,  'o' ,
	//			   'p' ,  'q' ,  'r' ,  's' ,  't' ,  'u' ,  'v' ,  'w' ,  'x' ,  'y' ,  'z' ,  '{' ,  '|' ,  '}' ,  '~' ,   0  ,
	/* 70 - 7F */  'p' ,  'q' ,  'r' ,  's' ,  't' ,  'u' ,  'v' ,  'w' ,  'x' ,  'y' ,  'z' ,   0  ,   0  ,   0  ,   0  ,   0  ,
	/* 80 - 8F */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* 90 - 9F */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* A0 - AF */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* B0 - BF */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* C0 - CF */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* D0 - DF */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
	/* E0 - EF */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  , 
	/* F0 - FF */   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,   0  ,  
};

void StringTokenizer(const unsigned char * string, size_t size, PPH_AVL_TREE ptree);

typedef struct _Token{
	char *Key;
	int Frequency;
	PH_AVL_LINKS Link;	// reference to AVL node - mind blowing technique copied from PROCESS HACKER SOURCES
}Token;

#endif
