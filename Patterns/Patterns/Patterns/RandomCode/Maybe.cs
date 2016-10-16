using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.RandomCode
{
    public class Maybe<T> : IEnumerable<T>
    {
        public static void Run()
        {
            Maybe<int> empty = new Maybe<int>();
            Maybe<int> notEmpty = new Maybe<int>(12);
            Console.WriteLine(empty.DefaultIfEmpty<int>().Single<int>());
            Console.WriteLine(empty.DefaultIfEmpty<int>(23).Single<int>());
            Console.WriteLine(notEmpty.FirstOrDefault<int>());
            Console.WriteLine(notEmpty.DefaultIfEmpty<int>().Single<int>());
            Console.WriteLine(notEmpty.ElementAtOrDefault<int>(0));
        }

        private readonly IEnumerable<T> values;

        public Maybe()
        {
            this.values = new T[0];
        }

        public Maybe(T value)
        {
            this.values = new T[1] { value };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
