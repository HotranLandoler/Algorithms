using Algorithms.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class MaxPriorityQueue<T>
        where T : IComparable<T>
    {
        private readonly IList<T?> a;

        public int Size { get; private set; }

        public T? Max => a[1];

        public MaxPriorityQueue(int capacity)
        {
            a = new T?[capacity + 1];
        }

        public MaxPriorityQueue(IList<T?> items)
        {
            a = items;
        }

        /// <summary>
        /// 插入元素
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Insert(T item)
        {
            if (Size + 1 >= a.Count) throw new Exception("Queue is full!");
            a[++Size] = item;
            Swim(Size);
        }

        public bool IsEmpty() => Size == 0;

        /// <summary>
        /// 移除并返回最大元素
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">队列为空</exception>
        public T RemoveMax()
        {
            if (IsEmpty()) throw new Exception("Queue is empty!");
            T max = Max!;
            Swap(1, Size);
            //防止游离
            a[Size--] = default;
            Sink(1);
            return max;
        }

        //public void Sort()
        //{
        //    while (Size > 1)
        //    {
        //        Swap(1, Size--);
        //        Sink(1);
        //    }
        //}

        private void Swim(int k)
        {
            while (k > 1 && Less(MaxPriorityQueue<T>.Parent(k), k))
            {
                Swap(k, MaxPriorityQueue<T>.Parent(k));
                k = MaxPriorityQueue<T>.Parent(k);
            }
        }

        private void Sink(int k)
        {
            Sink(k, Size);
        }

        private void Sink(int k, int n)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                //选择较大的子节点
                if (j < n && Less(j, j + 1)) j++;
                if (Less(j, k)) break;
                Swap(j, k);
                k = j;
            }
        }

        private void Swap(int i, int j) => a.Swap(i - 1, j - 1);

        private bool Less(int i, int j) => Utils.Less(a[i - 1]!, a[j - 1]!);

        private static int Parent(int k) => k / 2;
    }
}
