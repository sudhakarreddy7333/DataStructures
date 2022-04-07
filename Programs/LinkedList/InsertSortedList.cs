using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{
    //InsertSortedList lo = new InsertSortedList();
    //lo.Add(3);
    //        lo.Add(2);
    //        lo.Add(1);
    //        lo.Add(5);
    //        lo.Add(2);
    //        lo.Add(1);
    //        lo.Add(2);
    //        lo.RemoveDuplicates();
    //        lo.PrintElements();
    public class InsertSortedList
    {
        private Node first;
        public InsertSortedList()
        {
            first = null;
        }

        public void Add(int element)
        {
            Node newNode = new Node(element);
            if (first == null)
            {              
                first = newNode;
            }
            else
            {
                Node p = first;

                while(p != null && p.next != null && p.next.val <= element)
                {
                    p = p.next;
                }

                if(p == first)
                {
                    newNode.next = p;
                    first = newNode;
                }
                else
                {
                    newNode.next = p.next;
                    p.next = newNode;
                }
            }
        }

        public void RemoveDuplicates()
        {
            Node p = first , q = first;
            while(q != null)
            {
                if (p.val == q.val)
                {
                    p.next = q.next;
                }
                else
                {
                    p = q;
                }
                q = q.next;
            }
        }

        public void Remove(int element)
        {
            Node p = first;
            if(p.val == element)
            {
                first = p.next;
            }
            else
            {
                while(p != null && p.next != null && p.next.val != element)
                {
                    p = p.next;
                }
                p.next = p.next.next;
            }
        }

        public void PrintElements()
        {
            Node n = first;
            while (n != null)
            {
                Console.WriteLine(n.val);
                n = n.next;
            }
        }
    }
}
