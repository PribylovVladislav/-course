using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practice8._6
{
    internal class ListMethods
    {
        public void ListFill(List<int> range, Random rng)
        {
            for (int i = 0; i < 100; i++)
            {
                range.Add(rng.Next(0, 101));
            }
        }

        public void ListPrint(List<int> range)
        {
            foreach(int element in range)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine("\n");
        }
        
        public void ListRemove(List<int> range)
        {
            range.RemoveAll(element => ((element > 25) && (element < 50)));
        }
    }
}
