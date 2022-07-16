using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string snake = Console.ReadLine();
            Queue<char> stack = new Queue<char>();

            foreach (char c in snake)
            {
                stack.Enqueue(c);
            }

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char ch = stack.Peek();
                        matrix[row, col] = ch;
                        stack.Enqueue(stack.Dequeue());
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        char ch = stack.Peek();
                        matrix[row, col] = ch;
                        stack.Enqueue(stack.Dequeue());
                    }
                }

            }
            PrintMatrixString(matrix);
        }

        private static void PrintMatrixString(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}