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
            Func<int, string> myFunc2 = new Func<int, string>(i =>
            {
                string s = string.Format("This is the input:{0}", i);
                Console.WriteLine(s);
                return s;
            });
            myAction(1);
            Console.WriteLine("MyFunc returned:{0}", myFunc(2));

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> negativeList = new List<int>() { -2, -3, -6 };
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^");
            Method(list, "all list contents");
            Method(negativeList, "all negativeList contents");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("MyFunc returned:{0}", myFunc(2));
            var a = list.Select(x => x > 1);
            var a1 = list.Select(x => { return x > 1; }); // This is essentially same as the action in var a above. just more code.
            var b = list.Select(x => x % 2 == 0);
            var c = list.Select(x => x * 2);
            var d = list.Select(myFunc);
            var e = list.SelectMany(myFunc);
            var f = list.Where(i => i % 2 == 0).SelectMany(num => negativeList);
            var g = list.Where(i => i % 2 == 0).SelectMany(num => negativeList, (p, n) => new { p, n });
            var h = list.Where(i => i % 2 == 0).SelectMany(num => negativeList, (p, n) => p * n);
            var ii = list.Where(i => i % 2 == 0).SelectMany(num => negativeList.Where(i => i % 2 != 0), (p, n) => p * n);

            Method(a, "list.Select(x => x > 1)");
            Method(a1, "list.Select(x => { return x > 1; })");
            Method(b, "list.Select(x => x%2 == 0)");
            Method(c, "list.Select(x => x*2)");
            Method(d, "list.Select(myFunc)");
            Method(e, "list.SelectMany(myFunc)");
            Method(f, "list.Where(i => i % 2 ==0).SelectMany(num=>negativeList)");
            Method(g, "list.Where(i => i % 2 == 0).SelectMany(num => negativeList, (p, n) => new { p, n })");
            Method(h, "list.Where(i => i % 2 == 0).SelectMany(num => negativeList, (p, n) => p * n)");
            Method(ii, "list.Where(i => i % 2 == 0).SelectMany(num => negativeList.Where(i => i % 2 != 0), (p, n) => p * n); ");

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

        public static void Method(IEnumerable a, string methodName)
        {
            Console.WriteLine("****************{0}", methodName);
            foreach (var v in a)
            {
                Console.Write("{0}, ", v);
            }
            Console.WriteLine("****************");
        }

        public static int ListAdd(int i, List<int> list)
        {
            int val = 0;
            foreach (var l in list.Where(x => x > i))
            {
                val += l;
            }
            return val;
        }
    }
}
