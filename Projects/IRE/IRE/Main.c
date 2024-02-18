/*
 * IRE Mini Project - Implementing simple indexing and searching on wikipedia's data.
 * 
 * Module:  Main routine
 *
 * Author:  Vineel Kumar Reddy Kovvuri
 * E-mail:  vineel567@yahoo.co.in
 *
 */

#include "IRECommon.h"
#include "Indexer.h"
#include "Query.h"

int main()
{
	int ch;
	log = stderr; // intialize logging to standard error.
	printf("\n1.Indexing\n2.Searching\nEnter your choice:");
	scanf("%d%*c",&ch);
	if(ch == 1)
		Indexer();
	else if(ch == 2)
		Search();

	return 0;
}
