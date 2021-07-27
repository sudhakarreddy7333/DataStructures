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
            if(Length == 0 || index > Length - 1)
            {
                Add(value);
            }
            else
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

        //This inserts a new element into the array by shifting the elements to right
        public void InsertSorted(int value)
        {
            if (Arr != null && Length <= Capacity)
            {
                int i = Length - 1;
                while (i >= 0 && Arr[i] > value)
                {
                    Arr[i + 1] = Arr[i--];
                }
                Arr[i + 1] = value;
                Length++;
            }
        }

        public void DeleteSorted(int value)
        {
            if(Arr != null)
            {
                int index = new BinarySearch().SearchIterative(this, value);
                if (index == -1)
                    return;
                while(index < Length - 1)
                {
                    Arr[index] = Arr[index + 1];
                    index++;
                }
                Arr[index] = 0;
                Length--;
            }
        }

        public bool IsSorted()
        {
            if(Arr != null && Length > 0)
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    if (Arr[i] > Arr[i + 1])
                        return false;
                }
                return true;
            }
            else
            {
                return false;
            } 
        }

        //Arrange positive intergers after negative integers -5,-1,-2,0,6,7,3 
        public void Rearrange()
        {
            int i = 0, j = Length - 1;
            while(i<j)
            {
                while (Arr[i] < 0)
                {
                    i++;
                }
                while (Arr[j] > 0)
                {
                    j--;
                }

                if(i<j)
                {
                    var temp = Arr[i];
                    Arr[i] = Arr[j];
                    Arr[j] = temp;
                }   
            }
        }

    }
}
