using System;

namespace LinkedListOperations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddNextNode(new Node(1));
            list.AddNextNode(new Node(3));
            list.AddNextNode(new Node(5));
             list.AddNextNode(new Node(2));
            list.AddNextNode(new Node(4));
            list.AddNextNode(new Node(6));

            //Traverse
            foreach(int val in list.Traverse())
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();

            //Get Nth Item
            Console.WriteLine("First Item is: " + list.GetNode(1).Value);
            Console.WriteLine("Third Item is: " + list.GetNode(3).Value);
            Console.WriteLine("Last Item is: " + list.GetNode(list.Count).Value);

            // delete Node
            list.DeleteNode(1);
            list.DeleteNode(list.Count);
            foreach (int val in list.Traverse())
            {
                Console.Write(val + " ");
            }

        }
    }
}
