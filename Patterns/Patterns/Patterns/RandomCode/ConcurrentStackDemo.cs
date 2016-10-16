﻿using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.RandomCode
{
    class ConcurrentStackDemo
    {
        // Demonstrates:
        //      ConcurrentStack<T>.PushRange();
        //      ConcurrentStack<T>.TryPopRange();
        //      ConcurrentStack<T>.IsEmpty;
       public  static void Run()
        {
            int errorCount = 0;

            // Construct a ConcurrentStack
            ConcurrentStack<int> cs = new ConcurrentStack<int>();

            // Push some consecutively numbered ranges
            cs.PushRange(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            cs.PushRange(new int[] { 8, 9, 10 });
            cs.PushRange(new int[] { 11, 12, 13, 14 });
            cs.PushRange(new int[] { 15, 16, 17, 18, 19, 20 });
            cs.PushRange(new int[] { 21, 22 });
            cs.PushRange(new int[] { 23, 24, 25, 26, 27, 28, 29, 30 });

            // Now read them back, 3 at a time, concurrently
            Parallel.For(0, 10, i =>
            {
                int[] range = new int[3];
                if (cs.TryPopRange(range) != 3)
                {
                    Console.WriteLine("CS: TryPopRange failed unexpectedly");
                    Interlocked.Increment(ref errorCount);
                }

                // Each range should be consecutive integers, if the range was extracted atomically
                // And it should be reverse of the original order...
                if (!range.Skip(1).SequenceEqual(range.Take(range.Length - 1).Select(x => x - 1)))
                {
                    Console.WriteLine("CS: Expected consecutive ranges.  range[0]={0}, range[1]={1}", range[0], range[1]);
                    Interlocked.Increment(ref errorCount);
                }
            });
            int[] range1 = new int[3];
           cs.TryPopRange(range1); 

           if (!range1.Skip(1).SequenceEqual(range1.Take(range1.Length - 1).Select(x => x - 1)))
           {
               var a = range1.Skip(1);
               var b = range1.Take(range1.Length - 2);
                   var c = range1.Take(range1.Length - 1).Select(x => x - 1);
                   var d = range1.Select(x => x - 1);
               var e = range1.Skip(1).SequenceEqual(range1.Take(range1.Length - 1).Select(x => x - 1));
           }
           // We should have emptied the thing
            if (!cs.IsEmpty)
            {
                Console.WriteLine("CS: Expected IsEmpty to be true after emptying");
                errorCount++;
            }

            if (errorCount == 0) Console.WriteLine("  OK!");
        }
    }
}