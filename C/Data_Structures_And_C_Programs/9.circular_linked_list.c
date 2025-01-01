#include <stdio.h>
#include <stdlib.h>

struct list {
    int ele;
    struct list *next;
};

struct list *insert(struct list *l, int ele)
{
    struct list *node = calloc(1, sizeof(struct list));
    node->ele = ele;
    node->next = node;

    if (l == NULL) {
        return node;
    }

    node->next = l->next;
    l->next = node;
    return node;
}

struct list *delete(struct list *l, int *ele)
{
    struct list *node = NULL;

    if (l == NULL) return NULL;
    if (l->next == l) {
        node = l;
        *ele = node->ele;
        free(node);
        return NULL;
    } else {
        node = l->next;
        *ele = node->ele;
        l->next = node->next;
        free(node);
        return l;
    }
}


void dump_list(struct list *l)
{
    struct list *head = NULL, *p = NULL;
    if (l == NULL)
        return;

    p = head = l->next;

    do {
        printf("\n%d", p->ele);
        p = p->next;
    } while (p != head);
}

int main()
{
    struct list *l = NULL;

    l = insert(l, 10);
    l = insert(l, 20);
    l = insert(l, 30);
    l = insert(l, 40);

    dump_list(l);
}
