import java.util.ArrayDeque;
import java.util.Queue;
import java.util.Stack;

class Node {
    int data;
    Node left;
    Node right;

    public Node(int data) {
        this.data = data;
    }
}

public class TreeTraversals {

    public static void preorder(Node node) {
        if (node == null) return;
        System.out.print(node.data + " ");
        preorder(node.left);
        preorder(node.right);
    }

    public static void preorder_nonrec(Node node) {
        if (node == null) return;
        Stack<Node> stack = new Stack<>();

        while (true) {
            while (node != null) {
                System.out.print(node.data + " ");
                stack.push(node);
                node = node.left;
            }

            if (!stack.empty()) {
                node = stack.pop().right;
            } else {
                break;
            }
        }
    }

    public static void inorder(Node node) {
        if (node == null) return;
        inorder(node.left);
        System.out.print(node.data + " ");
        inorder(node.right);
    }

    public static void inorder_nonrec(Node node) {
        if (node == null) return;
        Stack<Node> stack = new Stack<>();

        while (true) {
            // push left nodes
            while (node != null) {
                stack.push(node);
                node = node.left;
            }

            if (!stack.empty()) {
                node = stack.pop();
                System.out.print(node.data + " ");
                node = node.right;
            } else {
                break;
            }
        }
    }

    public static void postorder(Node node) {
        if (node == null) return;
        postorder(node.left);
        postorder(node.right);
        System.out.print(node.data + " ");
    }

    public static void postorder_nonrec(Node node) {
        class NodeTracker {
            final Node node;
            boolean rightdone;

            public NodeTracker(Node node) {
                this.node = node;
            }
        }
        if (node == null) return;
        Stack<NodeTracker> stack = new Stack<>();
        while (true) {
            // push left nodes
            while (node != null) {
                stack.push(new NodeTracker(node));
                node = node.left;
            }

            if (!stack.empty()) {
                NodeTracker nodeTracker = stack.peek();
                node = nodeTracker.node;
                if (node.right != null && !nodeTracker.rightdone) {
                    nodeTracker.rightdone = true;
                    node = node.right;
                } else {
                    System.out.print(node.data + " ");
                    stack.pop();
                    node = null;
                }
            } else {
                break;
            }
        }
    }

