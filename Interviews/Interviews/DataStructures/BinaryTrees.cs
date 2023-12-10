using System;

namespace Interviews.DataStructures.BinaryTrees
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

        //public static Node PrintNodesInOrder(Node head)
        public static void PrintNodesInOrder(Node head)
        {
            //int count = 0; Console.WriteLine($"Print all nodes");
            //if (head == null) { Console.WriteLine($"List is empty"); return null; }

            //Node temp = head;
            //while (temp != null) { temp = head.Left; temp = PrintNodesInOrder(temp); }
            //Console.WriteLine($"Node {count++}: {head.Value}");
            //temp = head.Right;
            //while (temp != null) { temp = head.Right; temp = PrintNodesInOrder(temp); }
            //Console.WriteLine($"End of List");
            //return null;
            if (head == null) { return; }
            PrintNodesInOrder(head.Left);
            Console.WriteLine($"Node:{head.Value}");
            PrintNodesInOrder(head.Right);

        }

        public static void PrintNodesPreOrder(Node head)
        {
            if (head == null) { return; }
            Console.WriteLine($"Node:{head.Value}");
            PrintNodesPreOrder(head.Left);
            PrintNodesPreOrder(head.Right);
            return;
        }

        public static int GetTreeHeight(Node head, int h)
        {
            int height = h;
            if (head == null) { return height; }
            height++;
            Console.WriteLine($"Node:{head.Value}");
            int leftHeight = GetTreeHeight(head.Left, height);
            int rightHeight = GetTreeHeight(head.Right,height);
            height = leftHeight > rightHeight ? leftHeight : rightHeight;
            return height;
        }

        public static void Run()
        {
            Console.WriteLine(" #*#*#**#*#*#*#*#*#**##**#BinaryTrees#*#*#**#*#*#*#*#*#**##**# ");
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
                Node zero = new Node("Zero", null, null);
                Node a = new Node("One", zero, null);
                Node c = new Node("Three", null, null);
                Node b = new Node("Two", a, c);
                Node f = new Node("Six", null, null);
                Node e = new Node("Five", null, f);
                Node d = new Node("Four", b, e);

                BinaryTreePrinter binaryTree = new BinaryTreePrinter(d);
                Console.WriteLine($"###Calling PrintNodesInOrder({binaryTree.Head.Value}).");
                BinaryTrees.PrintNodesInOrder(binaryTree.Head);
                Console.WriteLine($"###Calling PrintNodesPreOrder({binaryTree.Head.Value}).");
                BinaryTrees.PrintNodesPreOrder(binaryTree.Head);
                Console.WriteLine($"###Calling GetTreeHeight({binaryTree.Head.Value}).");
                int height = BinaryTrees.GetTreeHeight(binaryTree.Head, -1);
                Console.WriteLine($"###Height = ({height}).");
            }
        }

    }
}
