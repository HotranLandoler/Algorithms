using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class BST<Key, Value>
        where Key : IComparable<Key>
    {
        private Node? root;

        public Value? this[Key key]
        {
            get => Get(key);
            set
            {
                if (value != null) Put(key, value);
                else throw new InvalidOperationException();
            }
        }

        //BUG
        public int Size() => Size(root);

        /// <summary>
        /// How many keys < k?
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(Key key) => Rank(key, root);

        public void Put(Key key, Value value)
            => root = Put(root, key, value);

        public Value? Get(Key key)
        {
            Node? p = root;
            while (p != null)
            {
                int compare = key.CompareTo(p.Key);
                if (compare < 0) p = p.Left;
                else if (compare > 0) p = p.Right;
                else return p.Value;
            }
            return default;
        }

        public void DeleteMin() => root = DeleteMin(root);

        public void Delete(Key key) { }

        public IEnumerable<Key> Keys()
        {
            Queue<Key> q = new Queue<Key>();
            Inorder(root, q);
            return q;
        }

        public Key? Floor(Key key)
        {
            Node? x = Floor(root, key);
            return x == null ? default : x.Key;
        }

        protected virtual Node Put(Node? x, Key key, Value val)
        {
            if (x == null) return new Node(key, val);
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Put(x.Left, key, val);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, val);
            else
                x.Value = val;

            UpdateCount(x);

            return x;
        }

        protected void UpdateCount(Node x) => x.Count = 1 + Size(x.Left) + Size(x.Right);

        private int Size(Node? x)
        {
            if (x == null) return 0;
            return x.Count;
        }

        private Node? Floor(Node? x, Key key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.Left, key);

            Node? t = Floor(x.Right, key);
            return t ?? x;
        }

        private int Rank(Key key, Node? x)
        {
            if (x == null) return 0;

            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) return Rank(key, x.Left);
            else if (cmp > 0) return 1 + Size(x.Left) + Rank(key, x.Right);
            else return Size(x.Left);
        }

        //中序遍历
        private void Inorder(Node? x, Queue<Key> q)
        {
            if (x == null) return;

            Inorder(x.Left, q);
            q.Enqueue(x.Key);
            Inorder(x.Right, q);
        }

        private Node? DeleteMin(Node? x)
        {
            if (x == null) return null;
            if (x.Left == null) return x.Right;
            x.Left = DeleteMin(x.Left);
            UpdateCount(x);
            return x;
        }

        private Node? Delete(Node? x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) x.Left = Delete(x.Left, key);
            else if (cmp > 0) x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null) return x.Left;
                if (x.Left == null) return x.Right;

                Node t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            UpdateCount(x);
            return x;
        }

        private Node Min(Node x)
        {
            //if (x == null) return null;

            Node p = x;
            while (p.Left != null)
            {
                p = p.Left;
            }
            return p;
        }

        protected class Node
        {
            public Key Key { get; }
            public Value Value { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            /// <summary>
            /// Number of nodes in subtree
            /// </summary>
            public int Count { get; set; }

            /// <summary>
            /// Color of parent link
            /// </summary>
            public LinkColor Color { get; set; }

            public Node(Key key, Value val, LinkColor color = LinkColor.Black)
            {
                this.Key = key;
                this.Value = val;
                this.Color = color;
            }
        }

        protected enum LinkColor
        {
            Black,
            Red
        }
    }
}
