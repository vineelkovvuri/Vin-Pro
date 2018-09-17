/*
	Its normal problem, Only trick is more emphasis is made on reading large inputs.
	I couldn't cut the problem without using malloc of size 5MB for both needle and hay
	Ideally should have to be done with KMP since it works on streaming data. But also
	unfortunately I dont know how to read the streaming data in C.....!!
*/

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
char *ned, *hay;
int main()
{
	int n;
	hay = malloc (sizeof(char) * (2000000));
	ned = malloc (sizeof(char) * (2000000));

	while (scanf("%d", &n) != EOF) {
		char *hayp;
		int found = 0;
		scanf("%s%s", ned, hay);
		for (hayp = &hay[0]; *hayp;) {
			char *p = strstr(hayp, ned);
			if (p == NULL) break;
			else {
				printf("%d\n", (int)(p - &hay[0]));
				hayp = p + 1;
				found = 1;
			}
		}
		if (found)
			printf("\n");
	}
	free(hay);
	free(ned);
	return 0;
}