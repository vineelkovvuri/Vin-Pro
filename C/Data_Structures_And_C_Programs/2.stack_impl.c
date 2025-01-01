#include <stdio.h>

#define STACK_SIZE 10

struct stack {
    int ele;
    struct stack *next;
};

void push(struct stack* head, int ele)
{
    struct stack *new = calloc(1, sizeof(struct stack));
    new->ele = ele;
    if (head == NULL) {
        head = new;
    } else {
        new->next = head;
        head = new;
    }
}

int pop(struct stack* head)
{
    if (head == NULL)
        return -1;
    struct stack* top = head;
    int ret = top->ele;
    head = head->next;
    free(top);
    return ret;
}


int main()
{
}