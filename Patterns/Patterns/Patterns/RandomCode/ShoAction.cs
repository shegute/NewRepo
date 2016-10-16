using System;

namespace Patterns.RandomCode
{
    class ShoAction
    {
        public static void Run(string[] args)
        {
            ShoAction.Sho(args);
        }

        private static void Sho(string[] args)
        {
            Action<string> message;
            
            if (args.Length > 1)
            {
                message = Sho;
                message(args[0]+args[1]);
            }
            else
            {
                message = Console.WriteLine;
            }
            message("Teststing thsi END");

            //bool s1 = true;
            //bool s2 = true;
            //if (s1 && s2)
            //{
            //    Console.WriteLine("this is a message box ");
            //}
        }

        private static void Sho(string obj)
        {
            Console.WriteLine("this is a message box " + obj);
        }
    }
}
