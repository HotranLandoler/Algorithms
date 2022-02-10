using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Vector
    {
        private double[] vec;

        public int Dimension => vec.Length;

        public double this[int index] => vec[index];

        public Vector(int len)
        {
            vec = new double[len];
        }

        public Vector(params double[] vec)
        {
            this.vec = vec;
        }

        /// <summary>
        /// 向量模长
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            double sum = 0;
            foreach (var item in vec)
            {
                sum += item * item;
            }
            return Math.Sqrt(sum);
        }

        /// <summary>
        /// 向量点乘
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Dot(Vector y)
        {
            if (Dimension != y.Dimension)
                throw new ArgumentException("Length not equal");
            double sum = 0;
            for (int i = 0; i < Dimension; i++)
                sum += vec[i] * y[i];
            return sum;
        }

        /// <summary>
        /// 行向量和矩阵相乘
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public Vector Mult(Matrix matrix)
        {
            if (!(Dimension == matrix.Row))
                throw new ArgumentException("Matrix rows and columns not match");
            double[] res = new double[matrix.Col];
            for (int i = 0; i < res.Length; i++)
            {
                double sum = 0;
                for (int k = 0; k < vec.Length; k++)
                {
                    sum += vec[k] * matrix[k, i];
                }
                res[i] = sum;
            }
            return new Vector(res);
        }

        /// <summary>
        /// 打印向量
        /// </summary>
        public void Print()
        {
            Console.Write("[ ");
            foreach (var item in vec)
            {
                Console.Write($"{item:0.00}, ");
            }
            Console.WriteLine("]");
        }
    }
}
