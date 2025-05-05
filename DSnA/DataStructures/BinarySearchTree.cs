using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA.DataStructures
{
    // Riley contributed this code
    public class BSNode
    {
        public int Value;
        public BSNode Left, Right;

        public BSNode(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }

    public class BinaryTreeTest
    {
        private BSNode root;
        private Random random = new Random();

        public void Insert(int value)
        {
            root = InsertRecursive(root, value);
        }

        private BSNode InsertRecursive(BSNode node, int value)
        {
            if (node == null)
            {
                return new BSNode(value);
            }
            if (value < node.Value)
            {
                node.Left = InsertRecursive(node.Left, value);
            }
            else
            {
                node.Right = InsertRecursive(node.Right, value);
            }
            return node;
        }

        public bool Search(int value)
        {
            return SearchRecursive(root, value);
        }

        private bool SearchRecursive(BSNode node, int value)
        {
            if (node == null)
            {
                return false;
            }
            if (value == node.Value)
            {
                return true;
            }
            else if (value < node.Value)
            {
                return SearchRecursive(node.Left, value);
            }
            else
            {
                return SearchRecursive(node.Right, value);
            }
        }
    }
}
