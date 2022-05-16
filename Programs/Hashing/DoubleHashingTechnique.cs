using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Hashing
{
    public class DoubleHashingTechnique
    {
        private int[] HashTable;
        int size = 10;

        private int nearestPrime;
        public DoubleHashingTechnique()
        {
            HashTable = new int[size];
            nearestPrime = GetNearestPrime();
        }
        private void Insert(int key)
        {
            int index = Hash(key);

            if(HashTable[index] != 0)
            {
               index = DoubleHash(key);
            }

            HashTable[index] = key;
        }

        private int DoubleHash(int key)
        {
            int i = 0; // h(x) = h1(x) + i*h2(x); h1(x) = linear hash; h2(x) = primeHash
            while (HashTable[(Hash(key) + i * GetPrimeHash(key)) % size] != 0)
            {
                i++;
            }
            return (Hash(key) + i * GetPrimeHash(key)) % size;
        }

        private int Hash(int key)
        {
            return (key % size);
        }

        private int GetPrimeHash(int key)
        {
            int primeIndex = nearestPrime - (key % nearestPrime);
            return primeIndex;
        }

        private int GetNearestPrime()
        {
            int pr = size;
            while (pr > 1)
            {
                bool isPrime = true;
                for (int k = 2; k < pr / 2; k++)
                {
                    if(pr % k == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime == false)
                {
                    pr--;
                }
                else
                {
                    return pr;
                }
            }

            return -1;
        }

        private int Search(int key)
        {
            int i = 0;
            while(HashTable[(Hash(key) + i * GetPrimeHash(key)) % size] != key)
            {
                if(HashTable[(Hash(key) + i * GetPrimeHash(key)) % size] == 0)
                {
                    return -1;
                }
                i++;
            }

            return Hash(key) + i * GetPrimeHash(key) % size;
        }

        public void RunProgram()
        {
            Insert(33);
            Insert(53);
            Insert(31);
            Console.WriteLine(Search(53));
            Console.WriteLine(Search(5));
        }
    }
}
