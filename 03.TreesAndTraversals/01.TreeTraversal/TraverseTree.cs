namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class TraverseTree
    {
        private static TreeNode<int>[] nodes;

        private static void Main()
        {
            #if DEBUG
            // Example tree, N-1 pairs of [parent node -> child node]
            Console.SetIn(new StreamReader("../../test0.in.txt"));
            #endif

            ProcessTree();

            /* TASK 1.
            You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1). 
            Write a program to read the tree and find:
            a) the root node */
            var root = FindRoot();
            root.PrintTree();
            Console.WriteLine("a) Root: {0}", root.Value);

            //// b) all leaf nodes
            var leafNodes = FindLeafNodes();
            Console.WriteLine("b) Leaf nodes: {0}", string.Join(", ", leafNodes));

            //// c) all middle nodes
            var middleNodes = FindMiddleNodes();
            Console.WriteLine("c) Middle nodes: {0}", string.Join(", ", middleNodes));

            //// d) the longest path in the tree
            var longestPath = FindLongestPath(root);
            Console.WriteLine("d) Longest path (through the root): {0}", string.Join(", ", longestPath));

            //// e) * all paths in the tree with given sum S of their nodes
            int pathSum = 6;
            Console.WriteLine("e) Paths with sum {0} of their nodes:", pathSum);
            FindPathsWithSum(nodes, pathSum);

            //// f) * all subtrees with given sum S of their nodes 
            int treeSum = 9;
            Console.WriteLine("f) Trees with sum {0} of their nodes:", treeSum);
            FindSubTreesSum(root, treeSum);
        }

        private static TreeNode<int> FindRoot()
        {
            var root = nodes.FirstOrDefault(n => !n.HasParent);
            if (root != null)
            {
                return root;
            }

            throw new ApplicationException("The tree has no root!");
        }

        private static IEnumerable<int> FindLeafNodes()
        {
            return nodes.Where(n => n.Children.Count == 0).Select(n => n.Value);
        }

        private static IEnumerable<int> FindMiddleNodes()
        {
            return nodes.Where(n => n.Children.Count != 0 && n.HasParent).Select(n => n.Value);
        }

        private static IEnumerable<int> FindLongestPath(TreeNode<int> root)
        {
            var firstPath = new List<TreeNode<int>>();
            var secondPath = new List<TreeNode<int>>();

            foreach (var child in root.Children)
            {
                var currentPath = MaxPathNodeToLeaf(child);
                if (currentPath.Count > secondPath.Count)
                {
                    if (currentPath.Count > firstPath.Count)
                    {
                        secondPath = firstPath;
                        firstPath = currentPath;
                    }
                    else
                    {
                        secondPath = currentPath;
                    }
                }
            }

            var longestPath = new List<int>();

            for (int i = secondPath.Count - 1; i >= 0; i--)
            {
                longestPath.Add(secondPath[i].Value);
            }

            longestPath.Add(root.Value);

            foreach (var item in firstPath)
            {
                longestPath.Add(item.Value);
            }

            return longestPath;
        }

        private static List<TreeNode<int>> MaxPathNodeToLeaf(TreeNode<int> root)
        {
            var longestPath = new List<TreeNode<int>>();

            var path = new List<TreeNode<int>>();
            path.Add(root);

            var stack = new Stack<List<TreeNode<int>>>();
            stack.Push(path);

            while (stack.Count != 0)
            {
                var currentPath = stack.Pop();
                var lastNode = currentPath[currentPath.Count - 1];

                foreach (var child in lastNode.Children)
                {
                    var newPath = new List<TreeNode<int>>(currentPath);
                    newPath.Add(child);
                    stack.Push(newPath);
                }

                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            return longestPath;
        }

        private static void FindPathsWithSum(TreeNode<int>[] nodes, int targetSum)
        {
            var startNode = new bool[nodes.Length];
            foreach (var node in nodes)
            {
                startNode[node.Value] = true;
                FindPathsFromNode(node, 0, targetSum, new Stack<int>(), node, startNode);
            }
        }

        private static void FindPathsFromNode(TreeNode<int> root, int sum, int target, Stack<int> path, TreeNode<int> previous, bool[] start)
        {
            path.Push(root.Value);
            sum += root.Value;
            if (sum >= target)
            {
                if (sum == target && (path.Count == 1 || !start[root.Value]))
                {
                    Console.WriteLine("Path: {0}", string.Join(" -> ", path));
                }
            }
            else
            {
                foreach (var child in root.Children.Where(c => c != previous))
                {
                    FindPathsFromNode(child, sum, target, path, root, start);
                }

                if (root.Parent != null && root.Parent != previous)
                {
                    FindPathsFromNode(root.Parent, sum, target, path, root, start);
                }
            }

            path.Pop();
        }

        private static int FindSubTreesSum(TreeNode<int> root, int target)
        {
            int subtreeSum = root.Value;
            foreach (var child in root.Children)
            {
                subtreeSum += FindSubTreesSum(child, target);
            }

            if (subtreeSum == target)
            {
                root.PrintTree();
            }

            return subtreeSum;
        }

        private static void ProcessTree()
        {
            int n = int.Parse(Console.ReadLine());
            //// Get Tree Nodes
            nodes = Enumerable.Range(0, n).Select(i => new TreeNode<int>(i)).ToArray();

            //// Connect Nodes
            for (int i = 0; i < n - 1; i++)
            {
                var vertices = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var parent = nodes[vertices[0]];
                var child = nodes[vertices[1]];
                parent.Children.Add(child);
                child.Parent = parent;
            }
        }
    }
}
