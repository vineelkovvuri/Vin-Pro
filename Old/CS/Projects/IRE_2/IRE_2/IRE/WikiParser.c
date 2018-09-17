/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Wiki XML Cruncher :) - Parser for wiki xml file - no regex, no worries - only strstr
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */


#include "WikiParser.h"
//#include "Tokenizer.h"  // including tokenizer in parser is very bad design.......

/*
takes care of  {{ and [[ inside {{Infobox and [[Category respectively
sample text:
{{Infobox 
| Age : 25
| date : {{ asdfasdfasdf , asdasdfasdfasdf }}  
| Weight : 50
}}
*/
char * IREstrstr(const char *src, const char * skip,const char * pat)
{
	const char * begin = src + 2; // skip {{ in {{Infobox and [[ in [[Category
	char * p1 = NULL,*p2 = NULL; 
	while(*begin){
		p1 = strstr(begin,pat);  //}}
		p2 = strstr(begin,skip);  //{{
		if(p2 == NULL) break;
		else if(p1 < p2) break; // {{ is not there at all or it is there after }}
		else  begin = p1 + 2; //skip }}
	}
	return p1;
}

char * IREstrchr(const char *src,const char c,int num)
{
	int i = 0;
	for(i = 0; i < num;i++)
		if(src[i] == c) return &src[i];
	return NULL;
}

/*
void DupArticle(struct WikiArticle *article, struct WikiArticle *temp)
{
	strcpy(temp->id,article->id);
	memcpy(temp,article,sizeof(struct WikiArticle));

	temp->category = malloc(sizeof(char)*article->categoryLength);
	memcpy(temp->category,article->category,article->categoryLength);

	temp->outlinks = malloc(sizeof(char)*article->outlinksLength);
	memcpy(temp->outlinks,article->outlinks,article->outlinksLength);

	temp->infobox = malloc(sizeof(char)*article->infoboxLength);
	memcpy(temp->infobox,article->infobox,article->infoboxLength);

	temp->content = malloc(sizeof(char)*article->contentLength);
	memcpy(temp->content,article->content,article->contentLength);
}*/
char * findUrlDelim(char *tagBegin)
{
	int i = 0;
	char * p = tagBegin;
	for(i=0;i < 200; i++){ // make sure the url doesnot exceed 200 chars
		if(*p == ' ' || *p == '|')
			return p;
	}
	return NULL;
}
void deleteURls(char * content,char * urlPrefix)
{//delete urls - http://
	char *tagBegin = NULL,*tagEnd = NULL;
	tagBegin = content;
	while(tagBegin = strstr(tagBegin,urlPrefix)){
		char *tagEnd = findUrlDelim(tagBegin);
		if(tagEnd  != NULL){
			tagEnd += 1; 
			memset(tagBegin,' ',tagEnd - tagBegin + 1);
			tagBegin = tagEnd;
		}
		else{  //move to next Citation -- FALL BACK
			tagBegin += 1;
		}
	}
}

