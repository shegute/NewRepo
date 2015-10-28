using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.RandomCode
{
    public delegate int ActionDelegate(int xx, int yy);


    class LamdaMethods
    {
        public static void Run()
        {
            ActionDelegate addDel = (x, y) => x + y;
            ActionDelegate mulDel = (x, y) => x * y;
            LamdaMethods l = new LamdaMethods();
            l.ProcessData(3, 3, addDel);
            l.ProcessData(3, 3, mulDel);

            Action<int, int, string> addAction = (x, y, s) => Console.WriteLine("Adding {0} and {1} ={2} for {3}", x, y, x + y, s);
            l.ProcessAction(12, 14, "Beharu", addAction);

            Func<int, int, int> addFunc = (x, y) => x + y;

            Func<int, int, int> multFunc = multFunImplementation;

            int z = l.ProcessFunc(2, 45, addFunc);
            Console.WriteLine(z);

            z = l.ProcessFunc(2, 45, multFunc);
            Console.WriteLine(z);

            List<Customer> customers = new List<Customer> { new Customer(1, "Nate"), new Customer(2, "Paula"), new Customer(3, "Mauli") };
            var cust = customers.Where(c => c.Id < 3).OrderBy(c => c.Name);
            foreach (Customer c in cust)
            {
                Console.WriteLine(c.Name);
            }
        }

        private static int multFunImplementation(int x, int y)
        {
            return x * y;
        }

        public void ProcessData(int x, int y, ActionDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine("Result is:{0}", result);
        }

        public void ProcessAction(int x, int y, string s, Action<int, int, string> action)
        {
            action(x, y, s);
        }

        public int ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            int z = func(x, y);
            return z;
        }
    }

    public class Customer
    {
        public Customer(int x, string y)
        {
            Id = x;
            Name = y;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
