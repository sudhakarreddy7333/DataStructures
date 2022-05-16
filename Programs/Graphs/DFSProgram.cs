using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Graphs
{
    public class DFSProgram
    {
        int[] visited;
        private void DFS(int[,] graph, int vertex, int size)
        {
            
            if(visited[vertex] == 0)
            {
                Console.Write(vertex + " ");
                visited[vertex] = vertex;
                for (int k = 1; k < size; k++)
                {
                    if (graph[vertex, k] == 1)
                    {
                        DFS(graph, k, 7);
                    }
                }
            }            
        }

        private void DFSIterative(int[,] graph, int startVertex, int size)
        {
            Stack<int> stack = new Stack<int>();
            int[] vertexVisited = new int[size];
            Console.Write(startVertex + " ");
            
            vertexVisited[startVertex] = 1;
            
            stack.Push(startVertex);
            
            while (stack.Count > 0)
            {
                int k = 1;
                startVertex = stack.Pop();
                while (k < size)
                {
                    if (graph[startVertex, k] == 1 && vertexVisited[k] == 0)
                    {
                        Console.Write(k + " ");
                        vertexVisited[k] = 1;
                        stack.Push(startVertex);
                        startVertex = k;
                        k = 1;
                    }
                    else
                    {
                        k++;
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

            visited = new int[7];
            DFS(graph, 2, 7);
            Console.WriteLine();
            DFSIterative(graph, 2, 7);
            Console.WriteLine();

            //visited = new int[7];

            //DFS(graph, 4, 7);
            //Console.WriteLine();
        }
    }
}
