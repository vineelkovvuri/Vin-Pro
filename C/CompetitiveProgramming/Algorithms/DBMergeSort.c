/* 	Program to perform 2-Way Merge sort on the input file 
	Author: Vineel Kumar Reddy Kovvuri 
			M TECH CSE - 201005035
	Status: Complete implementation	done	
*/

#include<stdio.h>
#include<string.h>
#include<stdlib.h>

//structure to hold each record
typedef struct _Record {
	char record[100]; 
}Record;

long RECORD_SIZE = 100;   
long TOTAL_RECORDS_IN_FILE = 0;
long TOTAL_MEM_SIZE = 2 ; //2 implies 2 MB => 2048KB ~ 2000KB = 2000*1000 Bytes = 2000*10 records (since each record is of 100 bytes)
long TOTAL_RECORDS_IN_MEM = 10000 * 2; //default to 20000 records

char filename[1000] = "C:\\Documents and Settings\\Hacker\\My Documents\\visual studio 2010\\Projects\\temp2\\Debug\\input.txt";
Record ** records ; // pointer to hold array of records....

//returns the ith record from the input file
void GetRecord(long offset, FILE *fp, Record * rec)
{
	fseek(fp, offset * RECORD_SIZE, SEEK_SET);
	fread(rec,sizeof(Record),1,fp);	
}

// T(n) = n - 1 worst case
void Merge(long rec1Start, long rec1End, long rec2Start, long rec2End)
{
	long i = rec1Start,j = rec2Start,k = 0; // i points to first sorted sub array and j points to second sorted sub array and k points to new file
	Record temp,rec1,rec2;

	FILE * infile = fopen(filename,"rb");   // read each record from the input file for merging
	FILE * tempfp = fopen("temp.txt","wb"); // temp file to hold merged content
	while(i <= rec1End && j <= rec2End){	// 2-Way merge 
		GetRecord(i,infile,&rec1);
		GetRecord(j,infile,&rec2);	
		if(strcmp(rec1.record,rec2.record) < 0){
			fwrite(&rec1,sizeof(Record),1,tempfp);
			i++;
		}
		else {
			fwrite(&rec2,sizeof(Record),1,tempfp);
			j++;
		}
		k++;
	}
	
	if(i > rec1End){	 //if 1st array is finished and 2nd array is left over copy the left over items manually
		long l;
		for(l = j; l <= rec2End; l++){
			GetRecord(l,infile,&temp);
			fwrite(&temp,sizeof(Record),1,tempfp);
		}
		k += rec2End - j + 1;
	}
	else if(j > rec2End){//if 2nd array is finished and 1st array is left over copy the left over items manually
		long l;
		for(l = i; l <= rec1End; l++){
			GetRecord(l,infile,&temp);
			fwrite(&temp,sizeof(Record),1,tempfp);
		}
		k += rec1End - i + 1;
	}
	fclose(tempfp);
	fclose(infile);

	//save the merged content from temp file to inputfile(overwriting)
	infile = fopen(filename,"rb+");
	tempfp = fopen("temp.txt","rb");
	fseek(infile,rec1Start * RECORD_SIZE,SEEK_SET);
	for(i = 0;i < k; i++){
		fread(&temp ,sizeof(Record),1,tempfp);
		fwrite(&temp,sizeof(Record),1,infile);
	}
	fclose(infile);
	fclose(tempfp);
}

int Compare(const void * record1, const void * record2)
{
	Record **rec1 = (Record **)record1;
	Record **rec2 = (Record **)record2;
	return memcmp((*rec1)->record,(*rec2)->record, 10);  // 10 => size of first column
}
// T(n) = O(nlogn) + 2n ~ O(nlogn)
void InMemorySort(long start , long end)
{
	long i;
	
	//read records to memory	
	FILE * fp = fopen(filename,"rb");
	fseek(fp, start * RECORD_SIZE, SEEK_SET);
	for(i = 0; i <= end - start;i++)
		fread(records[i],sizeof(Record),1,fp);
	fclose(fp);

	//sort the records
	qsort(records,end - start + 1,sizeof(Record*),Compare);  // qsort = QUICK SORT 
	
	//write records back to file
	fp = fopen(filename,"rb+");	
	fseek(fp, start * RECORD_SIZE, SEEK_SET);
	for(i = 0; i <= end - start;i++)
		fwrite(records[i],sizeof(Record),1,fp);
	fclose(fp);
}

// T(n) = 2T(n/2) + n - 1	if n >  TOTAL_RECORDS_IN_MEM
// T(n) = O(nlogn)			if n <= TOTAL_RECORDS_IN_MEM
void MergeSort(long start , long end)
{
	//if sub arrays are larger than memory size keep on sub dividing
	if(end - start + 1 > TOTAL_RECORDS_IN_MEM){
		MergeSort(start, (start + end)/2);
		MergeSort((start + end)/2 + 1, end);
		Merge(start,(start + end)/2,(start + end)/2 + 1,end);
	}
	else{ // Yes the system can digest the subarray.....so sort it in memory
		InMemorySort(start, end);
	}
}

//O(1)
long GetTotalRecords(const char *filename)
{
	long pos = 0;
	FILE * fp = fopen(filename,"rb");
	fseek(fp,0,SEEK_END);
	pos = ftell(fp);
	fclose(fp);
	return pos / RECORD_SIZE;
}

int main()
{
	long i;
	printf("\nEnter the file name(X=input.txt):");
	scanf("%s",filename);
	TOTAL_RECORDS_IN_FILE = GetTotalRecords(filename);
	printf("\nEnter the memory size in MB(Y):");
	scanf("%ld",&TOTAL_MEM_SIZE);
	TOTAL_RECORDS_IN_MEM = 10000 * TOTAL_MEM_SIZE;	//since 1 MB can store 10000 records, So total number of records = 10000*TOTAL_MEM_SIZE
	
	//Allocate memory(pointers) for storing the records
	records = (Record **) malloc(TOTAL_RECORDS_IN_MEM*sizeof(Record*));
	for(i = 0;i < TOTAL_RECORDS_IN_MEM;i++)
		records[i] = (Record *) malloc(sizeof(Record));
	
	MergeSort(0, TOTAL_RECORDS_IN_FILE - 1);
	printf("\nPlease open input.txt for sorted data");
	return 0;
}
