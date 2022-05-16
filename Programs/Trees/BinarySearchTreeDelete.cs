using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees
{
    public class BinarySearchTreeDelete
    {
        Node root;
        public BinarySearchTreeDelete(Node root)
        {
            this.root = root;
        }

        public void DeleteElement(int element)
        {
            Delete(root, element);
        }

        // TC O(logn) -> depends on height of a tree. 
        private Node Delete(Node node, int key)
        {
            if (node == null) return null;

            if (IsLeafNode(node) && node.data == key)
            {
                if (node == root)
                {
                    root = null;
                }
                return null;
            }
            else
            {
                if (key < node.data)
                {
                    node.leftChild = Delete(node.leftChild, key);
                }
                else if (key > node.data)
                {
                    node.rightChild = Delete(node.rightChild, key);
                }
                else
                {
                    if (Height(node.leftChild) >= Height(node.rightChild))
                    {
                        Node q = InOrderPredessor(node.leftChild);
                        node.data = q.data;
                        node.leftChild = Delete(node.leftChild, q.data);
                    }

                    else if (Height(node.rightChild) > Height(node.leftChild))
                    {
                        Node q = InOrderSuccessor(node.rightChild);
                        node.data = q.data;
                        node.rightChild = Delete(node.rightChild, q.data);
                    }
                }

                return node;

            }
        }

        private static bool IsLeafNode(Node node)
        {
            return node.leftChild == null && node.rightChild == null;
        }

        //left most child of right subtree of root.
        private Node InOrderSuccessor(Node node)
        {
            while (node != null && node.leftChild != null)
            {
                node = node.leftChild;
            }

            return node;
        }

        //right most child of left subtree of root.
        private Node InOrderPredessor(Node node)
        {
            while (node != null && node.rightChild != null)
            {
                node = node.rightChild;
            }

            return node;
        }

        private int Height(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            int x = Height(node.leftChild);
            int y = Height(node.rightChild);

            return x > y ? x + 1 : y + 1;
        }
    }
}
