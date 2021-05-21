using System;
namespace LinkedListOperations {
    public class Node {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node (int val = 0, Node next = null) {
            this.Value = val;
            this.Next = next;
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode (int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }

}