/*
* IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
* 
* Module:  Implementation of Searching part
*
* Author:  Vineel Kumar Reddy Kovvuri
* E-mail:  vineel567@yahoo.co.in
*
*/

#include "Query.h"

#define MAX_TOKENS_IN_QUERY 30
#define MAX_TOKENS_SIZE 30
#define MAX_NUM_RESULTS 20
#define MAX_TITLES 3000000
// 2D 26x26 array to capture file positions of strings beginning with aa,ab,ac.....zz in the final index
// so that Map[0][0] will give the file position of strings starting with aa
// similarly Map[25][25] will give the file position of strings starting with zz
fpos_t TitleMap[26][26];
fpos_t ContentMap[26][26];
fpos_t InfoboxMap[26][26];
fpos_t CategoryMap[26][26];
fpos_t OutlinksMap[26][26];

struct TitleEntry{
	int docid;
	char title[150];
};

 struct TitleEntry **TitleMapUnindexed;

 int titleCount = 0;
PH_AVL_TREE MasterTree ;  //initiate avl tree
int NumOfTokensInQuery;
PH_AVL_TREE tokensTrees[MAX_TOKENS_IN_QUERY]; 

QueryToken **results;


// AVL node compare routine
int Qcompare(PPH_AVL_LINKS Links1,PPH_AVL_LINKS Links2)
{
	QueryToken *node1 = CONTAINING_RECORD(Links1,QueryToken ,Link); //Greatest hack to get to node begining - AN EYE OPENER TO MY C KNOWLEDGE
	QueryToken *node2 = CONTAINING_RECORD(Links2,QueryToken ,Link); //Copied from PROCESS HACKER, the same hack is also present in linux kernel linked list implementation
	return node1->DocId - node2->DocId;
}
// AVL node enumerator routine
BOOLEAN QTreeCallback(PPH_AVL_TREE Tree,PPH_AVL_LINKS Element)
{
	QueryToken *node1 = CONTAINING_RECORD(Element,QueryToken ,Link); 
	QueryToken *token1;
	PPH_AVL_LINKS node;

	token1 = calloc(1,sizeof(QueryToken));
	token1->DocId = node1->DocId;
	token1->Frequency = node1->Frequency;
	token1->TokenCount = 1;
	if((node = PhFindElementAvlTree(&MasterTree,&token1->Link)) == NULL){
		PhAddElementAvlTree(&MasterTree,&token1->Link);
	}
	else{ // if docid is already existing update frequency and token count and free the allocated buffer
		QueryToken *existingToken = CONTAINING_RECORD(node, QueryToken, Link);
		existingToken->Frequency += token1->Frequency ; //cumilate frequency if the same token is repeated in same document in different sections like category, text e.t.c
		existingToken->TokenCount++;
		free(token1);
	}

	//printf("%d{%d:%d}\n",node1->DocId,node1->Frequency,node1->TokenCount);
	return TRUE;
}


// AVL node Delete routine
void QAVLDeleteCallback(PPH_AVL_LINKS node)
{
	QueryToken *node1 = CONTAINING_RECORD(node,QueryToken,Link);
	free(node1);
}

// master tree

// AVL node compare routine
int QMasterTreeCompare(PPH_AVL_LINKS Links1,PPH_AVL_LINKS Links2)
{
	QueryToken *node1 = CONTAINING_RECORD(Links1,QueryToken ,Link); //Greatest hack to get to node begining - AN EYE OPENER TO MY C KNOWLEDGE
	QueryToken *node2 = CONTAINING_RECORD(Links2,QueryToken ,Link); //Copied from PROCESS HACKER, the same hack is also present in linux kernel linked list implementation
	return node1->DocId - node2->DocId;
}

// Master AVL node enumerator routine
int k = 0;
BOOLEAN QMasterTreeCallback(PPH_AVL_TREE Tree,PPH_AVL_LINKS Element)
{
	QueryToken *node1 = CONTAINING_RECORD(Element,QueryToken ,Link); 
	//if(node1->TokenCount == NumOfTokensInQuery) 
	//printf("%d{%d:%d}\n",node1->DocId,node1->Frequency,node1->TokenCount);
	results[k] = calloc(1,sizeof(QueryToken));
	results[k]->DocId = node1->DocId;
	results[k]->Frequency = node1->Frequency;
	results[k]->TokenCount = node1->TokenCount;
	k++;
	return TRUE;
}


