using DSAlgorithms.Programs.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Hashing
{
    public class ChainingTechnique
    {
        private Node[] HashTable;   
        public ChainingTechnique()
        {
            HashTable = new Node[10];
        }
        private void Insert(int key)
        {
            int index = HashFunction(key);
            HashTable[index] = SortedInsert(HashTable[index], key);
        }

        private int Search(int key)
        {
            int index = HashFunction(key);
            Node head = HashTable[index];
            
            Node keyNode = SearchList(head, key);

            return keyNode == null ? -1 : keyNode.val;
        }

        private Node SearchList(Node head, int key)
        {
         
            Node p = head;

            while(p != null)
            {
                if (p.val == key)
                    return p;

                p = p.next;
            }

            return null;
        }

        private int HashFunction(int key)
        {
            int keyIndex = key % 10;
            return keyIndex;
        }


        private Node SortedInsert(Node first, int element)
        {
            Node newNode = new Node(element);
            if (first == null)
            {
                first = newNode;
            }
            else
            {
                Node p = first;

                while (p != null && p.next != null && p.next.val <= element)
                {
                    p = p.next;
                }

                if(p == first)
                {
                    if(p.val <= element)
                    {
                        p.next = newNode;
                    }
                    else
                    {
                        newNode.next = p;
                        first = newNode;
                    }
                }
                else
                {
                    newNode.next = p.next;
                    p.next = newNode;
                }
            }

            return first;
        }

        public void RunProgram()
        {
            Insert(21);
            Insert(11);
            Insert(31);
            Insert(43);
            Insert(53);
            Insert(57);

            Console.WriteLine(Search(11));
            Console.WriteLine(Search(57));
        }
    }
}
