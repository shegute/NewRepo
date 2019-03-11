using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Linked_Lists.SingleLinkedLists
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
        public string Value { get; set; }
        public Node Next { get; set; }
        public Node(string v, Node n)
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

            Console.WriteLine($"###INFO:Pop() Succeded.");
            return temp;
        }
        public void Push(Node newNode)
        {
            //if (this.Head != null) {
            newNode.Next = this.Head; this.Head = newNode;

            Console.WriteLine($"###INFO:Push({newNode.Value}) Succeded.");
            //}
        }


        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###StackSLL.RUN.");
            StackSLL stack = new StackSLL(new Node("A", null));
            stack.Push(new Node("B", null));
            stack.Push(new Node("C", null));
            SingleLinkedLists.PrintNode(stack.Pop());
            stack.Push(new Node("D", null));
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

                    Console.WriteLine($"###INFO:InsertAfter({markerNode.Value}, {newNode.Value}) Succeded.");
                    return true;
                }
                cur = cur.Next;
            }

            Console.WriteLine($"###INFO:InsertAfter({markerNode.Value}, {newNode.Value}) Failed.");
            return false;
        }
        public bool Remove(Node markerNode)
        {
            Node cur = this.Head; Node cur2 = this.Head;
            if (cur.Value == markerNode.Value)
            {
                this.Head = this.Head.Next; if (cur.Value == this.Tail.Value) { this.Tail = null; }
                Console.WriteLine($"###INFO:Remove({markerNode.Value}) Succeded.");
                return true;
            }
            while (cur != null)
            {
                cur = cur.Next;
                if (cur.Value == markerNode.Value)
                {
                    cur2.Next = cur.Next; if (cur.Value == this.Tail.Value) { this.Tail = cur2; }

                    Console.WriteLine($"###INFO:Remove({markerNode.Value}) Succeded.");
                    return true;
                }
                cur2 = cur2.Next;
            }

            Console.WriteLine($"###INFO:Remove({markerNode.Value}) Failed.");
            return false;
        }

        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###MaintainHeadNTail.RUN().");
            MaintainHeadNTail m = new MaintainHeadNTail(new Node("A", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.InsertAfter(new Node("A", null), new Node("B", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.InsertAfter(new Node("A", null), new Node("C", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);

            m.Remove(new Node("A", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.Remove(new Node("B", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.Remove(new Node("C", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);


        }
    }

    public class MthToLastElement
    {
        public Node Head { get; set; }
        public MthToLastElement(Node head) { this.Head = head; }

        public Node ReturnMthToLastElement(int m)
        {
            Node curNode = this.Head;
            Node curNode2 = this.Head;
            int count = 0;
            while (m > count++ && curNode != null)
            {
                curNode = curNode.Next;
                if (m == count)
                {
                    return curNode2;
                }

                curNode2 = curNode2.Next;
            }

            Console.WriteLine($"{m} node not found, since list was only {count} nodes long");
            return null;
        }
        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###MthToLastElement.RUN().");
            MthToLastElement mthToLast = new MthToLastElement(new Node("A", new Node("b", new Node("c", new Node("d", new Node("E", null))))));
            Console.WriteLine($"###Calling ReturnMthToLastElement(5).");
            SingleLinkedLists.Print(mthToLast.ReturnMthToLastElement(5));
            Console.WriteLine($"###Calling ReturnMthToLastElement(1).");
            SingleLinkedLists.Print(mthToLast.ReturnMthToLastElement(1));
            Console.WriteLine($"###Calling ReturnMthToLastElement(3).");
            SingleLinkedLists.Print(mthToLast.ReturnMthToLastElement(3));
            Console.WriteLine($"###Calling ReturnMthToLastElement(4).");
            SingleLinkedLists.Print(mthToLast.ReturnMthToLastElement(4));
            Console.WriteLine($"###Calling ReturnMthToLastElement(6).");
            SingleLinkedLists.Print(mthToLast.ReturnMthToLastElement(6));
        }
    }
}
