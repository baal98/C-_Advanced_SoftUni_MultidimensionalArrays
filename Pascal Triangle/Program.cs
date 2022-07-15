using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        long[][] jaggedArr = new long[input][];

        jaggedArr[0] = new long[1] { 1 };

        for (int row = 1; row < input; row++)
        {
            jaggedArr[row] = new long[row + 1];
            jaggedArr[row][0] = 1;
            jaggedArr[row][row] = 1;
            for (int col = 1; col < row; col++)
            {
                jaggedArr[row][col] = jaggedArr[row - 1][col - 1] + jaggedArr[row - 1][col];
            }
        }
        foreach (long[] row in jaggedArr)
        {
            Console.Write(string.Join(" ", row));
            Console.WriteLine();
        }
    }
}
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Pascal_Triangle
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int numberOfRows = int.Parse(Console.ReadLine());

//            long[][] matrix = new long[numberOfRows][];

//            for (int i = 0; i < numberOfRows; i++)
//            {
//                long[] arr = new long[i + 1];
//                arr[0] = 1;
//                arr[arr.Length - 1] = 1;
//                matrix[i] = arr;
//                for (int col = 1; col < arr.Length - 1; col++)
//                {
//                    matrix[i][col] = (matrix[i - 1][col - 1]) + (matrix[i - 1][col]);
//                }
//            }

//            for (int row = 0; row < numberOfRows; row++)
//            {
//                Console.WriteLine(String.Join(" ", matrix[row]));
//            }
//        }
//    }
//}
