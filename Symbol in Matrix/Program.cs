using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            char[,] matrix = new char[input, input];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string chars = Console.ReadLine();
                for (int col = 0; col < chars.Length; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            char searchedChar = Convert.ToChar(Console.ReadLine());
            bool isFound = false;
            int rowPosition = 0;
            int colPosition = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (searchedChar == matrix[row, col])
                    {
                        rowPosition = row;
                        colPosition = col;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine($"({rowPosition}, {colPosition})");
            }
            else
            {
                Console.WriteLine($"{searchedChar} does not occur in the matrix");
            }
        }
    }
}
