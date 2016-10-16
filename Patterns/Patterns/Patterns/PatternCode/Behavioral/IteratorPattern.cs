using System;
using System.Collections;

namespace DoFactory.GangOfFour.Iterator.Structural
{

    /// <summary>MainApp startup class for Structural. Iterator Design Pattern.</summary>
    class IteratorMainApp
    {
        /// <summary>Entry point into console application.</summary>
        public static void Run()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item D";
            a[1] = "Item A";
            a[2] = "Item F";
            a[3] = "Item C";
            a[4] = "Item E";
            a[5] = "Item G";
            a[6] = "Item B";
            a.AssignIterator(new ConcreteIteratorByIndex(a));
            a._iterator.Iterate();

            a.AssignIterator(new ConcreteIteratorByItem(a));
            a._iterator.First();
            a._iterator.Iterate();

            //// Create Iterator and provide aggregate
            //ConcreteIteratorByIndex i = new ConcreteIteratorByIndex(a);

            //Console.WriteLine("Iterating over collection:");
            //object item = i.First();
            //while (item != null)
            //{
            //    Console.WriteLine(item);
            //    item = i.Next();
            //}

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>The 'Aggregate' abstract class</summary>
    abstract class Aggregate
    {
        public abstract void AssignIterator(Iterator i);
    }

    /// <summary>The 'ConcreteAggregate' </summary>
    class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();
        public Iterator _iterator = null;

        public override void AssignIterator(Iterator iterator)
        {
            this._iterator = iterator;
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    /// <summary>The 'Iterator' abstract class.</summary>
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
        public abstract void Iterate();
    }

    /// <summary>The 'ConcreteIteratorByIndex' </summary>
    class ConcreteIteratorByIndex : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public ConcreteIteratorByIndex(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override void Iterate()
        {
            int[] visitedItems = new int[_aggregate.Count - 1];
            Console.WriteLine("Iterating over collection:");
            object item = this.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = this.Next();
            }
            _current = 0;
        }
    }


    /// <summary>The 'ConcreteIteratorByItem' </summary>
    class ConcreteIteratorByItem : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;
        int[] _iteratedItems;

        // Constructor
        public ConcreteIteratorByItem(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
            this._iteratedItems = new int[_aggregate.Count];
        }

        // Gets first iteration item
        public override object First()
        {
            int top = 0;
            int temp = 1;
            while ((top < this._aggregate.Count && temp < this._aggregate.Count) &&
                this._aggregate[top] != null && this._aggregate[temp] != null)
            {
                int comparision =
                    String.Compare(this._aggregate[top].ToString(), this._aggregate[temp].ToString(), StringComparison.Ordinal);

                if (comparision > 0)
                {
                    top = temp;
                }

                temp++;
            }
            _current = top;
            return _aggregate[top];
        }

        // Gets next iteration item
        public override object Next()
        {

            int[] _visitedItems = new int[_aggregate.Count];
            object ret = null;
            int start = _current;
            ret = this._aggregate[start];
            _visitedItems[start] = 1;
            _iteratedItems[start] = 1;

            int i = start + 1;
            if (start + 1 == this._aggregate.Count)
            {
                i = 0; // if at the last slot, go to 0.
            }
            if (this.AllItemsIterated())
            {
                return null; // if all items have been iterated, return.
            }
            for (; i < this._aggregate.Count && i != start; i++)
            {
                int comparision =
                    String.Compare(this._aggregate[start].ToString(), this._aggregate[i].ToString(), StringComparison.Ordinal);
                if (_current == start && comparision < 0 && _visitedItems[i] != 1 && _iteratedItems[i] != 1)
                {
                    start = i;
                    ret = this._aggregate[start];//for the first iteration in the for loop, only move the index if
                    // 1 first go through the for loop, 2 index item is larger than the current item
                    //3 item hasnt been visitied in this for loop, 4 item hasnt been visitied in this 
                }
                else if (comparision > 0 && _visitedItems[i] != 1 && _iteratedItems[i] != 1)
                {
                    start = i;
                    ret = this._aggregate[start];
                    // for the remaining iterations in this for loop, if the index item is smaller than the last item
                    //item hasnt been visitied in this for loop, item hasnt been visitied in this 
                }

                if (i + 1 == _aggregate.Count && _visitedItems[i] != 1)
                {
                    _visitedItems[i] = 1;
                    i = -1;
                    continue; //go to top of the item list if at the end and all items not visited yet.
                }
                _visitedItems[i] = 1;
            }
            _current = start;
            _iteratedItems[_current] = 1;
            return ret;
        }// Gets next iteration item

        public object Next2()
        {
            if (this.AllItemsIterated())
            {
                return null; // if all items have been iterated, return.
            }
            int[] _visitedItems = new int[_aggregate.Count];
            object ret = null;
            int start = _current;
            ret = this._aggregate[start];
            _visitedItems[start] = 1;
            _iteratedItems[start] = 1;

            int i = start + 1;
            if (start + 1 == this._aggregate.Count)
            {
                i = 0; // if at the last slot, go to 0.
            }

            while (!this.AllItemsVisited(_visitedItems))
            {
                int comparision =
                    String.Compare(this._aggregate[start].ToString(), this._aggregate[i].ToString(), StringComparison.Ordinal);
                if (_current == start && comparision < 0 && _visitedItems[i] != 1 && _iteratedItems[i] != 1)
                {
                    start = i;
                    ret = this._aggregate[start];//for the first iteration in the for loop, only move the index if
                    // 1 first go through the for loop, 2 index item is larger than the current item
                    //3 item hasnt been visitied in this for loop, 4 item hasnt been visitied in this 
                }
                else if (comparision > 0 && _visitedItems[i] != 1 && _iteratedItems[i] != 1)
                {
                    start = i;
                    ret = this._aggregate[start];
                    // for the remaining iterations in this for loop, if the index item is smaller than the last item
                    //item hasnt been visitied in this for loop, item hasnt been visitied in this 
                }

                if (i + 1 == _aggregate.Count && _visitedItems[i] != 1)
                {
                    _visitedItems[i] = 1;
                    i = 0;
                    continue; //go to top of the item list if at the end and all items not visited yet.
                }
                _visitedItems[i] = 1;
                i++;
            }

            _current = start;
            _iteratedItems[_current] = 1;
            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override void Iterate()
        {
            for (int i = 0; i < _aggregate.Count; i++)
            {
                _iteratedItems[i] = 0;
            }

            Console.WriteLine("Iterating over collection:");
            object item = this.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = this.Next2();
            }
            _current = 0;
        }

        private bool AllItemsIterated()
        {
            for (int i = 0; i < _iteratedItems.Length; i++)
            {
                if (_iteratedItems[i] == 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < _iteratedItems.Length; i++)
            {
                _iteratedItems[i] = 0;
            }

            return true;
        }



        private bool AllItemsVisited(int[] visitedItems)
        {
            for (int i = 0; i < visitedItems.Length; i++)
            {
                if (visitedItems[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}