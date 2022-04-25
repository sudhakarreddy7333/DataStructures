using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Queue
{
    //circular insert queue

    //QueueArray qa = new QueueArray();
    //qa.Enqueue(5);
    //        qa.Enqueue(10);
    //        qa.Enqueue(15);
    //        Console.WriteLine(qa.IsFull());
    //        qa.Enqueue(20);
    //        Console.WriteLine(qa.IsFull());
    //        Console.WriteLine(qa.Dequeue());
    //        Console.WriteLine(qa.Dequeue());
    //        qa.Enqueue(25);
    //        Console.WriteLine(qa.Dequeue());
    //        Console.WriteLine(qa.Dequeue());
    //        Console.WriteLine(qa.IsEmpty());
    //        Console.WriteLine(qa.Dequeue());
    //        Console.WriteLine(qa.IsEmpty());
    public class QueueArray
    {
        private int[] array;
        private int front;
        private int rear;
        public QueueArray(int size)
        {
            array = new int[size];
            front = rear = 0;
        }

        public QueueArray()
        {
            array = new int[5];
            front = rear = 0;
        }
        public void Enqueue(int val)
        {
            rear = (rear + 1) % array.Length;
            if (rear == front)
            {
                throw new Exception("Queue full");
            }
            array[rear] = val;
        }

        public int Dequeue()
        {
            if (rear == front)
            {
                throw new Exception("Queue empty");
            }

            front = (front + 1) % array.Length;
            return array[front];
        }

        public bool IsFull()
        {
            return (rear + 1) % array.Length == front;
        }

        public bool IsEmpty()
        {
            return rear == front;
        }
    }
}
