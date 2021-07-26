using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class BinarySearch
    {
        //ArrayADT must be sorted. Prefer iterative over tail recursion to save stack memory
        public int SearchIterative(ArrayADT arrayADT, int key)
        {
            if(arrayADT != null)
            {
                int low = 0;
                int high = arrayADT.Length - 1;
                while(low <= high)
                {
                    int mid = (low + high) / 2;

                    if (arrayADT[mid] == key)
                        return mid;

                    else if (key > arrayADT[mid])
                        low = mid + 1;

                    else
                        high = mid - 1;
                }
            }
            return -1;
        }

        public int SearchRecursive(ArrayADT arrayADT, int key)
        {
            if(arrayADT != null && arrayADT.Length > 0)
            {
                int low = 0;
                int high = arrayADT.Length - 1;
                return SearchRec(arrayADT, low, high, key);
            }
            return -1;
        }

        private int SearchRec(ArrayADT arrayADT, int low, int high, int key)
        {
            if(low <= high)
            {
                int mid = (low + high) / 2;
                if (arrayADT[mid] == key)
                    return mid;
                else if (key > arrayADT[mid])
                    return SearchRec(arrayADT, mid + 1, high, key);
                else
                    return SearchRec(arrayADT, low, mid - 1, key);
            }
            return -1;
        }
    }
}
