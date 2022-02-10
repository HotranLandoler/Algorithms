using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public interface IUnionFind
    {
        /// <summary>
        /// 连通分量数
        /// </summary>
        int Count { get; }
        /// <summary>
        /// 两节点是否在同一连通分量
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        bool IsConnected(int p, int q);
        /// <summary>
        /// 连接两个节点
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        void Union(int p, int q);
    }
}
