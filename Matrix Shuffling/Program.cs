using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = InputMatrixString();
            string snake = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputs = command.Split(' ');
                string action = inputs[0];
                if (action != "swap" || inputs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int row1 = int.Parse(inputs[1]);
                int col1 = int.Parse(inputs[2]);
                int row2 = int.Parse(inputs[3]);
                int col2 = int.Parse(inputs[4]);

                if (row1 < 0 || row1 >= matrix.GetLength(0)
                    || col1 < 0 || col1 >= matrix.GetLength(1)
                    || row2 < 0 || row2 >= matrix.GetLength(0)
                    || col2 < 0 || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string tempPosition = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = tempPosition;
                PrintMatrixString(matrix);
            }
        }

        private static void PrintMatrixString(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] InputMatrixInt()
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            if (rows < 0 || cols < 0)
            {
                return;
            }
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
        private static string[,] InputMatrixString()
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            if (rows < 0 || cols < 0)
            {
                return;
            }
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] arr = Console.ReadLine().Split(new string[] {"", " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}
