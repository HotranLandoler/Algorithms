using Algorithms.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SimpleAlgos
    {
        /// <summary>
        /// 检测多个数值是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool MultiEquals<T>(params T[] items)
            where T : IEquatable<T>
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                if (!items[i].Equals(items[i + 1]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 两个数是否严格在0和1之间
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool Within01(double x, double y)
        {
            if (x <= 0 || x >= 1)
                return false;
            return y > 0 && y < 1;
        }

        /// <summary>
        /// 将整数转换为二进制字符串
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string IntToBinary(int n)
        {
            StringBuilder sb = new();
            do
            {
                sb.Insert(0, n % 2);
                n /= 2;
            } while (n > 0);
            return sb.ToString();
        }

        /// <summary>
        /// 打印布尔矩阵
        /// </summary>
        /// <param name="bools"></param>
        public static void PrintBoolMatrix(bool[,] bools)
        {
            for (int i = 0; i < bools.GetLength(0); i++)
            {
                for (int j = 0; j < bools.GetLength(1); j++)
                {
                    //若要在字段中左对齐字符串，请在字段宽度前面加上负号，如 {0,-12} 定义12个字符左对齐字段。
                    Console.Write(string.Format("{0,-3}", Utils.BoolToString(bools[i, j])));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 打印转置矩阵
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        public static void PrintTransposedMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(string.Format("{0,-3}", matrix[j, i]));
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 返回不大于log2n的最大整数
        /// </summary>
        /// <param name="n"></param>
        public static int Lg(int n)
        {
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (Pow(n, i) <= n) max = i;
            }
            return max;
        }

        /// <summary>
        /// n的m次方
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int Pow(int n, int m)
        {
            int res = 1;
            for (int j = 0; j < m; j++)
            {
                res *= 2;
            }
            return res;
        }

        /// <summary>
        /// 返回数组，第i个元素值为整数i在数组中出现次数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int[] Histogram(int[] a, int m)
        {
            int[] res = new int[m];
            for (int i = 0; i < m; i++)
            {
                res[i] = CountAppear(a, i);
            }
            return res;
        }

        /// <summary>
        /// 某个数在数组中出现次数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int CountAppear(int[] a, int i)
        {
            int count = 0;
            foreach (var num in a)
            {
                if (num == i) count++;
            }
            return count;
        }

        /// <summary>
        /// 数组元素之和
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int SumArray(int[] a)
        {
            int sum = 0;
            foreach (var num in a)
            {
                sum += num;
            }
            return sum;
        }

        /// <summary>
        /// 计算ln(N!)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double LnNFactorial(int i)
        {
            if (i <= 1) return 0;
            return Math.Log(i) + LnNFactorial(i - 1);
        }

        /// <summary>
        /// 递归实现二分查找
        /// </summary>
        /// <param name="key"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int BinarySearch(int key, int[] a)
        {
            return Rank(key, a);
        }

        public static int Rank(int key, int[] a)
            => Rank(key, a, 0, a.Length - 1, 0);

        public static int Rank(int key, int[] a, int low, int high, int depth)
        {
            Console.WriteLine();
            for (int i = 0; i < depth; i++)
            {
                Console.Write(" ");
            }
            Console.Write($"low:{low}, high:{high}");
            if (low > high) return -1;
            int mid = low + (high - low) / 2;
            if (key < a[mid]) return Rank(key, a, low, mid - 1, ++depth);
            else if (key > a[mid]) return Rank(key, a, mid + 1, high, ++depth);
            else return mid;
        }

        /// <summary>
        /// 欧几里得算法求最大公约数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Gcd(int a, int b)
        {
            if (b == 0) return 0;
            int mod = a % b;
            Utils.P($"{a}%{b}={mod}");
            if (mod == 0) return b;
            return Gcd(b, mod);
        }

        public static double Binomial(int N, int k, double p)
        {
            if (N == 0 && k == 0) return 1.0;
            if (N < 0 || k < 0) return 0.0;
            return (1.0 - p) * Binomial(N - 1, k, p) + p * Binomial(N - 1, k - 1, p);
        }

        [Obsolete]
        public static double BinomialArray(int N, int k, double p)
        {
            if (N < 0 || k < 0) return 0.0;
            double[,] arr = new double[N + 1, k + 1];
            arr[0, 0] = 1.0;
            int i, j = 0;
            for (i = 1; i <= N; i++)
            {
                for (j = 1; j <= k; j++)
                {
                    arr[i, j] = (1.0 - p) * arr[i - 1, j] + p * arr[i - 1, j - 1];
                }
            }
            return arr[N, k];
        }

        /// <summary>
        /// 检测字符串左右括号是否配对
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckParenthesis(string input)
        {
            FixedCapacityStack<char> stack = new(30);
            foreach (char c in input.ToCharArray())
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                if (!stack.IsEmpty())
                {
                    if (c == ')' && stack.Pop() != '(')
                        return false;
                    if (c == ']' && stack.Pop() != '[')
                        return false;
                    if (c == '}' && stack.Pop() != '{')
                        return false;
                }
            }
            return stack.IsEmpty();
        }

        /// <summary>
        /// 补全左括号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CompleteBrackets(string input)
        {
            var arr = input.ToCharArray();
            FixedCapacityStack<string> ops = new(10);
            FixedCapacityStack<string> vals = new(10);
            foreach (var c in arr)
            {
                if (c == ')')
                {
                    //遇到右括号，弹出操作数和符号，压入完整表达式
                    var b = vals.Pop();
                    var a = vals.Pop();
                    vals.Push($"({a}{ops.Pop()}{b})");
                }
                else if ("+-*/".Contains(c))
                {
                    ops.Push(c.ToString());
                }
                else vals.Push(c.ToString());
            }
            return vals.Pop();
        }

        /// <summary>
        /// 拷贝栈的副本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static FixedCapacityStack<T> Copy<T>(FixedCapacityStack<T> stack)
        {
            FixedCapacityStack<T> copy = new(stack.Size * 4);
            foreach (var item in stack)
            {
                copy.Push(item);
            }
            return copy;
        }
    }
}
