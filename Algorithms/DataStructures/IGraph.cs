using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public interface IGraph
    {
        int VerticesCount { get; }
        int EdgeCount { get; }
        /// <summary>
        /// 添加一条边v-w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        void AddEdge(int v, int w);
        /// <summary>
        /// 和v相邻的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        IEnumerable<int> AdjsOf(int v);
    }
}
