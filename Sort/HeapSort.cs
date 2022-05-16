using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Sort
{
    //https://www.udemy.com/course/datastructurescncpp/learn/lecture/13190840#notes
    public class HeapSort
    {
        private int heapSize;


        public void Sort(int[] arr)
        {
            if (arr.Length == 0)
                return;

            // HeapSort = Build max heap of input array + (Remove element from heap and add it to end of the heap, heapify remaining elements);
            //Heapify - creation of heap one element at a time.

            BuildMaxHeap(arr); 
            PerformHeapSort(arr);
        }

        private void PerformHeapSort(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
        }

        private void BuildMaxHeap(int[] arr)
        {
            heapSize = (arr.Length - 1);

            //i = heapSize/2  is selected as heap's leaf nodes are already a max heap. 
            for (int i = heapSize /2; i >= 0; i--) 
            {
                //heapfiy starts from the end
                Heapify(arr, i);
            }
        }

        private void Heapify(int[] arr, int rootIndex)
        {
            int largest = rootIndex;
            int leftNode = 2 * rootIndex; //formula to get left node 2*(parent node)
            int rightNode = 2 * rootIndex + 1;

            if(leftNode <= heapSize && arr[leftNode] > arr[rootIndex])
            {
                largest = leftNode;
            }

            if (rightNode <= heapSize && arr[rightNode] > arr[largest])
            {
                largest = rightNode;
            }

            if(largest != rootIndex)
            {
                Swap(arr, rootIndex, largest);
                Heapify(arr, largest);
            }

        }

        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
    }
}
