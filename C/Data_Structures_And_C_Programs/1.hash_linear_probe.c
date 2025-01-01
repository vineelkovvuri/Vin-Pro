#include <stdio.h>
#include <string.h>

#define HASH_TABLE_SIZE 4

char* hash_table[HASH_TABLE_SIZE];

int hash(char* str)
{
    return str[0] % HASH_TABLE_SIZE;
}

int insert(char* str)
{
    int h, idx;
    h = idx = hash(str);

    do {
        if (hash_table[idx] == NULL) {
            hash_table[idx] = str;
            return idx;
        }

        if (strcmp(hash_table[idx], str) == 0) return idx;
        idx = (idx + 1) % HASH_TABLE_SIZE;
    } while (idx != h);

    return -1;
}

int find(char* str)
{
    int h, idx;
    h = idx = hash(str);

    do {
        if (hash_table[idx] == NULL) return -1;
        if (strcmp(hash_table[idx], str) == 0) return idx;
        idx = (idx + 1) % HASH_TABLE_SIZE;
    } while (idx != h);

    return -1;
}

int main()
{
    char *str[] = {
        "riya",
        "vihaan",
        "nischala",
        "vineel",
        "reddy",
    };

    for (int i = 0; i < sizeof(str)/sizeof(char*); i++) {
        int status = insert(str[i]);
        if (status != -1) {
            printf("\n%s inserted at %d", str[i], status);
        } else {
            printf("\n%s failed to insert", str[i]);
        }
    }

    for (int i = 0; i < sizeof(str)/sizeof(char*); i++) {
        int status = find(str[i]);
        if (status != -1) {
            printf("\n%s found at %d", str[i], status);
        } else {
            printf("\n%s failed to find", str[i]);
        }
    }

    return 0;
}
