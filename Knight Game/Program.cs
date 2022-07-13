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
        int rowCol = int.Parse(Console.ReadLine());

        char[,] matrix = new char[rowCol, rowCol];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] str = Console.ReadLine().ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = str[col];
            }
        }
        int counter = MaxCounterStrike(matrix);

        Console.WriteLine(counter);
    }

    private static int MaxCounterStrike(char[,] matrix)
    {
        int counter = 0;
        while (true)
        {
            int counterMaxStrike = 0;
            int tempCounter = counter;
            int rowPosition = 0;
            int colPosition = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int counterStrike = 0;
                    if (matrix[row, col] == 'K')
                    {
                        counterStrike = isFound(matrix, row, col, counterStrike);
                    }
                    else
                    {
                        continue;
                    }
                    if (counterStrike > counterMaxStrike)
                    {
                        counterMaxStrike = counterStrike;
                        rowPosition = row;
                        colPosition = col;
                    }
                }
            }
            if (counterMaxStrike > 0)
            {
                matrix[rowPosition, colPosition] = '0';
                counter++;
            }

            if (counter == tempCounter)
            {
                break;
            }
        }
        return counter;

    }

    private static bool isValidPosition(char[,] matrix, int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0)
            || col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }
        return true;
    }
    private static int isFound(char[,] matrix, int row, int col, int counterStrike)
    {
        if (isValidPosition(matrix, row - 2, col - 1))
        {
            if (matrix[row - 2, col - 1] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row - 2, col + 1))
        {
            if (matrix[row - 2, col + 1] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row + 2, col - 1))
        {
            if (matrix[row + 2, col - 1] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row + 2, col + 1))
        {
            if (matrix[row + 2, col + 1] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row - 1, col - 2))
        {
            if (matrix[row - 1, col - 2] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row + 1, col - 2))
        {
            if (matrix[row + 1, col - 2] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row - 1, col + 2))
        {
            if (matrix[row - 1, col + 2] == 'K')
            {
                counterStrike++;
            }
        }
        if (isValidPosition(matrix, row + 1, col + 2))
        {
            if (matrix[row + 1, col + 2] == 'K')
            {
                counterStrike++;
            }
        }
        return counterStrike;
    }
}
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Knight_Game
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int sizeOfBoard = int.Parse(Console.ReadLine());

//            char[,] chessBoard = new char[sizeOfBoard, sizeOfBoard];

//            for (int row = 0; row < chessBoard.GetLength(0); row++)
//            {
//                string chars = Console.ReadLine();

//                for (int col = 0; col < chessBoard.GetLength(1); col++)
//                {
//                    chessBoard[row, col] = chars[col];
//                }
//            }

//            int removedChar = 0;
//            int maxCounter = 0;
//            int rowPosition = 0;
//            int colPosition = 0;

//            if (chessBoard.Length > 4)
//            {
//                while (true)
//                {
//                    RemoveKnight(chessBoard, ref maxCounter, ref rowPosition, ref colPosition);
//                    if (maxCounter > 0)
//                    {
//                        maxCounter = 0;
//                        chessBoard[rowPosition, colPosition] = '0';
//                        removedChar++;
//                    }
//                    else
//                    {
//                        break;
//                    }
//                }
//                Console.WriteLine(removedChar);
//            }
//            else
//            {
//                Console.WriteLine(removedChar);
//            }

//        }

//        private static void RemoveKnight(char[,] chessBoard, ref int maxCounter, ref int rowPosition, ref int colPosition)
//        {
//            for (int row = 0; row < chessBoard.GetLength(0); row++)
//            {

//                for (int col = 0; col < chessBoard.GetLength(1); col++)
//                {
//                    int counter = 0;

//                    char currentChar = chessBoard[row, col];

//                    if (currentChar == 'K')
//                    {
//                        if (IsFound(row - 1, col - 2, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row + 1, col - 2, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row - 1, col + 2, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row + 1, col + 2, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row - 2, col - 1, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row - 2, col + 1, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row + 2, col - 1, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (IsFound(row + 2, col + 1, chessBoard))
//                        {
//                            counter++;
//                        }
//                        if (counter > maxCounter)
//                        {
//                            maxCounter = counter;
//                            rowPosition = row;
//                            colPosition = col;
//                        }
//                    }
//                }
//            }
//        }

//        static bool IsFound(int row, int col, char[,] matrix)
//        {
//            char searchedChar = 'K';
//            if (IsValidPosition(row, col, matrix))
//            {
//                if (matrix[row, col] == searchedChar)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//        static bool IsValidPosition(int row, int col, char[,] matrix)
//        {
//            if (col >= matrix.GetLength(1) || col < 0 || row < 0 || row >= matrix.GetLength(0))
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }
//    }
//}