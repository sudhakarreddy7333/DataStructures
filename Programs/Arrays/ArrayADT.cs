using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Arrays
{
    public class ArrayADT
    {
        public int Capacity { get; set; }
        public int Length { get; set; }
        private readonly int[] Arr;
        public ArrayADT()
        {
            Length = 0;
            Capacity = 10;
            Arr = new int[Capacity];
        }

        public void Add(int value)
        {
            if(Length<Capacity)
            {
                Arr[Length++] = value;
            }
        }

        public int this[int index]
        {
            get
            {
                return Get(index);
            }
            set { Set(index, value); }
        }

        private int Get(int index)
        {
            if (index >= 0 && index <= Length - 1)
            {
                return Arr[index];
            }
            return -1;
        }

        private void Insert(int index, int value)
        {
            if(index >= 0 && index < Capacity)
            {
                for (int i = Length - 1; i > index; i--)
                {
                    Arr[i] = Arr[i - 1];
                }
                Arr[index] = value;
            }
            if(index > Length)
            {
                Length++;
            }
        }

        private void Set(int index, int value)
        {
            if(index>=0 && index<=Length)
            {
                Arr[index] = value;
            }
        }

        public void Remove(int index)
        {
            if(index >=0 && index<=Length)
            {
                for (int i = index; i < Length; i++)
                {
                    Arr[i] = Arr[i+1];
                }
                Length--;
            }
        }

        public int Search(int key)
        {
            BinarySearch search = new BinarySearch();
            return search.SearchIterative(this, key);
        }

        public ArrayADT Reverse()
        {
            ArrayShift ops = new ArrayShift();
            return ops.Reverse(this);
        }

        public ArrayADT ShiftLeft()
        {
            return new ArrayShift().ShiftLeft(this);
        }
    }
}
