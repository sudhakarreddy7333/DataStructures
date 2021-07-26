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

        //public ArrayADT InsertInSortedArray(ArrayADT arr)
        //{

        //}
    }
}
