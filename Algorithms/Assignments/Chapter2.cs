using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Collections;

namespace Algorithms.Assignments
{
    public class Chapter2
    {
        public static void Practice1_3_1()
        {
            FixedCapacityStack<string> stack = new(3);
            stack.Push("，haha");
            foreach (var item in stack)
                Utils.P(item);

            stack.Push("🐖");
            foreach (var item in stack)
                Utils.P(item);

            stack.Push("你是");

            var copy = SimpleAlgos.Copy<string>(stack);
            copy.Push("%%%%");
            foreach (var item in stack)
                Console.Write(item);
            foreach (var item in copy)
                Console.Write(item);

            //Utils.P(stack.IsFull());
            //while (!stack.IsEmpty())
            //{
            //    Utils.P(stack.Pop());
            //}
            //Utils.P(stack.Pop());
        }

        public static void Practice1_3_4()
        {
            Utils.P(SimpleAlgos.CheckParenthesis("[()]{}{[()()]()}"));
            Utils.P(SimpleAlgos.CheckParenthesis("[(])"));
        }

        public static void Practice1_3_9()
        {
            Utils.P(SimpleAlgos.CompleteBrackets("1+2)*3-4)*5-6)))"));
        }

        public static void Practice1_3_14()
        {
            ResizingArrayQueue<int> queue = new(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            foreach (var item in queue)
            {
                Utils.P(item);
            }
        }

        public static void Practice1_3_31()
        {
            DoubleLinkedList<int> list = new();
            list.AddLast(1);
            list.AddHead(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);

            foreach (var item in list)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            foreach (var item in list.LastToHead)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.Write(list.RemoveHead());
            while (!list.IsEmpty())
                Console.Write(list.RemoveLast());
        }

        public static void Practice1_3_35()
        {
            RandomBag<int> bag = new();
            for (int i = 0; i < 10; i++)
            {
                bag.Add(i);
            }
            Utils.P(bag.GetRandom());
            foreach (var item in bag)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            RandomBag<string> choice = new("睡觉", "继续");
            Utils.P(choice.GetRandom());
        }

        private static void Practice1_5_18()
        {

        }
    }
}
