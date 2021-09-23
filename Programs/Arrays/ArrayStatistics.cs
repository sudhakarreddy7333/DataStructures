using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class ArrayStatistics
    {
        //https://www.geeksforgeeks.org/find-elements-array-least-two-greater-elements/
        public void PrintElementsGreaterThan2(int[] arr)
        {
            int first = 0, second = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > first)
                {
                    second = first;
                    first = arr[i];
                }
                else if(arr[i] > second)
                {
                    second = arr[i];
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < second) Console.Write($"{arr[i]}, ");
            }
        }

        public void PrintMeanMedian(int[] arr)
        {
            Array.Sort(arr);

            float mean = 0;
            float median = arr.Length % 2 == 0 ? (float)(arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2 : (float)arr[arr.Length / 2];
            
            for (int i = 0; i < arr.Length; i++)
            {
                mean += arr[i];
            }
            
            mean = mean / arr.Length;
            Console.WriteLine($"Mean {mean} Median {median}");
        }
    }
}
