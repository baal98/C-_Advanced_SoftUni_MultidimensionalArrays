using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquare = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfSquare, sizeOfSquare];
            int[,] mirrorMatrix = new int[sizeOfSquare, sizeOfSquare];
            int sumDiag1 = 0;
            int sumDiag2 = 0;

            for (int row = 0; row < sizeOfSquare; row++)
            {
                List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                List<int> arrMirror = arr.ToList();
                arrMirror.Reverse();

                for (int col = 0; col < sizeOfSquare; col++)
                {
                    matrix[row, col] = arr[col];
                    mirrorMatrix[row, col] = arrMirror[col];
                    if (row == col)
                    {
                        sumDiag1 += matrix[row, col];
                        sumDiag2 += mirrorMatrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumDiag1 - sumDiag2));
        }
    }
}
