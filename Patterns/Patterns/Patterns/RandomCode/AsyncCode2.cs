using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.RandomCode
{
    class AsyncCode2
    {
        static async void ProcessDataAsync()
        {
            // Start the HandleFile method.
            Task<int> task =
                HandleFileAsync(@"C:\Users\Nate\Source\Repos\NewRepo\Patterns\Patterns\Patterns\RandomCode\TextFile1.txt");

            // Control returns here before HandleFileAsync returns.
            // ... Prompt the user.
            Console.WriteLine("Please wait patiently " +
                "while I do something important.");

            // Wait for the HandleFile task to complete.
            // ... Display its results.
            int x = await task;
            Console.WriteLine("Count: " + x);
        }

        static async Task<int> HandleFileAsync(string file)
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                string v = "adfasfadsfa";//await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
        }

        public static async Task ShowIntAsync(int value)
        {
            Task<int> task = ReturnIntAsync(value);
            Console.WriteLine("Please wait patiently  while I do something important.");
            int x = await task;
            Console.WriteLine("This is the value from ShowIntAsync:{0}", x);
        }
        public static async Task<int> ReturnIntAsync(int value)
        {
            int i, j = 0;
            for (i = 0; i < value; i++)
            { j = i; }
            return value;
        }


        public static class AsyncCodeRunner2
        {
            public async static void Run()
            {
                // Create task and start it.
                // ... Wait for it to complete.
                //Task task = new Task(ProcessDataAsync);
                //task.Start();
                //task.Wait();
                //Console.ReadLine();
                Task task = new Task(() => ShowIntAsync(100));
                int task2 = await ReturnIntAsync(1000000);
                Console.WriteLine("This is the value from ReturnIntAsync (has ShowIntAsync.Start after it):{0}", task2);
                task.Start();
                task.Wait();
                Console.WriteLine("No matter how high the value in ReturnIntAsync, it will return before ShowIntAsync" +
                    " because we did an await on ReturnIntAsync before doing .Start on ShowIntAsync");

                Task task3 = new Task(() => ShowIntAsync(20000));
                task3.Start();
                task3.Wait();
                int task4 = await ReturnIntAsync(2000);

                Console.WriteLine("This is the value from ReturnIntAsync (has ShowIntAsync.Start before it):{0}", task4);


                await ShowIntAsync(30000);
                int task6 = await ReturnIntAsync(3000);

                Console.WriteLine("This is the value from ReturnIntAsync (has ShowIntAsync.Start before it):{0}", task6);
               // Console.ReadLine();
            }

        }
    }
}