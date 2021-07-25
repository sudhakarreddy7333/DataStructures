using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms
{
    class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        public int Count { get; set; }

        public DoublyLinkedList()
        {
            Count = 0;
        }
        public void AddHead(T value) 
        {
            DoublyLinkedListNode<T> adding = new DoublyLinkedListNode<T>(value, Head, null);

            if(Head != null)
            {
                Head.Previous = adding;
            }

            Head = adding;
            if(Tail == null)
            {
                Tail = Head;
            }

            Count++;
        }

        public void AddTail(T value)
        {
            if(Tail == null)
            {
                AddHead(value);
            }
            else
            {
                DoublyLinkedListNode<T> adding = new DoublyLinkedListNode<T>(value, null, Tail);
                Tail.Next = adding;
                Tail = adding;
                Count++;
            }
        }

        public DoublyLinkedListNode<T> Find(T value)
        {
            DoublyLinkedListNode<T> current = Head;
            while(current != null)
            {
                if(current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void GetEnumertator()
        {
            DoublyLinkedListNode<T> current = Head;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public bool Remove(T value)
        {
            DoublyLinkedListNode<T> found = Find(value);
            if (found == null)
                return false;

            var previous = found.Previous;
            var next = found.Next;

            //Removing head
            if(previous == null)
            {
                Head = next;
                if(Head != null)
                {
                    Head.Previous = null;
                }
            }
            else
            {
                previous.Next = next;
            }

            //Removing tail
            if(next == null)
            {
                Tail = previous;
                if(Tail != null)
                {
                    previous.Next = null;
                }   
            }
            else
            {
                next.Previous = previous;
            }
            Count--;
            return true;
        }
    }

    class DoublyLinkedListNode<TNode>
    {
        public DoublyLinkedListNode(TNode value, DoublyLinkedListNode<TNode> next, DoublyLinkedListNode<TNode> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
        public DoublyLinkedListNode<TNode> Next { get; set; }
        public DoublyLinkedListNode<TNode> Previous { get; set; }
        public TNode Value { get; set; }
    }
}
