using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = inputs[0];
            int cols = inputs[1];
            if (rows < 0 || cols < 0)
            {
                return;
            }
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int maxSum = int.MinValue;
            int rowPos = 0;
            int colPos = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                int sum = 0;

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    if (true)
                    {
                        sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    }

                    if (sum > maxSum)
                    {
                        rowPos = row;
                        colPos = col;
                        maxSum = sum;
                    }
                }

            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowPos; row < rowPos + 3; row++)
            {
                for (int col = colPos; col < colPos + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}