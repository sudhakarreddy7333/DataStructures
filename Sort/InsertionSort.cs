using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Sort
{
    public class InsertionSort
    {
        public void RunProgram()
        {
            var sorted = Sort(new int[] { 3, 2, 6, 1, 9, 2 });
            var sorted1 = Sort(new int[] { 1, 1, 1, 1, 1, 1 });
        }

        private int[] Sort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int j = i - 1;
                int element = list[i];

                while (j > -1 && list[j] > element)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j+1] = element;
            }

            return list;
        }

        private void Swap(int v1, int v2, int[] arr)
        {
            int temp = arr[v1];
            arr[v1] = arr[v2];
            arr[v2] = temp;
        }
    }
}
