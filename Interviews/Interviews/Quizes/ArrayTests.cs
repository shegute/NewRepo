using System;
using System.Collections.Generic;
using System.Linq;

namespace Interviews.Quizes.ArrayTests
{
    public class ArrayTests
    {

        public void Print(int[] n)
        {
            Console.WriteLine($"Print array:");

            for (int i = 0; i < n.Length; i++)
            {
                Console.Write($"{n[i]}, ");
            }
            Console.WriteLine($"");
        }

        public static void Run()
        {
            Console.WriteLine("");
            Console.WriteLine(" *(*(*(*(*(*(*(*)()*)*)ArrayTests*(*(*(*(*)*)(*)(*()*)(*)(*)(*) ");
            ArrayTests arrayTests = new ArrayTests();

            int[] sample = new int[] { 1, 8, 9, 10, 14, 16, 20 };
            Console.WriteLine($"###Sample before change");
            arrayTests.Print(sample);
            Console.WriteLine($"###Calling FindMissingNumbersInRange() on array:");
            arrayTests.Print(arrayTests.FindMissingNumbersInRange(sample));
        }

        public int[] FindMissingNumbersInRange(int[] numbers)
        {
            List<int> missingNumbers = new List<int>();
            int expectedNumber = numbers[0];
            for (int i = 0; i < numbers.Length;)
            {
                if (expectedNumber != numbers[i]) { missingNumbers.Add(expectedNumber++); } else { i++; expectedNumber++; }
            }
            return missingNumbers.ToArray<int>();
        }

    }
}
