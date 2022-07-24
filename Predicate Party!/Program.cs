using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var inputs = command.Split();

                Predicate<string> predicate = GetPredicate(inputs[1], inputs[2]);

                if (inputs[0] == "Remove")
                {
                    names.RemoveAll(predicate);
                }
                else if (inputs[0] == "Double")
                {
                    List<string> searchedNames = names.FindAll(predicate);

                    if (searchedNames.Any())
                    {
                        int indexName = names.FindIndex(predicate);
                        names.InsertRange(indexName, searchedNames);
                    }
                }
            }
            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string commandInfo, string param)
        {
            if (commandInfo == "StartsWith")
            {
                return x => x.StartsWith(param);
            }
            else if (commandInfo == "EndsWith")
            {
                return x => x.EndsWith(param);
            }
            else
            {
                int length = int.Parse(param);
                return x => x.Length == length;
            }
        }
    }
}
