using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class ArrayRotations
    {

        //TC O(n), SC O(1) efficient
        //Juggling algorithm
        //left rotate r = k
        //right rotate r = arr.Length - k;
        public int[] RotateJuggling(int[] arr, int r)
        {
            int sets = Gcd(arr.Length, r);
            for (int i = 0; i < sets; i++)
            {
                int j = i;
                int temp = arr[i];
                int d;
                while(true)
                {
                    d = (j + r) % arr.Length;
                    if (d == i)
                        break;

                    arr[j] = arr[d];
                    j = d;
                }

                arr[j] = temp;
            }
            return arr;
        }


        //This operation can also be performed using recursion but the recursion type would be tail recursion. 
        //Any recursion that uses tail recursion can use a loop to achieve the result
        //As recursion uses stack memory 
        //T(n) = T(n/b) + 1=> O(logn) 
        public int Gcd(int num1, int num2)
        {
            while(num2 != 0)
            {
                int c = num1 % num2;
                num1 = num2;
                num2 = c;
            }
            return num1;
        }

        //O(n*n)
        public int[] Rotate(int[] arr, int d)
        {
            while (d > 0)
            {
                int pop = arr[0];
                int i = 0;
                for (; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[i] = pop;
                d--;
            }
            return arr;
        }

        //https://www.geeksforgeeks.org/find-maximum-value-of-sum-iarri-with-only-rotations-on-given-array-allowed/
        public int MaxSumOnlyRotations(int[] arr)
        {
            int ro = 0;
            int arrSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                ro = ro + i*arr[i];
                arrSum = arrSum + arr[i];
            }

            int maxSum = ro;

            for (int j = 1; j < arr.Length; j++)
            {
                ro = ro + arrSum - arr.Length * arr[arr.Length - j];
                if (ro > maxSum)
                    maxSum = ro;
            }

            return maxSum;
        }

        //https://www.geeksforgeeks.org/find-rotation-count-rotated-sorted-array/
        public int GetRotationCount(int[] arr, int low, int high)
        {
            //Case 1 array is already sorted so return low 
            if (arr[low] <= arr[high])
                return low;

            int mid = (low + high) / 2;

            int prev = (mid + arr.Length - 1) % arr.Length;
            int next = (mid + 1) % arr.Length;

            Console.WriteLine($"prev {prev} next {next}");

            //Case 2 if mid element is the least element. Compare previous and next. Previous and next should be higher than mid
            if (arr[mid] < arr[prev] && arr[mid] < arr[next])
                return mid;

            //Case 3 if elements from mid to high are sorted then element lies between low and mid
            if (arr[mid] < high)
                return GetRotationCount(arr, low, mid - 1);

            // Case 4 if elements from low to mid are sorted then element lies between mid and high
            else if (arr[mid] > low)
                return GetRotationCount(arr, mid + 1, high);
            else
                return -1;

        }

        public void PrintLargetElement(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if(arr[i] > arr[i+1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
            Console.WriteLine(arr[^1]);
        }


        public int[] ArrayWave(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i = i+2)
            {
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }

            return arr;
        }

        public int[] RearrangeArrays(int[] arr)
        {
            int[] map = new int[2] { 0, -1 };
            for (int i = 0; i < arr.Length; i++)
            {
                if(i == map[1])
                {
                    map[0] = arr[i];
                    arr[i] = map[0];
                }
                else
                {
                    map[0] = arr[i];
                    arr[i] = arr[arr[i]];
                }
                
                map[1] = i;            
            }

            return arr;
        }
    }
}
