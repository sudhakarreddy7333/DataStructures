using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Graphs
{
    public class BFSProgram
    {
        private void BFS(int[,] graph, int startVertex, int size)
        {
            int i = startVertex;
            Queue<int> queue = new Queue<int>();
            int[] vertexVisited = new int[size];
            
            Console.Write(i+" ");
            queue.Enqueue(i);
            vertexVisited[i] = 1;
            while(queue.Count > 0)
            {
                i = queue.Dequeue();
                for (int k = 1; k < size; k++)
                {
                    if (graph[i, k] == 1 && vertexVisited[k] == 0)
                    {
                        Console.Write(k+" ");
                        vertexVisited[k] = 1;
                        queue.Enqueue(k);
                    }
                }
            }
        }


        public void RunProgram()
        {
            //G = (vertex, edge)
            int[,] graph = new int[7, 7]
            {
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 1, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0 }
            };
            
            BFS(graph, 1, 7);
            Console.WriteLine();
            BFS(graph, 4, 7);
            Console.WriteLine();
            BFS(graph, 6, 7);
        }
    }
}
