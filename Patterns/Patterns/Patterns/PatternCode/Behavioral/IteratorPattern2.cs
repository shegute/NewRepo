using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.PatternCode.Behavioral
{
    // Define the aggregate interface (collection)
    interface IAggregate
    {
        IIterator CreateIterator();
    }

    // Define the iterator interface
    interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // Concrete implementation of an aggregate (collection)
    class ConcreteAggregate : IAggregate
    {
        private ArrayList items = new ArrayList();

        public void AddItem(object item)
        {
            items.Add(item);
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public object this[int index]
        {
            get { return items[index]; }
        }
    }

    // Concrete implementation of an iterator
    class ConcreteIterator : IIterator
    {
        private ConcreteAggregate aggregate;
        private int index = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public object Next()
        {
            if (HasNext())
            {
                return aggregate[index++];
            }
            else
            {
                throw new InvalidOperationException("End of collection reached.");
            }
        }
    }

class IteratorPattern2
{
    static void Run()
    {
        ConcreteAggregate aggregate = new ConcreteAggregate();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        IIterator iterator = aggregate.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}

}