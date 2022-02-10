using System;
using System.Collections.Generic;
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

        public static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                P(item);
            }
        }


        /// <summary>
        /// bool转换为string
        /// </summary>
        /// <param name="b"></param>
        /// <returns>*表示真，空格表示假</returns>
        public static string BoolToString(bool b)
            => b ? "*" : " ";


    }
}
