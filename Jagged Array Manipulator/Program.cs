using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] inputs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                matrix[row] = inputs;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                double[] arr = matrix[row];
                double[] arrNext = matrix[row + 1];

                if (arr.Length == arrNext.Length)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        matrix[row][i] *= 2;
                        matrix[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (matrix[row][i] != 1 && matrix[row].Length != 0)
                        {
                            matrix[row][i] /= 2;
                        }
                    }
                    for (int i = 0; i < arrNext.Length; i++)
                    {
                        matrix[row + 1][i] /= 2;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] inputs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputs.Length != 4)
                {
                    continue;
                }
                string action = inputs[0];
                int row = int.Parse(inputs[1]);
                int col = int.Parse(inputs[2]);
                int value = int.Parse(inputs[3]);

                if (action == "Add")
                {
                    if (row < 0 || row >= rows || col < 0 || col >= matrix[row].Length)
                    {
                        continue;
                    }
                    matrix[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    if (row < 0 || row >= rows || col < 0 || col >= matrix[row].Length)
                    {
                        continue;
                    }
                    matrix[row][col] -= value;
                }
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
