package queue;

public class MyQueue {
    final int MAX_ELEMENTS = 10;
    int arr [] = new int[MAX_ELEMENTS];

    int front = 0, rear = 0;
    int num_elements = 0;

    public void enqueue(int ele) {
        if (num_elements >= MAX_ELEMENTS) {
            System.out.println("The queue is full");
            return;
        }
        arr[rear % MAX_ELEMENTS] = ele;
        rear++;
        num_elements++;
    }

    public int dequeue() {
        if (num_elements == 0) {
            System.out.println("The queue is empty");
            return -1;
        }

        int ele = arr[front % MAX_ELEMENTS];
        front++;
        num_elements--;
        return ele;
    }

    public void display()
    {
        for (int i = 0; i < num_elements; i++) {
            System.out.print(arr[(front + i) % MAX_ELEMENTS] + " ");
        }
        System.out.println();
    }

    public static void main(String[] args) {
        MyQueue mq = new MyQueue();
        mq.enqueue(10);
        mq.enqueue(20);
        mq.enqueue(30);

        mq.display();

        mq.dequeue();
        mq.dequeue();
        mq.display();

    }

}
