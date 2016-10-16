using System;

namespace Patterns.RandomCode
{
    public class ByRef
    {

        public static void Run()
        {
            ByRef a = new ByRef();
            Changes one = new Changes(0, "Zero");
            Changes two = new Changes(0, "Zero");
            Changes three = new Changes(0, "Zero");

            one.Display();
            a.ByRefrence(ref one);
            one.Display();
            two.Display();
            a.NotByRefrence(two);
            two.Display();
            three.Display();
            a.InnerValue(three.Numero, three.Stringero);
            three.Display();

        }

        public void ByRefrence(ref Changes c)
        {
            c.Numero = 1;
            c.Stringero = "One";
        }
        public void NotByRefrence(Changes c)
        {
            c.Numero = 2;
            c.Stringero = "Two";
        }
        public void InnerValue(int n,string s)
        {
            n = 3;
            s = "three";
        }
    }

    public class Changes
    {
        public int Numero { get; set; }
        public string Stringero { get; set; }

        public Changes(int n, string s)
        {
            Numero = n;
            Stringero = s;
        }
        public void Display()
        {
            Console.WriteLine("Number:{0} and string:{1}", Numero, Stringero);
        }
    }
}
