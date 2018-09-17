#include<stdio.h>

char * strdup(const char *s) {
	char *d = (char *)(malloc (strlen (s) + 1)); // Space for length plus nul
	if (d == NULL) return NULL;                  // No memory
	strcpy (d,s);                                // Copy the characters
	return d;                                    // Return the new string
}

int main()
{
	int n = 36;
	float f1 = n/2;

	do{
		f1 = ( f1 + (n/f1) ) / 2;
	}while( fabs(( f1 - (n/f1) ) / 2) > 0.01f);
	printf("\n%f",f1);
}


