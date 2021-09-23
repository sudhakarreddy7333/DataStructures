using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAlgorithms.Programs.Arrays
{
    //https://www.youtube.com/watch?v=0jWeUdxrGm4&ab_channel=Errichto
    //O(nlogn)
    public class Sparse
    {   
        int[,] sparseTable; 

        public void InitMinimumRangeQuery(int[] input)
        {
            sparseTable = BuildMinSparseTable(input); 
        }

        public void InitSumQuery(int[] input)
        {
            sparseTable = BuildSumSpareTable(input);
        }

        public int Query(int l, int r)
        {
            int j = GetExponent(l, r);
            int p = r - (1 << j) + 1; // (1 << j  = 2 pow j)
            return Math.Min(sparseTable[l, j], sparseTable[p, j]);
        }

        public int SumQuery(int l, int r)
        {
            int j = GetExponent(l, r);
            int answer = 0;

            //ex : if width (l - r + 1) is 7 then it can be written as 7 = 2 pow 2 + 2 pow 1 + 2 pow 0
            // So calculate sum of Sparse[2,2] + Sparse[6,1] + Sparse[8,0]

            for (; j >= 0; j--)
            {
                int currWidth = l + (1 << j) - 1;
                if (currWidth <= r)
                {
                    answer += sparseTable[l,j];
                    l += 1 << j; 
                }
            }
            return answer;
        }

        private static int GetExponent(int l, int r)
        {
            int width = r - l + 1;
            double pow = Math.Log2(width);
            return (int)Math.Floor(pow);
        }

        private int[,] BuildMinSparseTable(int[] arr)
        {
            int[,] sparse = new int[20,20];
            for (int k = 0; k < arr.Length; k++)
            {
                sparse[k, 0] = arr[k];
            }

            for (int k = 1; (1 << k) <= arr.Length ; k++)
            {
                for (int m = 0; m + (1 << k) - 1 < arr.Length; m++)
                {
                    sparse[m, k] = Math.Min(sparse[m, k - 1], sparse[m + (1 << (k - 1)), k - 1]);
                }
            }

            return sparse;
        }

        private int[,] BuildSumSpareTable(int[] arr)
        {
            int n = arr.Length;
            int[,] sparse = new int[20, 20];

            for (int k = 0; k < n; k++)
            {
                sparse[k, 0] = arr[k];
            }

            for (int k = 1; (1 << k) <= n; k++)
            {
                for (int m = 0; m + (1 << k) - 1 < n; m++)
                {
                    int p = m + (1 << (k - 1));
                    sparse[m, k] = sparse[m, k - 1] + sparse[p, k - 1];
                }
            }

            return sparse;
        }
    }

    //Sparse ms = new Sparse();
    //ms.InitMinimumRangeQuery(new int[] { 7, 2, 3, 9, 5, 10, 3, 1, 18 });
    //    Console.WriteLine(ms.Query(1, 2));
    //    Console.WriteLine(ms.Query(4, 6));
    //    Console.WriteLine(ms.Query(3, 8));
}
