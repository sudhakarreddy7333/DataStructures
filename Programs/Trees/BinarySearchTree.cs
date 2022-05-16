using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees
{
    //BinarySearchTree bst = new BinarySearchTree();
    //bst.Insert(1);
    //bst.Insert(3);
    //bst.Insert(2);
    //bst.Insert(5);
    //bst.Insert(6);

    //bst.PreOrder();
    //Programs.Trees.Node res = bst.Search(8);
    //if(res != null)
    //{
    //    Console.WriteLine($"Element found {res.data}");
    //}
    //else
    //{
    //    Console.WriteLine("Element not found");
    //}
    public class BinarySearchTree
    {
        Node root;

        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int element)
        {
            Node node = new Node
            {
                data = element
            };

            if (root == null)
            {
                root = node;
            }
            else
            {
                Node parentNode = GetParentNode(node.data);

                if (node.data < parentNode.data)
                {
                    parentNode.leftChild = node;
                }
                else
                {
                    parentNode.rightChild = node;
                }
            }
        }

        public Node Search(int element)
        {
            Node iterator = root;

            while(iterator != null)
            {
                if (iterator.data == element)
                    return iterator;
                else
                {
                    if(element < iterator.data)
                    {
                        iterator = iterator.leftChild;
                    }
                    else
                    {
                        iterator = iterator.rightChild;
                    }
                }
            }
            return null;
        }

        private Node GetParentNode(int element)
        {
            Node iterator = root;
            Node parentNode = root;

            //search where new node needs to be inserted and get its previous node.
            while (iterator != null)
            {
                parentNode = iterator;
                if (element < iterator.data)
                {
                    iterator = iterator.leftChild;
                }
                else
                {
                    iterator = iterator.rightChild;
                }
            }

            return parentNode;
        }

        private void PreOrderTraverse(Node node)
        {
            if(node != null)
            {
                Console.Write(node.data + " ");
                PreOrderTraverse(node.leftChild);
                PreOrderTraverse(node.rightChild);
            }

        }

        public void PreOrder()
        {
            PreOrderTraverse(root);
        }

        public Node GetRoot()
        {
            return root;
        }

        public void Delete(int element)
        {
            BinarySearchTreeDelete d = new BinarySearchTreeDelete(root);
            d.DeleteElement(element);
        }
    }
}
