using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lairSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = lairSize[0];
            int cols = lairSize[1];

            int playerRow = 0;
            int playerCol = 0;

            char[,] lair = new char[rows, cols];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = input[col];
                    if (lair[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string directions = Console.ReadLine();

            bool isWinner = false;
            bool isDead = false;

            foreach (var direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    case 'U':
                        nextRow = -1;
                        break;
                    case 'D':
                        nextRow = 1;
                        break;
                    case 'L':
                        nextCol = -1;
                        break;
                    case 'R':
                        nextCol = 1;
                        break;
                }

                lair[playerRow, playerCol] = '.';

                if (!isInRange(lair, playerRow + nextRow, playerCol + nextCol))
                {
                    isWinner = true;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;
                }

                if (lair[playerRow, playerCol] == 'B')
                {
                    isDead = true;
                }
                else if (!isWinner)
                {
                    lair[playerRow, playerCol] = 'P';
                }

                List<int[]> bunnies = new List<int[]>();

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            bunnies.Add(new int[] { row, col });
                        }
                    }
                }

                foreach (var bugsBunny in bunnies)
                {
                    int bunnyRow = bugsBunny[0];
                    int bunnyCol = bugsBunny[1];
                    //Up
                    if (isInRange(lair, bunnyRow - 1, bunnyCol))
                    {
                        if (lair[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }

                        lair[bunnyRow - 1, bunnyCol] = 'B';
                    }
                    //Down
                    if (isInRange(lair, bunnyRow + 1, bunnyCol))
                    {
                        if (lair[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }

                        lair[bunnyRow + 1, bunnyCol] = 'B';
                    }

                    //Left
                    if (isInRange(lair, bunnyRow, bunnyCol - 1))
                    {
                        if (lair[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isDead = true;
                        }

                        lair[bunnyRow, bunnyCol - 1] = 'B';
                    }
                    //Rigth
                    if (isInRange(lair, bunnyRow, bunnyCol + 1))
                    {
                        if (lair[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isDead = true;
                        }

                        lair[bunnyRow, bunnyCol + 1] = 'B';
                    }
                }


                if (isDead || isWinner)
                {
                    for (int row = 0; row < lair.GetLength(0); row++)
                    {
                        for (int col = 0; col < lair.GetLength(1); col++)
                        {
                            Console.Write($"{lair[row, col]}");
                        }

                        Console.WriteLine();
                    }
                }


                if (isDead)
                {
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
                else if (isWinner)
                {
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
            }
        }
        private static bool isInRange(char[,] lair, int row, int col)
        {
            return row >= 0 && row < lair.GetLength(0) && col >= 0 && col < lair.GetLength(1);
        }

    }
}