using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CS
{
    class Program
    {
        static void Main(string[] args)
        {
            //first
            int[] num_line = new int[10] { 2, 5, 12, 39, 1, 25, 10, 244, -33, 3 };
            var res = from item in num_line
                      where item > 0 && item.ToString().Length == 2
                      orderby item
                      select item;
            foreach  (int num in res)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            //second
            int d = 5;
            int[] a = new int[10] { 12, 165, 16, 1, 15, 111, 65, 65, 50, 2 };
            var res2 = (from aa in a
                        where aa > 0 && aa % 10 == d
                        select aa).Distinct();
            foreach (int b in res2)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();
            //third
            string[] str = new string[5] { "ASSAFQ", "FJYHFCGH", "HRSRVASBGOJFG", "AFNMYFBFD", "HGDGBG" };
            var res3 = (from items in str
                        orderby items.Length
                        select items).ThenByDescending(items => items);
            foreach (string c in res3)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
            //fourth
            int k1 = 1;
            int k2 = 4;
            int[] q = new int[15] { 4, -2, 13, 44, -1, 16, 153, -100, 11, 63, 10, 77, 32, -5, -3 };

            var res4 = from items in q
                   where items > 0
                   select items;

            res4 = res4.Skip(k1);
            res4 = res4.Take(k2);
            
            
            
            foreach (int c in res4)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
            int e = res4.Sum();
            Console.WriteLine(e);
            Console.WriteLine();
            //fifth
            int[] arrr = new int[9] { 2, 8, 7, 6, 5, 7, 8, 4, 5 };
            int k = 2;
            var left = from items in arrr
                       where items % 2 == 0
                       select items;
            var right = arrr.Skip(k);
            var res5 = left.Except(right);
            foreach (int m in res5)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine();
        }
    }
}