/*
	This method declaration may requrire some description
	2nd parameter is a function pointer to the TokenizerCallback
	This function pointer is executed upon extracting each wiki article.
	Directly calling tokenizer function by its name from wikiparser breaks
	modularity between Wikiparser module and Tokenizer module.

	Yes, My code should be MODULAR.
*/
void Parser(FILE * fp, void (*TokenizerCallback )( void * ))
{
	unsigned char ch;
	char tag[MAX_TAG_LEN];
	int i = 0,nextIsID;
	struct WikiArticle article;
	int initialContentCap = ONE_MB;
	int initialInfoboxCap = ONE_MB;
	int initialOutlinksCap = ONE_MB;
	int initialCategoryCap = ONE_MB;
	HANDLE hParserThread = NULL; //YeS aTlaSt I aM uSing tHreAds 
	ZeroMemory(&article,sizeof(struct WikiArticle));
	article.infobox  = (char *) malloc(initialInfoboxCap*sizeof(char));
	article.category = (char *) malloc(initialCategoryCap*sizeof(char));
	article.outlinks = (char *) malloc(initialOutlinksCap*sizeof(char));
	article.content  = (char *) malloc(initialContentCap*sizeof(char));
	//setvbuf(fp,NULL,_IOFBF,1024*1024*100);
	while(TRUE){
		i=0;
		//read a tag
		//skip until beginning of a next tag
		while(!feof(fp)){
			if(fgetc(fp) == '<'){
				tag[i++] = '<';
				break;
			}
		}
		while(!feof(fp)){
			ch = fgetc(fp);
			tag[i++] = ch;	
			if(ch == '>') {
				tag[i] = 0;
				break;
			}
		}
		//check for the tag name
		//if tag is title read until </title>
		if(strcmp(tag,"<title>") == 0){
			//read until < of </title>
			for(i=0; !feof(fp)&&(ch = fgetc(fp))!='<';i++)
				article.title[i] = ch;
			article.title[i] = 0;
			article.titleLength = i;
			// left over /title> will be skipped by next iteration of the first while loop
			nextIsID = TRUE;
		}
		else if(strcmp(tag,"<id>") == 0 && nextIsID == TRUE){
			//read until < of </id>
			for(i=0; !feof(fp)&&(ch = fgetc(fp))!='<';i++)
				article.id[i] = ch;
			article.id[i] = 0;
			// left over /id> will be skipped by next iteration of the first while loop
			nextIsID = FALSE;
		}
		else if(strcmp(tag,"<text xml:space=\"preserve\">") == 0){
			//Log(log,"Parsing document id:%s\n",article.id);
			for(i = 0; !feof(fp)&&(ch = fgetc(fp))!='<';i++){
				if(i >= initialContentCap)	article.content = realloc(article.content,initialContentCap *= 2);
				article.content[i] = ch;
			}
			article.content[i] = 0;
			article.contentLength = i;

#pragma region processingcontent

		/*					EXTRACTION OF TITLE ID AND TEXT TAGS ARE DONE						*/
		/*					FOLLOWING CODE WILL PROCESS TEXT TAG FOR INFOBOX,CATEGORIES ETC		*/
			{//delete generic tags from content - &lt;ref&gt;
				char *tagBegin = NULL,*tagEnd = NULL;
				tagBegin = article.content;
				while(tagBegin = strstr(tagBegin,"&lt;ref&gt;")){
					char *tagEnd = strstr(tagBegin,"&lt;/ref&gt;");
					if(tagEnd  != NULL){
						tagEnd += 12; 
						memset(tagBegin,' ',tagEnd - tagBegin);
						tagBegin = tagEnd;
					}
					else{  //move to next Citation -- FALL BACK
						break;
					}
				}
			}
			{//extract infobox from content
				char *infoboxBegin = NULL,*infoboxEnd = NULL;
				int infoboxSize = 0;
				article.infobox[0] = 0;
				infoboxBegin = article.content;
				while(infoboxBegin = strstr(infoboxBegin,"{{Infobox")){
					char *infoboxEnd = IREstrstr(infoboxBegin,"{{","}}");
					infoboxSize = 0;
					if(infoboxEnd != NULL){
						char * tempEnd;
						infoboxEnd += 2; //}} for }}
						tempEnd = infoboxEnd;
						infoboxEnd = strchr(infoboxBegin,'|');
						infoboxSize = infoboxEnd - (infoboxBegin + 10) + 1; // include "|" so that it ll be converted as space in tokenization
						if(article.infoboxLength + infoboxSize >= initialInfoboxCap)
							article.infobox = realloc(article.infobox,initialInfoboxCap *= 2); // = check is to make sure we have enough memory to copy \0
						strncat(article.infobox,infoboxBegin + 10,infoboxSize);
						memset(infoboxBegin,' ',tempEnd - infoboxBegin); // make null in the string
						article.infoboxLength += infoboxSize;
						infoboxBegin = tempEnd;
					}
					else{//move to next infobox -- FALL BACK
						break;
					}
				}
				article.infobox[article.infoboxLength] = 0;
			}
			{//extract category from content
				char *categoryBegin = NULL,*categoryEnd = NULL;
				int categorySize = 0;
				article.category[0] = 0;
				categoryBegin = article.content;
				while(categoryBegin = strstr(categoryBegin,"[[Category:")){
					char *categoryEnd = IREstrstr(categoryBegin,"[[","]]");
					categorySize = 0;
					if(categoryEnd != NULL){		// this check is needed because some categories not properly close. In such case ignore those category.
						categoryEnd += 2; //2 for ]]
						if(article.categoryLength + (categoryEnd - categoryBegin + 1) >= initialCategoryCap)
							article.category = realloc(article.category,initialCategoryCap *= 2); // = check is to make sure we have enough memory to copy \0
						strncat(article.category,categoryBegin + 11,categoryEnd - (categoryBegin + 11) + 1);
						categorySize = (categoryEnd - categoryBegin + 1);
						article.categoryLength += categorySize;
						memset(categoryBegin,' ',categoryEnd - categoryBegin + 1);
						categoryBegin = categoryEnd;
					}
					else { //move to next category -- FALL BACK
						break; // this is for skipping current categories beginning or else same [[Category will be matched again and loop forever
					}
				}
				article.category[article.categoryLength] = 0;
			}
			{//delete tags cotnaining languags from content - [[ * : * ]]
				char *tagBegin = NULL,*tagEnd = NULL;
				tagBegin = article.content;
				while(tagBegin = strstr(tagBegin,"[[")){
					char *tagEnd = strstr(tagBegin,"]]");
					if(tagEnd  != NULL){
						tagEnd += 2; 
						if(IREstrchr(tagBegin,':',tagEnd - tagBegin + 1) != NULL){
							memset(tagBegin,' ',tagEnd - tagBegin + 1);
						}
						tagBegin = tagEnd;
					}
					else{  //move to next Citation -- FALL BACK
						break;
					}
				}
			}
		/*	{//delete generic tags from content - &lt;ref&gt;
				char *tagBegin = NULL,*tagEnd = NULL;
				tagBegin = article.content;
				while(tagBegin = strstr(tagBegin,"&lt;ref")){
					char *tagEnd = strstr(tagBegin,"&gt;");
					if(tagEnd  != NULL){
						tagEnd += 4; 
						memset(tagBegin,' ',tagEnd - tagBegin);
						tagBegin = tagEnd;
					}
					else{  //move to next Citation -- FALL BACK
						break;
					}
				}
			}*/
			{//delete citation tags from content - {{cite;
				char *tagBegin = NULL,*tagEnd = NULL;
				tagBegin = article.content;
				while(tagBegin = strstr(tagBegin,"{{cite")){
					char *tagEnd = strstr(tagBegin,"}}");
					if(tagEnd  != NULL){
						tagEnd += 2; 
						memset(tagBegin,' ',tagEnd - tagBegin);
						tagBegin = tagEnd;
					}
					else{  //move to next Citation -- FALL BACK
						break;
					}
				}
			}
			
			{//delete urls - http://
				deleteURls(article.content,"http://");
				deleteURls(article.content,"ftp://");
				deleteURls(article.content,"https://");
				deleteURls(article.content,"ftps://");
			}
			/*{//extract Outlinks from content
				char *outlinksBegin = NULL,*outlinksEnd = NULL;
				int outlinksSize = 0;
				article.outlinks[0] = 0;
				outlinksBegin = article.content;
				while(outlinksBegin = strstr(outlinksBegin,"[[")){
					char *outlinksEnd = strstr(outlinksBegin,"]]");
					outlinksSize = 0;
					if(outlinksEnd  != NULL){
						outlinksSize = outlinksEnd - (outlinksBegin + 2);
						outlinksEnd += 2; //2 for ]]
						if(article.outlinksLength + outlinksSize >= initialOutlinksCap)
							article.outlinks = realloc(article.outlinks,initialOutlinksCap *= 2); // = check is to make sure we have enough memory to copy \0
						strncat(article.outlinks,outlinksBegin + 2,outlinksSize + 1);
						article.outlinksLength += outlinksSize;
						memset(outlinksBegin,' ',outlinksEnd - outlinksBegin + 1);
						outlinksBegin = outlinksEnd;
					}
					else{  //move to next Outlinks -- FALL BACK
						break;
					}
				}
				article.outlinks[article.outlinksLength] = 0;
			}*/
#pragma endregion processingcontent

			//Invokde Tokenizer callback
			//Log(log,"Invoking Tokenizer Callback for id:%s\n",tempArticle.id);
			TokenizerCallback(&article);

			// left over /text> will be skipped by next iteration of the first while loop
		}
		//free memory
		if(feof(fp))break;
	}
	free(article.outlinks);
	free(article.content);
	free(article.infobox);
	free(article.category);

	Log(log,"Parsing done\n");
}


