using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    public static class CollectionExt
    {
        public static void Print<T>(this IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item?.ToString()}, ");
            }
            Console.WriteLine();
        }

        public static void Shuffle<T>(this IList<T> items, int seed = 0)
        {
            Random rand = new(seed);

            for (int i = 0; i < items.Count; i++)
            {
                int randIdx = rand.Next(0, items.Count);
                //随机交换
                Swap(items, i, randIdx);
            }
        }

        public static void Swap<T>(this IList<T> items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        /// <summary>
        /// 是否按升序排列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool IsOrdered<T>(this IList<T> items)
            where T : IComparable<T>
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                if (items[i].CompareTo(items[i + 1]) > 0)
                    return false;
            }
            return true;
        }
    }
}
