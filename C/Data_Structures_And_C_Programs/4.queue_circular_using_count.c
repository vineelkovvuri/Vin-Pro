#include <stdio.h>

#define QUEUE_SIZE 4

struct queue {
    int arr[QUEUE_SIZE];
    int front;  //  0
    int rear;   // -1
    int count;
};

int is_full(struct queue* q)
{
    return q->count == QUEUE_SIZE;
}

int is_empty(struct queue* q)
{
    return q->count == 0;
}

void enqueue(struct queue* q, int ele)
{
    if (is_full(q)) {
        printf("Queue is full");
        return;
    }

    q->rear = (q->rear + 1) % QUEUE_SIZE;
    q->arr[q->rear] = ele;
    q->count++;
}

int dequeue(struct queue* q)
{
    if (is_empty(q)) {
        return -1;
    }

    int ele = q->arr[q->front];

    q->front = (q->front + 1) % QUEUE_SIZE;

    q->count--;

    return ele;
}

int main()
{
    struct queue q = {{0}, 0, -1, 0};

    enqueue(&q, 1);
    enqueue(&q, 2);
    enqueue(&q, 3);
    enqueue(&q, 4);
    printf("\ndequeue = %d", dequeue(&q));
    printf("\ndequeue = %d", dequeue(&q));
    enqueue(&q, 5);
    enqueue(&q, 6);
    printf("\ndequeue = %d", dequeue(&q));
    printf("\ndequeue = %d", dequeue(&q));
    printf("\ndequeue = %d", dequeue(&q));
    printf("\ndequeue = %d", dequeue(&q));

    return 0;
}