using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees
{
    public class BinaryTree
    {
        Node root;
        Queue<Node> queue;
        public BinaryTree()
        {
            root = null;
            queue = new Queue<Node>();
        }

        public void Create()
        {
            Console.WriteLine("Enter root element..");
            int.TryParse(Console.ReadLine(), out int rootValue);

            Node rootElement = new Node();
            rootElement.data = rootValue;
            root = rootElement;
            queue.Enqueue(rootElement);

            while(queue.Count != 0)
            {
                Node parent = queue.Dequeue();
                Console.WriteLine($"Enter left child of {parent.data} node. Enter -1 if no node exists");
                int.TryParse(Console.ReadLine(), out int left);

                if(left != -1)
                {
                    Node leftNode = new Node();
                    leftNode.data = left;
                    parent.leftChild = leftNode;
                    queue.Enqueue(leftNode);
                }

                Console.WriteLine($"Enter Right child of {parent.data} node. Enter -1 if no node exists");
                int.TryParse(Console.ReadLine(), out int right);

                if (right != -1)
                {
                    Node rightNode = new Node();
                    rightNode.data = right;
                    parent.rightChild = rightNode;
                    queue.Enqueue(rightNode);
                }
            }
        }

        private void PreOrderTraverse(Node n)
        {
            if(n != null)
            {
                Console.Write(n.data+" ");
                PreOrderTraverse(n.leftChild);
                PreOrderTraverse(n.rightChild);
            }
        }

        private void InOrderTraverse(Node n)
        {
            if (n != null)
            {
                InOrderTraverse(n.leftChild);
                Console.Write(n.data + " ");
                InOrderTraverse(n.rightChild);
            }
        }

        private void PostOrderTraverse(Node n)
        {
            if (n != null)
            {
                PostOrderTraverse(n.leftChild);
                PostOrderTraverse(n.rightChild);
                Console.Write(n.data + " ");
            }
        }

        public void PreOrder()
        {
            Console.WriteLine("PreOrder traversal");
            PreOrderTraverse(root);
            Console.WriteLine();
        }

        public void PreOrderIterative()
        {
            Node n = root;

            Console.WriteLine("Preorder traversal iterative");
            Stack<Node> itStack = new Stack<Node>();

            while(n != null || itStack.Count > 0)
            {
                if(n != null)
                {
                    Console.Write(n.data + " ");
                    itStack.Push(n);
                    n = n.leftChild;
                }
                else
                {
                    Node parent = itStack.Pop();
                    n = parent.rightChild;
                }
            }
        }

        public void InOrderIterative()
        {
            Node n = root;

            Console.WriteLine("InOrder traversal iterative");
            Stack<Node> itStack = new Stack<Node>();
            while (n != null || itStack.Count > 0)
            {
                if (n != null)
                {
                    itStack.Push(n);
                    n = n.leftChild;
                }
                else
                {
                    Node parent = itStack.Pop();
                    Console.Write(parent.data + " ");
                    n = parent.rightChild;
                }
            }
        }

        public void LevelOrder()
        {
            Node n = root;
            Console.WriteLine("LevelOrder traversal iterative");
            Queue<Node> levelQueue = new Queue<Node>();

            Console.Write(n.data + " ");
            levelQueue.Enqueue(n);

            while(levelQueue.Count > 0)
            {
                Node parent = levelQueue.Dequeue();
                if (parent.leftChild != null)
                {
                    Console.Write(parent.leftChild.data + " ");
                    levelQueue.Enqueue(parent.leftChild);
                }
                
                if(parent.rightChild != null)
                {
                    Console.Write(parent.rightChild.data + " ");
                    levelQueue.Enqueue(parent.rightChild);
                }
            }
        }


        public void InOrder()
        {
            Console.WriteLine("Inorder traversal");
            InOrderTraverse(root);
            Console.WriteLine();
        }

        public void PostOrder()
        {
            Console.WriteLine("PostOrder traversal");
            PostOrderTraverse(root);
            Console.WriteLine();
        }
    }

    public class Node
    {
        public Node leftChild;
        public Node rightChild;
        public int data;
        public Node()
        {
            leftChild = null;
            rightChild = null;
        }
    }
}
