using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees
{
    //ConstructBSTFromTraversal bs = new ConstructBSTFromTraversal();
    //bs.Create(new int[] { 30, 20, 10, 15, 25, 40, 50, 45 });
    //bs.InOrderTraversal();
    public class ConstructBSTFromTraversal
    {
        Node root;
        public ConstructBSTFromTraversal()
        {
            root = null;
        }
        public void Create(int[] preOrderList)
        {
            int i = 0;
            Node pointer = null;
            Stack<Node> stack = new Stack<Node>();

            //insert root
            if(root == null)
            {
                Node node = new Node();
                node.data = preOrderList[i++];
                root = node;
                stack.Push(node);
                pointer = node;
            }

            while (i < preOrderList.Length)
            {
                Node node = new Node();
                if (preOrderList[i] < pointer.data)
                {
                    node.data = preOrderList[i++];
                    pointer.leftChild = node;
                    pointer = node;
                }
                else if (preOrderList[i] > node.data)
                {
                    if(IsElementPointerRightChild(preOrderList[i], pointer.data, stack))
                    {
                        node.data = preOrderList[i++];
                        stack.Push(node);
                        pointer.rightChild = node;
                        pointer = node;
                    }
                    else
                    {
                        //element should be added before the pointer node.
                        pointer = stack.Pop();
                    }
                }
            }
        }

        private static bool IsElementPointerRightChild(int element, int pointerData, Stack<Node> stack)
        {
            return stack.Count > 0 && element < stack.Peek().data && element > pointerData || stack.Count == 0;
        }

        private void InOrder(Node node)
        {
            if(node != null)
            {
                InOrder(node.leftChild);
                Console.Write(node.data + " ");
                InOrder(node.rightChild);
            }
        }

        //If tree creation is successful then InOrderTraversal returns nodes in sorted order.
        public void InOrderTraversal()
        {
            InOrder(root);
        }
    }
}