//Qsort Results compare function

int ResultsCompare(const void * _result1,const void * _result2)
{
	QueryToken **result1 = (QueryToken **)_result1;
	QueryToken **result2 = (QueryToken **)_result2;

	if((*result2)->TokenCount != (*result1)->TokenCount) return (*result2)->TokenCount - (*result1)->TokenCount;
	else return (*result2)->Frequency - (*result1)->Frequency;
}


void CreateMaps() 
{
	char temp[250];
	int t;
	
	FILE *fp;
	char *rec;
	int res,prec1 = -1,prec2 = -1;
	fpos_t pos;
	rec = malloc(sizeof(char)*20*ONE_MB);

	TitleMapUnindexed = (struct TitleEntry ** )malloc(sizeof(struct TitleEntry *)*MAX_TITLES);
	titleCount = 0;
	Log(log,"mapping unindexed title file\n");
	fp = fopen(TITLES_UNINDEXED_FILENAME,"rbS");
	while(!feof(fp)){
		fgetpos(fp,&pos);
		res = fscanf(fp,"%[^\n]%*c",rec); 
		if(res != 0 && res != EOF){
			char * ptr = strchr(rec,'|');
			sprintf(temp,"%.*s",ptr-rec,rec);
			 TitleMapUnindexed[titleCount] = (struct TitleEntry *)malloc(sizeof(struct TitleEntry));
			 TitleMapUnindexed[titleCount]->docid = atoi(temp);
			 sprintf(TitleMapUnindexed[titleCount]->title,"%s",ptr+1);
			 titleCount++;
		}
	}
	fclose(fp);


	Log(log,"mapping title file\n");
	memset(TitleMap,-1,sizeof(TitleMap));
	fp = fopen(TITLES_FILENAME,"rbS");
	prec1 = -1;prec2 = -1;
	while(!feof(fp)){
		fgetpos(fp,&pos);
		res = fscanf(fp,"%[^\n]%*c",rec); 
		if(res != 0 && res != EOF){
			if(prec1 != rec[0] || prec2 != rec[1]){
				TitleMap[rec[0]-'a'][rec[1]-'a'] = pos;
				prec1 = rec[0];
				prec2 = rec[1];
			}
		}
	}
	fclose(fp);
	/*
	Log(log,"mapping content file\n");
	memset(ContentMap,-1,sizeof(ContentMap));
	fp = fopen(CONTENT_FILENAME,"rbS");
	prec1 = -1;prec2 = -1;
	while(!feof(fp)){
		fgetpos(fp,&pos);
		res = fscanf(fp,"%[^\n]%*c",rec); 
		if(res != 0 && res != EOF){
			if(prec1 != rec[0] || prec2 != rec[1]){
				ContentMap[rec[0]-'a'][rec[1]-'a'] = pos;
				prec1 = rec[0];
				prec2 = rec[1];
			}
		}
	}
	fclose(fp);
	*/
	Log(log,"mapping category file\n");
	memset(CategoryMap,-1,sizeof(CategoryMap));
	fp = fopen(CATEGORY_FILENAME,"rbS");
	prec1 = -1;prec2 = -1;
	while(!feof(fp)){
		fgetpos(fp,&pos);
		res = fscanf(fp,"%[^\n]%*c",rec); 
		if(res != 0 && res != EOF){
			if(prec1 != rec[0] || prec2 != rec[1]){
				CategoryMap[rec[0]-'a'][rec[1]-'a'] = pos;
				prec1 = rec[0];
				prec2 = rec[1];
			}
		}
	}
	fclose(fp);

	Log(log,"mapping infobox file\n");
	memset(InfoboxMap,-1,sizeof(InfoboxMap));
	fp = fopen(INFOBOX_FILENAME,"rbS");
	prec1 = -1;prec2 = -1;
	while(!feof(fp)){
		fgetpos(fp,&pos);
		res = fscanf(fp,"%[^\n]%*c",rec); 
		if(res != 0 && res != EOF){
			if(prec1 != rec[0] || prec2 != rec[1]){
				InfoboxMap[rec[0]-'a'][rec[1]-'a'] = pos;
				prec1 = rec[0];
				prec2 = rec[1];
			}
		}
	}
	fclose(fp);
	free(rec);
}

