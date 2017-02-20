using System;
using System.Collections.Generic;

namespace Patterns.RandomCode
{
    class IteratorYieldDemo
    {
        static ICollection<string> namesInDB = new List<string> { "ted", "bin", "mini", "bet" };

        public static void Run()
        {
            IEnumerable<string> iEnum = NameEnumerable();
            namesInDB.Add("ed");
            namesInDB.Add("*******red");
            Printer(iEnum);
        }

        public static IEnumerable<string> NameEnumerable()
        {
            //return names;
            ICollection<string> names = namesInDB;
            foreach (var name in names)
            {
                string helloname = "Hello " + name;
                yield return helloname;
            }
        }

        public static IEnumerable<string> NameEnumerable2()
        {
            //return names;
            ICollection<string> names = namesInDB;
            foreach (var name in names)
            {
                string helloname = "Hello " + name;
                yield return helloname;
            }
        }

        public static void Printer(IEnumerable<string> iEnum)
        {
            foreach (var s in iEnum)
            {
                Console.WriteLine(s);
            }
        }
    }
}
