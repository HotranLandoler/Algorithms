using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Collections
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private DoubleNode head = new(default);
        private DoubleNode? last = null;

        private int count = 0;

        /// <summary>
        /// 从表尾到表头遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> LastToHead
        {
            get
            {
                DoubleNode? p = last;
                while (p != null && p != head)
                {
                    yield return p.value;
                    p = p.prev;
                }
            }
        }

        public bool IsEmpty() => count == 0;

        /// <summary>
        /// 在表头插入
        /// </summary>
        /// <param name="item"></param>
        public void AddHead(T item)
        {
            var node = new DoubleNode(item);
            InsertAfter(head, node);
            count++;
        }

        private void InsertAfter(DoubleNode after, DoubleNode node)
        {
            if (after.next == null)
            {
                after.next = node;
                node.prev = after;
                last = node;
                return;
            }
            node.next = after.next;
            node.prev = after;
            after.next.prev = node;
            after.next = node;
        }

        /// <summary>
        /// 在表尾添加
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            if (last == null)
            {
                AddHead(item);
                return;
            }
            var node = new DoubleNode(item);
            InsertAfter(last, node);

            last = node;
            count++;
        }

        /// <summary>
        /// 删除开头元素
        /// </summary>
        /// <returns></returns>
        public T? RemoveHead()
        {
            if (head.next == null) return default;
            var node = head.next;
            if (node.next != null)
                node.next.prev = head;
            head.next = node.next;
            count--;
            return node.value;
        }

        /// <summary>
        /// 删除尾部元素
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public T? RemoveLast()
        {
            if (last == null) return default;
            var node = last;
            if (node.prev == null)
                throw new NullReferenceException("last.prev is null");
            node.prev.next = null;
            if (last.prev == head)
                last = null;
            else last = last.prev;
            count--;
            return node.value;
        }

        private void Remove(DoubleNode node)
        {
            if (node == head)
                throw new ArgumentException("Removing list head");
            if (node == last)
                RemoveLast();

            if (node.prev == null)
                throw new NullReferenceException("Prev node is null");
            if (node.next == null)
                throw new NullReferenceException("Next node is null");

            node.prev.next = node.next;
            node.next.prev = node.prev;
            count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleNode? p = head.next;
            while (p != null)
            {
                yield return p.value;
                p = p.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoubleNode
        {
            internal T? value;
            internal DoubleNode? next = null;
            internal DoubleNode? prev = null;

            internal DoubleNode(T? val)
            {
                value = val;
            }
        }
    }
}