    public static void level_order(Node node) {
        if (node == null) return;

        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            node = queue.remove();
            System.out.print(node.data + " ");
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);
        }
    }

    public static int find_max(Node node) {
        if (node == null) {
            return Integer.MIN_VALUE;
        }

        int lmax = find_max(node.left);
        int rmax = find_max(node.right);

        return Math.max(node.data, Math.max(lmax, rmax));
    }

    public static int find_max_nonrec(Node node) {
        if (node == null) {
            return Integer.MIN_VALUE;
        }

        int max = Integer.MIN_VALUE;
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);
            if (max < node.data) max = node.data;
        }

        return max;
    }

    public static boolean find_element(Node node, int element) {
        if (node == null) return false;

        if (node.data == element) {
            return true;
        }

        return find_element(node.left, element) || find_element(node.right, element);
    }

    public static Node get_node(Node node, int element) {
        if (node == null) return null;

        if (node.data == element) {
            return node;
        }

        Node leftNode = get_node(node.left, element);
        if (leftNode != null) return leftNode;

        Node rightNode = get_node(node.right, element);
        return rightNode;
    }

    public static boolean insert_node(Node node, Node newNode) {
        if (node == null) return false;

        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node.left != null) {
                queue.add(node.left);
            } else {
                node.left = newNode;
                break;
            }

            if (node.right != null) {
                queue.add(node.right);
            } else {
                node.right = newNode;
                break;
            }
        }

        return false;
    }

    public static int tree_size(Node node) {
        if (node == null) return 0;

        return tree_size(node.left) + 1 + tree_size(node.right);
    }

    public static int tree_size_nonrec(Node node) {
        if (node == null) return 0;

        int node_count = 0;
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);

        while (!queue.isEmpty()) {
            node = queue.remove();
            node_count++;
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);
        }

        return node_count;
    }

    public static void print_level_order_reverse(Node node) {
        Queue<Node> queue = new ArrayDeque<>();
        Stack<Node> stack = new Stack<>();

        queue.add(node);

        while (!queue.isEmpty()) {
            node = queue.remove();

            if (node.right != null) {
                queue.add(node.right);
            }

            if (node.left != null) {
                queue.add(node.left);
            }

            stack.push(node);
        }

        while (!stack.isEmpty()) {
            System.out.print(stack.pop().data + " ");
        }
    }

    public static int tree_height(Node node) {
        if (node == null) return 0;

        return 1 + Math.max(tree_height(node.left), tree_height(node.right));
    }

    public static int tree_height_nonrec(Node node) {
        if (node == null) return 0;

        int height = 0;
        Queue<Node> queue = new ArrayDeque<>();
        Node dummy = new Node(-1);
        queue.add(node);
        queue.add(dummy);
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node == dummy) {
                height++;
                if (queue.size() != 0) queue.add(dummy);
            } else {
                if (node.left != null) queue.add(node.left);
                if (node.right != null) queue.add(node.right);
            }
        }

        return height;
    }

    public static Node deepest_node(Node node, Integer height) {
        if (node == null) return null;

        if (node.left == null && node.right == null) {
            height = 0;
            return node;
        }

        Integer left_height = 0;
        Integer right_height = 0;
        Node lnode = deepest_node(node.left, left_height);
        Node rnode = deepest_node(node.right, right_height);
        if (left_height <= right_height) {
            height = right_height + 1;
            return rnode;
        } else {
            height = left_height + 1;
            return lnode;
        }
    }

    public static Node deepest_node_nonrec(Node node) {
        if (node == null) return null;

        Node deepest_node = null;
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            deepest_node = node = queue.remove();
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);
        }

        return deepest_node;
    }

    public static int count_leafs(Node node) {
        if (node == null) return 0;
        if (node.left == null && node.right == null) return 1;

        return count_leafs(node.left) + count_leafs(node.right);
    }

    public static int count_leafs_nonrec(Node node) {
        if (node == null) return 0;

        int leafs_count = 0;
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);

            if (node.left == null && node.right == null) {
                leafs_count++;
            }
        }

        return leafs_count;
    }


    public static int count_full_nodes(Node node) {
        if (node == null) return 0;
        int full_nodes_count = count_full_nodes(node.left) + count_full_nodes(node.right);
        if (node.left != null && node.right != null) return full_nodes_count + 1;
        else return full_nodes_count;
    }

    public static int count_full_nodes_nonrec(Node node) {
        if (node == null) return 0;

        int full_nodes_count = 0;
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);

            if (node.left != null && node.right != null) {
                full_nodes_count++;
            }
        }

        return full_nodes_count;
    }


    public static int count_half_nodes(Node node) {
        if (node == null) return 0;
        int half_nodes_count = count_half_nodes(node.left) + count_half_nodes(node.right);
        if ((node.left != null && node.right == null) || (node.left == null && node.right != null))
            return half_nodes_count + 1;
        else return half_nodes_count;
    }

    public static int count_half_nodes_nonrec(Node node) {
        if (node == null) return 0;

        int half_nodes_count = 0;
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);

            if ((node.left != null && node.right == null) || (node.left == null && node.right != null)) {
                half_nodes_count++;
            }
        }

        return half_nodes_count;
    }

    public static boolean structural_identical(Node node1, Node node2) {
        if (node1 == null && node2 == null) return true;
        if (node1 == null || node2 == null) return false;

        boolean lcheck = structural_identical(node1.left, node2.left);
        if (!lcheck) return false;

        boolean rcheck = structural_identical(node1.right, node2.right);
        if (!rcheck) return false;

        return node1.data == node2.data;
    }

//    public static int tree_diameter_util(Node node, Integer child_diameter) {
//        if (node == null) {
//            child_diameter = 0;
//            return 0;
//        }
//
//        if (node.left == null && node.right == null) {
//            child_diameter = 0;
//            return 1;
//        }
//
//    }

    //    public static int tree_diameter(Node node) {
