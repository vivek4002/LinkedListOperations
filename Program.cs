using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Net;

namespace LinkedListOperations {
    class MainClass {
        public static void Main (string[] args) {
            var problems = new LinkedListProblems ();
            LinkedList list = new LinkedList ();
            list.AddNextNode (new Node (1));
            list.AddNextNode (new Node (3));
            list.AddNextNode (new Node (5));
            list.AddNextNode (new Node (2));
            list.AddNextNode (new Node (4));
            list.AddNextNode (new Node (6));

            problems.ReverseIterative(list);
            problems.ReverseRecursive(list);

            var commonNode= new Node(7);
            list.AddNextNode(commonNode);

            var list2= new LinkedList();
            list2.AddNextNode(new Node(8));
            list2.AddNextNode(new Node (9));
            list2.AddNextNode(commonNode);
            list2.AddNextNode(new Node (10));
            list2.AddNextNode(new Node (11));

            var cn= problems.FindCommonNode(list, list2);
            Console.WriteLine($"Common Node in Lists: {cn.Value}");



            Console.WriteLine ($"Third node from last is:{problems.FindNthNodeFromLast(list, 3)}");
            Console.WriteLine ($"First node from last is:{problems.FindNthNodeFromLast(list, 1)}");
            Console.WriteLine ($"Seventh node from last is:{problems.FindNthNodeFromLast(list, 7)}");

        }

    }
}