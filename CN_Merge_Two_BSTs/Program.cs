using System;
using System.Collections.Generic;

namespace CN_Merge_Two_BSTs
{
    class Program
    {
        public class TreeNode<T>
        {
            public T data;
            public TreeNode<T> left;
            public TreeNode<T> right;

            public TreeNode(T data)
            {
                this.data = data;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("CN_Merge_Two_BSTs");
        }

        private static void convertBSTTOInorder(TreeNode<int> root, List<int> list)
        {
            if (root == null) return;

            convertBSTTOInorder(root.left, list);
            list.Add(root.data);
            convertBSTTOInorder(root.right, list);
        }

        private static List<int> mergeTwosortedLinkedList(List<int> list1, List<int> list2)
        {
            List<int> ans = new List<int>();
            int n = list1.Count;
            int m = list2.Count;
            int i = 0, j = 0;

            while (i < n && j < m)
            {
                if (list1[i] < list2[j])
                {
                    ans.Add(list1[i]);
                    i++;
                }
                else
                {
                    ans.Add(list2[j]);
                    j++;
                }
            }

            while (i < n)
            {
                ans.Add(list1[i]);
                i++;
            }

            while (j < m)
            {
                ans.Add(list2[j]);
                j++;
            }

            return ans;
        }

        private static TreeNode<int> inorderToBST(int s, int e, List<int> inOrder)
        {
            if (s > e)
            {
                return null;
            }

            int mid = (s + e) / 2;
            TreeNode<int> root = new TreeNode<int>(inOrder[mid]);
            root.left = inorderToBST(s, mid - 1, inOrder);
            root.right = inorderToBST(mid + 1, e, inOrder);

            return root;
        }

        public static TreeNode<int> mergeBST(TreeNode<int> root1, TreeNode<int> root2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            // step 1
            convertBSTTOInorder(root1, list1);
            convertBSTTOInorder(root2, list2);

            // step 2
            // merge two sorted linkedList
            List<int> ans = mergeTwosortedLinkedList(list1, list2);

            // step 3
            // inorder to Balanced BST
            return inorderToBST(0, ans.Count - 1, ans);
        }

    }
}
