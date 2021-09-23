using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSAlgorithms.Programs.Arrays.Hard
{
    public class MedianOfIntegerStreams
    {
        private List<int> input;
        public MedianOfIntegerStreams()
        {
            input = new List<int>();
        }
        public void AddNumber(int num)
        {
            input.Add(num);
        }
        public void CalculateMedian()
        {
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();

            foreach (var item in input)
            {
                if(maxHeap.IsEmpty() || maxHeap.Top() > item)
                {
                    maxHeap.Push(item);
                }
                else
                {
                    minHeap.Push(item);
                }

                if(maxHeap.Size > minHeap.Size + 1)
                {
                   minHeap.Push(maxHeap.Pop());
                }
                else if(maxHeap.Size + 1 < minHeap.Size)
                {
                    maxHeap.Push(minHeap.Pop());
                }
            }

            if (maxHeap.IsEmpty() == false && minHeap.IsEmpty())
            {
                Console.WriteLine($"Median {maxHeap.Top()}");
            }
            else if (maxHeap.IsEmpty() == false && minHeap.IsEmpty() == false)
            {
                if (maxHeap.Size == minHeap.Size)
                {
                    double median = (double)(maxHeap.Top() + minHeap.Top()) / 2;
                    Console.WriteLine($"Median {median}");
                }
                else if (maxHeap.Size > minHeap.Size)
                {
                    Console.WriteLine($"Median {maxHeap.Top()}");
                }
                else
                {
                    Console.WriteLine($"Median {minHeap.Top()}");
                }
            }

        }
    }


    public class MinHeap : IHeap
    {
        private List<int> minHeapList;
        private int heapSize;

        public int Size { get { return minHeapList.Count; } }

        public MinHeap()
        {
            minHeapList = new List<int>();
        }
        public bool IsEmpty()
        {
            return minHeapList.Count == 0;
        }

        public int Pop()
        {
            if(minHeapList.Count > 0)
            {
                int minElement = minHeapList.First();
                minHeapList.Remove(minElement);
                heapSize--;
                Heapify(minHeapList, 0);
                return minElement;
            }
            throw new IndexOutOfRangeException("List is empty");
        }

        public void Push(int element)
        {
            minHeapList.Add(element);
            CalculateMinHeap();
        }

        private void CalculateMinHeap()
        {
            if (minHeapList.Count == 0)
                return;

            heapSize = minHeapList.Count - 1;

            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(minHeapList, i);
            }
            
        }

        private void Heapify(List<int> minHeapList, int index)
        {
            int smallest = index;
            int leftNode = 2 * index;
            int rightNode = 2 * index + 1;

            if(leftNode <= heapSize && minHeapList[leftNode] < minHeapList[index])
            {
                smallest = leftNode;
            }

            if (rightNode <= heapSize && minHeapList[rightNode] < minHeapList[smallest])
            {
                smallest = rightNode;
            }

            if (smallest != index)
            {
                Swap(minHeapList, index, smallest);
                Heapify(minHeapList, smallest);
            }
        }

        private void Swap(List<int> minHeapList, int x, int y)
        {
            minHeapList[x] = minHeapList[x] + minHeapList[y];
            minHeapList[y] = minHeapList[x] - minHeapList[y];
            minHeapList[x] = minHeapList[x] - minHeapList[y];
        }

        public int Top()
        {
            if (minHeapList.Count > 0)
                return minHeapList.First();

            throw new IndexOutOfRangeException("List is empty");
        }
    }

    public class MaxHeap : IHeap
    {
        private List<int> maxHeapList;
        private int heapSize;

        public int Size { get { return maxHeapList.Count; } }

        public MaxHeap()
        {
            maxHeapList = new List<int>();
        }
        
        public int Top()
        {
            if(maxHeapList.Count > 0) return maxHeapList.First();
            else throw new IndexOutOfRangeException("No items in heap"); 
        }

        public int Pop()
        {
            if(maxHeapList.Count > 0)
            {
                int maxElement = maxHeapList.First();
                maxHeapList.Remove(maxElement);
                heapSize--;
                Heapify(maxHeapList, 0);
                return maxElement;
            }
            throw new IndexOutOfRangeException("No items in heap");
        }

        public void Push(int element)
        {
            maxHeapList.Add(element);
            Sort();
        }

        public bool IsEmpty()
        {
            return maxHeapList.Count == 0;
        }

        public void Sort()
        {
            if (maxHeapList.Count == 0)
                return;

            BuildMaxHeap();
        }

        private void BuildMaxHeap()
        {
            heapSize = maxHeapList.Count - 1;
            for (int i = heapSize / 2; i >= 0 ; i--)
            {
                Heapify(maxHeapList, i);
            }
        }

        private void Heapify(List<int> maxHeapList, int index)
        {
            int largest = index;
            int leftNode = 2 * index; //formula to get left node 2*(parent node)
            int rightNode = 2 * index + 1;

            if (leftNode <= heapSize && maxHeapList[leftNode] > maxHeapList[index])
            {
                largest = leftNode;
            }

            if (rightNode <= heapSize && maxHeapList[rightNode] > maxHeapList[largest])
            {
                largest = rightNode;
            }

            if (largest != index)
            {
                Swap(maxHeapList, index, largest);
                Heapify(maxHeapList, largest);
            }
        }

        private void Swap(List<int> arr, int x, int y)
        {
            arr[x] = arr[x] + arr[y];
            arr[y] = arr[x] - arr[y];
            arr[x] = arr[x] - arr[y];
        }
    }

    internal interface IHeap
    {
        int Top();
        int Pop();
        void Push(int element);
        bool IsEmpty();
        int Size { get;}
    }
}
