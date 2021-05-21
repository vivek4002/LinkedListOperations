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

        public void ReverseIterative (LinkedList list) {
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

        public void ReverseRecursive (LinkedList list) {
            list.Head = ReverseRecursive (list.Head, null);
        }

        private Node ReverseRecursive (Node head, Node temp) {
            if (head == null) return temp;
            var next = head.Next;
            head.Next = temp;
            temp = head;
            return ReverseRecursive (next, temp);
        }

        //we can do it by hashmap, 2 stacks sorting with searching
        // efficient approach: get length of both lists and calculate the difference d.
        //move d steps in longer list,
        // after that move one step in both lists and compare
        // first common node is the point where they meet
        // O(1) space and O(m+n) time
        public Node FindCommonNode (LinkedList l1, LinkedList l2) {
            int len1 = 0;
            int len2 = 0;
            var diff = 0;
            var node = l1.Head;
            while (node != null) {
                len1++;
                node = node.Next;
            }
            node = l2.Head;
            while (node != null) {
                len2++;
                node = node.Next;
            }
            node = l1.Head;
            var node2 = l2.Head;
            if (len1 > len2) {
                diff = len1 - len2;
                while (diff != 0) {
                    node = node.Next;
                    diff--;
                }
            } else {
                diff = len2 - len1;
                while (diff != 0) {
                    node2 = node2.Next;
                    diff--;
                }
            }
            while (node != null && node2 != null) {
                node = node.Next;
                node2 = node2.Next;
                if (node == node2) return node;
            }

            return null;
        }

        public Node findMiddleNode (LinkedList list) {
            var node1 = list.Head;
            var node2 = list.Head;
            while (node2 != null && node2.Next != null && node2.Next.Next != null) {
                node1 = node1.Next;
                node2 = node2.Next.Next;
            }
            return node1;
        }

        public void ReverseListInPairs (LinkedList list) {
            var node = list.Head;
            Node temp = null;
            Node prev = null;
            list.Head = node.Next;
            while (node != null && node.Next != null) {
                temp = node.Next.Next;
                if (prev != null) {
                    prev.Next = node.Next;
                }
                node.Next.Next = node;
                node.Next = temp;
                prev = node;
                node = temp;

            }
        }

        public ListNode MergeKLists (ListNode[] lists) {
            if (lists == null || lists.Length == 0) return null;
            var node1 = lists[0];
            ListNode finalList = null;
            ListNode nextNode = null;
            for (int i = 1; i < lists.Length; i++) {
                var node2 = lists[i];
                if (node1 == null) { node1 = node2; continue; }
                if (node2 == null) { continue; }
                ListNode node2Add = null;
                while (node1 != null && node2 != null) {
                    if (node1.val < node2.val) {
                        node2Add = new ListNode (node1.val);
                        node1 = node1.next;
                    } else {
                        node2Add = new ListNode (node2.val);
                        node2 = node2.next;
                    }
                    if (finalList == null) {
                        finalList = node2Add;
                    } else {
                        nextNode.next = node2Add;
                    }
                    nextNode = node2Add;
                }
                while (node1 != null) {
                    nextNode.next = new ListNode (node1.val);
                    nextNode = nextNode.next;
                    node1 = node1.next;
                }
                while (node2 != null) {
                    nextNode.next = new ListNode (node2.val);
                    nextNode = nextNode.next;
                    node2 = node2.next;
                }
                if (nextNode != null) nextNode.next = null;
                node1 = finalList;
                finalList = null;

            }
            return node1;
        }

        public void ReversAfterKElements (int k, LinkedList list) {
            ReversAfterKElements (k, list, list.Head, null);
        }

        private void ReversAfterKElements (int k, LinkedList list, Node fix, Node prev) {
            if (k == 0) return;
            var node = fix;
            // we need previous element from last iteration to link the reversed list in this iteration.
            var xtemp = fix;
            //move the fix to the point till where we need to reverse the list (k+1)
            for (int i = 1; i <= k; i++) {
                if (fix == null) return;
                fix = fix.Next;
            }
            var temp = fix;
            // reverse the list
            while (node != fix) {
                var next = node.Next;
                node.Next = temp;
                temp = node;
                node = next;
            }
            // link the previous list 
            if (prev != null) prev.Next = temp;
            else list.Head = temp;
            prev = xtemp;
            // do untill we reach to the end
            ReversAfterKElements (k, list, fix, prev);
        }
    }

}