void ProcessResult(char * res,PPH_AVL_TREE tokenTree)
{
	int firstDocid = 0;
	char * token;
	QueryToken *token1;
	token = strtok (res,"|");
	
	while (token != NULL){
		//printf ("%s\n",token);
		PPH_AVL_LINKS node;
		char  docid[30],freq[10];
		token1 = calloc(1,sizeof(QueryToken));
		sprintf(docid,"%.*s",strchr(token,'{') - token,token );
		sprintf(freq,"%.*s",strchr(token,'}') - strchr(token,'{')-1, strchr(token,'{')+1 );
		//if(firstDocid == 0){
			//firstDocid  = atoi(docid);
			token1->DocId = atoi(docid);
	//	}
	//	else{
		//	token1->DocId = atoi(docid) + firstDocid;
		//}
		token1->Frequency = atoi(freq);
		if((node = PhFindElementAvlTree(tokenTree,&token1->Link)) == NULL){
			PhAddElementAvlTree(tokenTree,&token1->Link);
		}
		else{ // if docid is already existing update frequency and token count and free the allocated buffer
			QueryToken *existingToken = CONTAINING_RECORD(node, QueryToken, Link);
			existingToken->Frequency += token1->Frequency ; //cumilate frequency if the same token is repeated in same document in different sections like category, text e.t.c
			free(token1);
		}
		token = strtok (NULL,"|");
	}
}

void SearchInTitles(char * token,PPH_AVL_TREE tokenTree)
{
	if(TitleMap[token[0]-'a'][token[1]-'a'] !=-1){
		FILE *fp;
		char *rec;
		int res,n;
		n = strlen(token);
		rec = malloc(sizeof(char)*20*ONE_MB);
		fp = fopen(TITLES_FILENAME,"rbS");
		fsetpos(fp,&TitleMap[token[0]-'a'][token[1]-'a']);
		while(!feof(fp)){
			res = fscanf(fp,"%[^\n]%*c",rec); 
			if(res != 0 && res != EOF){
				if(rec[0] == token[0] && rec[1] == token[1]){
					char * ptr;
					ptr = strchr(rec,'|');
					if(n == ptr-rec)
						if(strncmp(token,rec,n) == 0){
							ProcessResult(ptr+1,tokenTree);//printf("\n%s",rec);
							break;
						}
				}
				else break;
			}
		}
		free(rec);
		fclose(fp);
	}
}

void SearchInContent(char * token,PPH_AVL_TREE tokenTree)
{
	if(ContentMap[token[0]-'a'][token[1]-'a'] !=-1){
		FILE *fp;
		char *rec;
		int res,n;
		n = strlen(token);
		rec = malloc(sizeof(char)*20*ONE_MB);
		fp = fopen(CONTENT_FILENAME,"rbS");
		fsetpos(fp,&ContentMap[token[0]-'a'][token[1]-'a']);
		while(!feof(fp)){
			res = fscanf(fp,"%[^\n]%*c",rec); 
			if(res != 0 && res != EOF){
				if(rec[0] == token[0] && rec[1] == token[1]){
					char * ptr;
					ptr = strchr(rec,'|');
					if(n == ptr-rec)
						if(strncmp(token,rec,n) == 0){
							ProcessResult(ptr+1,tokenTree);//printf("\n%s",rec);
							break;
						}
				}
				else break;
			}
		}
		free(rec);
		fclose(fp);
	}
}
void SearchInInfobox(char * token,PPH_AVL_TREE tokenTree)
{
	if(InfoboxMap[token[0]-'a'][token[1]-'a'] !=-1){
		FILE *fp;
		char *rec;
		int res,n;
		n = strlen(token);
		rec = malloc(sizeof(char)*20*ONE_MB);
		fp = fopen(INFOBOX_FILENAME,"rbS");
		fsetpos(fp,&InfoboxMap[token[0]-'a'][token[1]-'a']);
		while(!feof(fp)){
			res = fscanf(fp,"%[^\n]%*c",rec); 
			if(res != 0 && res != EOF){
				if(rec[0] == token[0] && rec[1] == token[1]){
					char * ptr;
					ptr = strchr(rec,'|');
					if(n == ptr-rec)
						if(strncmp(token,rec,n) == 0){
							ProcessResult(ptr+1,tokenTree);//printf("\n%s",rec);
							break;
						}
				}
				else break;
			}
		}
		free(rec);
		fclose(fp);
	}
}

