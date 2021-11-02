using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Strings
{
    public class MaxProductOfWordLengths
    {
        //Solving this problem with bit manipulations
       public void Find(string[] words)
        {
            int n = words.Length;
            List<int> mark = new List<int>(new int[n]);
            
            //Preprocess mark list with binary represenation of input. 
            //Ex if words =  "abc", "def'
            //mark[0] = (1 << ('a' - 'a')) | (1 << ('b' - 'a')) | (1 << ('c' - 'a')) = 1 << 0 | 1 << 1 | 1 << 2 = 1 + 2 + 4 = 7
            //mark[0] = 7 // binary representaion of abc is 3 store the result in mark list
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    mark[i] = mark[i] | GetBinary(words[i][j]);
                }
            }
            int maxProduct = 0;

            //perform bitwise and operation between two words 
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    //if AND operation returns 0 then two words are disctinct
                    //7 & 8  = 0 1 1 1  | 1 0 0 0 = 0 so 7 and 8 are different
                    if ((mark[i] & mark[j]) == 0)
                    {
                        maxProduct = Math.Max(maxProduct, words[i].Length * words[j].Length);
                    }
                }
            }

            Console.WriteLine(maxProduct);
            
        }

        private int GetBinary(char c)
        {
            return 1 << c - 'a';
        }
    }
}
