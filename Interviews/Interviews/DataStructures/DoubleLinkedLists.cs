using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.DataStructures.DoubleLinkedLists
{
    public class DoubleLinkedLists
    {
        public static void Print(Node head)
        {
            int count = 0; Node temp = head; Console.WriteLine($"Print all nodes");
            while (temp != null) { Console.WriteLine($"Node {count++}: {temp.Value}"); temp = temp.Next; }
            Console.WriteLine($"List is empty");
        }

        public static void PrintReverse(Node head)
        {
            int count = 0; Node temp = head; Console.WriteLine($"Print all nodes in reverse");
            while (temp.Next != null) { temp = temp.Next; }
            while (temp != null) { Console.WriteLine($"Node {count++}: {temp.Value}"); temp = temp.Previous; }
            Console.WriteLine($"List is empty");
        }
        public static void PrintNode(Node printNode)
        { if (printNode != null) { Console.WriteLine($"Print Node: {printNode.Value}"); } }

        public static Node PrintAllNodesIncludingChildren(Node head)
        {
            Console.WriteLine($"Print all nodes including children.");
            if (head == null) { Console.WriteLine($"List is empty"); return null; }
            Console.WriteLine($"Print all nodes including children for node{head.Value}");
            Node curNode = head;
            PrintNode(curNode);
            Node temp = curNode.Child;
            while (temp != null) { temp = curNode.Child; temp = PrintAllNodesIncludingChildren(temp); }
            Node temp2 = curNode.Next;
            while (temp2 != null) { temp2 = curNode.Next; temp2 = PrintAllNodesIncludingChildren(temp2); }
            return null;
        }
        public static void PrintAllNodesIncludingChildren2(Node head)
        {
            if (head == null) { Console.WriteLine($"List is empty"); return ; }
            Console.WriteLine($"Print all nodes including children for node{head.Value}.");
            Node curNode = head;
            PrintNode(curNode);
            PrintAllNodesIncludingChildren2(curNode.Child);  
             PrintAllNodesIncludingChildren2(curNode.Next);  
            return  ;
        }
        //public static Node PrintAllNodesIncludingChildrenReverse(Node head)
        //{ // NOT SURE IF THIS IS POSSIBLE TO ACHIEVE WITHOUT  ALOT OF BUGS oR SPECIAL CODE
        //    Console.WriteLine($"Print all nodes including children in reverse");
        //    if (head == null) { Console.WriteLine($"List is empty"); return null; }
        //    Node curNode = head;
        //    while (curNode.Next != null) { curNode = curNode.Next; }

        //    Node temp = curNode.Child;
        //    while (temp != null) { temp = curNode.Child; PrintReverse(temp); } //temp = PrintAllNodesIncludingChildrenReverse(temp); }
        //    //Node temp2 = curNode.Next;
        //    ////while (temp2!= null) { temp2 = curNode.Next; PrintAllNodesIncludingChildrenReverse(curNode.Next); }
        //    //while (temp2!= null) { temp2 = curNode.Next; temp2 = PrintAllNodesIncludingChildrenReverse(temp2); }
        //    PrintNode(curNode);
        //    Node temp3 = curNode.Previous;
        //    while (temp3!= null) { temp3 = curNode.Previous; temp3 = PrintAllNodesIncludingChildrenReverse(temp3); }
        //    while (temp3 != null) { temp3 = curNode.Previous; PrintReverse(temp3); }
        //    return null;
        //}

        public static void Run()
        {
            Console.WriteLine("*!*!!*!*!*!**!*!*!*!*!*!*DoubleLinkedLists*!*!!*!*!*!**!*!*!*!*!*!*");
            FlattenList.Run();
        }

    }

    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node Child { get; set; }
        public Node(string v, Node n, Node p, Node c)
        { this.Value = v; this.Next = n; this.Previous = p; this.Child = c; }
    }

    public class FlattenList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public FlattenList(Node head, Node tail) { this.Head = head; this.Tail = tail; }

        public Node ReturnFlattenedList()
        {
            Console.WriteLine($"###INFO:ReturnFlattenedList() start.");
            Node curNode = this.Head;
            while (curNode != null)
            {
                //Node temp = curNode.Child;
                //while (temp != null) { this.Tail.Next = temp; this.Tail = temp; temp = temp.Child; }

                if (curNode.Child != null)
                {
                    this.Tail.Next = curNode.Child;
                    curNode.Child.Previous = this.Tail;
                }
                while (this.Tail.Next != null) { this.Tail = this.Tail.Next; }
                curNode = curNode.Next;
            }
            return curNode;
        }
        public Node ReturnUnFlattenedList()
        {
            Console.WriteLine($"###INFO:ReturnUnFlattenedList() start.");
            Node curNode = this.Head;
            while (curNode != null)
            {
                //Node temp = curNode.Child;
                //while (temp != null) { this.Tail.Next = temp; this.Tail = temp; temp = temp.Child; }
                this.BreakLink(curNode);
                this.Tail = curNode;
                curNode = curNode.Next;
            }
            return curNode;
        }
        public void BreakLink(Node curNode)
        {
            while (curNode.Child != null)
            {
                if (curNode.Child.Previous != null) { curNode.Child.Previous.Next = null; curNode.Child.Previous = null; }
                curNode = curNode.Child;
            }
            return;
        }
        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###FlattenList.RUN().");

            Node b1c = new Node("B1C", null, null, null);
            Node b1b = new Node("B1B", b1c, null, null);
            b1c.Previous = b1b;
            Node b1a = new Node("B1A", b1b, null, null);
            b1b.Previous = b1a;
            Node b1 = new Node("B1", null, null, b1a);

            Node a4 = new Node("A4", null, null, null);
            Node a3 = new Node("A3", a4, null, null);
            a4.Previous = a3;
            Node a2 = new Node("A2", a3, null, null);
            a3.Previous = a2;
            Node a1 = new Node("A1", a2, null, null);
            a2.Previous = a1;


            Node c = new Node("C", null, null, null);

            Node b = new Node("B", c, null, b1);
            c.Previous = b;

            Node a = new Node("A", b, null, a1);
            b.Previous = a;

            FlattenList flattenList = new FlattenList(a, c);

            Console.WriteLine($"###Calling Print({a.Value}).");
            DoubleLinkedLists.Print(a);
            Console.WriteLine($"###Calling PrintReverse({a.Value}).");
            DoubleLinkedLists.PrintReverse(a);
            Console.WriteLine($"###Calling PrintAllNodesIncludingChildren({a.Value}).");
            DoubleLinkedLists.PrintAllNodesIncludingChildren(a);
            //DoubleLinkedLists.PrintAllNodesIncludingChildrenReverse(a);

            flattenList.ReturnFlattenedList();
            Console.WriteLine($"###Calling Print({flattenList.Head.Value}).");
            DoubleLinkedLists.Print(flattenList.Head);
            Console.WriteLine($"###Calling PrintReverse({flattenList.Tail.Value}).");
            DoubleLinkedLists.PrintReverse(flattenList.Tail);

            flattenList.ReturnUnFlattenedList();
            Console.WriteLine($"###Calling Print({flattenList.Head.Value}).");
            DoubleLinkedLists.Print(flattenList.Head);
            Console.WriteLine($"###Calling PrintReverse({flattenList.Tail.Value}).");
            DoubleLinkedLists.PrintReverse(flattenList.Tail);
            Console.WriteLine($"###Calling PrintAllNodesIncludingChildren({flattenList.Head.Value}).");
            DoubleLinkedLists.PrintAllNodesIncludingChildren(flattenList.Head);
            Console.WriteLine($"###Calling PrintAllNodesIncludingChildren2({flattenList.Head.Value}).");
            DoubleLinkedLists.PrintAllNodesIncludingChildren2(flattenList.Head);
        }

    }
}