void SearchInCategory(char * token,PPH_AVL_TREE tokenTree)
{
	if(CategoryMap[token[0]-'a'][token[1]-'a'] !=-1){
		FILE *fp;
		char *rec;
		int res,n;
		n = strlen(token);
		rec = malloc(sizeof(char)*20*ONE_MB);
		fp = fopen(CATEGORY_FILENAME,"rbS");
		fsetpos(fp,&CategoryMap[token[0]-'a'][token[1]-'a']);
		while(!feof(fp)){
			res = fscanf(fp,"%[^\n]%*c",rec); 
			if(res != 0 && res != EOF){
				if(rec[0] == token[0] && rec[1] == token[1]){
					char * ptr;
					ptr = strchr(rec,'|');
					if(n == ptr-rec)
						if(strncmp(token,rec,n) == 0){
							ProcessResult(ptr+1,tokenTree);//printf("\n%s",rec);
							break;
						}
				}
				else break;
			}
		}
		free(rec);
		fclose(fp);
	}
}

void SearchInOutlinks(char * token,PPH_AVL_TREE tokenTree)
{
	if(OutlinksMap[token[0]-'a'][token[1]-'a'] !=-1){
		FILE *fp;
		char *rec;
		int res,n;
		n = strlen(token);
		rec = malloc(sizeof(char)*20*ONE_MB);
		fp = fopen(OUTLINKS_FILENAME,"rbS");
		fsetpos(fp,&OutlinksMap[token[0]-'a'][token[1]-'a']);
		while(!feof(fp)){
			res = fscanf(fp,"%[^\n]%*c",rec); 
			if(res != 0 && res != EOF){
				if(rec[0] == token[0] && rec[1] == token[1]){
					char * ptr;
					ptr = strchr(rec,'|');
					if(n == ptr-rec)
						if(strncmp(token,rec,n) == 0){
							ProcessResult(ptr+1,tokenTree);//printf("\n%s",rec);
							break;
						}
				}
				else break;
			}
		}
		free(rec);
		fclose(fp);
	}
}

int IRECompareString(const void * v1,const void * v2)
{
	const struct TitleEntry ** t1 = (struct TitleEntry ** )v1;
	const struct TitleEntry ** t2 = (struct TitleEntry ** )v2;
	return (*t1)->docid - (*t2)->docid;
}
int GetTitleForID(int id,char *title)
{
	//int res;
	//char *ptr;
	//FILE *fp ;
	struct TitleEntry * pItem;
/*	if(TitleMapUnindexed[id] != 0){
		fp = fopen(TITLES_UNINDEXED_FILENAME,"rbS");
		fsetpos(fp,TitleMapUnindexed[id]);
		res = fscanf(fp,"%[^\n]%*c",title); 
		if(res != 0 && res != EOF){
			char * ptr = strchr(title,'|');
			sprintf(title,"%s",ptr+1);
		}
		fclose(fp);
	}*/

	pItem = bsearch (&id, TitleMapUnindexed, titleCount, sizeof (struct TitleEntry *), IRECompareString);
	if(pItem != NULL){
		strcpy(title,pItem->title);
		return 1;
	}
	else return 0;


}

