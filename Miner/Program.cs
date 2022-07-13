using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[,] field = new string[fieldSize, fieldSize];

            string[] moveDirections = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }

            int minerStartRowPosition = 0;
            int minerStartColPosition = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == "s")
                    {
                        minerStartRowPosition = row;
                        minerStartColPosition = col;
                    }
                }
            }

            int coalsCount = CalculateCoalsCounts(field);

            for (int i = 0; i < moveDirections.Length; i++)
            {
                string currentDirection = moveDirections[i];

                if (currentDirection == "up" && isInRange(field, minerStartRowPosition - 1, minerStartColPosition))
                {
                    if (field[minerStartRowPosition - 1, minerStartColPosition] == "c")
                    {
                        coalsCount--;
                        field[minerStartRowPosition - 1, minerStartColPosition] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }
                    else if (field[minerStartRowPosition - 1, minerStartColPosition] == "e")
                    {
                        Console.WriteLine($"Game over! ({minerStartRowPosition - 1}, {minerStartColPosition})");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[minerStartRowPosition - 1, minerStartColPosition] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }

                    minerStartRowPosition = minerStartRowPosition - 1;
                }
                if (currentDirection == "down" && isInRange(field, minerStartRowPosition + 1, minerStartColPosition))
                {
                    if (field[minerStartRowPosition + 1, minerStartColPosition] == "c")
                    {
                        coalsCount--;
                        field[minerStartRowPosition + 1, minerStartColPosition] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }
                    else if (field[minerStartRowPosition + 1, minerStartColPosition] == "e")
                    {
                        Console.WriteLine($"Game over! ({minerStartRowPosition + 1}, {minerStartColPosition})");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[minerStartRowPosition + 1, minerStartColPosition] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }

                    minerStartRowPosition += 1;
                }
                if (currentDirection == "right" && isInRange(field, minerStartRowPosition, minerStartColPosition + 1))
                {
                    if (field[minerStartRowPosition, minerStartColPosition + 1] == "c")
                    {
                        coalsCount--;
                        field[minerStartRowPosition, minerStartColPosition + 1] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }
                    else if (field[minerStartRowPosition, minerStartColPosition + 1] == "e")
                    {
                        Console.WriteLine($"Game over! ({minerStartRowPosition}, {minerStartColPosition + 1})");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[minerStartRowPosition, minerStartColPosition + 1] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }

                    minerStartColPosition += 1;
                }
                if (currentDirection == "left" && isInRange(field, minerStartRowPosition, minerStartColPosition - 1))
                {
                    if (field[minerStartRowPosition, minerStartColPosition - 1] == "c")
                    {
                        coalsCount--;
                        field[minerStartRowPosition, minerStartColPosition - 1] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }
                    else if (field[minerStartRowPosition, minerStartColPosition - 1] == "e")
                    {
                        Console.WriteLine($"Game over! ({minerStartRowPosition}, {minerStartColPosition - 1})");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[minerStartRowPosition, minerStartColPosition - 1] = "s";
                        field[minerStartRowPosition, minerStartColPosition] = "*";
                    }

                    minerStartColPosition -= 1;
                }
            }

            if (coalsCount == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerStartRowPosition}, {minerStartColPosition})");
            }
            else
            {
                Console.WriteLine($"{coalsCount} coals left. ({minerStartRowPosition}, {minerStartColPosition})");
            }
        }
        static int CalculateCoalsCounts(string[,] field)
        {
            int coalsCount = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == "c")
                    {
                        coalsCount++;
                    }
                }
            }

            return coalsCount;
        }
        public static bool isInRange(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}