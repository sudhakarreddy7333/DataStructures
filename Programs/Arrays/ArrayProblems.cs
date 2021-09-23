using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class ArrayProblems
    {
        public int SingleMissingElement(ArrayADT input)
        {
            if(input != null)
            {
                int diff = input[0];
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i] - i != diff)
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }

        //O(n)
        public ArrayADT MultipleMissingElements(ArrayADT input)
        {
            if(input != null)
            {
                int difference = input[0];
                ArrayADT missingElements = new ArrayADT();
                for (int i = 1; i < input.Length; i++)
                {
                    int newDifference = input[i] - i;
                    if (newDifference != difference)
                    {
                        while(difference < newDifference)
                        {
                            missingElements.Add(difference + i);
                            difference++;
                        }
                    }
                }
                return missingElements;
            }
            return null;
        }

        //O(n) - Preferred over MultipleMissingElements as hashing  executes faster
        public ArrayADT MultipleMissingElementsHash(ArrayADT input)
        {
            if(input != null)
            {
                Dictionary<int, bool> elements = new Dictionary<int, bool>();
                ArrayADT missingElements = new ArrayADT();
                for (int i = 0; i < input.Length; i++)
                {
                    elements[input[i]] = true;
                }

                for (int j = input[0]; j < input[input.Length - 1]; j++)
                {
                    if (elements.ContainsKey(j) == false)
                    {
                        missingElements.Add(j);
                    }
                }
                return missingElements;
            }
            return null;
        }

        public void PrintDuplicatesSorted(ArrayADT input)
        {
            if(input != null)
            {
                int lastDuplicate = 0;
                int duplicates = 0;
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if(input[i] == input[i+1] && (lastDuplicate != input[i] || duplicates == 0))
                    {
                        lastDuplicate = input[i];
                        duplicates++;
                        Console.WriteLine(lastDuplicate);
                    }
                }

                if(duplicates == 0)
                {
                    Console.WriteLine("No duplicates found");
                }
            }
        }

        //O(n) as workdone by while loop inside is negligible also it will update i to j - 1. 
        public void PrintDuplicatesWithCountSorted(ArrayADT input)
        {
            if(input != null)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if(input[i] == input[i+1])
                    {
                        int j = i;
                        while (j < input.Length - 1 && input[j] == input[j + 1]) j++;

                        Console.WriteLine($"Element {input[i]} appeared {j - i + 1} times");
                        i = j - 1;
                    }
                }
            }
        }

        //O(n) for unsorted array using hash table and without hash table it would require O(n pow 2)
        //Another approach is to sort the input array O(nlogn) and find duplicates O(n) so TC = O(nlogn). 
        //If array is unsorted use hash table 
        public void PrintDuplicatesWithCountUnsorted(ArrayADT input)
        {
            //input  { 0,3,2,4,5,3,4,3,0 }
            if (input != null)
            {
                Dictionary<int, int> duplicatesMap = new Dictionary<int, int>();

                //O(n)
                for (int i = 0; i < input.Length; i++)
                {
                    if(duplicatesMap.ContainsKey(input[i]))
                    {
                        duplicatesMap[input[i]] = duplicatesMap[input[i]] + 1;
                    }
                    else
                    {
                        duplicatesMap[input[i]] = 1;
                    }
                }

                //O(n)
                foreach (var item in duplicatesMap)
                {
                    if(item.Value > 1)
                    Console.WriteLine($"Element {item.Key} was duplicated {item.Value} times");
                }
            }
        }

        //Finding a Pair of Elements with sum K
        public void TargetSumUnSorted(ArrayADT input, int target)
        {
            if(input != null)
            {
                Dictionary<int, int> pairsHash = new Dictionary<int, int>();
                for (int i = 0; i < input.Length; i++)
                {
                    if(pairsHash.ContainsKey(target - input[i]))
                    {
                        Console.WriteLine($" Elements index {pairsHash[target - input[i]]} , {i}");
                    }
                    else
                    {
                        pairsHash[input[i]] = i;
                    }
                }
            }
        }

        //O(n) as the array is already sorted and work is done by while loop scanning the entire array
        public void TargetSumSorted(ArrayADT input, int target)
        {
            if(input != null)
            {
                int i = 0, j = input.Length - 1;
                while(i<j)
                {
                    if(input[i] + input[j] == target)
                    {
                        Console.WriteLine($" Element indexes {i++} , {j--}");
                    }
                    else if(input[i] + input[j] > target)
                    {
                        j--;
                    }
                    else if(input[i] + input[j] < target)
                    {
                        i++;
                    }
                }
            }
        }

        //O(n)
        public void MaxMin(ArrayADT input)
        {
            if(input != null)
            {
                int max = input[0], min = input[0];

                for (int i = 0; i < input.Length; i++)
                {
                    //Best case n - 1 comparisions when the list is in decreasing order
                    if(input[i] < min)
                    {
                        min = input[i];
                    }
                    //worst case comparisons 2(n-1) when list is in increasing order
                    else if(input[i] > max)
                    {
                        max = input[i];
                    }
                }

                Console.WriteLine($" Minimun : {min}, Maximun : {max}");
            }
        }
    }
}
