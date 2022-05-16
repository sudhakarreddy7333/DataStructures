using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Sort
{
    public class QuickSort
    {
        private void SortRecursive(int[] list, int start, int end)
        {
            if(start < end)
            {
                int pos = GetPivotPartitionPosition(list, start, end);
                SortRecursive(list, start, pos - 1);
                SortRecursive(list, pos + 1, end);
            }
        }

        private int GetPivotPartitionPosition(int[] list, int start, int end)
        {
            int pivotIndex =  start;

            int i = start;
            int j = end;

            while(i < j)
            {
                while(i < end && list[pivotIndex] >= list[i])
                {
                    i++;
                }

                while (j > start && list[pivotIndex] < list[j])
                {
                    j--;
                }

                if(i < j)
                {
                    Swap(list, i, j);
                }
            }

            Swap(list, j, pivotIndex);

            return j;
        }

        public void RunProgram()
        {
            var list = new int[] { 10, 60, 15, 8, 5, 0 };
            SortRecursive(list, 0, list.Length - 1);

            var list1 = new int[] { 10, 20, 30, 40, 50, 60 };
            SortRecursive(list1, 0, list1.Length - 1);

            var list2 = new int[] { 10, 5};
            SortRecursive(list2, 0, list2.Length - 1);

            Console.WriteLine("Done");
        }

        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
    }
}
