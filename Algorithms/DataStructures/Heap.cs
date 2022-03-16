using Algorithms.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Heap<T>
        where T : IComparable<T>
    {
        //private readonly IList<T> a;

        //public int Size { get; private set; }

        //public T Max => a[1];

        //public Heap(IList<T> items)
        //{
        //    a = items;
        //}

        public static void Sort(IList<T> a)
        {
            int N = a.Count;
            //Build heap
            for (int k = N / 2; k >= 1; k--)
            {
                Sink(a, k, N);
            }
            //sort
            while (N > 1)
            {
                Swap(a, 1, N--);
                Sink(a, 1, N);
            }
        }

        private static void Sink(IList<T> a, int k, int n)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                //选择较大的子节点
                if (j < n && Less(a, j, j + 1)) j++;
                if (Less(a, j, k)) break;
                Swap(a, j, k);
                k = j;
            }
        }

        private static void Swap(IList<T> a, int i, int j) => a.Swap(i - 1, j - 1);

        private static bool Less(IList<T> a, int i, int j) => Utils.Less(a[i - 1]!, a[j - 1]!);
    }
}
