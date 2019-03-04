using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Linked_Lists
{
    public class SingleLinkedLists
    {
        public static void Print(Node head)
        {
            int count = 0; Node temp = head; Console.WriteLine($"Print all nodes");
            while (temp != null) { Console.WriteLine($"Node {count++}: {temp.Value}"); temp = temp.Next; }
            Console.WriteLine($"List is empty");
        }
        public static void PrintNode(Node printNode)
        { if (printNode != null) { Console.WriteLine($"Print Node: {printNode.Value}"); } }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node(int v, Node n)
        { this.Value = v; this.Next = n; }
    }

    public class StackSLL
    {
        public Node Head { get; set; }
        public StackSLL(Node head) { this.Head = head; }
        public Node Pop()
        {
            Node temp = null;
            if (this.Head != null)
            { temp = this.Head; this.Head = this.Head.Next; temp.Next = null; }
            return temp;
        }
        public void Push(Node newNode)
        {
            //if (this.Head != null) {
            newNode.Next = this.Head; this.Head = newNode;
            //}
        }


        public static void Run()
        {
            StackSLL stack = new StackSLL(new Node(0, null));
            stack.Push(new Node(1, null));
            stack.Push(new Node(2, null));
            SingleLinkedLists.PrintNode(stack.Pop());
            stack.Push(new Node(3, null));
            SingleLinkedLists.Print(stack.Head);
            while (stack.Head != null) { SingleLinkedLists.PrintNode(stack.Pop()); }
        }

    }

    public class MaintainHeadNTail
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public MaintainHeadNTail(Node head) { this.Head = head; this.Tail = head; }

        public bool InsertAfter(Node markerNode, Node newNode)
        {
            Node cur = this.Head;
            while (cur != null)
            {
                if (cur.Value == markerNode.Value)
                {
                    newNode.Next = cur.Next; cur.Next = newNode;
                    if (cur.Value == this.Tail.Value) { this.Tail = newNode; }
                    //if (null == this.Tail) { this.Tail = newNode; }
                    //if (null == this.Head) { this.Head = newNode; }
                    return true;
                }
                cur = cur.Next;
            }

            return false;
        }
        public bool Remove(Node markerNode)
        {
            Node cur = this.Head; Node cur2 = this.Head;
            if (cur.Value == markerNode.Value) { this.Head = this.Head.Next; if (cur.Value == this.Tail.Value) { this.Tail = null; } return true; }
            while (cur != null)
            {
                cur = cur.Next;
                if (cur.Value == markerNode.Value) {
                    cur2.Next = cur.Next; if (cur.Value == this.Tail.Value) { this.Tail = cur2; }
                    return true; }
                cur2 = cur2.Next;
            }

            return false;
        }

        public static void Run()
        {
            MaintainHeadNTail m = new MaintainHeadNTail(new Node(0, null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.InsertAfter(new Node(0, null), new Node(1, null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.InsertAfter(new Node(0, null), new Node(2, null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);

            m.Remove(new Node(0, null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.Remove(new Node(1, null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.Remove(new Node(2, null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);


        }
    }
}
