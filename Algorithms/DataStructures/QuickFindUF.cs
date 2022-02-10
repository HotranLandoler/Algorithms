using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class QuickFindUF : IUnionFind
    {
        private int[] id;

        public QuickFindUF(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }

            Count = n;
        }

        public int Count { get; private set; }

        /// <summary>
        /// 是否连通
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsConnected(int a, int b) => id[a] == id[b];

        /// <summary>
        /// 连通
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            if (IsConnected(p, q)) return;
            int pId = id[p];
            int qId = id[q];

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                    id[i] = qId;
            }
            Count--;
        }
    }
}
