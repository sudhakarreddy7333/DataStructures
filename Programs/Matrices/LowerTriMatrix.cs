using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Matrices
{
    //IMatrix ms = new LowerTriMatrix(4);
    //ms.Insert(1, 1, 2);
    //        ms.Insert(2, 2, 4);
    //        ms.Insert(2, 1, 1);
    //        ms.Insert(3, 1, 5);
    //        ms.Insert(3, 2, 9);
    //        ms.Insert(3, 3, 6);
    //        ms.Insert(4, 1, 6);
    //        ms.Insert(4, 2, 7);
    //        ms.Insert(4, 3, 1);
    //        ms.Insert(4, 4, 1);
    //        ms.Display();
    public class LowerTriMatrix : IMatrix
    {
        private int[] matrix;
        private int dimension;
        public LowerTriMatrix()
        {
            matrix = new int[2];
            dimension = 2;
        }

        public LowerTriMatrix(int dimension)
        {
            this.dimension = dimension;
            int elements = dimension * (dimension + 1) / 2; //there will be n*(n+1)/2 non zero elements
            matrix = new int[elements];
        }
        public void Display()
        {
            for (int i = 1; i <= dimension; i++)
            {
                for (int j = 1; j <= dimension; j++)
                {
                    if (i >= j)
                    {
                        int index = GetIndex(i, j);
                        Console.Write(matrix[index]);
                    } 
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
            if (row >= col && row > 0)
            {
                int index = GetIndex(row, col);
                return matrix[index];
            }
            return 0;
        }

        public void Insert(int row, int col, int value)
        {
            if(row >= col && row > 0)
            {
                int index = GetIndex(row, col);
                matrix[index] = value;
            }
        }

        public void Update(int row, int col, int value)
        {
            if (row >= col && row > 0)
            {
                int index = GetIndex(row, col);
                matrix[index] = value;
            }
        }

        private int GetIndex(int row, int col)
        {
            return (row * (row - 1) / 2) + (col - 1); //row major formula to get index
        }
    }
}
