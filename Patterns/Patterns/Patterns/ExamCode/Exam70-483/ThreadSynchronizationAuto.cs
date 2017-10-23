
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.ExamCode.Exam70_483
{

    public class ThreadSynchronizationAuto
    {
        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        private static AutoResetEvent event_2 = new AutoResetEvent(false);

        public static void Run()
        {
            Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                              "The threads wait on AutoResetEvent #1, which was created\r\n" +
                              "in the signaled state, so the first thread is released.\r\n" +
                              "This puts AutoResetEvent #1 into the unsignaled state.");
            Console.ReadLine();

            for (int i = 1; i < 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }
            Thread.Sleep(250);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Press Enter to release another thread.");
                Console.ReadLine();
                event_1.Set();
                Thread.Sleep(250);
            }

            Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Press Enter to release a thread.");
                Console.ReadLine();
                event_2.Set();
                event_1.Set();//Only required for ThreadProc3 since all events have to be released for the thread to run dur to WaitAll();
                Thread.Sleep(250);
            }

            // Visual Studio: Uncomment the following line.
            //Console.Readline();
        }

        static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
            event_1.WaitOne();
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

            Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
            event_2.WaitOne();
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

            Console.WriteLine("{0} ends.", name);
        }

        static void ThreadProc2()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on Any.", name);
            WaitHandle.WaitAny(new WaitHandle[] { event_1, event_2 });
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);
            Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

            Console.WriteLine("{0} ends.", name);
        }
        static void ThreadProc3()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} waits on All.", name);
            WaitHandle.WaitAll(new WaitHandle[] { event_1, event_2 });
            Console.WriteLine("{0} is released from AutoResetEvent #1.", name);
            Console.WriteLine("{0} is released from AutoResetEvent #2.", name);
            Console.WriteLine("{0} ends.", name);
        }
    }
}