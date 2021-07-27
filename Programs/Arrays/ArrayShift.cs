using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class ArrayShift
    {
        public ArrayADT Reverse(ArrayADT arr)
        {
            if(arr != null && arr.Length > 0)
            {
                for (int i = 0, j=arr.Length -1; i<j; i++, j--)
                {
                    Swap(arr, i, j);
                }
                return arr;
            }
            return null;
        }

        private static void Swap(ArrayADT arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public ArrayADT ShiftLeft(ArrayADT arr)
        {
            if(arr != null && arr.Length > 0)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = 0;
                return arr;
            }
            return null;
        }

        public ArrayADT Merge(ArrayADT a1, ArrayADT a2)
        {
            if(a1 != null && a2 != null)
            {
                int i = 0, j = 0, k = 0;
                ArrayADT mergedArray = new ArrayADT();

                while(i<a1.Length && j<a2.Length)
                {
                    if (a1[i] <= a2[j])
                    {
                        mergedArray[k++] = a1[i++];
                    }
                    else
                    {
                        mergedArray[k++] = a2[j++];
                    }
                }

                while (i < a1.Length)
                {
                    mergedArray[k++] = a1[i++];
                }

                while (j < a2.Length)
                {
                    mergedArray[k++] = a2[j++];
                }

                return mergedArray;
            }
            return null;
        }
    }
}
