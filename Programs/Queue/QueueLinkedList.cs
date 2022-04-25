using DSAlgorithms.Programs.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Queue
{
    //QueueLinkedList q = new QueueLinkedList();

    //q.Enqueue(1);
    //        q.Enqueue(2);
    //        Console.WriteLine(q.Dequeue().val);
    //        Console.WriteLine(q.Dequeue().val);
    //        //q.Dequeue(); //throws queue empty exception
    //        q.Enqueue(3);
    //        Console.WriteLine(q.Dequeue().val);
    //        q.Enqueue(4);
    //        q.Enqueue(5);
    //        q.Enqueue(6);
    //        Console.WriteLine(q.Dequeue().val);
    //        Console.WriteLine(q.Dequeue().val);
    //        Console.WriteLine(q.Dequeue().val);
    public class QueueLinkedList
    {
        private Node front;
        private Node rear;
        public QueueLinkedList()
        {
            front = rear = null;
        }
        public void Enqueue(int element)
        {
            Node n = new Node();
            n.val = element;
            //when 1st node is inserted or front node points to end of linked list. 
            if (rear == null || front == null)
            {
                front = rear = n;
            }
            else
            {
                rear.next = n;
                rear = n;
            }
        }

        public Node Dequeue()
        {
           
            if (front == null)
            {
                throw new Exception("Queue empty");
            }

            Node dqueue = front;
            front = front.next;

            return dqueue;
        }
    }
}
