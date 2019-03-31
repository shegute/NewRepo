using Interviews.DataStructures.BinaryTrees;
using Interviews.DataStructures.DoubleLinkedLists;
using Interviews.DataStructures.SingleLinkedLists;
using Interviews.DataStructures.SortingTests;
using Interviews.Quizes;
using Interviews.Quizes.ArrayTests;
using Interviews.Quizes.IntegerTests;
using Interviews.Quizes.StringTests;
using System;

namespace Interviews
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num;
            bool test = false;
            if (args.Length > 0) { test = int.TryParse(args[0], out num); }

            while (test == false)
            {
                Program.PrintMenu();
                string arg = Console.ReadLine();
                test = int.TryParse(arg, out num);

                if (num == 1) { SingleLinkedLists.Run(); }
                else if (num == 2) { DoubleLinkedLists.Run(); }
                else if (num == 3) { BinaryTrees.Run(); }
                else if (num == 4) { StringTests.Run(); }
                else if (num == 5) { Sorting.Run(); }
                else if (num == 6) { CellCompete.Run(); } // Any other class from Misc Quizes folder.Run();
                else if (num == 7) { ArrayTests.Run(); }
                else if (num == 8) { IntegerTests.Run(); }
                else if (num == 0) { System.Environment.Exit(0); }
                test = false;
            }
        }

        public static void PrintMenu()
        {          
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%Please enter a numeric argument.%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("1 for single linked lists.");
            Console.WriteLine("2 for dobule linked lists.");
            Console.WriteLine("3 for trees.");
            Console.WriteLine("4 for strings.");
            Console.WriteLine("5 for sorting.");
            Console.WriteLine("6 for Misc Quizes.");
            Console.WriteLine("7 for arrays.");
            Console.WriteLine("8 for integer.");
            Console.WriteLine("0 to exit.");
        }
    }
}
