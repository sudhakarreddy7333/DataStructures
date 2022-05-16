using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees.AVL
{
    //https://www.udemy.com/course/datastructurescncpp/learn/lecture/13190664#notes

    //AVLTree at = new AVLTree();
    //at.InsertElement(10);
    //at.InsertElement(20);
    //at.InsertElement(15);
    //at.InsertElement(18);
    //at.InsertElement(14);
    //at.InsertElement(25);
    //at.DeleteElement(18);
    public class AVLTree
    {
        private Node root;

        public AVLTree()
        {
            root = null;
        }

        public void DeleteElement(int element)
        {
            DeleteNodeFromAVLTree d = new DeleteNodeFromAVLTree(root);
            root = d.DeleteElement(element);
        }

        public void InsertElement(int element)
        {
            Insert(root, element);
        }
        private Node Insert(Node pointer, int element)
        {
          
            if(pointer == null)
            {
                Node node = new Node();
                node.Data = element;
                node.Height = 1;

                if(root == null)
                {
                    root = node;
                }

                return node;
            }
            else
            {
                Node node = new Node();
                node.Data = element;
                if (node.Data < pointer.Data)
                {
                    pointer.LeftChild = Insert(pointer.LeftChild, element);
                }
                else if(node.Data > pointer.Data)
                {
                    pointer.RightChild = Insert(pointer.RightChild, element);
                }

                pointer.Height = GetNodeHeight(pointer);

                if (BalanceFactor(pointer) == 2 && BalanceFactor(pointer.LeftChild) == 1) // root is positive and leftchild bf is positive then perform LL Rotation
                    return LLRotation(pointer);
                else if (BalanceFactor(pointer) == 2 && BalanceFactor(pointer.LeftChild) == -1) // root is positive and leftchild bf is negative then perform LR Rotation
                    return LRRotation(pointer);
                else if (BalanceFactor(pointer) == -2 && BalanceFactor(pointer.RightChild) == -1) // root is negative and leftchild bf is negative then perform RR Rotation
                    return RRRotation(pointer);
                else if (BalanceFactor(pointer) == -2 && BalanceFactor(pointer.RightChild) == 1) // root is negative and leftchild bf is positive then perform RL Rotation
                    return RLRotation(pointer);
                return pointer;
            }

        }

        private Node RLRotation(Node pointer)
        {
            Node pointerRightChild = pointer.RightChild;
            Node pointerRightLeftChild = pointerRightChild.LeftChild;

            Node pointerRightLeftLeftChild = pointerRightLeftChild.LeftChild;
            Node pointerRightLeftRightChild = pointerRightLeftChild.RightChild;

            pointerRightLeftChild.RightChild = pointerRightChild;
            pointerRightChild.LeftChild = pointerRightLeftLeftChild;

            pointerRightLeftChild.LeftChild = pointer;
            pointer.RightChild = pointerRightLeftRightChild;

            if(pointer == root)
            {
                root = pointerRightLeftChild;
            }

            pointerRightChild.Height = GetNodeHeight(pointerRightChild);
            pointer.Height = GetNodeHeight(pointer);
            pointerRightLeftChild.Height = GetNodeHeight(pointerRightLeftChild);

            return pointerRightLeftChild;
        }

        private Node RRRotation(Node pointer)
        {
            Node pointerRightChild = pointer.RightChild;
            Node pointerRightLeftChild = pointerRightChild.LeftChild;

            pointerRightChild.LeftChild = pointer;
            pointer.RightChild = pointerRightLeftChild;

            pointer.Height = GetNodeHeight(pointer);
            pointerRightChild.Height = GetNodeHeight(pointerRightChild);

            if(pointer == root)
            {
                root = pointerRightChild;
            }

            return pointerRightChild;
        }

        private Node LRRotation(Node pointer)
        {
            Node pointerLeftChild = pointer.LeftChild;
            Node pointerLeftRightChild = pointerLeftChild.RightChild;

            pointerLeftChild.RightChild = pointerLeftRightChild.RightChild;
            pointer.LeftChild = pointerLeftRightChild.LeftChild;

            pointerLeftRightChild.RightChild = pointer;
            pointerLeftRightChild.LeftChild = pointerLeftChild;

            pointerLeftChild.Height = GetNodeHeight(pointerLeftChild);
            pointerLeftRightChild.Height = GetNodeHeight(pointerLeftRightChild);
            pointer.Height = GetNodeHeight(pointer);

            if (root == pointer)
            {
                root = pointerLeftRightChild;
            }

            return pointerLeftRightChild;
        }

        private Node LLRotation(Node pointer)
        {
            Node pointerLeftChild = pointer.LeftChild;
            Node pointerLeftRightChild = pointerLeftChild.RightChild;
            pointerLeftChild.RightChild = pointer;
            pointer.LeftChild = pointerLeftRightChild;

            pointer.Height = GetNodeHeight(pointer);
            pointerLeftChild.Height = GetNodeHeight(pointer);

            if(pointer == root)
            {
                root = pointerLeftChild;
            }

            return pointerLeftChild;
        }

        private int GetNodeHeight(Node pointer)
        {
            if (pointer == null)
                return 1;

            int leftSubTreeHeight = pointer.LeftChild != null ? pointer.LeftChild.Height : 0;
            int rightSubTreeHeight = pointer.RightChild != null ? pointer.RightChild.Height : 0;

            return (leftSubTreeHeight > rightSubTreeHeight) ? leftSubTreeHeight + 1 : rightSubTreeHeight + 1;
        }

        private int BalanceFactor(Node pointer)
        {
            if (pointer == null)
                return 0;

            int leftSubTreeHeight = pointer.LeftChild != null ? pointer.LeftChild.Height : 0;
            int rightSubTreeHeight = pointer.RightChild != null ? pointer.RightChild.Height : 0;

            return leftSubTreeHeight - rightSubTreeHeight;
        }
    }
}
