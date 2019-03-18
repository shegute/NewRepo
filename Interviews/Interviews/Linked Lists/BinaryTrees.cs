using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Linked_Lists.BinaryTrees
{
    public class BinaryTrees
    {
        public class Node
        {
            public string Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Child { get; set; }
            public Node(string v, Node l, Node r)
            { this.Value = v; this.Left = l; this.Right = r; }
        }

        public static Node PrintNodesInOrder(Node head)
        {
            int count = 0; Console.WriteLine($"Print all nodes");
            if (head == null) { Console.WriteLine($"List is empty"); return null; }

            Node temp = head;
            while (temp != null) { temp = head.Left; temp = PrintNodesInOrder(temp); }
            Console.WriteLine($"Node {count++}: {head.Value}");
            temp = head.Right;
            while (temp != null) { temp = head.Right; temp = PrintNodesInOrder(temp); }
            Console.WriteLine($"End of List");
            return null;
        }

        public static void PrintNodesPreOrder(Node head)
        { 
            if (head == null) {   return; } 
            Console.WriteLine($"Node:{head.Value}");
            PrintNodesInOrder(head.Left);
            PrintNodesInOrder(head.Right);  
            return  ;
        }

        public static void Run()
        {
            BinaryTreePrinter.Run();
        }

        public class BinaryTreePrinter
        {
            public Node Head;
            public BinaryTreePrinter(Node h) { this.Head = h; }


            public static void Run()
            {
                Console.WriteLine($"");
                Console.WriteLine($"");
                Console.WriteLine($"###BinaryTreePrinter.RUN().");
                Node a = new Node("One", null, null);
                Node c = new Node("Three", null, null);
                Node b = new Node("Two", a, c);
                Node e = new Node("Five", null, null);
                Node d = new Node("Four", b, e);

                BinaryTreePrinter binaryTree = new BinaryTreePrinter(d);
                Console.WriteLine($"###Calling PrintNodesInOrder({binaryTree.Head.Value}).");
                BinaryTrees.PrintNodesInOrder(binaryTree.Head);
                Console.WriteLine($"###Calling PrintNodesPreOrder({binaryTree.Head.Value}).");
                BinaryTrees.PrintNodesPreOrder(binaryTree.Head);
            }
        }

    }
}
