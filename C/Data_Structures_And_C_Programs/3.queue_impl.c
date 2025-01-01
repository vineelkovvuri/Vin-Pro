#include <stdio.h>

struct queue_node {
    int ele;
    struct queue_node *next;
};

struct queue {
    struct queue_node *head;
    struct queue_node *tail;
};

void enqueue(struct queue* q, int ele)
{
    struct queue_node *new = calloc(1, sizeof(struct queue_node));
    new->ele = ele;

    if (q->tail == NULL) {
        q->head = q->tail = new;
    } else {
        q->tail->next = new;
        q->tail = q->tail->next;
    }
}

int dequeue(struct queue* q)
{
    if (q == NULL || q->head == NULL)
        return -1;
    struct queue_node* node = q->head;
    q->head = q->head->next;
    int ret = node->ele;
    free(node);
    return ret;
}


int main()
{
}