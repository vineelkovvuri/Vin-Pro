#include<stdio.h>
#include<ctype.h>
#include<string.h>
#include<stdlib.h>
#include<math.h>

char sen[1500];
int main()
{
	while (1) {
		sen[0] = 0;
		scanf("%[^\n]", &sen);
		if (strlen(sen) == 0) {
			getchar();
		} else {
			int i = 0;
			if (strcmp(sen, "*") == 0) break;
			for (i = 1; sen[i]; i++) {
				if (sen[i-1] == ' '){
					if (tolower(sen[i]) != tolower(sen[0]==' '?sen[1]:sen[0])) {
						printf("N\n");
						break;
					}
				}
			}
			if (sen[i] == 0) printf("Y\n");
		}
	}
	return 0;
}

