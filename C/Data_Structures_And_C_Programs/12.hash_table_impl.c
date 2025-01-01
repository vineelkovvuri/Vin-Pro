#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>

#define INITIAL_CAPACITY 4

struct hash_table {
    struct hash_table_entry {
        const char *key;
        const char *value;
    } * entries;

    int count;
    int capacity;
};

void ensure_hash_table_capacity(struct hash_table *ht);
struct hash_table_entry *put(struct hash_table *ht, const char *key, const char *value);

#define FNV_OFFSET 14695981039346656037UL
#define FNV_PRIME  1099511628211UL

uint64_t fnv_1a(const char *str)
{
    uint64_t hash = FNV_OFFSET;

    for (int i = 0; str[i]; i++) {
        hash = hash ^ str[i];
        hash = hash * FNV_PRIME;
    }

    return hash;
}

struct hash_table *create_hash_table(int capacity)
{
    struct hash_table *ret = NULL;

    ret = calloc(1, sizeof(struct hash_table));
    if (ret == NULL)
        goto exit;

    ret->entries = calloc(capacity, sizeof(struct hash_table_entry));
    if (ret->entries == NULL)
        goto free_entries;

    ret->capacity = capacity;

    return ret;

free_entries:
    free(ret->entries);
exit:
    free(ret);
    return NULL;
}

void destroy_hash_table(struct hash_table *ht)
{
    if (ht == NULL) return;
    free(ht->entries);
    free(ht);
}

void ensure_hash_table_capacity(struct hash_table *ht)
{
    if (ht->count < ht->capacity)
        return;

    int new_capacity = (int)(ht->capacity * 1.5);
    struct hash_table *new_ht = NULL;

    new_ht = create_hash_table(new_capacity);
    for (int i = 0; i < ht->capacity; i++) {
        put(new_ht, ht->entries[i].key, ht->entries[i].value);
    }

    free(ht->entries);
    ht->entries = new_ht->entries;
    ht->capacity = new_ht->capacity;
    ht->count = new_ht->count;
    free(new_ht);
}

struct hash_table_entry *put(struct hash_table *ht, const char *key, const char *value)
{
    uint64_t hash = fnv_1a(key);
    int index = hash % ht->capacity;
    int idx = index;

    ensure_hash_table_capacity(ht);

    do {
        if (ht->entries[idx].key == NULL) {
            ht->entries[idx].key = key;
            ht->entries[idx].value = value;
            ht->count++;
            return &ht->entries[idx];
        } else if (ht->entries[idx].key == key) {
            return &ht->entries[idx];
        }
        idx = (idx + 1) % ht->capacity;
    } while (idx != index);

    return NULL;
}

struct hash_table_entry *get(struct hash_table *ht, const char *key)
{
    uint64_t hash = fnv_1a(key);
    int index = hash % ht->capacity;
    int idx = index;

    do {
        if (ht->entries[idx].key == NULL)
            return NULL;

        if (ht->entries[idx].key == key)
            return &ht->entries[idx];

        idx = (idx + 1) % ht->capacity;
    } while (idx != index);

    return NULL;
}

void dump_hash_table(struct hash_table *ht)
{
    for (int i = 0; i < ht->capacity; i++) {
        if (ht->entries[i].key == NULL) continue;
        printf("\n[%s %s]", ht->entries[i].key, ht->entries[i].value);
    }
}

int main()
{
    struct hash_table *ht = create_hash_table(INITIAL_CAPACITY);
    char *str[] = {
        "1", "riya1",
        "4", "vineel4",
        "3", "vihaan2",
        "2", "nischala3",
        "5", "vineel5",
        "6", "vineel6",
        "7", "vineel7",
        "8", "vineel8",
        "9", "vineel9",
        "10", "vineel10",
        "11", "vineel11",
        "12", "vineel12",
        "13", "vineel13",
        "14", "vineel14",
        "15", "reddy15",
    };

    for (int i = 0; i < sizeof(str) / sizeof(char*); i+=2) {
        put(ht, str[i], str[i+1]);
    }

    // struct hash_table_entry *hte = get(ht, str[15*2]);
    // printf("\nkey=%s value=%s", hte->key, hte->value);
    dump_hash_table(ht);

    return 0;
}
