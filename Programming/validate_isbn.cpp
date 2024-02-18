#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <cctype>

int validate(char *isbn) {
	int i = 0;
	int charcount = 0;
	int checksum = 0;
	int valid_length = 13;

    if (!isbn && !*isbn)
        return -1;
    
	for (i = 0; i < valid_length - 1 && isbn[i]; i++) {
		if (i == 2 || i == 6 || i == 10) {
            if (isbn[i] != '-')
                return -1;
        }
        else {
            if (!isdigit(isbn[i]))
                return -1;
            else
                checksum += (++charcount) * (isbn[i] - '0');
        }
    }

    if (i == valid_length - 1) {
        if (isbn[valid_length] != 0) // make sure the input string is of expected length;
            return -1;
        else {
            checksum %= 11;
            if (checksum < 10)
                return isbn[i] == '0' + checksum;
            return tolower(isbn[i]) == 'x';
        }
	}
	return -1;
}


int validate_isbn()
{
    char isbn[15] = {0};
    while (1) {
        printf("\nEnter isbn:");
        scanf("%s", isbn);
        printf("\nIs Valid ISBN? %d", validate(isbn));
    }
    return 0;
}