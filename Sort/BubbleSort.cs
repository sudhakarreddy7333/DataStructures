using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Sort
{
    public class BubbleSort
    {
        private int[] Sort(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++) //passes  (n-1)
            {
                for (int j = 0 ; j < list.Length - 1 - i; j++) //comparisions (n - 1 - skip already sorted comparisons)
                {
                    if(list[j] > list[j + 1])
                    {
                        Swap(j, j+1, list);
                    }
                }
            }
            return list;
        }

        private void Swap(int v1, int v2, int[] arr)
        {
            int temp = arr[v1];
            arr[v1] = arr[v2];
            arr[v2] = temp;
        }

        public void RunProgram()
        {
           var sorted =  Sort(new int[] { 3, 2, 6, 1, 9, 2 });
            var sorted1 = Sort(new int[] { 1, 1, 1, 1, 1, 1 });
        }

    }
}
