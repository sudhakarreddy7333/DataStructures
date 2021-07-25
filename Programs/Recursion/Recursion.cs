using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Recursion
{
    public class Recursion
    {
        static int x = 0;
        public void StaticRecursion()
        {
            Console.WriteLine($"{func(5)}"); // 5+5+5+5+5 = 25
            Console.WriteLine($"{func1()}"); // x= 5;
        }

        int func(int n)
        {
            if(n>0)
            {
                x++;
                return func(n - 1) + x;
            }
            return 0;
        }

        int func1()
        {
            return x; 
        }

        /// <summary>
        /// A recursive function where the function calls itself at the end
        /// </summary>
        /// <param name="n"></param>
        public void TailRecursion(int n)
        {
            if(n>0)
            {
                Console.WriteLine(n);
                TailRecursion(n-1);
            }
        }

        /// <summary>
        /// A recursive function where the function calls itself at the begining
        /// </summary>
        /// <param name="n"></param>
        public void HeadRecursion(int n)
        {
            if(n>0)
            {
                HeadRecursion(n - 1);
                Console.WriteLine(n);
            }
        }

        // 0(2 pow n)
        public void TreeRecursion(int n)
        {
            if(n > 0)
            {
                Console.WriteLine(n);
                TreeRecursion(n - 1);
                TreeRecursion(n - 1);
            }
        }


        public void IndirectRecursion(int n)
        {
            if(n>0)
            {
                IndirectRecursionA(n);
            }
        }

        private void IndirectRecursionA(int n)
        {
            if (n > 0)
            {
                Console.WriteLine(n);
                IndirectRecursionB(n - 1);
            }

        }

        private void IndirectRecursionB(int n)
        {
            if(n>0)
            {
                Console.WriteLine(n);
                IndirectRecursionA(n / 2);
            }
        }

        public int NestedRec(int n)
        {
            if (n > 100)
                return n - 10;

            else
                return NestedRec(NestedRec(n + 11));
        }

        //works for any value of n
        public long SumOfNNumbersConstantTime(long n)
        {
            return n * (n + 1) / 2;
        }

        //Doesnt work for very large value of n as recursion works on consuming stack memory. So SC will be O(n)
        public long SumOfNNumbersRec(long n)
        {
            if (n == 0)
                return 0;
            else
                return SumOfNNumbersRec(n - 1) + n;
        }

        //Exponent function with less multiplications
        public int Pow(int m, int n)
        {
            if (n == 0)
                return 1;

            if (n % 2 == 0)
                return Pow(m * m, n / 2);
            else
                return Pow(m * m, (n - 1) / 2) * m;
        }

        public float TaylorsIterative(float x, float n)
        {
            float s = 1;
            for(;n>0;n--)
            {
                s = 1 + (x / n) * s;
            }
            return s;
        }

        static double taylors = 1;
        public double TaylorsRecursive(int x, int n)
        {
            if (n == 0)
                return taylors;

            taylors = 1 + (taylors / n) * x;
            return TaylorsRecursive(x, n - 1);
        }

        //O(n)
        public int FibonaciiIterative(int n)
        {
            if (n <= 1)
                return n;

            int f0 = 0, f1 = 1, sum = 0;
            for(int i=2; i<=n; i++)
            {
                sum = f0 + f1;
                f0 = f1;
                f1 = sum;
            }
            return sum;
        }

        public int FibonacciRecursiveMemorization(int n)
        {
            int res = FibonacciRecursiveWithoutMem(n);
            return res;
        }

        Dictionary<int, int> mem = new Dictionary<int, int>();
        //This makes less recursive calls due to memoization Time complexity O(n) and efficient
        private int FibonacciRecursive(int n)
        {
            if (n <= 1)
            {
                if(mem.ContainsKey(n) == false)
                {
                    mem[n]=n;
                    return n;
                }
            }
            else
            {
                if (mem.ContainsKey(n - 2) == false)
                {
                    int f0 = FibonacciRecursive(n - 2);
                    mem[n-2]= f0;
                }

                if (mem.ContainsKey(n - 1) == false)
                {
                    int f1 = FibonacciRecursive(n - 1);
                    mem[n - 1]= f1;
                }
            }

            return mem[n - 2] + mem[n - 1];
        }

        //This makes more recursive calls resulting in O(2 pow n) time complexity T(n) = 2T(n-1) + 1 = O(2 pow n)
        private int FibonacciRecursiveWithoutMem(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return FibonacciRecursiveWithoutMem(n - 2) + FibonacciRecursiveWithoutMem(n - 1);
        }

        public int NcrIterative(int n, int r)
        {
            if (r > n)
                return -1;

            int num, den = 0;
            num = fact(n);
            den = fact(r) * fact(n - r);
            return num / den;
        }

        private int fact(int n)
        {
            if (n == 0)
                return 1;
            return fact(n - 1) * n;
        }

        public int NcrRecursive(int n, int r)
        {
            if (r == 0 || n == r)
                return 1;

            return NcrRecursive(n - 1, r - 1) + NcrRecursive(n - 1, r);
        }


        public void TOH(int disks, int t1, int t2, int t3)
        {
            if(disks > 0)
            {
                TOH(disks - 1, t1, t3, t2);
                Console.WriteLine($"Moving disk from {t1} to {t3}");
                TOH(disks - 1, t2, t1, t3);
            }
        }
    }
}
