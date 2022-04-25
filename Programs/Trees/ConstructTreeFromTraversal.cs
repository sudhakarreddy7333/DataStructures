using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees
{

    //ConstructTreeFromTraversal t = new ConstructTreeFromTraversal();
    //Programs.Trees.Node root = t.Generate(new int[] { 10, 5, 6, 12, 4 }, new int[] { 5, 10, 12, 6, 4 });
    //t.PreOrderTraversal(root);
    public class ConstructTreeFromTraversal
    {
        private int[] preOrderList;
        private int[] inOrderList;
        private int preOrderIndex;

        public Node Generate(int[] inOrderList, int[] preOrderList)
        {
            this.preOrderList = preOrderList;
            this.inOrderList = inOrderList;
            return GenerateTree(0, inOrderList.Length - 1);
        }

        private Node GenerateTree(int start, int end)
        {
            if (start > end)
                return null;

            Node node = new Node();
            node.data = preOrderList[preOrderIndex++];

            if (start == end)
                return node;

            int foundIndex = GetElementIndex(node.data, start, end);

            if(foundIndex > -1)
            {
                node.leftChild = GenerateTree(start, foundIndex - 1);
                node.rightChild = GenerateTree(foundIndex + 1, end);
            }

            return node;
        }

        private int GetElementIndex(int element, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (element == inOrderList[i])
                    return i;
            }
            return -1;
        }

        public void PreOrderTraversal(Node n)
        {
            if (n != null)
            {
                Console.Write(n.data + " ");
                PreOrderTraversal(n.leftChild);
                PreOrderTraversal(n.rightChild);
            }
        }
    }
}
