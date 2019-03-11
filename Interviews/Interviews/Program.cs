using Interviews.Linked_Lists.DoubleLinkedLists;
using Interviews.Linked_Lists.SingleLinkedLists;
using Interviews.Linked_Lists.StringTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interviews.Linked_Lists.BinaryTrees.BinaryTrees;

namespace Interviews
{
    class Program
    {
        static void Main(string[] args)
        {
            StackSLL.Run();
            MaintainHeadNTail.Run();
            MthToLastElement.Run();
            FlattenList.Run();
            BinaryTreePrinter.Run();
            StringTests.Run();
        }
    }
}
