using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Trees.AVL
{
    public class DeleteNodeFromAVLTree
    {
        private Node root;
        public DeleteNodeFromAVLTree(Node rootNode)
        {
            root = rootNode;
        }

        public Node DeleteElement(int element)
        {
            Delete(root, element);
            return root;
        }
        private Node Delete(Node pointer, int key)
        {
            if(pointer == null)
            {
                return null;
            }

            if(pointer.LeftChild == null && pointer.RightChild == null && pointer.Data == key)
            {
                return null;
            }

            if(key < pointer.Data)
            {
                pointer.LeftChild = Delete(pointer.LeftChild, key);
            }
            else if(key > pointer.Data)
            {
                pointer.RightChild = Delete(pointer.RightChild, key);
            }
            else if( key == pointer.Data)
            {
                if(GetNodeHeight(pointer.LeftChild) > GetNodeHeight(pointer.RightChild))
                {
                    Node leftPredecessor = InOrderPredecessor(pointer.LeftChild);
                    pointer.Data = leftPredecessor.Data;
                    pointer.LeftChild = Delete(leftPredecessor, leftPredecessor.Data);

                }
                if (GetNodeHeight(pointer.LeftChild) <= GetNodeHeight(pointer.RightChild))
                {
                    Node rightPredecessor = InOrderSuccessor(pointer.RightChild);
                    pointer.Data = rightPredecessor.Data;
                    pointer.RightChild = Delete(rightPredecessor, rightPredecessor.Data);
                }

                pointer.Height = GetNodeHeight(pointer);

                // Balance Factor and Rotation
                if (BalanceFactor(pointer) == 2 && BalanceFactor(pointer.LeftChild) == 1) //L1 Rotation
                    return LLRotation(pointer);
                else if (BalanceFactor(pointer) == 2 && BalanceFactor(pointer.LeftChild) == -1) //L-1 Rotation
                    return LRRotation(pointer);
                else if (BalanceFactor(pointer) == -2 && BalanceFactor(pointer.RightChild) == -1) //R-1 Rotation
                    return RRRotation(pointer);
                else if (BalanceFactor(pointer) == -2 && BalanceFactor(pointer.RightChild) == 1) //L1 Rotation
                    return RLRotation(pointer);
                else if (BalanceFactor(pointer) == 2 && BalanceFactor(pointer.LeftChild) == 0) //L0 Rotation
                    return LLRotation(pointer);
                else if (BalanceFactor(pointer) == 2 && BalanceFactor(pointer.RightChild) == 0) //R0 Rotation
                    return RRRotation(pointer);
                
            }
            return pointer;
        }

        private int GetNodeHeight(Node pointer)
        {
            if (pointer == null)
                return 1;

            int leftSubTreeHeight = pointer.LeftChild != null ? pointer.LeftChild.Height : 0;
            int rightSubTreeHeight = pointer.RightChild != null ? pointer.RightChild.Height : 0;

            return (leftSubTreeHeight > rightSubTreeHeight) ? leftSubTreeHeight + 1 : rightSubTreeHeight + 1;
        }

        private Node InOrderPredecessor(Node pointer)
        {

            while(pointer != null && pointer.RightChild != null)
            {
                pointer = pointer.RightChild;
            }

            return pointer;
            
        }

        private Node InOrderSuccessor(Node pointer)
        {

            while (pointer != null && pointer.LeftChild != null)
            {
                pointer = pointer.LeftChild;
            }

            return pointer;

        }

        private int BalanceFactor(Node pointer)
        {
            if (pointer == null)
                return 0;

            int leftSubTreeHeight = pointer.LeftChild != null ? pointer.LeftChild.Height : 0;
            int rightSubTreeHeight = pointer.RightChild != null ? pointer.RightChild.Height : 0;

            return leftSubTreeHeight - rightSubTreeHeight;
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

            if (pointer == root)
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

            if (pointer == root)
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

            if (pointer == root)
            {
                root = pointerLeftChild;
            }

            return pointerLeftChild;
        }
    }
}
