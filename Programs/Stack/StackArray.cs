using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Stack
{
    //StackArray st = new StackArray(6);
    //st.Push(3);
    //st.Push(2);
    //st.Push(5);
    //st.Push(7);
    //st.Push(8);
    //st.Push(9);
    //Console.WriteLine(st.Pop());
    //Console.WriteLine(st.Pop());
    //Console.WriteLine(st.Pop());
    //Console.WriteLine(st.Pop());
    //Console.WriteLine(st.Pop());
    //Console.WriteLine(st.Pop());
    //Console.WriteLine(st.Peek(1));
    //Console.WriteLine(st.Peek(2));
    //Console.WriteLine(st.Peek(4));
    public class StackArray
    {
        int[] stack;
        int top;
        int size;
        public StackArray(int size = 5)
        {
            stack = new int[size];
            top = -1;
            this.size = size;
        }
        public void Push(int element)
        {
            if(IsFull())
            {
                throw new StackOverflowException();
            }

            stack[++top] = element;
        }

        public int Pop()
        {
            if(IsEmpty())
            {
                throw new Exception("Stack underflow");
            }

            return stack[top--];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == size - 1;
        }


        public int Peek(int pos)
        {
            int index = top - pos + 1;   //pos = 0 means peek at last inserted element.  index starts from 1 
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return stack[index];
        }
    }
}
