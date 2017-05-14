using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTwoCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //first
            int[] num_line = new int[10] { 2, 5, -2, 9, 11, -14, -12, 12, 55, -3};
            int positive = num_line.First(p => p > 0);
            int negative = num_line.Last(p => p < 0);
            Console.WriteLine(positive + " " + negative);
            //second
            int L = 6;
            string[] A = new string[5] { "zxcdsaq", "asd32asd", "2wwera", "vcasdf", "3wwera" };
            int t;
            var res = Convert.ToString(A.LastOrDefault(s => s.Length == L && int.TryParse(s.Substring(0, 1), out t) == true) ?? "Not found");
            Console.WriteLine(res);
            //third
            char C = '4';
            string[] str_line = new string[3] { "4asd4", "asdd", "4sddd4"};
            var res2 = Convert.ToString(str_line.Count(s => s.Length > 1 && s.Substring(0, 1) == C.ToString() && s.Substring(s.Length - 1, 1) == C.ToString()));
            Console.WriteLine(res2);
            //fourth
            int sum= 0;
            sum = str_line.Sum(s => s.Length);
            Console.WriteLine(sum);
        }
    }
}
