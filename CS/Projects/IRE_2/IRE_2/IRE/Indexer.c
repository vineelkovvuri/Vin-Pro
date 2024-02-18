/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Driving module for initiating following sequence
 *          parsing -> tokenizing -> indexing -> merging
 *                         |-> stopword removal 
 *                         |-> stemming
 *
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#include "Wikiparser.h"
#include "Tokenizer.h"
#include "Filter.h"
#include "StopwordsFilter.h"
#include <AVL.h>
#include "FileMerger.h"

FILE *outFile,*titleUnindexed;
char currentArticleID[20];

// AVL node compare routine
int compare(PPH_AVL_LINKS Links1,PPH_AVL_LINKS Links2)
{
	Token *node1 = CONTAINING_RECORD(Links1,Token ,Link); //Greatest hack to get to node begining - AN EYE OPENER TO MY C KNOWLEDGE
	Token *node2 = CONTAINING_RECORD(Links2,Token ,Link); //Copied from PROCESS HACKER, the same hack is also present in linux kernel linked list implementation
	return strcmp(node1->Key,node2->Key);
}
// AVL node enumerator routine
BOOLEAN TreeCallback(PPH_AVL_TREE Tree,PPH_AVL_LINKS Element)
{
	Token *node1 = CONTAINING_RECORD(Element,Token ,Link);
	fprintf(outFile,"%s|%s{%d}\n",node1->Key,currentArticleID,node1->Frequency);
	return TRUE;
}
// AVL node Delete routine
void AVLDeleteCallback(PPH_AVL_LINKS node)
{
	Token *node1 = CONTAINING_RECORD(node,Token,Link);
	if(node1->Key != NULL)
		free(node1->Key);
	free(node1);
}

/* 
	This method is invoked by wikiparser upon extracting each document from wiki.xml
*/
void TokenizerThreadCallback(void *_article)
{
	struct WikiArticle * article = (struct WikiArticle *)_article;
	char outFilePath[MAX_PATH];
	
	PH_AVL_TREE tree ;  //initiate avl tree
	strcpy(currentArticleID, article->id);


//	fprintf(titleUnindexed,"%s|%s\n",article->id,article->title);

#ifdef TITLE

	//tokenizing Title
	sprintf(outFilePath,"%s%s.txt",TITLES_PATH,article->id);
	outFile = fopen(outFilePath,"wbS");
	PhInitializeAvlTree(&tree,compare,AVLDeleteCallback);		//initiate avl tree
	StringTokenizer(article->title,article->titleLength,&tree);	//invoke tokenizer
	PhEnumAvlTree(&tree,TreeEnumerateInOrder,TreeCallback);		//
	PhDeleteTree(tree.Root.Right,&tree);
	fclose(outFile);
	MergeDir(TITLES_PATH);

#endif

#ifdef CONTENT
	//tokenizing content
	sprintf(outFilePath,"%s%s.txt",CONTENT_PATH,article->id);
	outFile = fopen(outFilePath,"wbS");
	PhInitializeAvlTree(&tree,compare,AVLDeleteCallback);
	StringTokenizer(article->content,article->contentLength,&tree);
	PhEnumAvlTree(&tree,TreeEnumerateInOrder,TreeCallback);
	PhDeleteTree(tree.Root.Right,&tree);
	fclose(outFile);
	MergeDir(CONTENT_PATH);

#endif
#ifdef CATEGORY
	//tokenizing category
	sprintf(outFilePath,"%s%s.txt",CATEGORY_PATH,article->id);
	outFile = fopen(outFilePath,"wbS");
	PhInitializeAvlTree(&tree,compare,AVLDeleteCallback);
	StringTokenizer(article->category,article->categoryLength,&tree);
	PhEnumAvlTree(&tree,TreeEnumerateInOrder,TreeCallback);
	PhDeleteTree(tree.Root.Right,&tree);
	fclose(outFile);
	MergeDir(CATEGORY_PATH);

#endif
#ifdef INFOBOX
	//tokenizing Infobox
	sprintf(outFilePath,"%s%s.txt",INFOBOX_PATH,article->id);
	outFile = fopen(outFilePath,"wbS");
	PhInitializeAvlTree(&tree,compare,AVLDeleteCallback);
	StringTokenizer(article->infobox,article->infoboxLength,&tree);
	PhEnumAvlTree(&tree,TreeEnumerateInOrder,TreeCallback);
	PhDeleteTree(tree.Root.Right,&tree);
	fclose(outFile);
	MergeDir(INFOBOX_PATH);

#endif	
/*	//tokenizing Outlinks
	sprintf(outFilePath,"%s%s.txt",OUTLINKS_PATH,article->id);
	outFile = fopen(outFilePath,"wb");
	PhInitializeAvlTree(&tree,compare,AVLDeleteCallback);
	Log(log,"Data structures initialized\n");
	Log(log,"Invoking Tokenizer\n");
	StringTokenizer(article->outlinks,article->outlinksLength,&tree,filters,sizeof(filters)/sizeof(int*));
	PhEnumAvlTree(&tree,TreeEnumerateInOrder,TreeCallback);
	PhDeleteTree(tree.Root.Right,&tree);
	fclose(outFile);
*/
	//free(article->category);
	//free(article->outlinks);
	//free(article->content);
	//free(article->infobox);

}
void InitializeFilters()
{
	SF_InitializeStopWordsFilter();
}
void CreateFolderStructure()
{
	CreateDirectory(DESTINATION_PATH,NULL);
	CreateDirectory(CONTENT_PATH,NULL);
	CreateDirectory(CATEGORY_PATH,NULL);
	CreateDirectory(INFOBOX_PATH,NULL);
	CreateDirectory(OUTLINKS_PATH,NULL);
	CreateDirectory(TITLES_PATH,NULL);
}
int Indexer()
{
	FILE *fp;
	CreateFolderStructure();

	fp = fopen(PARSE_FILE_PATH,"rbS");
	titleUnindexed  = fopen(TITLES_UNINDEXED_FILENAME,"wbS");
	
	Log(log,"Loading Stopwords\n");
	InitializeFilters();
	
	Log(log,"Invoking Parser -> Tokenizer -> Indexing.........Please Wait\n");
	Parser(fp,TokenizerThreadCallback); // Parser invokes Tokenizer once each article is fetched.....
	fclose(fp);
	fclose(titleUnindexed);
	
	/*                    MERGE OPERATION BEGINS                   */
	Log(log,"Merging intermediate files started\n");


	/*MergeDir(TITLES_PATH);
	MergeDir(CATEGORY_PATH);
	MergeDir(INFOBOX_PATH);
	MergeDir(CONTENT_PATH);*/
	Log(log,"Merging is done\n");
	Log(log,"Please re-run the program and chose searching to query the indexes\n");
	return 0;
}

