using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    public interface IBag<T> : IEnumerable<T>
    {
        void Add(T item);
        bool IsEmpty();
        int Size { get; }
    }
}
