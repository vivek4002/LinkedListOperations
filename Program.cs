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

            Console.WriteLine ($"Third node from last is:{problems.FindNthNodeFromLast(list, 3)}");
            Console.WriteLine ($"First node from last is:{problems.FindNthNodeFromLast(list, 1)}");
            Console.WriteLine ($"Seventh node from last is:{problems.FindNthNodeFromLast(list, 7)}");

        }

    }
}