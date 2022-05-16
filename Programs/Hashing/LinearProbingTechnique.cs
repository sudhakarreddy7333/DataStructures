using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Hashing
{
    // Hash function rule :  Only half of hash table shoulb be filled with keys. 
    //Loading factor <= 0.5
    public class LinearProbingTechnique
    {
        private int[] HashTable;
        private int size = 10;
        public LinearProbingTechnique()
        {          
            HashTable = new int[size];
        }
        private void Insert(int key)
        {
           int index = Hash(key);

            if(HashTable[index] != 0)
            {
                int probeIndex = GetProbeIndex(key, index);
                HashTable[probeIndex] = key;
            }
            else
            {
                HashTable[index] = key;
            }
        }

        private int Search(int key)
        {
            int index = Hash(key);

            int i = 0;

            while(HashTable[(index + i) % size] != key)
            {
                if(HashTable[(index + i) % size] == 0)
                {
                    return -1; //Empty space found. So element doest not exist;
                }
                i++;
            }

            return (index + i) % size;
        }


        private int Hash(int key)
        {
            return key % size;
        }

        private int GetProbeIndex(int key, int index)
        {
            int i = 0;

            while(HashTable[(index + i) % size] != 0)
            {
                i++;
            }

            return (index + i) % size;
        }



        public void RunProgram()
        {
            Insert(12);
            Insert(22);
            Insert(45);
            Console.WriteLine(Search(22));
            Console.WriteLine(Search(32));
        }
    }
}
