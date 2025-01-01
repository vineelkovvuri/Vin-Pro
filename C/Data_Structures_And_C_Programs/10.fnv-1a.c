#include <stdio.h>
#include <stdint.h>

#define FNV_OFFSET 14695981039346656037UL
#define FNV_PRIME 1099511628211UL

unsigned long fnv_1a(char *str)
{
    unsigned long hash = FNV_OFFSET;

    for (int i = 0; str[i]; i++) {
        hash = hash ^ str[i];
        hash = hash * FNV_PRIME;
    }

    return hash;
}


uint64_t _hash(const char* key) {
    uint64_t hash = FNV_OFFSET;
    for (const char* p = key; *p; p++) {
        hash ^= (uint64_t)(unsigned char)(*p);
        hash *= FNV_PRIME;
    }
    return hash;
}

int main()
{
    printf("\n%llx  %llx", fnv_1a("vineelkumarreddy"), _hash("vineelkumarreddy"));
    printf("\n%llx  %llx", fnv_1a("vineelkumarredd1"), _hash("vineelkumarredd1"));
    return 0;
}
