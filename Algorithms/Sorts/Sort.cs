using Algorithms.Collections;
using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    public class Sort<T>
        where T : IComparable<T>
    {
        private readonly IList<T> _items;

        public Sort(IList<T> items)
        {
            _items = items;
        }

        private static bool Less(T it, T that) =>
            Utils.Less(it, that);

        private static bool LessCount(T it, T that, ref int count)
        {
            count++;
            return Less(it, that);
        }

        public bool IsOrdered() => _items.IsOrdered();

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <returns></returns>
        public IList<T> BubbleSort()
        {
            for (int i = 0; i < _items.Count - 1; i++)
            {
                for (int j = 0; j < _items.Count - 1 - i; j++)
                {
                    if (Less(_items[j + 1], _items[j]))
                        _items.Swap(j, j + 1);
                }
            }
            return _items;
        }

        /// <summary>
        /// 选择排序，在遍历中将第i项与所有剩余元素中的最小项交换，排好序的元素在数组左端依次排列
        /// </summary>
        public IList<T> SelectionSort()
        {
            var items = _items;
            for (int i = 0; i < items.Count; i++)
            {
                int min = i; //min = i + 1错误
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (Less(items[j], items[min])) min = j;
                }
                items.Swap(i, min);
            }
            return items;
        }

        public IList<T> InsertionSort()
        {
            var items = _items;
            //1-sort
            HSort(items);
            return items;
        }

        public IList<T> ShellSort()
        {
            var items = _items;
            int h = 1;
            //3X+1递增序列
            while (h < items.Count / 3) h = 3 * h + 1;
            while (h >= 1)
            {
                HSort(items, h);
                h /= 3;
            }
            return items;
        }

        public IList<T> MergeSort()
        {
            var aux = new T[_items.Count];
            MergeSort(aux, 0, aux.Length - 1);
            return _items;
        }

        public IList<T> QuickSort()
        {
            //打乱数组
            _items.Shuffle();
            QuickSort(0, _items.Count - 1);
            return _items;
        }

        public IList<T> HeapSort()
        {
            Heap<T>.Sort(_items);
            return _items;
        }

        private void QuickSort(int low, int high)
        {
            if (high <= low) return;
            int j = Partition(_items, low, high);
            QuickSort(low, j - 1);
            QuickSort(j + 1, high);
        }

        private void MergeSort(IList<T> aux, int low, int high)
        {
            if (high <= low) return;
            int mid = low + (high - low) / 2;
            MergeSort(aux, low, mid);
            MergeSort(aux, mid + 1, high);
            //改进：若已经有序，跳过Merge
            if (Less(_items[mid], _items[mid + 1])) return;
            Merge(aux, low, mid, high);
        }

        /// <summary>
        /// 将两个有序子数组合并为一个有序数组
        /// </summary>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        private void Merge(IList<T> aux, int low, int mid, int high)
        {
            //左数组指针
            int i = low;
            //右数组指针
            int j = mid + 1;
            //全部复制到辅助数组
            for (int k = low; k <= high; k++)
                aux[k] = _items[k];
            for (int k = low; k <= high; k++)
            {
                //从两边选出较小数填回
                if (i > mid) _items[k] = aux[j++]; //左边数组用尽
                else if (j > high) _items[k] = aux[i++];
                else if (Less(aux[i], aux[j])) _items[k] = aux[i++];
                else _items[k] = aux[j++];
            }
        }

        /// <summary>
        /// 切分元素
        /// </summary>
        /// <param name="items"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns>已归位元素的索引</returns>
        private static int Partition(IList<T> items, int low, int high)
        {
            int i = low;
            int j = high + 1;

            while (true)
            {
                //从左向右扫描直到找到不小于切分元素的项
                while (Less(items[++i], items[low]))
                    if (i == high) break;

                //从右向左扫描找不大于切分元素的项
                while (Less(items[low], items[--j]))
                    if (j == low) break; //实际上是多余的检查

                //指针重合时停止
                if (j <= i) break;

                items.Swap(i, j);
            }

            items.Swap(low, j);

            return j;
        }

        //h-sort，使间隔h的元素序列有序
        private static void HSort(IList<T> items, int h = 1)
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i; j >= h; j -= h)
                {
                    if (LessCount(items[j], items[j - h], ref count))
                        items.Swap(j, j - h);
                    else break;
                }
            }
            Console.WriteLine($"{count}/N={((double)count) / items.Count}");
        }
    }
}
