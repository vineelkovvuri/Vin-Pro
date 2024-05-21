package linkedlist;

import java.util.HashSet;

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
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    public static Node reverse_recursive(Node prev, Node head) {
        if (head == null) return null;
        if (head.next == null) {
            head.next = prev;
            return head;
        }
        Node newHead = reverse_recursive(head, head.next);
        head.next = prev;
        return newHead;
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


    public static Node remove_duplicates2(Node head) {

        for (Node node1 = head; node1 != null; node1 = node1.next) {
            for (Node node2 = node1.next, prev = null; node2 != null;) {
                if (node1.element != node2.element) {
                    prev = node2;
                    node2 = node2.next;
                } else {
                    prev.next = node2.next;
                    node2.next = null;
                    node2 = prev.next;
                }
            }
        }

        return head;
    }


    public static Node remove_duplicates(Node head) {
        HashSet<Integer> set = new HashSet<>();

        for (Node node = head, prev = null; node != null; ) {
            if (!set.contains(node.element)) {
                set.add(node.element);
                prev = node;
                node = node.next;
            } else {
                prev.next = node.next;
                node.next = null;
                node = prev.next;
            }
        }

        return head;
    }

    public static Node add_two_poly(Node node1, Node node2) {

        node1 = reverse(node1);
        node2 = reverse(node2);

        Node result = null;
        Node node3 = null;
        int carry = 0;
        for (Node n1 = node1, n2 = node2; n1 != null || n2 != null;) {

            int num1 = n1 == null ? 0 : n1.element;
            int num2 = n2 == null ? 0 : n2.element;

            int digit = (num1 + num2 + carry) % 10;
            carry = (num1 + num2) / 10;

            if (result == null) {
                result = node3 = new Node(digit);
            } else {
                node3.next = new Node(digit);
                node3 = node3.next;
            }

            if (n1 != null) n1 = n1.next;
            if (n2 != null) n2 = n2.next;
        }

        node1 = reverse(node1);
        node2 = reverse(node2);
        result = reverse(result);

        return result;
    }

    public static void main(String[] args) {

        Node head = append(null, 60);
        head = append(head, 50);
        head = append(head, 40);
        head = append(head, 30);
        head = append(head, 20);
        head = append(head, 10);
        display(head);



//        Node head2 = append(null, 1);
//        head2 = append(head2, 5);
//        head2 = append(head2, 9);
//        head2 = append(head2, 3);
//        head2 = append(head2, 2);
//        head2 = append(head2, 1);
//        display(head2);
//        Node head3 = append(null, 1);
//        head3 = append(head3, 5);
//        head3 = append(head3, 9);
//        head3 = append(head3, 3);
//        head3 = append(head3, 2);
//        head3 = append(head3, 1);
//        display(head3);
//
//        Node result = add_two_poly(head2, head3);
//        display(result);


//        Node head2 = append(null, 10);
//        head2 = append(head2, 50);
//        head2 = append(head2, 20);
//        head2 = append(head2, 30);
//        head2 = append(head2, 20);
//        head2 = append(head2, 10);
//        display(head2);
//
//        head2 = remove_duplicates2(head2);
//        display(head2);

//        Node head2 = append(null, 10);
//        head2 = append(head2, 50);
//        head2 = append(head2, 20);
//        head2 = append(head2, 30);
//        head2 = append(head2, 20);
//        head2 = append(head2, 10);
//        display(head2);
//
//        head2 = remove_duplicates(head2);
//        display(head2);


//        Node node = reverse_recursive(null, head);
//        display(node);

//        Node node = reverse(head);
//        display(node);

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
