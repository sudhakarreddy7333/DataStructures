using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class SetOperations
    {
        public ArrayADT Union(ArrayADT first, ArrayADT second)
        {
            if(first != null && second != null)
            {
                int i = 0, j = 0, k = 0;
                ArrayADT unionArray = new ArrayADT();

                while(i<first.Length && j<second.Length)
                {
                    if (first[i] < second[j])
                    {
                        unionArray[k++] = first[i++];
                    }
                    else if (first[i] > second[j])
                    {
                        unionArray[k++] = second[j++];
                    }
                    else if (first[i] == second[j])
                    {
                        int eq = first[i++];
                        unionArray[k++] = eq;
                        j++;
                    }
                }
                

                //add remaining elements of a1
                while(i<first.Length)
                {
                    unionArray[k++] = first[i++];
                }

                //add remaining elements of a2
                while (j<second.Length)
                {
                    unionArray[k++] = second[j++];
                }

                return unionArray;
            }
            return null;
        }

        public ArrayADT Intersection(ArrayADT first, ArrayADT second)
        {
            if (first != null && second != null)
            {
                int i = 0, j = 0, k = 0;
                ArrayADT unionArray = new ArrayADT();

                while (i < first.Length && j < second.Length)
                {
                    if (first[i] < second[j])
                    {
                        i++;
                    }
                    else if (first[i] > second[j])
                    {
                        j++;
                    }
                    else if(first[i] == second[j])
                    {
                        int eq = first[i++];
                        unionArray[k++] = eq;
                        j++;
                    }
                }
                return unionArray;
            }
            return null;
        }


        public ArrayADT Difference(ArrayADT first, ArrayADT second)
        {
            if(first != null && second != null)
            {
                int i = 0, j = 0, k = 0;
                ArrayADT diffArray = new ArrayADT();
                while(i<first.Length && j < second.Length)
                {
                    if (first[i] < second[j])
                    {
                        diffArray[k++] = first[i++];
                    }
                    else if (second[j] < first[i])
                    {
                        j++;
                    }
                    else if (first[i] == second[j])
                    {
                        i++;
                        j++;
                    }
                }
                

                //add remaining elements of a1
                while (i < first.Length)
                {
                    diffArray[k++] = first[i++];
                }
                return diffArray;
            }
            return null;
        }
    }
}
