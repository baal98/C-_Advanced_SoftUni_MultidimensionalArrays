using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int[,] matrix = new int[numberOfRows, numberOfRows];

            for (int row = 0; row < numberOfRows; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < numberOfRows; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();
                string action = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0 || row >= numberOfRows || col < 0 || col >= numberOfRows)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (action == "Add")
                {
                    matrix[row, col] += value;
                }
                else
                {
                    matrix[row, col] -= value;
                }

            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfRows; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}