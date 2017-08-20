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
void split(char *pat,char ** patsub)
{
	int i=0,j=0,k=0,start;
	//	char * pch;
	start = 0;

	for(i=0;pat[i];i++){
		if(pat[i]!='*' && pat[i]!='?'){
			patsub[j][k++] = pat[i];
		}
		else if(pat[i] == '*'){
			if(i != 0){
				j++;
				k = 0;
			}
			continue;
		}
		else if(pat[i] == '?'){
			if(j!=0){
				j++;
				k=0;
			}
			patsub[j][k] = '?';
			if(pat[i+1]!=0){
				j++;
				k=0;
			}
			continue;
		}
	}
	if(strcmp(pat,"*") != 0)
		subpatsize = j+1;
	else
		subpatsize = 0;
	//	return 0;
}

char * beginswith( char*src,char*pat)
{
	int i=0;
	for(i=0;pat[i]!='\0';i++)
		if(pat[i] != src[i])return NULL;
	return src + strlen(pat);
}
int main()
{
	char *buff,*p,pat[100]={0}, *subpat[10],filename[1000]={0};
	long bytes=0;
	int i=0,c,start = 0,_break = 0;
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

	if(strcmp(pat,"*") == 0){
		printf("0");
	}
	else{
		//
		for(i=0;i<subpatsize;i++){ //size of sub pat
			subpat[i] = (char *) calloc(20,sizeof(char));
		}
		split(pat,subpat);

		/*for(i=0;i<subpatsize;i++)
		  printf("%s|",subpat[i]);*/
		//exit(0);	
		p = buff;
		while(p <= buff+strlen(buff)  && _break == 0 &&subpatsize !=0){
			for(start=0,i=0;i<subpatsize && _break == 0;i++){
				if(strcmp(subpat[i],"*") != 0){
					if(strcmp(subpat[i],"?") == 0){
						p = matchques(p);
						i++;
						if(i<subpatsize && _break == 0)
							p = beginswith(p,subpat[i]);
						//printf("\n%s",p);
					}
					else {
						p = matchalpha(p,subpat[i]);
						//printf("\n%s",p);
					}
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





