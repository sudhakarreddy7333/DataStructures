using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees
{
    //ConstructTreeFromTraversal t = new ConstructTreeFromTraversal();
    //Programs.Trees.Node root = t.Generate(new int[] { 7, 10, 5, 6, 12, 4 }, new int[] { 5, 10, 7, 12, 6, 4 });

    //BinaryTreeOperations op = new BinaryTreeOperations();
    //Console.WriteLine("Nodes count: "+ op.CountNodes(root));
    //Console.WriteLine("Leaf nodes count: " + op.CountLeafNodes(root)); //nodes with 0 childrens;
    //Console.WriteLine("Nodes with degree 2 count: " + op.CountNodesWithDegree2(root)); //nodes with 2 childrens;
    //Console.WriteLine("Sum of nodes: " + op.SumOfNodes(root)); //sum of nodes;
    //Console.WriteLine("Sum of leaf nodes: " + op.SumOfLeafNodes(root)); //sum of nodes;
    //Console.WriteLine("count internal nodes: " + op.CountInternalNodes(root)); //sum of nodes;
    //Console.WriteLine("count nodes with degree 1: " + op.NodesCountWithDegree1(root)); //sum of nodes;
    public class BinaryTreeOperations
    {

        public int CountNodes(Node root)
        {
            if(root != null)
            {
                int leftNodes = CountNodes(root.leftChild);
                int rightNodes = CountNodes(root.rightChild);
                return leftNodes + rightNodes + 1;
            }
            return 0;
        }

        public int CountNodesWithDegree2(Node root)
        {
            if (root != null)
            {
                int leftNodes = CountNodesWithDegree2(root.leftChild);
                int rightNodes = CountNodesWithDegree2(root.rightChild);

                if (root.leftChild != null && root.rightChild != null)
                {
                    return leftNodes + rightNodes + 1;
                }
                else
                {
                    return leftNodes + rightNodes;
                }
                
            }
            return 0;
        }

        public int CountLeafNodes(Node root)
        {
            if (root != null)
            {
                int leftNodes = CountLeafNodes(root.leftChild);
                int rightNodes = CountLeafNodes(root.rightChild);

                if (root.leftChild == null && root.rightChild == null)
                {
                    return leftNodes + rightNodes + 1;
                }
                else
                {
                    return leftNodes + rightNodes;
                }
            }
            return 0;
        }

        // non leaf nodes
        public int CountInternalNodes(Node root)
        {
            if (root != null)
            {
                int leftNodes = CountLeafNodes(root.leftChild);
                int rightNodes = CountLeafNodes(root.rightChild);

                if (root.leftChild == null || root.rightChild == null)
                {
                    return leftNodes + rightNodes + 1;
                }
                else
                {
                    return leftNodes + rightNodes;
                }
            }
            return 0;
        }

        public int NodesCountWithDegree1(Node root)
        {
            if (root != null)
            {
                int leftNodes = NodesCountWithDegree1(root.leftChild);
                int rightNodes = NodesCountWithDegree1(root.rightChild);

                if (root.leftChild!= null ^ root.rightChild != null) // root.leftChild!= null && root.rightChild == null || root.leftChild == null && root.rightChild != null. E-XOR
                {
                    return leftNodes + rightNodes + 1;
                }
                else
                {
                    return leftNodes + rightNodes;
                }
            }
            return 0;
        }

        public int SumOfLeafNodes(Node root)
        {
            if (root != null)
            {
                int leftNodes = SumOfLeafNodes(root.leftChild);
                int rightNodes = SumOfLeafNodes(root.rightChild);

                if (root.leftChild == null && root.rightChild == null)
                {
                    return root.data;
                }
                return leftNodes + rightNodes;
            }
            return 0;
        }

        public int SumOfNodes(Node root)
        {
            if (root != null)
            {
                int leftNodes = SumOfNodes(root.leftChild);
                int rightNodes = SumOfNodes(root.rightChild);
                return leftNodes + rightNodes + root.data;
            }
            return 0;
        }
    }
}
