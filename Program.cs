using DSAlgorithms.Programs.Arrays;
using DSAlgorithms.Programs.LinkedList;
using DSAlgorithms.Programs.Recursion;
using DSAlgorithms.Sort;
using System;
using System.Collections.Generic;

namespace DSAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayADT adt = new ArrayADT();
            adt.Add(2);
            adt.Add(4);
            adt.Add(7);
            adt.Add(8);
            adt.Add(10);

            var mergedArray = new ArrayProblems().MultipleMissingElementsHash(adt);
        }

        private static void HeapSort()
        {
            HeapSort hs = new HeapSort();
            int k = 10;
            int[] arr = new int[k];

            var rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
            }

            hs.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static void Mergesort()
        {
            MergeSort ms = new MergeSort();

            int[] arr = new int[1000000];

            var rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1000000);
            }

            Console.WriteLine("Time before sort" + DateTime.Now);
            ms.Sort(arr);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            Console.WriteLine("Time after sort" + DateTime.Now);
            Console.ReadKey();
        }

        private static void NewMethod()
        {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            for (int i = 1; i <= 55; i++)
            {
                //doublyLinkedList.AddTail(i);
                doublyLinkedList.AddHead(i);
            }

            //Console.WriteLine(doublyLinkedList.Find(3).Value);
            //Console.WriteLine(doublyLinkedList.Find(4).Value);
            //doublyLinkedList.GetAll();
            doublyLinkedList.Remove(31);
            doublyLinkedList.Remove(3);
            doublyLinkedList.Remove(4);
            doublyLinkedList.Remove(23);
            doublyLinkedList.Remove(78);
            doublyLinkedList.GetEnumertator();
            Console.ReadKey();
        }

        public static int Reverse(int x)
        {
            int reversed = 0;
            if (x == 0)
                return reversed;

            while (x != 0)
            {
                int remainder = x % 10;
                try
                {
                    reversed = checked(reversed * 10 + remainder);
                    x = x / 10;
                }
                catch(Exception e)
                {
                    return 0;
                }
            }


            return reversed;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> keyVal = new Dictionary<int, int>();
            var res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int el = target - nums[i];
                if (keyVal.TryGetValue(el, out int found))
                {
                    if (nums[found] == el)
                    {
                        res[0] = found; res[1] = i;
                        break;
                    }
                }          
                else
                {
                    keyVal.Add(nums[i], i);
                }
            }
            return res;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int max = 0;
            for (int r = 0, l = 0; r < s.Length; r++)
            {
                if (map.ContainsKey(s[r]))
                {                   
                    l = Math.Max(map[s[r]] + 1, l);
                    map[s[r]] = r;
                }
                else
                {
                    map.Add(s[r], r);
                }
                
                max = Math.Max(r - l + 1, max);
            }
            return max;
        }

        
 //Definition for singly-linked list.
         
    }
}
