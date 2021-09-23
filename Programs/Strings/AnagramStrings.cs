using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Strings
{
    public class AnagramStrings
    {
        public bool IsAnagram(string s, string t)
        {

            //if (first.Length != second.Length)
            //    return false;

            //first = first.ToLower();
            //second = second.ToLower();

            //Dictionary<char, int> hash = new Dictionary<char, int>();

            //for (int i = 0; i < first.Length; i++)
            //{
            //    if(hash.ContainsKey(first[i]))
            //    {
            //        hash[first[i]] += 1;
            //    }
            //    else
            //    {
            //        hash.Add(first[i], 1);
            //    }
            //}

            //for (int i = 0; i < second.Length; i++)
            //{
            //    if (hash.ContainsKey(second[i]))
            //    {
            //        hash[second[i]] -= 1;
            //    }
            //}

            //foreach (var item in hash.Keys)
            //{
            //    if (hash[item] != 0)
            //        return false;
            //}
            //return true;


            if (s.Length != t.Length) return false;
            int[] numChars = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                numChars[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (numChars[t[i] - 'a']-- <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
