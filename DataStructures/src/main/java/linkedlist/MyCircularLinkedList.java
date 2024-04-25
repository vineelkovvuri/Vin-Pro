package linkedlist;


public class MyCircularLinkedList {

    public static Node append(Node tail, int element)
    {
        Node node = new Node(element);
        if (tail == null) {
            node.next = node;
        } else {
            node.next = tail.next;
            tail.next = node;
        }
        return node;
    }

    public static void display(Node tail)
    {
        if (tail == null) return;
        Node head = tail.next;
        Node node = head;

        do {
            System.out.print(node.element + " ");
            node = node.next;
        } while (node != head);

        System.out.println();
    }

    public static void main(String[] args) {
        Node tail = append(null, 10);
        tail = append(tail, 20);
        tail = append(tail, 30);
        tail = append(tail, 40);


//        display(tail);
    }
}
