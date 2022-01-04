using System;

namespace _450._Delete_Node_in_a_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("450. Delete Node in a BST");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private static TreeNode findLastNodeInLeftSubTree(TreeNode root)
        {
            if (root.right == null) return root;
            return findLastNodeInLeftSubTree(root.right);
        }

        private static TreeNode helper(TreeNode root)
        {
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;

            // means both left and right part exist;
            // task is to find last node is left sub tree and right of that should be root.right;

            TreeNode rightChild = root.right;
            TreeNode lastNodeInLeftSubTree = findLastNodeInLeftSubTree(root.left);
            lastNodeInLeftSubTree.right = rightChild;
            return root.left;
        }

        // TC -> O(logN) -> Log N base 2
        // SC -> O(1)
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key) return helper(root);
            TreeNode dummy = root;

            while (root != null)
            {
                if (root.val > key)
                {// go left side
                    if (root.left != null && root.left.val == key)
                    {
                        root.left = helper(root.left);
                        break;
                    }
                    else
                    {
                        root = root.left;
                    }
                }
                else
                {// go ti right side
                    if (root.right != null && root.right.val == key)
                    {
                        root.right = helper(root.right);
                        break;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
            }
            return dummy;
        }
    }
}
