namespace _07.FindPathsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* TASK 7
     * We are given a matrix of passable and non-passable cells. 
     * Write a recursive program for finding all paths between two cells in the matrix.
     */ 

    public class Program
    {
        private static Random generator = new Random();

        private static int[,] matrix;
        private static bool[,] visitedFields;
        private static int size;
        private static int count = 0;
        private static int[] dRow = { 1, -1, 0, 0 };
        private static int[] dCol = { 0, 0, 1, -1 };

        private static int startRow = 0;
        private static int startCol = 0;
        private static int endRow = 0;
        private static int endCol = 0;

        private static int empty = 0;
        private static int taken = 1;
        private static int start = 5;
        private static int end = 7;

        public static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter matrix size: ");
                size = int.Parse(Console.ReadLine());
            } while (size <= 1);

            GenerateMatrix(); 
            
            FindAllPaths(startRow, startCol, new Stack<Tuple<int, int>>());
            Console.WriteLine("There are {0} paths between the start and end cell.", count);
        }

        private static void FindAllPaths(int row, int col, Stack<Tuple<int, int>> path)
        {
            path.Push(new Tuple<int, int>(row, col));
            visitedFields[row, col] = true;

            if (row == endRow && col == endCol)
            {
                Console.WriteLine(string.Join(string.Empty, path.Reverse()));
                count++;
            }
            else
            {
                for (int dir = 0; dir < 4; dir++)
                {
                    int nextRow = row + dRow[dir];
                    int nextCol = col + dCol[dir];
                    if (IsInsideMatrix(nextRow, nextCol) &&
                        matrix[nextRow,nextCol] != taken &&
                        !visitedFields[nextRow, nextCol])
                    {
                        FindAllPaths(nextRow, nextCol, path);
                    }
                }
            }

            visitedFields[row, col] = false;
            path.Pop();
        }

        private static bool IsInsideMatrix(int row, int col)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        private static void GenerateMatrix()
        {
            matrix = new int[size, size];
            visitedFields = new bool[size, size];
            GenerateStartAndEnd();
            PopulateRest();
        }

        private static void PopulateRest()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    visitedFields[row, col] = false;
                    if (matrix[row, col] != start && matrix[row, col] != end)
                    {
                        //// Implement 20 % chance for filling with empty cells
                        matrix[row, col] = generator.Next(0, 10) > 2 ? empty : taken;
                    }

                    Console.Write(string.Format(" {0} ", matrix[row, col]));
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void GenerateStartAndEnd()
        {
            do
            {
                startRow = GetNumber(0, size - 1);
                startCol = GetNumber(0, size - 1);
                endRow = GetNumber(0, size - 1);
                endCol = GetNumber(0, size - 1);
            } while (startRow == endRow && startCol == endCol);

            matrix[startRow, startCol] = start;
            matrix[endRow, endCol] = end;
            Console.WriteLine(matrix[startRow, startCol]);
        }

        private static int GetNumber(int min, int max)
        {
            return generator.Next(min, max);
        }
    }
}
