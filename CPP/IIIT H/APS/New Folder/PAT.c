#include<stdio.h>
#include<stdlib.h>
#include<string.h>


int subpatsize = 10;

char * matchalpha(char * src,char *pat)
{
	char *c;
	c = strstr(src,pat); 
	if(c != NULL) return c + strlen(pat);
	return NULL;
}
char * matchques(char * src)
{
	if(src[0] != 0) return src + 1;
	return NULL;
}
void split(char *pat, char * delim,char ** patsub)
{
	int i=0;
	char * pch;
	char pattern[100] = {0};
	strcpy(pattern,pat);
	pch = strtok (pattern,delim);
	for(i=0;pch != NULL;i++){
		strcpy(patsub[i],pch);
		pch = strtok (NULL, delim);
	}
	subpatsize = i+1;
	//	return 0;
}


int main()
{
	char *buff,*p,pat[100], *subpat[10],filename[1000]={0};
	long bytes=0;
	int i=0,c,nsubpat=3,start = 0,_break = 0;
	FILE *fp;
	scanf("%s",filename);
	fp = fopen(filename,"r");
	scanf("%s",pat);
	//load in to buff
	fseek(fp,0,SEEK_END);
	bytes = ftell(fp);
	rewind(fp);
	buff = (char *)calloc(bytes,sizeof(char));

	for(i=0;(c = fgetc(fp)) != EOF;i++)
		buff[i] = c;
	fclose(fp);

	if(strcmp(pat,"?") == 0){
		for(i=0;buff[i];i++){
			printf("%d ",i);
		}
	}
	else if(strcmp(pat,"*") == 0)
		printf("%d ",0);
	else{
		//
		for(i=0;i<subpatsize;i++){ //size of sub pat
			subpat[i] = (char *) calloc(20,sizeof(char));
		}
		split(pat,"*?",subpat);
		for(i=0;i<subpatsize;i++){ //size of sub pat
			//	printf("%s|",subpat[i]);
		}

		p = buff;
		while(p <= buff+strlen(buff)  && _break == 0){
			for(start=0,i=0;i<nsubpat && _break == 0;i++){
				if(strcmp(subpat[i],"*") != 0){
					p = matchalpha(p,subpat[i]);
					if(p == NULL){
						_break = 1;
					}
					else if( i == 0 ){
						start = p - buff - strlen(subpat[i]);
					}
				}
			}
			if(_break == 0)
				printf("%d ", start);
		}
	}
	return 0;
}


