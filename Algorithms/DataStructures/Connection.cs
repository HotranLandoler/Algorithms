using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    internal struct Connection
    {
        public int P;
        public int Q;

        public Connection(int p, int q)
        {
            P = p;
            Q = q;
        }

        public override string ToString()
        {
            return $"{P}->{Q}";
        }
    }
}
