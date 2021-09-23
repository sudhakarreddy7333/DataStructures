using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays.Sorting
{
    public class SortAbsDifference
    {
        //https://www.geeksforgeeks.org/sort-an-array-according-to-absolute-difference-with-given-value/
        //O(nlogn)
        public int[] Sort(int[] arr, int k)
        {
            SortedDictionary<int, List<int>> sortedDic = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                int diff = Math.Abs(arr[i] - k);
                if (sortedDic.ContainsKey(diff))
                {
                    List<int> currElements = sortedDic[diff];
                    currElements.Add(arr[i]);
                    sortedDic[diff] = currElements;
                }
                else
                {
                    List<int> newElements = new List<int>();
                    newElements.Add(arr[i]);
                    sortedDic.Add(diff, newElements);
                }
            }

            int index = 0;

            foreach (var item in sortedDic.Keys)
            {
                List<int> elements = sortedDic[item]; 
                for (int i = 0; i < elements.Count; i++)
                {
                    arr[index++] = elements[i];
                }
            }
            return arr;
        }
    }
}
