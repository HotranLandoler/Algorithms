using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Matrix
    {
        private readonly double[,] matrix;

        public double this[int row, int col] => matrix[row, col];

        public int Row => matrix.GetLength(0);
        public int Col => matrix.GetLength(1);

        public Matrix(int row, int col)
        {
            matrix = new double[row, col];
        }

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">A的列数与B的行数不匹配</exception>
        public Matrix Mult(Matrix b)
        {
            if (!(matrix.GetLength(1) == b.matrix.GetLength(0)))
                throw new ArgumentException("Matrix rows and columns not match");

            int row = matrix.GetLength(0);
            int col = b.matrix.GetLength(1);
            int num = matrix.GetLength(1);
            Matrix res = new Matrix(row, col);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < num; k++)
                    {
                        sum += matrix[i, k] * b.matrix[k, j];
                    }
                    res.matrix[i, j] = sum;
                }
            }
            return res;
        }

        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            double[,] res = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0;j < col; j++)
                {
                    res[i, j] = matrix[j, i];
                }
            }
            return new Matrix(res);
        }

        /// <summary>
        /// 矩阵-向量乘法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Vector Mult(Vector x)
        {
            if (!(matrix.GetLength(1) == x.Dimension))
                throw new ArgumentException("Matrix rows and columns not match");
            double[] res = new double[matrix.GetLength(0)];
            for (int i = 0; i < res.Length; i++)
            {
                double sum = 0;
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    sum += matrix[i, k] * x[k];
                }
                res[i] = sum;
            }
            return new Vector(res);
        }

        /// <summary>
        /// 打印矩阵
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Console.Write("{0, 3}, ", matrix[i, j].ToString("0.00"));
                }
                Console.WriteLine();
            }
        }
    }
}
