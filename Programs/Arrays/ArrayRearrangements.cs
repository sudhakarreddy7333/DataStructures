using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class ArrayRearrangements
    {
        //Rearrange a[i] = i;
        public int[] Problem1(int[] arr)
        {
            int i = 0;
            while(i<arr.Length)
            {
                if(arr[i] != i && arr[i] >= 0)
                {
                    int temp = arr[i];
                    arr[i] = arr[temp];
                    arr[temp] = temp;
                }
                else
                {
                    i++;
                }
            }
            return arr;
        }

        //https://www.geeksforgeeks.org/rearrange-array-arri-arrj-even-arri/
        public int[] Problem2(int[] arr)
        {
            Array.Sort(arr);
            int length = arr.Length;
            
            int[] result = new int[length];

            int evenPos = length / 2;
            int oddPos = length - evenPos;
            
            for (int i = oddPos - 1, j = 0; i >= 0 && j < length; j += 2, i--)
            {
                result[j] = arr[i];
            }

            for (int i = oddPos, j = 1; i < length && j < length; j += 2, i++)
            {
                result[j] = arr[i];
            }

            return result;
        }

        //O(n)
        public int[] RearrangePosAndNegAlternate(int[] arr)
        {
            int k = 0;
            //Negative numbers are moved to left
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    int temp = arr[k];
                    arr[k] = arr[i];
                    arr[i] = temp;
                    k++;
                }
            }

            //positive numbers start index
            int pos = k;

            for (int i = 0; i < arr.Length && pos < arr.Length && i < pos; i+=2)
            {
                if(arr[i] < 0)
                {
                    int temp = arr[i];
                    arr[i] = arr[pos];
                    arr[pos++] = temp;
                }
            }

            return arr;
        }

        public int[] ZeroesToRight(int[] arr)
        {
            int nonZeroCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != 0)
                arr[nonZeroCount++] = arr[i];
            }

            while(nonZeroCount < arr.Length)
            {
                arr[nonZeroCount++] = 0;
            }

            return arr;
        }


        public int[] ZeroesToRightSingleTraverse(int[] arr)
        {
            if(arr!= null)
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if(arr[i] != 0)
                    {
                        int temp = arr[count];
                        arr[count++] = arr[i];
                        arr[i] = temp;
                    }
                }

                return arr;
            }
            return null;
        }

        //https://www.geeksforgeeks.org/minimum-swaps-required-bring-elements-less-equal-k-together/
        public int MinimumSwaps(int[] arr, int k)
        {
            int j = arr.Length - 1;
            int i = 0;
            int swaps = 0;
            while(i < j)
            {
                if(arr[i] < k)
                {
                    i++;
                }

                if(arr[j] > k)
                {
                    j--;
                }

                if(arr[i] >= k && arr[j] <= k)
                {
                    swaps++;
                    int temp = arr[i];
                    arr[i++] = arr[j];
                    arr[j--] = temp;
                }
            }

            return swaps;
        }


        public int[] RearrangePosNegOrder(int[] arr)
        {
            int j = arr.Length - 1;
            while (j >= 0)
            {
                if (arr[j] >= 0)
                {
                    LeftRotateByOne(arr, j);
                }
                j--;
            }
            int neg = GetNegativeElementsCount(arr);
            int k = arr.Length - 1;
            Reverse(arr, neg, k);
            return arr;
        }

        private static void LeftRotateByOne(int[] arr, int j)
        {
            int temp = arr[j];
            int i = j;
            while (i < arr.Length - 1)
            {
                arr[i] = arr[i + 1];
                i++;
            }
            arr[i] = temp;
        }

        private static int GetNegativeElementsCount(int[] arr)
        {
            int neg = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < 0)
                    neg++;
            }

            return neg;
        }

        private static void Reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int temp = arr[start];
                arr[start++] = arr[end];
                arr[end--] = temp;
            }
        }

        public int[] ArrangeEvenPosGreaterThanOdd(int[] arr)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                //even
                if (i % 2 == 0 && arr[i] <= arr[i - 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
                else if(i % 2 == 1 && arr[i] >= arr[i - 1])
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }

        //https://www.geeksforgeeks.org/double-first-element-move-zero-end/
        public int[] DoubleFirstMoveZeroesEnd(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if(arr[i + 1] != 0 && arr[i] != 0)
                {
                    arr[i] = 2 * arr[i];
                    arr[i + 1] = 0;
                }
            }

            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != 0)
                {
                    int temp = arr[i];
                    arr[i] = arr[count];
                    arr[count++] = temp;
                }
            }

            

            return arr;
        }

        //https://www.geeksforgeeks.org/reorder-a-array-according-to-given-indexes/
        public void ArrangeArraysIndex(int[] arr, int[] index)
        {
            if (arr.Length == index.Length)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if(i != index[i])
                    {
                        int tempEle = arr[i];
                        arr[i] = arr[index[i]];
                        arr[index[i]] = tempEle;

                        int tempIndex = index[i];
                        index[i] = index[tempIndex];
                        index[tempIndex] = tempIndex;
                    }
                }

                Console.WriteLine("Elements");
                foreach (var item in arr)
                {

                    Console.Write(item+", ");
                }
                Console.WriteLine("");
                Console.WriteLine("Index");
                foreach (var item in index)
                {
                    Console.Write(item +", ");
                }
            }
        }

        //https://www.geeksforgeeks.org/rearrange-array-arrj-becomes-arri-j/
        public int[] ArrangeArrays(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {

                // retrieving old value and
                // storing with the new one
                arr[arr[i] % n] = arr[arr[i] % n] +  i * n;
            }

            for (int i = 0; i < n; i++)
            {

                // retrieving new value
                arr[i] = arr[i] / n;
            }

            return arr;
        }

        //https://www.geeksforgeeks.org/rearrange-array-maximum-minimum-form-set-2-o1-extra-space/
        public int[] MaxMinNoExtraSpace(int[] arr)
        {
            int max = arr.Length - 1;
            int length = arr[^1] + 1;
            int min = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    //after below operation arr[min] = arr[i] + arr[max] * length. So to get previous value perform arr[min] = arr[i] % length
                    arr[i] = arr[i] + (arr[max--] % length) * length;
                }
          
                else if (i % 2 == 1)
                {
                    //after below operation arr[max] = arr[i] + arr[min] * length. So to get previous value perform arr[max] = arr[i] % length
                    arr[i] = arr[i] + (arr[min++] % length) * length;                 
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] / length;
            }

            return arr;
        }

        //https://www.geeksforgeeks.org/positive-elements-at-even-and-negative-at-odd-positions-relative-order-not-maintained/
        public int[] PosEvenNegOdd(int[] arr)
        {
            int pos = 0;
            int neg = 1;

            while(true)
            {
                while (pos < arr.Length && arr[pos] >= 0) pos += 2;
                while (neg < arr.Length && arr[neg] <= 0) neg += 2;

                if (pos < arr.Length - 1 && neg < arr.Length - 1)
                {
                    int temp = arr[pos];
                    arr[pos] = arr[neg];
                    arr[neg] = temp;
                }
                else
                {
                    break;
                }
            }
            return arr;
        }


        public int[] ShuffleArray(int[] arr)
        {
            Random r = new Random(); 
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = r.Next(i + 1, arr.Length - 1);
                int temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }
    }
}
