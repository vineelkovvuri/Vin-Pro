#include<stdio.h>
#include<string.h>
#include<stdlib.h>

#define true 1
#define false 0

int main()
{
	char s1[110] = {0};
	char s2[210] = {0};
	while (scanf("%s", s1) != EOF) {
		int i = 0, j = 0;
		int isJava = -1, error = false;
		for (i = 0, j = 0; s1[i]; i++) {
			if (isupper(s1[i])) {
				if (isJava == 0) {
					printf("Error!\n");
					error = true;
					break;
				}
				if (i == 0) { //Cannot have uppercase as starting letter
					printf("Error!\n");
					error = true;
					break;
				}
				if (isJava == -1)
					isJava = 1;
				
				s2[j++] = '_';
				s2[j++] = tolower(s1[i]);
			} else if (s1[i] == '_') {
				if (isJava == 1) {
					printf("Error!\n");
					error = true;
					break;
				}
				if (i == 0) { //Cannot have underscore as starting letter
					printf("Error!\n");
					error = true;
					break;
				}
				if (isJava == -1)
					isJava = 0;	
				if (islower(s1[i+1]))
					s2[j++] = toupper(s1[++i]);
				else {
					printf("Error!\n");
					error = true;
					break;
				}	
			} else {
				s2[j++] = s1[i];
			}
		}
		s2[j] = 0;
		if (!error)
			printf("%s\n", s2);
	}
	return 0;
}
