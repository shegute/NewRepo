using System;

namespace Patterns.RandomCode
{
    public class EventsAndDelegates
    {
        public static void Run()
        {
            Turumba turmbaNefi = new Turumba(EdertegnochJoro);
            turmbaNefi += new Turumba(NonEdertegnochJoro);
            turmbaNefi.Invoke(5,"Cherkos");
        }

        public delegate void Turumba(int time, string place);
        
        private static void EdertegnochJoro(int time, string place)
        {
            Console.WriteLine("I heard we have to go to {0} at {1}",place, time);
        }
        
        private static void NonEdertegnochJoro(int time, string place)
        {
            Console.WriteLine("I heard edertegnoch have to go to {0} at {1}",place, time);
            Console.WriteLine("Lucky I am not edertegna :).");
        }
    }

}
