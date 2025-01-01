#include <stdio.h>

#define QUEUE_SIZE 4

struct queue {
    int arr[QUEUE_SIZE];
    int front;  // -1
    int rear;   // -1
};

int is_full(struct queue* q)
{
    if (q->front == -1 && q->rear == -1) {
        return 0;
    }

    return (q->rear + 1) % QUEUE_SIZE == q->front;
}

int is_empty(struct queue* q)
{
    return q->front == -1;
}

void enqueue(struct queue* q, int ele)
{
    if (is_full(q)) {
        printf("Queue is full");
        return;
    }

    q->rear = (q->rear + 1) % QUEUE_SIZE;
    q->arr[q->rear] = ele;

    if (q->front == -1) q->front = 0;
}

int dequeue(struct queue* q)
{
    if (is_empty(q)) {
        return -1;
    }

    int ele = q->arr[q->front];

    if (q->front == q->rear) {
        q->front = q->rear = -1;
    } else {
        q->front = (q->front + 1) % QUEUE_SIZE;
    }

    return ele;
}

int main()
{
    struct queue q = {{0}, -1, -1};

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