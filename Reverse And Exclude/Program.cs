using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ').Select(int.Parse).Reverse();
            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> predicate = x => x % divisor != 0;

            inputs = inputs.Where(x => predicate(x));

            Console.WriteLine(String.Join(" ", inputs));

            //Here is using Func<int, bool>
            //Func<int, bool> predicate1 = x => x % divisor != 0;
            //inputs = inputs.Where(predicate1);
            //Console.WriteLine(String.Join(" ", inputs));
        }
    }
}
