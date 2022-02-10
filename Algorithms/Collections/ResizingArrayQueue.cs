using System.Collections;

namespace Algorithms.Collections
{
    public class ResizingArrayQueue<T> : IEnumerable<T>
    {
        private T[] array;

        private int head = 0;
        private int tail = -1;
        public int Size => tail + 1 - head;

        public ResizingArrayQueue(int capacity = 10)
        {
            array = new T[capacity];
        }

        public void Enqueue(T item)
        {
            tail++;
            array[tail] = item;
            if (tail == array.Length - 1)
            {
                Resize();
            }
        }

        private void Resize()
        {
            //重新分配空间
            var newArray = new T[array.Length * 2];
            int k = 0;
            for (int i = head; i <= tail; i++)
            {
                newArray[k++] = array[i];
            }
            array = newArray;
            tail -= head;
            head = 0;
        }

        public T Dequeue()
        {
            var item = array[head];
            array[head] = default;
            head++;
            return item;
        }

        public bool IsEmpty() => Size == 0;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = head; i <= tail; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
