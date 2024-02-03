using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Quizes.IntegerTests
{
    public class IntegerTests
    {

        public static void Print(int[] n)
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
            Console.WriteLine(" *(*(*(*(*(*(*(*)()*)*)IntegerTests*(*(*(*(*)*)(*)(*()*)(*)(*)(*) ");
            IntegerTests integerTests = new IntegerTests();

            int sample = 58385;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            sample = 333;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            sample = 158385;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            sample = 1;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            sample = 9;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            sample = 11;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            sample = -121;
            Console.WriteLine($"###Calling IsAPalindromNumber({sample}) on integer:");
            Console.WriteLine(integerTests.IsAPalindromNumber(sample));
            int[] arr = new int[] { 1, 4, 20, 3, 10, 5 };
            int targetSum = 33;
            Console.WriteLine($"###Calling findSubArray({arr}, {targetSum}) on integer:");
            Print( integerTests.findSubArray(arr,targetSum)) ;
        }


        public bool IsAPalindromNumber(int number)
        {
            if (number < 10 && number > -1) { return false; }
            if (number < 0) { number= number * -1; }

            int digitCounter = 10; int digitCounter2 = 10; int dividend = 1;
            while (dividend >= 1) { dividend = number / digitCounter; if (dividend < 10) { break; } { digitCounter *= 10;  } }

            bool isPalindrome = false; int firstDigit, lastDigit, numberCopy, numberCopy2;

            numberCopy = numberCopy2 = number;
            do
            {
                Tuple<int, int, int> firstDigitSet = this.GetFirstDigit(numberCopy, digitCounter);
                firstDigit = firstDigitSet.Item1; digitCounter = firstDigitSet.Item2; numberCopy = firstDigitSet.Item3;

                Tuple<int, int> lastDigitSet = this.GetLastDigit(numberCopy2, digitCounter2);
                lastDigit = lastDigitSet.Item1; numberCopy2 = lastDigitSet.Item2;
                isPalindrome = firstDigit == lastDigit;
            }
            while (digitCounter != digitCounter2 && digitCounter >0 && digitCounter2>0 && isPalindrome);

            return isPalindrome;
        }

        public Tuple<int, int, int> GetFirstDigit(int number, int digitCounter)
        {
            int digit = number / digitCounter; number = number % digitCounter; digitCounter /= 10;
            return new Tuple<int, int, int>(digit, digitCounter, number);
        }

        public Tuple<int, int> GetLastDigit(int number, int digitCounter)
        {
            int digit = number % digitCounter; number = number / digitCounter;
            return new Tuple<int, int>(digit, number);
        }

        public int[] findSubArray(int[] arr, int targetSum)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                int index = i;
                while (sum < targetSum)
                {
                    sum += arr[index];
                    index++;
                }
                if (sum == targetSum)
                {

                    List<int> subArray = new List<int>();

                    for (int j = i; j < index; j++)
                    { subArray.Add(arr[j]); }
                    return subArray.ToArray();
                }

            }

            return new int[0];

        }
    }
}
