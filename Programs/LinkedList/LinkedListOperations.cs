using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{
    public class LinkedListOperations
    {
        public Node list;
        public Node head;
        public LinkedListOperations()
        {
            list = null;
            head = null;
        }
        public void Insert(int element)
        { 
            //adding nodes from tail;
            Node newNode = new Node();
            newNode.val = element;
            if (head != null)
            {
                newNode.next = head;
            }
            head = newNode;
        }
        public void PrintElements()
        {
            Node n = head;
            while(n != null)
            {
                Console.WriteLine(n.val);
                n = n.next;
            }
        }

        public Node Max()
        {
            if (head == null)
                return new Node();

            Node p = head;
            Node maxNode = p;
            while(p != null)
            {
                maxNode = p.val > maxNode.val ? p : maxNode;
                p = p.next;
            }

            return maxNode;
        }

        public Node MaxRecursive()
        {
            return MaxRec(head);
        }

        private Node MaxRec(Node n)
        {
            if (n == null)
                return new Node();

            Node max = MaxRec(n.next);
            return max.val < n.val ? n : max;
        }

        public void Insert(int element, int index)
        {
            if (index == 0)
            {
                Insert(element);
            }   
            else
            {
                Node q = head;
                for (int i = 0; i < index - 1; i++)
                {
                    q = q.next;
                }

                Node newNode = new Node(element);
                newNode.next = q.next;
                q.next = newNode;
            }
        }
    }
}
