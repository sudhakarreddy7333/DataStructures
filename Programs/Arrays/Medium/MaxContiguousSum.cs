using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays.Medium
{
    //https://www.youtube.com/watch?v=2MmGzdiKR9Y&ab_channel=BackToBackSWE
    public class MaxContiguousSum
    {
        public int Find(int[] nums)
        {
            int globalMax = nums[0];
            int currentMax = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentMax = Math.Max(currentMax + nums[i], nums[i]);
                globalMax = Math.Max(currentMax, globalMax);
            }
            return globalMax;
        }
    }
}
