#include <stdio.h>
#include <stdlib.h>

struct set {
    int coeff;
    int power;
    struct set *next;
};

struct set *insert(struct set *s, int coeff, int power)
{
    struct set dummy = {0, 0, s}, *p;
    p = &dummy;

    while (p->next && p->next->power < power) {
        p = p->next;
    }

    if (p->next && p->next->power == power) {
        return dummy.next;
    }

    struct set *node = calloc(1, sizeof(struct set));
    node->coeff = coeff;
    node->power = power;
    node->next = p->next;
    p->next = node;

    return dummy.next;
}

struct set *add(struct set *p1, struct set *p2)
{
    struct set *result = NULL;

    while (p1 && p2) {
        if (p1->power > p2->power) {
            result = insert(result, p2->coeff, p2->power);
            p2 = p2->next;
        } else if (p1->power < p2->power) {
            result = insert(result, p1->coeff, p1->power);
            p1 = p1->next;
        } else {
            result = insert(result, p1->coeff + p2->coeff, p1->power);
            p1 = p1->next;
            p2 = p2->next;
        }
    }

    while (p1) {
        result = insert(result, p1->coeff, p1->power);
        p1 = p1->next;
    }

    while (p2) {
        result = insert(result, p2->coeff, p2->power);
        p2 = p2->next;
    }

    return result;
}

struct set *is_member(struct set *s, int coeff)
{
    while (s) {
        if (s->coeff == coeff) {
            return s;
        }
        s = s->next;
    }

    return NULL;
}

void dump_set(struct set *s)
{
    while (s) {
        printf("\n%dx%d", s->coeff, s->power);
        s = s->next;
    }
}

int main()
{
    struct set *p1 = NULL;
    p1 = insert(p1, 10, 4);
    p1 = insert(p1, 3, 3);
    p1 = insert(p1, 20, 2);
    p1 = insert(p1, 5, 1);
    p1 = insert(p1, 15, 0);
    printf("\nP1:");
    dump_set(p1);

    struct set *p2 = NULL;
    p2 = insert(p2, 1, 4);
    p2 = insert(p2, 2, 2);
    p2 = insert(p2, 1, 1);
    p2 = insert(p2, 1, 0);
    printf("\nP2:");
    dump_set(p2);

    struct set *result = add(p1, p2);
    printf("\nResults:");
    dump_set(result);

    return 0;
}