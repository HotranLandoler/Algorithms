using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// 左倾红黑树
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class LeftRBT<Key, Value> : BST<Key, Value>
        where Key : IComparable<Key>
    {
        protected override Node Put(Node? x, Key key, Value val)
        {
            if (x == null) return new Node(key, val, LinkColor.Red);

            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Put(x.Left, key, val);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, val);
            else
                x.Value = val;

            //左倾
            if (IsRed(x.Right) && !IsRed(x.Left)) x = RotateLeft(x);
            //平衡4-node
            if (IsRed(x.Left) && IsRed(x.Left?.Left)) x = RotateRight(x);
            //拆分4-node
            if (IsRed(x.Left) && IsRed(x.Right)) FlipColor(x);

            UpdateCount(x);

            return x;
        }

        private bool IsRed(Node? node)
        {
            return node != null && node.Color == LinkColor.Red;
        }

        private Node RotateLeft(Node h)
        {
            Assert.IsTrue(IsRed(h.Right));

            Node x = h.Right!;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = LinkColor.Red;
            return x;
        }

        //使左倾的红色连接暂时右倾
        private Node RotateRight(Node h)
        {
            Assert.IsTrue(IsRed(h.Left));

            Node x = h.Left!;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = LinkColor.Red;
            return x;
        }

        //改变颜色来拆分临时的4-node
        //BUG
        private void FlipColor(Node h)
        {
            Assert.IsFalse(IsRed(h));
            Assert.IsTrue(IsRed(h.Left));
            Assert.IsTrue(IsRed(h.Right));

            h.Color = LinkColor.Red;
            h.Left!.Color = LinkColor.Black;
            h.Right!.Color = LinkColor.Black;
        }
    }
}
