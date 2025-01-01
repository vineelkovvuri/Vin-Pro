package queue;

public class MyQueueLinkedList {
    class Node {
        int element;
        Node next;

        public Node(int element) {
            this.element = element;
        }
    }

    Node front, rear;

    public void enqueue(int ele) {
        Node node = new Node(ele);
        if (front == null) {
            front = rear = node;
        } else {
            rear.next = node;
            rear = rear.next;
        }
    }

    public int dequeue() {
        if (front == null) {
            System.out.println("Queue is empty");
            return -1;
        } else {
            Node node = front;
            front = front.next;
            node.next = null;
            return node.element;
        }
    }

    public void display() {
        for (Node node = front; node != null; node = node.next) {
            System.out.print(node.element + " ");
        }
        System.out.println();
    }

    public static void main(String[] args) {
        MyQueueLinkedList mq = new MyQueueLinkedList();
        mq.enqueue(10);
        mq.enqueue(20);
        mq.enqueue(30);

        mq.display();

        mq.dequeue();
        mq.dequeue();
        mq.display();

    }
}
