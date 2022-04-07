using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.LinkedList
{
    public class MergeLinkedList
    {
        //https://www.udemy.com/course/datastructurescncpp/learn/lecture/13133298#overview

//        MergeLinkedList ml = new MergeLinkedList();
//        Node firstHead = null;
//            for (int i = 5; i > 0; i--)
//            {
//                var newNode = new Node();
//        newNode.val = i + 2; // add non incrementing numbers like 1,2,3,4
//                if(firstHead != null)
//                {
//                    newNode.next = firstHead;
//                }
//    firstHead = newNode;
//            }

//Node secondHead = null;
//            for (int i = 10; i > 5; i--)
//            {
//                var newNode = new Node();
//newNode.val = i - 1;
//                if (secondHead != null)
//                {
//                    newNode.next = secondHead;
//                }
//                secondHead = newNode;
//            }

//            ml.Merge(firstHead, secondHead);
        public void Merge(Node firstList, Node secondList)
        {
            Node mergeListHead, mergeListTail;

            if(firstList.val < secondList.val)
            {
                mergeListTail = mergeListHead = firstList;
                firstList = firstList.next;
                mergeListTail.next = null;
            }
            else{
                mergeListTail = mergeListHead = secondList;
                secondList = secondList.next;
                mergeListTail.next = null;
            }

            while(firstList != null && secondList != null)
            {
                if(firstList.val < secondList.val)
                {
                    mergeListTail.next = firstList;
                    mergeListTail = firstList;
                    firstList = firstList.next;
                    mergeListTail.next = null;
                }
                else
                {
                    mergeListTail.next = secondList;
                    mergeListTail = secondList;
                    secondList = secondList.next;
                    mergeListTail.next = null;
                }
            }

            if(firstList != null)
            {
                mergeListTail.next = firstList;
            }
            else
            {
                mergeListTail.next = secondList;
            }


            while(mergeListHead != null)
            {
                Console.WriteLine(mergeListHead.val);
                mergeListHead = mergeListHead.next;
            }
        }
    }
}
