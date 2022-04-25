using DSAlgorithms.Programs.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Stack
{
    //Pros
    //Stack grows irrespective of size. or until heap memory is available


    //StackLinkedList sl = new StackLinkedList();
    //sl.Push(1);
    //sl.Push(2);
    //sl.Push(3);
    //sl.Push(4);
    //sl.Push(5);
    //sl.Push(6);
    //sl.Pop();
    //sl.Pop();
    //sl.Pop();
    //sl.Pop();
    //sl.Pop();
    //sl.Peek();
    //sl.Pop();
    //sl.Pop();
    public class StackLinkedList<T>
    {
        Node<T> top;
        public StackLinkedList()
        {
            top = null;
        }
        public void Push(T element)
        {
            Node<T> n = new Node<T>(); //If heap is full then object will not be intilaized. 
            if(n == null)
            {
                throw new StackOverflowException();
            }

            n.val = element;
            n.next = top;
            top = n;
        }

        public T Pop()
        {
            if (top == null)
                throw new Exception("Stack underflow");

            T topElement =  top.val;
            top = top.next;
            return topElement;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public bool IsFull()
        {
            Node<T> n = new Node<T>();
            return n == null;
        }

        //returns top element
        public T Peek()
        {
            if (top != null)
                return top.val;

            return default;
        }
    }
}
