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
    }
}
