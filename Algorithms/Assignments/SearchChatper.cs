using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Assignments
{
    public class SearchChatper
    {
        public static void SymbolTable()
        {
            BST<string, int> dict = new();
            dict["one"] = 1;
            dict["two"] = 2;
            dict["three"] = 3;
            //Console.WriteLine(dict.Get("two"));
            //Console.WriteLine(dict["one"]);
            foreach (var key in dict.Keys())
            {
                Console.Write(dict[key]);
            }
            Console.WriteLine();
        }
    }
}
