using System;

namespace _701._Insert_into_a_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("701. Insert into a Binary Search Tree");
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

        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            TreeNode cur = root;

            while (true)
            {
                // if (cur.val < val) will also work
                if (cur.val <= val)
                {
                    if (cur.right != null) 
                        cur = cur.right;
                    else
                    {
                        cur.right = new TreeNode(val);
                        break; // IMP -> otherwise infinite loop
                    }
                }
                else
                {
                    if (cur.left != null)
                        cur = cur.left;
                    else
                    {
                        cur.left = new TreeNode(val);
                        break;
                    }
                }
            }
            return root;
        }
    }
}
