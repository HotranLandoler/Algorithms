using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    public class FixedCapacityStack<T> : IEnumerable<T>
    {
        private readonly T[] array;

        private int size = 0;
        public int Size => size;

        public FixedCapacityStack(int capacity)
        {
            array = new T[capacity];
        }

        public void Push(T item)
        {
            array[size] = item;
            size++;
        }

        public T Pop()
        {
            var item = array[size];
            array[size] = default;
            size--;
            return item;
        }

        public T Peek() => array[size-1];

        public bool IsEmpty() => size == 0;

        public bool IsFull() => size == array.Length;

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator(array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }       

        private class ArrayEnumerator : IEnumerator<T>
        {
            private T[] items;
            private int index = -1;

            public T Current => items[index];

            object IEnumerator.Current => Current;

            public ArrayEnumerator(T[] items)
            {
                this.items = items;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                index++;
                return index < items.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
