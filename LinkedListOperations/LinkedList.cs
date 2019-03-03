using System;
namespace LinkedListOperations
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Adds the new node at the last of the list.
        /// </summary>
        /// <param name="n">N.</param>
        public void AddNextNode(Node n)
        {
            if (Head != null)
            {
                var currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = n;
            }
            else
            {
                Head = n;
            }
            Count++;
        }

        /// <summary>
        /// Traverse the Linked List.
        /// </summary>
        /// <returns>The traverse.</returns>
        public int[] Traverse()
        {
            int[] vals = new int[Count];
            var currentNode = Head;
            int i = 0;
            while (currentNode != null)
            {  
            vals[i] = currentNode.Value;
            currentNode = currentNode.Next;
                i++;
            }
            return vals;
        }

        /// <summary>
        /// Gets Nth node.
        /// </summary>
        /// <returns>The node.</returns>
        /// <param name="n">N.</param>
        public Node GetNode(int n)
        {
            if (n > Count || n<= 0)
                return null;
            int i = 0;
            var currentNode = Head;
            while (i < n - 1)
            {
                currentNode = currentNode.Next;
                i++;
            }
            return currentNode;
        }

        /// <summary>
        /// Deletes Nth node.
        /// </summary>
        /// <param name="n">N.</param>
        public void DeleteNode(int n)
        {
            if (n > Count || n <= 0)
                return ;
            //delete the Head
            if (n == 1)
            {
                Head = Head.Next;
                Count--;
                return;
            }
            //delete the last node
            if (n == Count)
            {
                var newLastNode = GetNode(Count - 1);
                newLastNode.Next = null;
                Count--;
                return;
            }
            var nodeToDelete = GetNode(n);
            var previosNode = GetNode(n - 1);
            //assign the nodeToDelete.next to previousNode.next
            previosNode.Next = nodeToDelete.Next;
            Count--;
        }
    }
}
