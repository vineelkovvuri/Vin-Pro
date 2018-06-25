/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Base header file contain some common routines
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#ifndef __IRECOMMON_H_
#define __IRECOMMON_H_

#pragma warning(disable:4996) 

#define _CRT_DISABLE_PERFCRIT_LOCKS

#include<Windows.h>
#include<process.h>

#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<ctype.h>
#include<time.h>
#include<stdarg.h>

#define TRUE 1
#define FALSE 0


#define CONTENT
#define CATEGORY
#define INFOBOX
#define TITLE


//modify this base dir path accordingly when you are building from a different path
//all files go to their respective folders using this base dir as their parent folder
//#define BASE_DIR							    "C:\\Documents and Settings\\Hacker\\My Documents\\visual studio 2010\\Projects\\IRE\\Debug\\"
#define BASE_DIR							    "E:\\IRE\\"


#define PARSE_FILE_PATH							BASE_DIR##"wiki.xml"
#define STOPWORDS_FILE_PATH						BASE_DIR##"stopwords.txt"
#define DESTINATION_PATH						BASE_DIR##"Processed\\"
#define CONTENT_PATH							BASE_DIR##"Processed\\Content\\"
#define CATEGORY_PATH							BASE_DIR##"Processed\\Category\\"
#define INFOBOX_PATH							BASE_DIR##"Processed\\Infobox\\"
#define OUTLINKS_PATH							BASE_DIR##"Processed\\Outlinks\\"
#define TITLES_PATH								BASE_DIR##"Processed\\Titles\\"
#define CONTENT_FILENAME						BASE_DIR##"Processed\\Content\\index.txt"
#define CATEGORY_FILENAME						BASE_DIR##"Processed\\Category\\index.txt"
#define INFOBOX_FILENAME						BASE_DIR##"Processed\\Infobox\\index.txt"
#define OUTLINKS_FILENAME						BASE_DIR##"Processed\\Outlinks\\index.txt"
#define TITLES_FILENAME							BASE_DIR##"Processed\\Titles\\index.txt"

#define SECOND_CONTENT_FILENAME						BASE_DIR##"Processed\\Content\\2index.txt"
#define SECOND_CATEGORY_FILENAME						BASE_DIR##"Processed\\Category\\2index.txt"
#define SECOND_INFOBOX_FILENAME						BASE_DIR##"Processed\\Infobox\\2index.txt"
#define SECOND_OUTLINKS_FILENAME						BASE_DIR##"Processed\\Outlinks\\2index.txt"
#define SECOND_TITLES_FILENAME							BASE_DIR##"Processed\\Titles\\2index.txt"

#define TITLES_UNINDEXED_FILENAME				BASE_DIR##"Processed\\Titles_unindexed.txt"


#define ONE_KB  1024
#define ONE_MB  1024*1024


int Log(FILE *fp,const char *fmt, ...);

// file for logging....
FILE * log;

#endif