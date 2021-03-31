using System;
namespace LinkedListOperations
{
    public class LinkedList
    {
        public Node Head { get; set; }
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

        public Node GetPreviousNode(Node N){
            
            if(Head==N) return null;
            var currentNode=Head;
            while(currentNode!=null){
                if(currentNode.Next==N)
                {
                    return currentNode;
                }
                currentNode=currentNode.Next;
            }
            return null; 
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

        public Node SearchNode(int val)
        {
            var currentNode= Head;
            while(currentNode!=null){
                if(currentNode.Value==val) return currentNode;
                currentNode=currentNode.Next;
            }
            return null;
        }

        //Swap the nodes without swapping the data
        // swapping the data could be slow when the node has large data
        // so we can swap the nodes just by re-arranging the references
        public void SwapNodes(int a, int b)
        {
            var node1= SearchNode(a);
            var node2= SearchNode(b);
            var prevNode1= GetPreviousNode(node1);
            var prevNode2= GetPreviousNode(node2);
            var temp=node1.Next;
            node1.Next=node2.Next;
            node2.Next=temp;
            prevNode1.Next=node2;
            prevNode2.Next= node1;
        }

    }
}
