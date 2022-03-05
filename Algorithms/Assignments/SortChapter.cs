using Algorithms.Collections;
using Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Assignments
{
    public class SortChapter
    {
        private static double[] GenerateArray(int count)
        {
            var items = Utils.GetSortedArray(count);
            items.Shuffle();

            return items;
        }

        private static void TestSort<T>(Sort<T> sort, Func<IList<T>> algo, string algoName)
            where T : IComparable<T>
        {
            Utils.GetRunningTime(algo, algoName);
            Assert.IsTrue(sort.IsOrdered());
        }

        private static Sort<double> CreateSort(int count)
        {
            var items = GenerateArray(count);
            return new(items);
        }

        public static void BubbleSort(int count)
        {
            var sort = CreateSort(count);

            TestSort(sort, sort.BubbleSort, "Bubble");
        }

        public static void SelectionSort(int count)
        {
            var sort = CreateSort(count);

            TestSort(sort, sort.SelectionSort, "Selection");
        }

        public static void InsertionSort(int count)
        {
            var sort = CreateSort(count);

            TestSort(sort, sort.InsertionSort, "Insertion");
        }

        public static void ShellSort(int count)
        {
            var sort = CreateSort(count);

            TestSort(sort, sort.ShellSort, "Shell");
        }

        public static void MergeSort(int count)
        {
            var sort = CreateSort(count);

            TestSort(sort, sort.MergeSort, "Merge");
        }

        public static void QuickSort(int count)
        {
            var sort = CreateSort(count);

            TestSort(sort, sort.QuickSort, "Quick");
        }
    }
}