//        if (node == null) return 0;
//
//
//    }
    public static int tree_diameter_nonrec(Node node) {
        if (node == null) return 0;

        Node dummy = new Node(-1);
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        queue.add(dummy);
        int diameter = 0;
        int max_diameter = 0;
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node == dummy) {
                if (queue.size() != 0) {
                    queue.add(dummy);
                }
                if (max_diameter < diameter) max_diameter = diameter;
                diameter = 0;
            } else {
                diameter++;
                if (node.left != null) queue.add(node.left);
                if (node.right != null) queue.add(node.right);
            }
        }

        return max_diameter;
    }

    public static int find_level_with_max_sum(Node node) {
        if (node == null) return 0;

        Node dummy = new Node(-1);
        Queue<Node> queue = new ArrayDeque<>();
        queue.add(node);
        queue.add(dummy);
        int sum = 0;
        int max_sum = 0;
        while (!queue.isEmpty()) {
            node = queue.remove();
            if (node == dummy) {
                if (!queue.isEmpty()) {
                    queue.add(dummy);
                }
                if (max_sum < sum) {
                    max_sum = sum;
                }
                sum = 0;
            } else {
                sum += node.data;
                if (node.left != null) queue.add(node.left);
                if (node.right != null) queue.add(node.right);
            }
        }

        return max_sum;
    }

    public static void print_all_paths(Node node, Queue<Node> queue) {
        if (node == null) return;

        queue.add(node);

        if (node.left == null && node.right == null) {
            for (Node n : queue)
                System.out.print(n.data + " ");
            System.out.println();
        } else {
            print_all_paths(node.left, queue);
            print_all_paths(node.right, queue);
        }

        queue.remove(node);
    }

    public static boolean find_path_sum_exists(Node node, int sum, Integer total_sum) {
        if (node == null) return false;

        total_sum += node.data;

        if (total_sum == sum) {
            return true;
        }

        boolean lfind = find_path_sum_exists(node.left, sum, total_sum);
        if (lfind) return true;
        boolean rfind = find_path_sum_exists(node.right, sum, total_sum);
        if (rfind) return true;

        total_sum -= node.data;

        return false;
    }

    public static void create_mirror_tree(Node node) {
        if (node == null) return;

        create_mirror_tree(node.left);
        create_mirror_tree(node.right);

        Node temp = node.left;
        node.left = node.right;
        node.right = temp;
    }

    public static boolean check_mirror_trees(Node node1, Node node2) {
        if (node1 == null && node2 == null) return true;

        if (node1 == null || node2 == null) return false;

        if (node1.data != node2.data) return false;

        return check_mirror_trees(node1.left, node2.left) &&
                check_mirror_trees(node1.right, node2.right);
    }

    
    public static void main(String[] args) {
        Node root = new Node(1);
        root.left = new Node(2);
        root.right = new Node(3);
        root.left.left = new Node(4);
        root.left.right = new Node(5);
        root.right.left = new Node(6);
        root.right.right = new Node(7);
        root.right.right.left = new Node(8);

        System.out.println(check_mirror_trees(root, root));



//        inorder(root);
//        System.out.println();
//        create_mirror_tree(root);
//        inorder(root);

//        System.out.println(find_path_sum_exists(root, 7, 0));


//        print_all_paths(root, new ArrayDeque<>());
//        System.out.println(find_level_with_max_sum(root));
//        System.out.println(tree_diameter_nonrec(root));

//        System.out.println(structural_identical(root, root));
//        System.out.println(count_half_nodes(root));
//        System.out.println(count_half_nodes_nonrec(root));


//        System.out.println(count_full_nodes(root));
//        System.out.println(count_full_nodes_nonrec(root));

//        System.out.println(count_leafs(root));
//        System.out.println(count_leafs_nonrec(root));

//        Node node = deepest_node(root, 0);
//        System.out.println(node.data);
//        node = deepest_node_nonrec(root);
//        System.out.println(node.data);

//        System.out.println();
//        System.out.println(tree_height(root));
//
//        System.out.println();
//        System.out.println(tree_height_nonrec(root));


//        System.out.println();
//        print_level_order_reverse(root);


//        preorder(root);
//        System.out.println("");
//        preorder_nonrec(root);

//        inorder(root);
//        System.out.println();
//        inorder_nonrec(root);
//
//        postorder(root);
//        System.out.println();
//        postorder_nonrec(root);

//        level_order(root);

    }
}
