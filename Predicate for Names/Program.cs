using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string, bool> func = x => x.Length <= nameLength;

            Console.WriteLine(string.Join("\n", names.Where(func)));
        }
    }
}
