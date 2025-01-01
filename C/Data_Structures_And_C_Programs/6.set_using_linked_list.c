#include <stdio.h>
#include <stdlib.h>

struct set {
    int ele;
    struct set *next;
};

struct set *insert(struct set *s, int ele)
{
    struct set dummy, *p;
    dummy.next = s;

    p = &dummy;

    while (p->next && p->next->ele < ele) {
        p = p->next;
    }

    if (p->next && p->next->ele == ele) {
        return dummy.next;
    }

    struct set *node = calloc(1, sizeof(struct set));
    node->ele = ele;
    node->next = p->next;
    p->next = node;

    return dummy.next;
}

struct set *is_member(struct set *s, int ele)
{
    while (s) {
        if (s->ele == ele) {
            return s;
        }
        s = s->next;
    }

    return NULL;
}

void dump_set(struct set *s)
{
    while (s) {
        printf("\n%d", s->ele);
        s = s->next;
    }
}

int main()
{
    struct set *head = NULL;
    head = insert(head, 10);
    head = insert(head, 10);
    head = insert(head, 20);
    head = insert(head, 5);
    dump_set(head);


    return 0;
}