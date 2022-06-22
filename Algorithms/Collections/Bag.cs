using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    public class Bag<T> : IBag<T>
    {
        private readonly DoubleLinkedList<T> list;

        public int Size { get; private set; } = 0;

        public Bag()
        {
            list = new DoubleLinkedList<T>();
        }

        public bool IsEmpty() => Size == 0;

        public void Add(T item)
        {
            list.AddLast(item);
            Size++;
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
