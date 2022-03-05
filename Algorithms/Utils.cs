using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Utils
    {
        /// <summary>
        /// 打印
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        public static void P<T>(T content)
        {
            if (content == null) return;
            Console.WriteLine(content.ToString());
        }

        /// <summary>
        /// bool转换为string
        /// </summary>
        /// <param name="b"></param>
        /// <returns>*表示真，空格表示假</returns>
        public static string BoolToString(bool b)
            => b ? "*" : " ";

        public static double[] GetSortedArray(int count)
        {
            var arr = new double[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        public static void GetRunningTime<T>(Func<T> action, string name)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            Console.WriteLine($"{name} Time: {stopwatch.Elapsed.TotalMilliseconds}");
        }
    }
}
