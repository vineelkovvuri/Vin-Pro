/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  2-Way file merger for merging intermediate index files
 *	 							 	 
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#include "FileMerger.h"

static void FileMerge(char *file1Path, char * file2Path, char * outfilePath,
	char *rec1,char *rec2            // avoid repeated allocation of memory every time..
									 // will be allocated in MergeDir and passed to this function
	)
{
	int res;
	char *chr1,*chr2;
	char word1[MAX_WORD_SIZE],word2[MAX_WORD_SIZE];
	FILE *file1,*file2,*outfile;
	file1 = fopen(file1Path,"rbS");
	file2 = fopen(file2Path,"rbS");
	outfile = fopen(outfilePath,"wbS");

	fscanf(file1,"%[^\n]%*c",rec1); 
	fscanf(file2,"%[^\n]%*c",rec2);	
	while(!feof(file1) && !feof(file2)){	// 2-Way merge 
		chr1 = strchr(rec1,'|');
		chr2 = strchr(rec2,'|');
		strncpy(word1,rec1,chr1 - rec1); word1[chr1 - rec1] = 0;
		strncpy(word2,rec2,chr2 - rec2); word2[chr2 - rec2] = 0;
		res = strcmp(word1,word2);
		if(res < 0){
			fprintf(outfile,"%s\n",rec1);
			if(!feof(file1) && !feof(file2))
				fscanf(file1,"%[^\n]%*c",rec1); 
		}
		else if(res > 0){
			fprintf(outfile,"%s\n",rec2);
			if(!feof(file1) && !feof(file2))
				fscanf(file2,"%[^\n]%*c",rec2); 
		}
		else { //if res == 0 both strings are same till |
			fprintf(outfile,"%.*s%s%s\n",(chr1 - rec1),rec1,chr1,chr2);
			if(!feof(file1) && !feof(file2)){
				fscanf(file1,"%[^\n]%*c",rec1); 
				fscanf(file2,"%[^\n]%*c",rec2); 
			}
		}
	}
	if(feof(file1)){	 //if 1st array is finished and 2nd array is left over copy the left over items manually
		while(!feof(file2)){
			res = fscanf(file2,"%[^\n]%*c",rec1); //reusing rec1 memory
			if(res != 0 && res != EOF)fprintf(outfile,"%s\n",rec1);//reusing rec1 memory
		}
	}
	else if(feof(file2)){//if 2nd array is finished and 1st array is left over copy the left over items manually
		while(!feof(file1)){
			res = fscanf(file1,"%[^\n]%*c",rec1); //reusing rec1 memory
			if(res != 0 && res != EOF)fprintf(outfile,"%s\n",rec1);//reusing rec1 memory
		}
	}
	fclose(file1);
	fclose(file2);
	fclose(outfile);
}
/*
	This function iterates over the given folder and merges the 2 files at a time (by creating new files and deleting old ones)
	and this process is repeated until final index.txt file is produced in the folder
*/
void MergeDir(char *path) 
{
	char *rec1, *rec2 ; //Pointers to hold lines read by Merge Function -- Optimization
	WIN32_FIND_DATA data={0};	// back to my win32 knowledge. I know nothing moves without U - iterates files in a directory
	HANDLE h;
	int nfilePaths,i=0;
	char temp[MAX_PATH];
	char outfilePath[MAX_PATH];
	char **filePaths = malloc(sizeof(char*)*MAX_NUM_FILES);
	srand (time(NULL));
	sprintf(temp,"%s*.*",path);					//path = c:\windows name = *.*
	rec1 = malloc(sizeof(char)*MAX_RECORD_SIZE);
	rec2 = malloc(sizeof(char)*MAX_RECORD_SIZE);

	while(TRUE){ //loop thru all the files
		i = 0;
		ZeroMemory(&data,sizeof(WIN32_FIND_DATA));
		h = FindFirstFile(temp,&data);	//temp = c:\windows\*.*
		if(h != INVALID_HANDLE_VALUE){  //Check whether we got valid handle or not 
			do{
				if(ValidDir(data)){		//Checks whether the Dir is . or .. - USELESS FILES 
					filePaths[i] = malloc(sizeof(char)*MAX_PATH);
					sprintf(filePaths[i++],"%s%s",path,data.cFileName); 
				}
			}while(FindNextFile(h,&data));
			nfilePaths = i;
			FindClose(h);

			if(nfilePaths > 1){ // proceed only if at least 2 files are present.
				for(i = 0;  i < nfilePaths - 1; i+=2){
					sprintf(outfilePath,"%s%d%d%d_merged.txt",path,GetTickCount(),rand(),rand());
					//Log(log,"Merging : %s + %s => %s\n",filePaths[i],filePaths[i+1],outfilePath);
					FileMerge(filePaths[i],filePaths[i+1],outfilePath,
						  rec1,rec2);// Yes I am passing memory for file merge to use. Instead of FileMerge create them each time - Optimization :)
					DeleteFile(filePaths[i]);
					DeleteFile(filePaths[i+1]);
					free(filePaths[i]);
					free(filePaths[i+1]);
				} 
			}else if(nfilePaths == 1){
				char outfilename[MAX_PATH]={0};
				sprintf(outfilename,"%s%s",path,"index.txt");
				MoveFile(filePaths[0],outfilename); // rename the final file as index.txt
				free(filePaths[0]);					// U cannot escape from my mental garbage collector - 100% no memory leak
				break;
			}
			else{
				break;
			}
		}
		else break;
	}
	free(rec1);
	free(rec2);
	free(filePaths);
}
