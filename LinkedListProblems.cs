using System;
namespace LinkedListOperations {
    public class LinkedListProblems {

        // we can do it efficently by using Dictionary
        // But if we dont want to constant space,
        // we use two variables. second variable starts running when first one reached nth node
        public int FindNthNodeFromLast (LinkedList list, int n) {
            var i = list.Head;
            var j = list.Head;
            if (i == null) return -1;
            int count = 1;
            while (i.Next != null) {
                count++;
                i = i.Next;
                if (count > n) {
                    j = j.Next;
                }
            }
            if (count >= n) {
                return j.Value;
            } else {
                return -1;
            }
        }

        // floyd algorithm where there are two pointers running at different speed
        // if both pointers match, there is a cycle
        public bool ContainsLoop (LinkedList list) {
            var sp = list.Head;
            var fp = list.Head;

            while (fp != null && sp != null) {
                if (fp.Next == null) return false;
                sp = sp.Next;
                fp = fp.Next.Next;
                if (sp == fp) return true;
            }
            return false;
        }

        //Explanation why this algo works:
        //https://stackoverflow.com/questions/2936213/explain-how-finding-cycle-start-node-in-cycle-linked-list-work#:~:text=This%20is%20Floyd's%20algorithm%20for%20cycle%20detection.&text=In%20the%20first%20part%20of,first%20node%20in%20the%20cycle.
        public Node findLoop (LinkedList list) {
            var sp = list.Head;
            var fp = list.Head;
            while (fp != null && sp != null) {
                if (fp.Next == null) return null;
                sp = sp.Next;
                fp = fp.Next.Next;
                if (sp == fp) {
                    break;
                };
            }
            sp = list.Head;
            while (sp != fp) {
                sp = sp.Next;
                fp = fp.Next;
            }
            return sp;

        }

        public void ReverseIterative(LinkedList list) {
            var node = list.Head;
            Node temp = null;
            Node next = null;
            while (node != null) {
                next = node.Next;
                node.Next = temp;
                temp = node;
                list.Head = node;
                node = next;

            }
        }
    }

}