using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{
    /**
 * https://leetcode.com/problems/add-two-numbers/
 */

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkedListReversePrint
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
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

                head = new ListNode(sum % 10, head);
                carry = sum / 10;
            }
            return ReverseList(head);
        }

        private ListNode ReverseList(ListNode node)
        {
            ListNode head = null;
            while (node != null)
            {
                ListNode next = node.next;
                node.next = head;
                head = node;
                node = next;
            }
            return head;
        }

        private ListNode ReverseListRecursive(ListNode node)
        {
            if (node == null || node.next != null)
                return node;

            ListNode rest = ReverseListRecursive(node.next);

            node.next.next = node;
            node.next = null;
            return rest;
        }
    }
}
