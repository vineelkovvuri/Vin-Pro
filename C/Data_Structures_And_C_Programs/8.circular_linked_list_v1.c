#include <stdio.h>
#include <stdlib.h>

struct list_node {
    int ele;
    struct list_node *next;
};

struct list {
    struct list_node *tail;
};

void insert(struct list *l, int ele)
{
    struct list_node *node = calloc(1, sizeof(struct list_node));
    node->ele = ele;
    node->next = node;

    if (l->tail) {
        node->next = l->tail->next;
        l->tail->next = node;
    }

    l->tail = node;
}

void dump_list(struct list *l)
{
    struct list_node *head = NULL, *p = NULL;
    if (l->tail == NULL) return;

    p = head = l->tail->next;

    do {
        printf("\n%d", p->ele);
        p = p->next;
    } while (p != head);
}

int main()
{
    struct list l = {0};

    insert(&l, 10);
    insert(&l, 20);
    insert(&l, 30);
    insert(&l, 40);

    dump_list(&l);

}
