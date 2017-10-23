using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.RandomCode
{
    public class RandomStuff
    {
        public static void Run()
        {
            RandomStuff r = new RandomStuff();
            r.SizeOf();
        }

        public void SizeOf()
        {
            Console.WriteLine("Size of int: {0}", sizeof(int));
            Console.WriteLine("Size of byte: {0}", sizeof(byte));
            Console.WriteLine("Size of char: {0}", sizeof(char));
            Console.WriteLine("Size of double: {0}", sizeof(double));
            Console.WriteLine("Size of bool: {0}", sizeof(bool));
            
        }
    }
}
