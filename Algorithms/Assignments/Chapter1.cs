using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Assignments
{
    public class Chapter1
    {
        public static void Assign1_1_1()
        {
            Console.WriteLine((0 + 15) / 2);
            Console.WriteLine(2.0e-6 * 100000000.1);
            Console.WriteLine(true && false || true && true);
        }

        public static void Assign1_1_2()
        {
            var a = (1 + 2.236) / 2;
            var b = (1 + 2 + 3 + 4.0);
            var c = (4.1 >= 4);
            var d = (1 + 2 + "3");
            Utils.P($"{a} {b} {c} {d}");
        }

        public static void Assign1_1_3()
        {
            int[] nums = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Convert.ToInt32(Console.Read());
            }
            if (SimpleAlgos.MultiEquals(nums))
                Utils.P("equal");
            else Utils.P("not equal");
        }

        public static void Assign1_1_5()
        {
            Utils.P(SimpleAlgos.Within01(0.68, 1.73));
        }

        public static void Assign1_1_9()
        {
            Utils.P(SimpleAlgos.IntToBinary(10));
        }

        public static void Assign1_1_11()
        {
            var bools = new bool[,]
            {
                {true, false, true},
                {false, true, false},
                {true, true, false},
            };
            SimpleAlgos.PrintBoolMatrix(bools);
        }

        public static void Assign1_1_13()
        {
            var nums = new int[3, 4]
                {
                    {1,3,2,4},
                    {2,3,4,5},
                    {3,4,5,6},
                };
            SimpleAlgos.PrintTransposedMatrix(nums);
        }

        public static void Assign1_1_14()
            => Utils.P(SimpleAlgos.Lg(1));

        public static void Assign1_1_15()
        {
            var arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i + 1;
            Utils.P(SimpleAlgos.SumArray(SimpleAlgos.Histogram(arr, 12)));
        }

        public static void Assign1_1_20()
            => Utils.P(SimpleAlgos.LnNFactorial(5));

        public static void Assign1_1_22()
            => SimpleAlgos.BinarySearch(2, new int[] { 1, 2, 3, 4, 5, 6, 7 });

        public static void Assign1_1_24()
            => Utils.P(SimpleAlgos.Gcd(1111111, 1234567));

        public static void Assign1_1_27()
        {
            Utils.P(SimpleAlgos.BinomialArray(10, 5, 0.5));
            Utils.P(SimpleAlgos.Binomial(10, 5, 0.5));
        }

        public static void Assign1_1_33()
        {
            Matrix a = new Matrix(new double[,] { { 1, 2 }, { 1, -1 } });
            Matrix b = new Matrix(new double[,] { { 4, 3, -2 }, { -3, 0, 1 } });
            //a.Transpose().Print();
            Vector x = new Vector(1, 2);
            //Vector y = new Vector(2, 2, 1);
            //Utils.P(x.Dot(y));
            //a.Mult(x).Print();
            x.Mult(a).Print();
        }
    }
}
