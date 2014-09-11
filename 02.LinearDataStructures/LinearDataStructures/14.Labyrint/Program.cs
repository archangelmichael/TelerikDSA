namespace _14.Labyrint
{
    using System;
    using System.IO;
    /*
     * * We are given a labyrinth of size N x N. 
     * Some of its cells are empty (0) and some are full (x). 
     * We can move from an empty cell to another empty cell if they share common wall. 
     * Given a starting position (*) calculate and fill in the array the minimal distance 
     * from this position to any other cell in the array. 
     * Use "u" for all unreachable cells.
     */

    public class Program
    {
        private const string START = "*";

        private const string EMPTY = "0";

        private const string FULL = "x";

        private const string NON = "u";

        private static int startRow = 0;

        private static int startCol = 0;

        private static string[,] labyrinth;

        public static void Main(string[] args)
        {
            ////The Console is set to get data from the zero test
            if (File.Exists("../../test.00.in.txt"))
            {
                Console.SetIn(new StreamReader("../../test.00.in.txt"));
            }

            labyrinth = GetInput();
            Console.WriteLine("Initial state!");
            PrintLabyrint();
            
            FindStart();
            Solve(startRow, startCol, 0);
            FillUnreachableCells();

            Console.WriteLine("\nPopulated state!");
            PrintLabyrint();
        }

        private static string[,] GetInput()
        {
            int labyrintSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[labyrintSize, labyrintSize];
            for (int row = 0; row < labyrintSize; row++)
            {
                string[] inputLine = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < inputLine.Length; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            return matrix;
        }
       
        private static void FindStart()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == START)
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }

        private static void Solve(int row, int col, int step)
        {
            if (row < 0 || col < 0 ||
                row >= labyrinth.GetLength(0) ||
                col >= labyrinth.GetLength(1) ||
                labyrinth[row, col] == FULL)
            {
                return;
            }

            int currValue;

            if (int.TryParse(labyrinth[row, col], out currValue) && currValue < step && currValue > 0)
            {
                return;
            }

            if (int.TryParse(labyrinth[row, col], out currValue) && (currValue == 0 || currValue > step))
            {
                labyrinth[row, col] = step.ToString();
            }

            Solve(row + 1, col, step + 1);
            Solve(row - 1, col, step + 1);
            Solve(row, col + 1, step + 1);
            Solve(row, col - 1, step + 1);
        }

        private static void FillUnreachableCells()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == EMPTY)
                    {
                        labyrinth[row, col] = NON;
                    }
                }
            }
        }

        private static void PrintLabyrint()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write(labyrinth[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
