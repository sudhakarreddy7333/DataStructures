using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{

    public class LinkedListReversePrint
    {
        public Node AddTwoNumbers(Node l1, Node l2)
        {
            Node head = null;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                head = new Node(sum % 10, head);
                carry = sum / 10;
            }
            return ReverseList(head);
        }

        private Node ReverseList(Node node)
        {
            Node head = null;
            while (node != null)
            {
                Node next = node.next;
                node.next = head;
                head = node;
                node = next;
            }
            return head;
        }

        private Node ReverseListRecursive(Node node)
        {
            if (node == null || node.next != null)
                return node;

            Node rest = ReverseListRecursive(node.next);

            node.next.next = node;
            node.next = null;
            return rest;
        }
    }
}
