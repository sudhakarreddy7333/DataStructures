using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{
    //CircularLinkedList cl = new CircularLinkedList();

    //cl.Insert(1);
    //cl.Insert(2);
    //cl.Insert(4);
    //cl.Insert(5);
    //cl.Insert(6, 0);
    //cl.Insert(8, 4);
    ////cl.Delete(1);
    //cl.Delete(5);
    //cl.Display();
    public class CircularLinkedList
    {
        private Node head = null;
        private Node last;
        public CircularLinkedList()
        {
            last = head;
        }
        public void Insert(int n)
        {
            Node newNode = new Node(n);
            if(head == null)
            {
                head = newNode;
                head.next = head;
                last = head;
            }
            else
            {
                newNode.next = head;
                last.next = newNode;
                last = newNode;
            }
        }

        public void Insert(int n, int index)
        {
            Node newNode = new Node(n);
            if (index == 0)
            {  
                newNode.next = head;

                if(head == null)
                {
                    head = newNode;
                    head.next = head;
                }
                else
                {
                    Node p = head;
                    do
                    {
                        p = p.next;
                    } while (p.next != head);

                    p.next = newNode;
                }

                head = newNode;
            }
            else
            {
                Node p = head;
                int nodeLength = 0;
                do
                {
                    nodeLength++;
                    p = p.next;
                }
                while (p != head) ;

                if(nodeLength+1 < index)
                {
                    throw new Exception("Out of bounds");
                }

                p = head;

                for (int i = 0; i < index - 1; i++)
                {
                    p = p.next;
                }

                newNode.next = p.next;
                p.next = newNode;
            }
        }

        //https://www.udemy.com/course/datastructurescncpp/learn/lecture/13145038#overview
        public void Delete(int index)
        {
            
            if(index == 1)
            {
                Node p = head;

                do
                {
                    p = p.next;

                } while (p.next != head);

                if (head != null)
                {
                    head = head.next;
                }
                p.next = head;
            }
            else
            {
                Node p = head;
                for (int i = 0; i < index - 2; i++)
                {
                    p = p.next;
                }

                Node q = p.next;
                p.next = q.next;
            }
        }

        public void Display()
        {
            Node p = head;
            do
            {
                Console.WriteLine(p.val);
                p = p.next;
            } while (p != head);
        }
    }
}
