using System;
using System.Collections.Generic;

namespace Interviews.DataStructures.SingleLinkedLists
{
    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }
        public Node(string v, Node n)
        { this.Value = v; this.Next = n; }
    }
    public class SingleLinkedLists
    {

        public static void Print(Node head)
        {
            int count = 0; Node temp = head; Console.WriteLine($"Print all nodes");
            while (temp != null && count<1000) { Console.WriteLine($"Node {count++}: {temp.Value}"); temp = temp.Next; }
            Console.WriteLine($"List is empty");
        }
        public static void PrintNode(Node printNode)
        { if (printNode != null) { Console.WriteLine($"Print Node: {printNode.Value}"); } }

        public static void Run()
        {
            Console.WriteLine(" *(*(*(*(*(*(*(*(*(*(*(*(*(SingleLinkedLists*(*(*(*(*(*(*(*(*(*(*(*(*( ");
            StackSLL.Run();
            MaintainHeadNTail.Run();
            MthToLastElement.Run();
            PrintMiddleElement.Run();
            RemoveDuplicateNode.Run();
            CheckIfPalindrome.Run();
            RotateList.Run();
            ReverseList.Run();
            RotateListTwo.Run();
            CheckIfLoop.Run();
        }
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

        public bool InsertAfter(string markerNodeValue, Node newNode)
        {
            Node cur = this.Head;
            while (cur != null)
            {
                if (cur.Value == markerNodeValue)
                {
                    newNode.Next = cur.Next; cur.Next = newNode;
                    if (cur.Value == this.Tail.Value) { this.Tail = newNode; }
                    //if (null == this.Tail) { this.Tail = newNode; }
                    //if (null == this.Head) { this.Head = newNode; }

                    Console.WriteLine($"###INFO:InsertAfter({markerNodeValue}, {newNode.Value}) Succeded.");
                    return true;
                }
                cur = cur.Next;
            }

            Console.WriteLine($"###INFO:InsertAfter({markerNodeValue}, {newNode.Value}) Failed.");
            return false;
        }
        public bool Remove(string markerNodeValue)
        {
            Node cur = this.Head; Node cur2 = this.Head;
            if (cur.Value == markerNodeValue)
            {
                this.Head = this.Head.Next; if (cur.Value == this.Tail.Value) { this.Tail = null; }
                Console.WriteLine($"###INFO:Remove({markerNodeValue}) Succeded.");
                return true;
            }
            while (cur != null)
            {
                cur = cur.Next;
                if (cur.Value == markerNodeValue)
                {
                    cur2.Next = cur.Next; if (cur.Value == this.Tail.Value) { this.Tail = cur2; }

                    Console.WriteLine($"###INFO:Remove({markerNodeValue}) Succeded.");
                    return true;
                }
                cur2 = cur2.Next;
            }

            Console.WriteLine($"###INFO:Remove({markerNodeValue}) Failed.");
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
            m.InsertAfter("A", new Node("B", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.InsertAfter("A", new Node("C", null));
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);

            m.Remove("A");
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.Remove("B");
            SingleLinkedLists.PrintNode(m.Head);
            SingleLinkedLists.PrintNode(m.Tail);
            SingleLinkedLists.Print(m.Head);
            m.Remove("C");
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
            int count = 1;
            if (m == count)
            {
                return curNode;
            }
            while (m > count++ && curNode != null)
            {
                curNode = curNode.Next;
                if (m == count)
                {
                    return curNode;
                }
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

    public class PrintMiddleElement
    {
        public Node Head;
        public PrintMiddleElement(Node h) { this.Head = h; }

        public void PrintMiddleNode()
        {
            Node curNode = this.Head;
            Node curNode2 = this.Head;
            if (curNode == null) { Console.WriteLine("List is Empty"); return; }

            while (curNode.Next != null)
            {
                curNode = curNode.Next;
                if (curNode.Next == null) { SingleLinkedLists.PrintNode(curNode2); return; }
                curNode = curNode.Next;
                curNode2 = curNode2.Next;
            }

            SingleLinkedLists.PrintNode(curNode2); return;
        }


        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###PrintMiddleElement.RUN().");
            Node head = new Node("A", new Node("b", new Node("c", new Node("d", new Node("E", null)))));
            PrintMiddleElement printMiddleElement = new PrintMiddleElement(head);
            Console.WriteLine($"###Calling PrintMiddleNode().");
            printMiddleElement.PrintMiddleNode();
            head = new Node("F", new Node("G", new Node("h", null)));
            printMiddleElement = new PrintMiddleElement(head);
            Console.WriteLine($"###Calling PrintMiddleNode().");
            printMiddleElement.PrintMiddleNode();
        }
    }

    public class RemoveDuplicateNode
    {
        public Node Head;
        public RemoveDuplicateNode(Node h) { this.Head = h; }

        public void RemoveDuplicate()
        {
            Node curNode = this.Head;
            if (curNode == null) { Console.WriteLine("List is Empty"); return; }
            int count = 0;
            while (curNode != null && curNode.Next != null)
            {
                if (curNode.Value.Equals(curNode.Next.Value))
                {
                    Console.WriteLine($"Removing dup node");
                    count++;
                    SingleLinkedLists.PrintNode(curNode.Next);
                    curNode.Next = curNode.Next.Next;
                    continue;
                }

                curNode = curNode.Next;
            }
            if (count > 0) { Console.WriteLine($"Removed {count} duplicate node(s)"); return; }
            Console.WriteLine($"No duplicate node(s) found for removal.");
        }


        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###RemoveDuplicateNode.RUN().");
            Node head = new Node("A", new Node("c", new Node("c", new Node("c", new Node("E", new Node("E", null))))));
            RemoveDuplicateNode removeDuplicateNode = new RemoveDuplicateNode(head);
            Console.WriteLine($"###Calling RemoveDuplicate().");
            removeDuplicateNode.RemoveDuplicate();
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(removeDuplicateNode.Head);
            head = new Node("F", new Node("F", null));
            removeDuplicateNode = new RemoveDuplicateNode(head);
            Console.WriteLine($"###Calling RemoveDuplicate().");
            removeDuplicateNode.RemoveDuplicate();
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(removeDuplicateNode.Head);
        }
    }

    public class CheckIfPalindrome
    {
        public Node Head;
        public CheckIfPalindrome(Node h) { this.Head = h; }

        public bool IsPalindrome()
        {
            Node curNode = this.Head;
            Node curNode2 = this.Head;
            Stack<string> previousValues = new Stack<string>();
            if (curNode == null) { Console.WriteLine("List is Empty"); return false; }
            int count = 0;
            while (curNode != null)
            {
                previousValues.Push(curNode2.Value);
                if (curNode.Next != null) { count++; curNode = curNode.Next; curNode2 = curNode2.Next; }
                curNode = curNode.Next;
            }
            if (count < 1) { Console.WriteLine($"Not a palindrome. Nodes count <1"); return false; }
            //else if (count%2!=0 ) { previousValues.Pop(); }
            while (curNode2 != null && previousValues.Count > 0)
            {
                if (!curNode2.Value.Equals(previousValues.Pop()))
                {
                    { Console.WriteLine($"Not a palindrome. Poped value ne to {curNode2.Value} "); return false; }
                }
                curNode2 = curNode2.Next;
            }
            //if (previousValues.Count > 0) { Console.WriteLine($"Not all beginning nodes popped"); return false; }
            //else if (curNode2 != null) { Console.WriteLine($"Not all ending nodes visited"); return false; }
            Console.WriteLine($"This list is a palindrome."); return true;
        }
        public bool isPali()
        {
            Node cur = this.Head;
            Node cur2 = this.Head;
            Stack<string> stk = new Stack<string>();
            while (cur != null && cur.Next != null)
            {
                stk.Push(cur2.Value);
                cur2 = cur2.Next;
                cur = cur.Next;
                cur = cur.Next;
            }
            if (stk.Count % 2 == 0) { cur2 = cur2.Next; }
            while (cur2 != null)
            {
                if (stk.Pop() != cur2.Value) { return false; }
                cur2 = cur2.Next;
            }

            return true;
        }


        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###CheckIfPalindrome.RUN().");
            Node head = new Node("a", new Node("c", new Node("c", new Node("t", new Node("o", new Node("r", null))))));
            CheckIfPalindrome checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(acctor).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("F", null);
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(F).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("F", null);
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(F).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("c", new Node("i", new Node("v", new Node("v", new Node("i", new Node("c", null))))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(civic).");
            Console.WriteLine($"{checkIfPalindrome.isPali()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("c", new Node("i", new Node("v", new Node("i", new Node("c", null)))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling isPali(civic).");
            Console.WriteLine($"{checkIfPalindrome.isPali()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("c", new Node("i", new Node("v", new Node("v", new Node("i", new Node("c", null))))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling isPali(civvic).");
            Console.WriteLine($"{checkIfPalindrome.isPali()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("r", new Node("e", new Node("d", new Node("d", new Node("e", new Node("r", null))))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(redder).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("r", new Node("e", new Node("a", new Node("d", new Node("d", new Node("a", new Node("e", new Node("r", null))))))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(readdaer).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("e", new Node("d", new Node("d", new Node("e", new Node("r", null)))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(edder).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);

            head = new Node("r", new Node("e", new Node("d", new Node("d", new Node("e", null)))));
            checkIfPalindrome = new CheckIfPalindrome(head);
            Console.WriteLine($"###Calling IsPalindrome(redde).");
            Console.WriteLine($"{checkIfPalindrome.IsPalindrome()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfPalindrome.Head);
        }
    }


    public class CheckIfLoop
    {
        public Node Head;
        public CheckIfLoop(Node h) { this.Head = h; }

        public Node createLoop(Node h)
        {
            Node cur = h;
            Node temp;
            while (cur.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = h.Next; //Create loop from tail to the 2nd node from head.
            return h;
        }

        public bool detectLoop()
        {
            Node cur = this.Head; Node trailer = this.Head;
            while (cur != null && cur.Next != null)
            {
                cur = cur.Next;
                if (cur == trailer || cur.Next == trailer) { return true; }
                trailer = trailer.Next;
                cur = cur.Next;
            }
            return false;
        }


        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###CheckIfLooop.RUN().");
            Node head = new Node("a", new Node("c", new Node("c", new Node("t", new Node("o", new Node("r", null))))));
            CheckIfLoop checkIfLoop = new CheckIfLoop(head);
            Console.WriteLine($"###Calling CheckIfLooop(acctor).");
            Console.WriteLine($"{checkIfLoop.detectLoop()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfLoop.Head);

            Node node1 = new Node("AA", null);
            Node node2 = new Node("B", node1);
            Node node3 = new Node("C", node2);
            Node head2 = new Node("A", node3);
            node1.Next = head2.Next;
            checkIfLoop = new CheckIfLoop(head2);
            //checkIfLoop.Head = checkIfLoop.createLoop(checkIfLoop.Head);
            Console.WriteLine($"###Calling checkIfLoop(AA,E,D,C,B,A,D).");
            Console.WriteLine($"{checkIfLoop.detectLoop()}");
            Console.WriteLine($"###Calling Print().");
            SingleLinkedLists.Print(checkIfLoop.Head);
        }
    }

    public class RotateList
    {
        public Node Head;
        public RotateList(Node h) { this.Head = h; }

        public void RotateNodes(int rotationPoint)
        {
            Node curNode = this.Head;
            Node tail = this.Head;
            Node temp = this.Head;
            if (curNode == null) { Console.WriteLine("List is Empty"); return; }
            int count = 0;
            while (curNode != null)
            {
                tail = curNode;
                if (count + 1 == rotationPoint)
                {
                    Console.WriteLine($"Found rotation point:{rotationPoint} at node:{curNode.Value}. Count:{count}");

                    break;
                }
                curNode = curNode.Next; count++;
            }
            if (curNode != null && curNode.Next != null) { this.Head = curNode.Next; }
            else { Console.WriteLine($"Rotation point not found:"); return; }

            Console.WriteLine($"Head set to :{this.Head.Value}");
            Console.WriteLine($"Tail set to :{tail.Value}");
            while (curNode.Next != null)
            {
                curNode = curNode.Next;
            }
            curNode.Next = temp;
            tail.Next = null;

        }


        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###RotateList.RUN().");
            Node head = new Node("a", new Node("c", new Node("t", new Node("o", new Node("r", null)))));
            RotateList rotateList = new RotateList(head);
            Console.WriteLine($"###Calling RotateNodes(2)."); rotateList.RotateNodes(2);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", new Node("c", new Node("t", new Node("o", new Node("r", null)))));
            rotateList = new RotateList(head);
            Console.WriteLine($"###Calling RotateNodes(1)."); rotateList.RotateNodes(1);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", new Node("c", new Node("t", new Node("o", new Node("r", null)))));
            rotateList = new RotateList(head);
            Console.WriteLine($"###Calling RotateNodes(4)."); rotateList.RotateNodes(4);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", new Node("c", new Node("t", new Node("o", new Node("r", null)))));
            rotateList = new RotateList(head);
            Console.WriteLine($"###Calling RotateNodes(8)."); rotateList.RotateNodes(8);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", new Node("c", null));
            rotateList = new RotateList(head);
            Console.WriteLine($"###Calling RotateNodes(1)."); rotateList.RotateNodes(1);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", null);
            rotateList = new RotateList(head);
            Console.WriteLine($"###Calling RotateNodes(0)."); rotateList.RotateNodes(0);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);
        }
    }

    public class ReverseList
    {
        public Node Head;
        public ReverseList(Node h) { this.Head = h; }

        public void ReverseNodes()
        {
            Node curNode = null;
            Node curNode2 = this.Head;
            Node curNode3 = this.Head;
            if (curNode2 == null) { Console.WriteLine("List is Empty"); return; }
            while (curNode2 != null)
            {
                curNode3 = curNode2.Next;
                curNode2.Next = curNode;
                curNode = curNode2;
                curNode2 = curNode3;
            }
            this.Head = curNode;
        }

        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###ReverseList.RUN().");
            Node head = new Node("a", new Node("c", new Node("t", new Node("o", new Node("r", null)))));
            ReverseList rotateList = new ReverseList(head);
            Console.WriteLine($"###Calling ReverseNodes()."); rotateList.ReverseNodes();
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", new Node("c", null));
            rotateList = new ReverseList(head);
            Console.WriteLine($"###Calling ReverseNodes()."); rotateList.ReverseNodes();
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            head = new Node("a", null);
            rotateList = new ReverseList(head);
            Console.WriteLine($"###Calling ReverseNodes()."); rotateList.ReverseNodes();
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);
        }
    }


    public class RotateListTwo
    {
        public Node Head;
        public RotateListTwo(Node h) { this.Head = h; }

        public Node rotate(Node head, int k)
        {
            Node currentHead = head;

            //First make node at k head and break previous pointer to it
            int count = 0;
            while (count < k && currentHead.Next != null)
            {
                currentHead = currentHead.Next; count++;
                if (count + 1 == k) { }
            }

            //Then break previous pointer to currentHead 
            Node currentTail = head;
            count = 0;
            while (count < k && currentHead.Next != null)
            {
                currentTail = currentTail.Next;
                count++;
                if (count + 1 == k) { currentTail.Next = null; break; }
            }

            //Then point old tail to old head 
            Node oldTail = currentHead;
            while (oldTail.Next != null)
            {
                oldTail = oldTail.Next;
            }
            oldTail.Next = head;
            this.Head = currentHead;
            return currentHead;
        }

        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"###RotateListTwo.RUN().");
            Node head = new Node("a", new Node("c", new Node("t", new Node("o", new Node("r", null)))));
            RotateListTwo rotateList = new RotateListTwo(head);
            Console.WriteLine($"###Calling RotateListTwo()."); rotateList.rotate(head, 3);
            Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            //head = new Node("a", new Node("c", null));
            //rotateList = new RotateListTwo(head);
            //Console.WriteLine($"###Calling ReverseNodes()."); rotateList.rotate(head, 1);
            //Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);

            //head = new Node("a", null);
            //rotateList = new RotateListTwo(head);
            //Console.WriteLine($"###Calling ReverseNodes()."); rotateList.rotate(head, 1);
            //Console.WriteLine($"###Calling Print()."); SingleLinkedLists.Print(rotateList.Head);
        }
    }
}
