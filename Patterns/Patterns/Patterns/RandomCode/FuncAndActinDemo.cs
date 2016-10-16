using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.RandomCode
{
    internal class FuncAndActinDemo
    {
        public static void Run()
        {
            Action<int> myAction = new Action<int>(PrintString);
            Func<int, string> myFunc = new Func<int, string>(PrintAndReturnString);
            myAction(1);
            Console.WriteLine("MyFunc returned:{0}", myFunc(2));

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var a = list.Select(x => x > 1);
            var b = list.Select(x => x % 2 == 0);
            var c = list.Select(x => x * 2);
            var d = list.Select(myFunc);

            Method(a, "list.Select(x => x > 1)");
            Method(b, "list.Select(x => x%2 == 0)");
            Method(c, "list.Select(x => x*2)");
            Method(d, "list.Select(myFunc)");

        }


        public static void PrintString(int i)
        {
            PrintAndReturnString(i);
        }

        public static string PrintAndReturnString(int i)
        {
            string s = string.Format("This is the input:{0}", i);
            Console.WriteLine(s);
            return s;
        }

        public static void Method(IEnumerable a, string method)
        {
            Console.WriteLine("****************{0}", method);
            foreach (var v in a)
            {
                Console.Write("{0}, ", v);
            }
            Console.WriteLine("****************");
        }

        public static int ListAdd(int i, List<int> list)
        {
            int val = 0;
            foreach (var l in list.Where(x=>x>i))
            {
                val += l;
            }
            return val;
        }
    }
}
