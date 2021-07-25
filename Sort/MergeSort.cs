using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Sort
{
    public class MergeSort
    {
        public int[] Sort(int[] unSortedArray)
        {
            int l = 0;
            int h = unSortedArray.Length - 1;
            SortMethod(ref unSortedArray,l, h);
            return unSortedArray;
        }

        private void SortMethod(ref int[] unSortedArray, int left, int right)
        {
            if (left < right) //atleast there are two elements so split
            {
                int mid = (left + right) / 2;
                SortMethod(ref unSortedArray, left, mid); //sort left half of the array
                SortMethod(ref unSortedArray, (mid+1), right); //sort right half of the array
                MergeMethod(ref unSortedArray, left, mid, right); // merge two halves of sorted arrays
            }
        }

        private void MergeMethod(ref int[] unSortedArray, int left, int mid, int right)
        {
            var leftarray = new int[mid - left + 1];
            var rightarray = new int[right - mid];

            TwoWayMergeSort(unSortedArray, left, mid, leftarray, rightarray);
        }

        private static void TwoWayMergeSort(int[] unSortedArray, int left, int mid, int[] leftarray, int[] rightarray)
        {
            int n1 = leftarray.Length;
            int n2 = rightarray.Length;
            for (int g = 0; g < n1; g++)
            {
                leftarray[g] = unSortedArray[left + g];
            }

            for (int q = 0; q < n2; q++)
            {
                rightarray[q] = unSortedArray[mid + q + 1];
            }

            var k = left;
            int i = 0, j = 0;
            while (i < n1 && j < n2)
            {
                if (leftarray[i] <= rightarray[j])
                {
                    unSortedArray[k++] = leftarray[i++];
                }
                else
                {
                    unSortedArray[k++] = rightarray[j++];
                }
            }

            //If left array contains more elements then add left over elements after sorting into destination array
            for (; i < n1; i++)
            {
                unSortedArray[k++] = leftarray[i];
            }

            //If right array contains more elements then add left over elements after sorting into destination array
            for (; j < n2; j++)
            {
                unSortedArray[k++] = rightarray[j];
            }
        }
    }
}
