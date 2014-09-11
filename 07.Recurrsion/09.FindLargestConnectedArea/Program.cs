namespace _09.FindLargestConnectedArea
{
    using System;

    /* TASK 9
     * Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
     */

    public class Program
    {
        private static Random generator = new Random();

        private static int[,] matrix;
        private static bool[,] visitedFields;
        private static int size;
        private static int[] dRow = { 1, -1, 0, 0 };
        private static int[] dCol = { 0, 0, 1, -1 };

        private static int empty = 0;
        private static int taken = 1;

        public static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter matrix size: ");
                size = int.Parse(Console.ReadLine());
            } while (size <= 1);

            GenerateMatrix();

            int maxCount = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] != taken && !visitedFields[row, col])
                    {
                        int count = FindConnectedArea(row, col);
                        maxCount = Math.Max(maxCount, count);
                    }
                }
            }

            Console.WriteLine("Largest area: {0} cells.", maxCount);
        }

        private static int FindConnectedArea(int row, int col)
        {
            visitedFields[row, col] = true;
            int count = 1;
            for (int dir = 0; dir < 4; dir++)
            {
                int nextRow = row + dRow[dir];
                int nextCol = col + dCol[dir];
                if (IsInsideMatrix(nextRow, nextCol) &&
                    matrix[nextRow, nextCol] != taken &&
                    !visitedFields[nextRow, nextCol])
                {
                    count += FindConnectedArea(nextRow, nextCol);
                }
            }

            return count;
        }

        private static bool IsInsideMatrix(int row, int col)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        private static void GenerateMatrix()
        {
            matrix = new int[size, size];
            visitedFields = new bool[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    visitedFields[row, col] = false;
                    matrix[row, col] = generator.Next(0, 10) > 3 ? empty : taken;
                    Console.Write(string.Format(" {0} ", matrix[row, col]));
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}