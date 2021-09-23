using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Strings
{
    public class StringPermutations
    {
        public void PrintPermutations(char[] str)
        {
            PermutationsSwap(str, 0, str.Length - 1);
        }

        private void PermutationsSwap(char[] str, int l, int h)
        {
            if (l == h)
            {
                Console.WriteLine(str);
            }

            else
            {

                for (int i = l; i <= h; i++)
                {
                    Swap(i, l, str);
                    PermutationsSwap(str, l + 1, h);
                    Swap(i, l, str);
                }
            }

        }

        private void Swap(int i, int j, char[] str)
        {
            char temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

        public void PrintPermutations(string str)
        {
            perm(str, "");    
        }

        void perm(string str, string prefix)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1); //concat characters other than char at i. 
                    perm(rem, prefix + str[i]);
                }
            }
        }
    }
}
