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
        int matrixSize = int.Parse(Console.ReadLine());
        int[,] poleMatrix = new int[matrixSize, matrixSize];

        for (int row = 0; row < matrixSize; row++)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < matrixSize; col++)
            {
                poleMatrix[row, col] = arr[col];
            }
        }
        string[] inputsBomb = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Queue bombs = new Queue();

        for (int bomb = 0; bomb < inputsBomb.Length; bomb++)
        {
            int[] inputs = inputsBomb[bomb].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = inputs[0];
            int col = inputs[1];
            int bombPower = poleMatrix[row, col];
            if (bombPower <= 0)
            {
                continue;
            }
            BombExplosion(poleMatrix, row, col, bombPower);
        }

        int counterLiveCells = 0;
        int sumLiveCells = 0;
        for (int row = 0; row < poleMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < poleMatrix.GetLongLength(1); col++)
            {
                if (poleMatrix[row, col] > 0)
                {
                    sumLiveCells += poleMatrix[row, col];
                    counterLiveCells++;
                }
            }
        }
        Console.WriteLine($"Alive cells: {counterLiveCells}");
        Console.WriteLine($"Sum: {sumLiveCells}");
        for (int row = 0; row < poleMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < poleMatrix.GetLongLength(1); col++)
            {
                Console.Write(poleMatrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
    static bool IsValidCoordinates(int[,] poleMatrix, int row, int col)
    {
        if (!(row < 0 || row >= poleMatrix.GetLength(0)
            || col < 0 || col >= poleMatrix.GetLength(1)))
        {
            return true;
        }
        return false;
    }
    static void BombExplosion(int[,] poleMatrix, int row, int col, int bombPower)
    {
        if (IsValidCoordinates(poleMatrix, row - 1, col - 1) && poleMatrix[row - 1, col - 1] > 0)
        {
            poleMatrix[row - 1, col - 1] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row - 1, col) && poleMatrix[row - 1, col] > 0)
        {
            poleMatrix[row - 1, col] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row - 1, col + 1) && poleMatrix[row - 1, col + 1] > 0)
        {
            poleMatrix[row - 1, col + 1] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row, col - 1) && poleMatrix[row, col - 1] > 0)
        {
            poleMatrix[row, col - 1] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row, col) && poleMatrix[row, col] > 0)
        {
            poleMatrix[row, col] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row, col + 1) && poleMatrix[row, col + 1] > 0)
        {
            poleMatrix[row, col + 1] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row + 1, col - 1) && poleMatrix[row + 1, col - 1] > 0)
        {
            poleMatrix[row + 1, col - 1] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row + 1, col) && poleMatrix[row + 1, col] > 0)
        {
            poleMatrix[row + 1, col] -= bombPower;
        }
        if (IsValidCoordinates(poleMatrix, row + 1, col + 1) && poleMatrix[row + 1, col + 1] > 0)
        {
            poleMatrix[row + 1, col + 1] -= bombPower;
        }
    }
}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Bombs
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int sizeBattleField = int.Parse(Console.ReadLine());

//            int[,] battleField = new int[sizeBattleField, sizeBattleField];

//            for (int row = 0; row < battleField.GetLength(0); row++)
//            {
//                int[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

//                for (int col = 0; col < battleField.GetLength(1); col++)
//                {
//                    battleField[row, col] = inputs[col];
//                }
//            }

//            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

//            for (int i = 0; i < coordinates.Length; i++)
//            {
//                string[] coordinate = coordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
//                int rowPosition = int.Parse(coordinate[0]);
//                int colPosition = int.Parse(coordinate[1]);
//                int bombValue = battleField[rowPosition, colPosition];

//                if (battleField[rowPosition, colPosition] <= 0)
//                {
//                    continue;
//                }

//                if (IsValidCoordinate(battleField, rowPosition - 1, colPosition - 1))
//                {
//                    if (battleField[rowPosition - 1, colPosition - 1] > 0)
//                    {
//                        battleField[rowPosition - 1, colPosition - 1] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition - 1, colPosition))
//                {
//                    if (battleField[rowPosition - 1, colPosition] > 0)
//                    {
//                        battleField[rowPosition - 1, colPosition] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition - 1, colPosition + 1))
//                {
//                    if (battleField[rowPosition - 1, colPosition + 1] > 0)
//                    {
//                        battleField[rowPosition - 1, colPosition + 1] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition, colPosition - 1))
//                {
//                    if (battleField[rowPosition, colPosition - 1] > 0)
//                    {
//                        battleField[rowPosition, colPosition - 1] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition, colPosition + 1))
//                {
//                    if (battleField[rowPosition, colPosition + 1] > 0)
//                    {
//                        battleField[rowPosition, colPosition + 1] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition + 1, colPosition - 1))
//                {
//                    if (battleField[rowPosition + 1, colPosition - 1] > 0)
//                    {
//                        battleField[rowPosition + 1, colPosition - 1] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition + 1, colPosition))
//                {
//                    if (battleField[rowPosition + 1, colPosition] > 0)
//                    {
//                        battleField[rowPosition + 1, colPosition] -= bombValue;
//                    }
//                }
//                if (IsValidCoordinate(battleField, rowPosition + 1, colPosition + 1))
//                {
//                    if (battleField[rowPosition + 1, colPosition + 1] > 0)
//                    {
//                        battleField[rowPosition + 1, colPosition + 1] -= bombValue;
//                    }
//                }
//                battleField[rowPosition, colPosition] -= bombValue;

//            }
//            int activeBomb = 0;
//            int sumActiveBomb = 0;

//            for (int row = 0; row < battleField.GetLength(0); row++)
//            {
//                for (int col = 0; col < battleField.GetLength(1); col++)
//                {
//                    if (battleField[row, col] > 0)
//                    {
//                        activeBomb++;
//                        sumActiveBomb += battleField[row, col];
//                    }
//                }
//            }

//            Console.WriteLine($"Alive cells: {activeBomb}");
//            Console.WriteLine($"Sum: {sumActiveBomb}");

//            for (int row = 0; row < battleField.GetLength(0); row++)
//            {
//                for (int col = 0; col < battleField.GetLength(1); col++)
//                {
//                    Console.Write(battleField[row, col] + " ");
//                }
//                Console.WriteLine();
//            }

//        }
//        private static bool IsValidCoordinate(int[,] battleField, int rowPosition, int colPosition)
//        {
//            return rowPosition >= 0 && rowPosition < battleField.GetLength(0) && colPosition >= 0 && colPosition < battleField.GetLength(1);
//        }
//    }
//}