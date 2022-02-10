using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// QuickFind的改进
    /// </summary>
    public class QuickUnionUF : IUnionFind
    {
        //每个值代表节点的父节点，根节点的父节点为自己
        private int[] id;

        //根id所在树包含的元素数
        private int[] size;

        public QuickUnionUF(int n)
        {
            id = new int[n];
            size = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                size[i] = 1;
            }

            Count = n;
        }

        public int Count { get; private set; }

        public bool IsConnected(int p, int q) => Find(p) == Find(q);

        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;

            //加权合并，小树合并到大树
            if (size[rootP] > size[rootQ])
            {
                id[rootQ] = rootP;
                size[rootP] += size[rootQ];
            }
            else
            {
                id[rootP] = rootQ;
                size[rootQ] += size[rootP];
            }
            //id[rootP] = rootQ;

            Count--;
        }

        //返回节点的根节点
        //由于树会变得过高，Find成本会过高
        private int Find(int p)
        {
            while (p != id[p])
            {
                //每个节点指向祖父，压缩树深度
                id[p] = id[id[p]];

                p = id[p];
            }

            return p;
        }
    }
}
