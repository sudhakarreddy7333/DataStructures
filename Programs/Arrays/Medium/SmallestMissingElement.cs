using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays.Medium
{
    public class SmallestMissingElement
    {
        public int Find(int[] arr)
        {
            return BinSearch(arr, 0, arr.Length - 1);
        }


        private int BinSearch(int[] arr, int l, int h)
        {
            if(l > h)
            {
                return h + 1;
            }

            if (l != arr[l])
                return l;

            int mid = (l + h) / 2;
            if (arr[mid] == mid)
                return BinSearch(arr, mid + 1, h);

            if (arr[mid] > mid)
            {
                h = mid - 1;
            }

            return BinSearch(arr, l, h);
        }
    }
}
