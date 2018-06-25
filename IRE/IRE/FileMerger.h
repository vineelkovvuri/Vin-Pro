/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  File Merging header file 
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */


#ifndef __FILEMERGER_H__
#define __FILEMERGER_H__

#include "IRECommon.h"

#define ValidDir(data) strcmp(data.cFileName,".")&&strcmp(data.cFileName,"..")

#define MAX_WORD_SIZE 25
#define MAX_NUM_FILES 410000
#define MAX_RECORD_SIZE ONE_MB // 1MB

void MergeDir(char *path) ;


#endif
