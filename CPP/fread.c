#include<stdio.h>

struct record{
	char subject[80];
	//int inter,exter,total;
}records[10];	

main()
{
	
	
	int i = 0,n;
	FILE *fp = fopen("C:\\Documents and Settings\\Hacker\\Desktop\\Class Marks 3-1.txt","r");
	
	n = fread(records,sizeof(struct record),10,fp);
	
	for(i=0;i<n;i++)
	{
		records[i].subject[79] = 0;
		printf("\n%s|",records[i].subject);
		printf("\n----------------------------------------------------------------------");
	}
	
	
	
	fclose(fp);
}
