using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays.RangeQueries
{
    public class RangeAddOperations
    {
        private int[] input;
       
        public void AddConstantTime(ref int[] arr, int l, int r, int value)
        {
            int n = arr.Length;
            if(r < n && l >= 0)
            {
                arr[l] += value;
                if(r != n - 1)
                {
                    arr[r + 1] -= value;
                }
            }

            input = arr;
        }

        public int[] PrintArray()
        {
            for (int i = 1; i < input.Length; i++)
            {
                input[i] = input[i] + input[i - 1];
            }

            return input;
        }
    }
}
