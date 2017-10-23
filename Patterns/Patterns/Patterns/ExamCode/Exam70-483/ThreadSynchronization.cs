using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.ExamCode.Exam70_483
{

    public class ThreadSynchronization
    {
        static AutoResetEvent autoEvent;

        static void DoWork()
        {
            Console.WriteLine("   worker thread started, now waiting on event...");
            autoEvent.WaitOne();
            Console.WriteLine("   worker thread reactivated, now exiting...");
        }

        public static void Run()
        {
            autoEvent = new AutoResetEvent(false);

            Console.WriteLine("main thread starting worker thread...");
            Thread t = new Thread(DoWork);
            t.Start();

            Console.WriteLine("main thread sleeping for 1 second...");
            Thread.Sleep(1000);

            Console.WriteLine("main thread signaling worker thread...");
            autoEvent.Set();

            Console.WriteLine("main thread, now exiting...");
        }
    }
}