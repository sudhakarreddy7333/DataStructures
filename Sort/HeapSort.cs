using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Sort
{

    public class HeapSort
    {
        private int heapSize;


        public void Sort(int[] arr)
        {
            if (arr.Length == 0)
                return;

            // HeapSort = Build max heap of input array + (Remove element from heap and add it to end of the heap, heapify remaining elements);

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

            for (int i = heapSize /2; i >= 0; i--) //i = heapsize/2 is selected for least computations required to build max heap array. You can also select i=heapsize. 
            {
                //heapfiy starts from the end
                Heapify(arr, i);
            }
        }

        private void Heapify(int[] arr, int index)
        {
            int largest = index;
            int leftNode = 2 * index; //formula to get left node 2*(parent node)
            int rightNode = 2 * index + 1;

            if(leftNode <= heapSize && arr[leftNode] > arr[index])
            {
                largest = leftNode;
            }

            if (rightNode <= heapSize && arr[rightNode] > arr[largest])
            {
                largest = rightNode;
            }

            if(largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
            }

        }

        private void Swap(int[] arr, int x, int y)
        {
            arr[x] = arr[x] + arr[y];
            arr[y] = arr[x] - arr[y];
            arr[x] = arr[x] - arr[y];
        }
    }
}
