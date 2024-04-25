package linkedlist;

class NodePair {
    Node node1;
    Node node2;

    public NodePair(Node node1, Node node2) {
        this.node1 = node1;
        this.node2 = node2;
    }
}

public class MyLinkedList {
    public static Node append(Node head, int element) {
        Node node = new Node(element);
        if (head == null) {
            return node;
        } else {
            node.next = head;
            return node;
        }
    }

    public static void display(Node head) {
        for (Node node = head; node != null; node = node.next) {
            System.out.print(node.element + " ");
        }
        System.out.println();
    }

    public static int count_nodes(Node head) {
        int count = 0;
        for (Node node = head; node != null; node = node.next) {
            count++;
        }
        return count;
    }

    public static int find_middle_node(Node head) {
        if (head == null) return -1;

        Node slow = head, fast = head, prev = null;

        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            prev = slow;
            slow = slow.next;
        }

        if (fast == null) { // even case
            System.out.println("even " + prev.element);
        } else {
            System.out.println("odd " + slow.element);
        }

        return slow.element;
    }

    public static Node find_kth_node_from_end(Node head, int k) {
        int count = count_nodes(head); // 6
        int n = count - k; // 6 - 2 = 3
        Node node = head;

        for (int i = 0; node != null && i < n; i++) {
            node = node.next;
        }

        if (node != null) {
            return node;
        } else {
            return null;
        }
    }

    public static Node reverse(Node head) {
        Node prev = null, curr = head, next = null;

        if (head == null) return null;
        if (head.next == null) return head;

        while (curr != null) {
            System.out.println(curr.element);
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    public static NodePair split_list(Node head) {
        Node slow = head, fast = head, prev = null;

        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            prev = slow;
            slow = slow.next;
        }

        if (fast == null) {
            prev.next = null;
            return new NodePair(head, slow);
        } else {
            Node temp = slow.next;
            slow.next = null;
            return new NodePair(head, temp);
        }
    }

    public static void main(String[] args) {

        Node head = append(null, 60);
        head = append(head, 50);
        head = append(head, 40);
        head = append(head, 30);
        head = append(head, 20);
        head = append(head, 10);
        display(head);

        Node node = reverse(head);
        display(node);

//        Node node = find_kth_node_from_end(head, 2);
//        System.out.println(node.element);

//        int count = count_nodes(head);
//        System.out.println(count);

//        display(head);

//        NodePair nodePair = split_list(head);
//        display(nodePair.node1);
//        display(nodePair.node2);


//        System.out.println(find_middle_node(head));
    }

}
