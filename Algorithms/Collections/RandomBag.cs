using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    /// <summary>
    /// 在迭代时按随机顺序元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RandomBag<T> : IEnumerable<T>
    {
        private T[] array;

        public int Count { get; private set; } = 0;

        public bool IsEmpty => Count == 0;

        public RandomBag(int capacity = 10)
        {
            array = new T[capacity];
        }

        public RandomBag(params T[] items)
        {
            array = items;
            Count = items.Length;
        }

        public void Add(T item)
        {
            array[Count] = item;
            Count++;
        }

        /// <summary>
        /// 获取随机元素
        /// </summary>
        /// <returns></returns>
        public T GetRandom()
        {
            Random rand = new();
            return array[rand.Next(0, Count)];
        }

        private T[] ShuffleArray()
        {
            Random rand = new();

            T[] newArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = 0; i < Count; i++)
            {
                int randIdx = rand.Next(0, Count);
                //随机交换
                T temp = newArray[i];
                newArray[i] = newArray[randIdx];
                newArray[randIdx] = temp;
            }
            return newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] newArray = ShuffleArray();
            foreach (var item in newArray)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
