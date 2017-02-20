using System;
using System.Threading.Tasks;

namespace Patterns.RandomCode
{
    class AsyncCode
    {
        public async Task<int> PrintSumAsync()
        {
            int value1 = await GetValueAsync();
            int value2 = await GetValueAsync();
            Console.WriteLine("Sum of two random numbers is: {0}", value1 + value2);
            return 0;
        }

        private async Task<int> GetValueAsync()
        {
            int random = ComputeValue();
            return random;
        }

        private int ComputeValue()
        {
            return new Random().Next(1, 1000);
        }

        public void SecondMethod()
        {
            Console.WriteLine("This is the test I need");
        }
    }

    public static class AsyncCodeRunner
    {
        public async static void Run()
        {
            var a = new AsyncCode();
            await a.PrintSumAsync();
            a.SecondMethod();
        }
    }
}