void ProcessQuery( char* query ) 
{
	//1.split the query in to tokens at ' '
	//2.each token should be analysed if it contains ':'

	char *ptr;
	char * token;
	char ** tokens ;
	int i=0;

	//Create tokens from the query
	tokens = malloc(sizeof(char*)*MAX_TOKENS_IN_QUERY);
	token = strtok (query," ");
	while (token != NULL){
		tokens[i++] = token;
		token = strtok (NULL," ");
	}
	NumOfTokensInQuery = i;
	//For each token create an AVL tree containing document id and related information in the nodes
	//so we have, for n query tokens n AVL trees created
	for(i=0;i<NumOfTokensInQuery;i++){
		PhInitializeAvlTree(&tokensTrees[i],Qcompare,QAVLDeleteCallback);		//initiate avl tree
		if((ptr = strchr(tokens[i],':'))!=NULL){
			char prefix[20];
			sprintf(prefix,"%.*s",ptr-tokens[i],tokens[i]);
			if(strlen(ptr+1) > 2){
				if(strcmp(prefix,"title")==0){
					SearchInTitles(ptr+1,&tokensTrees[i]);
					//search in category index
				}
				else if(strcmp(prefix,"category")==0){
					SearchInCategory(ptr+1,&tokensTrees[i]);
					//search in category index
				}
				else if(strcmp(prefix,"infobox")==0){
					SearchInInfobox(ptr+1,&tokensTrees[i]);
					//search in infobox index
				}
				else if(strcmp(prefix,"content")==0){
					SearchInContent(ptr+1,&tokensTrees[i]);
					//search in content index
				}
				else if(strcmp(prefix,"outlink")==0){
					SearchInOutlinks(ptr+1,&tokensTrees[i]);
					//search in content index
				}
			}
		}
		else{
			if(strlen(tokens[i]) > 2){
				SearchInTitles(tokens[i],&tokensTrees[i]);
				//printf("\nCategory");
				SearchInCategory(tokens[i],&tokensTrees[i]);
				//printf("\nInfobox");
				SearchInInfobox(tokens[i],&tokensTrees[i]);
				//printf("\nContent");
				SearchInContent(tokens[i],&tokensTrees[i]);
				//search in all the three indexes
				SearchInOutlinks(ptr+1,&tokensTrees[i]);
			}
		}
	}
	free(tokens);

	//Creation of AVL trees for each token is done(by this point)......
	//Now I create a master avl tree whose node's TokenCount indicates word combinations in the given query...
	//for example: if TokenCount for a node is 2 it implies that 2 words from the query are present at the node's doc id
	//             if TokenCount for a node is 3 it implies that 3 words from the query are present at the node's doc id
	//So obviously nodes with higher TokenCount are ranked 1st -- ofcourse if nodes have same TokenCount i still need to
	//take care of their document frequency ;)
	PhInitializeAvlTree(&MasterTree,Qcompare,QAVLDeleteCallback);		//initiate avl tree
	for(i = 0;i < NumOfTokensInQuery; i++){
		PhEnumAvlTree(&tokensTrees[i],TreeEnumerateInOrder,QTreeCallback);		//
		PhDeleteTree(tokensTrees[i].Root.Right,&tokensTrees[i]);
	}
	//prepare results from the master avl tree
	{
		int TotalResultsCount = MasterTree.Count;
		int minimum;
		char title[200];
		k = 0;
		results = malloc(sizeof(QueryToken*)*TotalResultsCount);				//allocate as many pointers as the results in Master AVL
		PhEnumAvlTree(&MasterTree,TreeEnumerateInOrder,QMasterTreeCallback);	//
		PhDeleteTree(MasterTree.Root.Right,&MasterTree);

		//now sort the results..
		qsort(results,TotalResultsCount,sizeof(QueryToken*),ResultsCompare);
		//Iterate top MAX_NUM_RESULTS results.....and sign off
		minimum = TotalResultsCount < MAX_NUM_RESULTS ? TotalResultsCount : MAX_NUM_RESULTS;
		printf("\n==================================================================================");
		printf("\n%-12s | %-10s | %-10s | %-10s","Document id","Frequency","Word Combination","Title");
		printf("\n==================================================================================");
		for(i = 0;i<minimum;i++){
			if(GetTitleForID(results[i]->DocId,&title) != 0);
				printf("\n%-12d | %-10d | %-10d | %-10s",results[i]->DocId,results[i]->Frequency,results[i]->TokenCount,title);
		}
		printf("\n==================================================================================");
		for(i = 0;i<TotalResultsCount;i++)
			free(results[i]);
		free(results);
	}
	//YES MY JOB IS DONE................................................
}


void Search()
{
	char query[100];
	CreateMaps();
	while(1){
		printf("\nEnter the query:");
		scanf("%[^\n]%*c",query);
		ProcessQuery(query);
	}
}