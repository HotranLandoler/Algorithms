using Algorithms.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Graph : IGraph
    {
        private readonly Bag<int>[] adjLists;

        public int VerticesCount { get; }

        public int EdgeCount => throw new NotImplementedException();

        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            adjLists = new Bag<int>[verticesCount];
            for (int i = 0; i < adjLists.Length; i++)
            {
                adjLists[i] = new Bag<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adjLists[v].Add(w);
            adjLists[w].Add(v);
        }

        public IEnumerable<int> AdjsOf(int v) => adjLists[v];

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
