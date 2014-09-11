namespace _08.SearchForPossiblePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* TASK 8
     * Modify the above program to check whether a path exists between two cells without finding all possible paths. 
     * Test it over an empty 100 x 100 matrix.
     */

    public class Program
    {
        private static Random generator = new Random();

        private static int[,] matrix;
        private static bool[,] visitedFields;
        private static int size;
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

            var pathExists = FindAllPaths(startRow, startCol, new Stack<Tuple<int, int>>());
            Console.WriteLine("A path {0}.", pathExists ? "exists" : "does not extist");
        }

        private static bool FindAllPaths(int row, int col, Stack<Tuple<int, int>> path)
        {
            path.Push(new Tuple<int, int>(row, col));
            visitedFields[row, col] = true;

            if (row == endRow && col == endCol)
            {
                Console.WriteLine(string.Join(" => ", path.Reverse()));
                return true;
            }
            else
            {
                for (int dir = 0; dir < 4; dir++)
                {
                    int nextRow = row + dRow[dir];
                    int nextCol = col + dCol[dir];
                    if (IsInsideMatrix(nextRow, nextCol) &&
                        matrix[nextRow, nextCol] != taken &&
                        !visitedFields[nextRow, nextCol])
                    {
                        if (FindAllPaths(nextRow, nextCol, path))
                        {
                            return true;
                        }
                    }
                }
            }

            visitedFields[row, col] = false;
            path.Pop();
            return false;
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

