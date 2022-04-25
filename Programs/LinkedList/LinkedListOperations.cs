using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{
    //LinkedListOperations dl = new LinkedListOperations();
    //dl.Insert(1);
    //dl.Insert(2);
    //dl.Insert(5);
    ////dl.Insert(6);
    ////dl.Insert(7);
    ////dl.Insert(8);
    //var n = dl.FindMiddleNode();
    //Console.WriteLine(n.val);
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

        //use two pointers p, q. move p by 2 steps and q by 1 step. when p is null q has covered half the distance
        public Node FindMiddleNode()
        {
            Node p = head , q = head;

            while(p != null)
            {
                p = p.next;
                if (p == null)
                    return q;

                q = q.next;
                p = p.next;
            }

            throw new Exception("No middle element"); //list contains even no of elements.
        }
    }
}
