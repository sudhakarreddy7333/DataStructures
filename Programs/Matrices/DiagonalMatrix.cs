using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Matrices
{
    public class DiagonalMatrix : IMatrix
    {
        private int[] matrix;
        public DiagonalMatrix()
        {
            matrix = new int[2];
        }

        public DiagonalMatrix(int dimension)
        {
            matrix = new int[dimension];
        }
        public void Display()
        {
            for (int i = 1; i <= matrix.Length; i++)
            {
                for (int j = 1; j <= matrix.Length; j++)
                {
                    if (i == j)
                        Console.Write(matrix[i - 1]);
                    else
                    {
                        Console.Write(0);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        public int Get(int row, int col)
        {
            if (row == col && row > 0)
            {
                return matrix[row - 1];
            }
            return 0;
        }

        public void Insert(int row, int col, int value)
        {
            if(row == col && row > 0)
            {
                matrix[row - 1] = value;
            }
        }

        public void Update(int row, int col, int value)
        {
            if (row == col && row > 0)
            {
                matrix[row - 1] = value;
            }
        }
    }
}
