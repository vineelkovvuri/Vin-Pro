#include<stdio.h>

typedef struct _Record {
	char record[100]; 
}Record;


int main()
{
	printf("%d",sizeof(Record));
}