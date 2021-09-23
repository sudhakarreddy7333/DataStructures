using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    //cyclic rotate array by 1 element in clockwise
    public class CyclicRotateArray
    {
        public int[] RotateByOne(int[] arr)
        {
           
            if (arr == null)
                return null;

            int lastElement = arr[^1];
            int i = arr.Length - 1;
            for (; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[i] = lastElement;
            return arr;

        }
    }
}
