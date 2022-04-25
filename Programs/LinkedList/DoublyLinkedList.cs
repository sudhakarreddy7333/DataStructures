using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList.Doubly
{
    public class DoublyLinkedList
    {
        Node head;
        Node last;
        public DoublyLinkedList()
        {
            head = null;
            last = head;
        }
        public void Insert(int val)
        {
            var newNode = new Node();
            newNode.val = val;
            if (head == null)
            {
                newNode.prev = null;
                newNode.next = null;
                head = newNode;
            }
            else
            {
                newNode.next = null;
                newNode.prev = last;
                last.next = newNode;
               
            }
            last = newNode;
        }

        public void Insert(int val, int index)
        {
            Node newNode = new Node();
            newNode.val = val;
            if (index== 0)
            {
                if(head == null)
                {
                    newNode.prev = newNode.next = null;
                }
                else
                {
                    newNode.next = head;
                    head.prev = newNode;
                }
                head = newNode;
            }
            else
            {
                Node p = head;

                for (int i = 0 ; i < index - 1; i++)
                {
                    p = p.next;
                }

                newNode.next = p.next;
                newNode.prev = p;
                
                //set last node to the newnode when the index to insert is at last
                if (p.next == null)
                    last = newNode;

                p.next = newNode;
            }
        }

        public void Delete(int index)
        {
            if(index == 1)
            {
                if(head != null)
                {
                    //check if you are deleting the only node in the list. 
                    //In this case you need to check if next node is not null and then make its prev node null.
                    if (head.next != null)
                    {
                        head.next.prev = null;
                    }
                    head = head.next;
                }
            }
            else
            {
                Node p = head;
                for (int i = 1; i < index; i++)
                {
                    p = p.next;
                }

                p.prev.next = p.next;
                if(p.next != null)
                {
                    p.next.prev = p.prev;
                }
            }
        }

        public void Reverse()
        {
            Node p = head;
            while (p != null)
            {
                //reversing a dll is swapping node's prev with next and next with prev.
                var temp = p.next;
                p.next = p.prev;
                p.prev = temp;
                p = p.prev;

                //if last node is reached then set head to p;
                if(p != null && p.next == null)
                {
                    head = p;
                }
            }
        }

        public void Display()
        {
            Node p = head;

            while(p != null)
            {
                Console.WriteLine(p.val);
                p = p.next;
            }
        }
    }
}
