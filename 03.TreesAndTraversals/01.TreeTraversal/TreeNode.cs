namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value, TreeNode<T> parent = null)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
            this.Parent = parent;
        }

        public bool HasParent
        {
            get
            {
                return this.Parent != null;
            }
        }

        public T Value { get; set; }

        public List<TreeNode<T>> Children { get; private set; }

        public TreeNode<T> Parent { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        // Iterates over the children and parent of the node
        public IEnumerable<TreeNode<T>> Adjacent()
        {
            if (this.Parent != null)
            {
                yield return this.Parent;
            }

            foreach (var child in this.Children)
            {
                yield return child;
            }
        }

        // Prints the node and all its children
        public void PrintTree()
        {
            Console.WriteLine("Tree");
            this.Print(string.Empty, true);
        }

        // Prints the nodes recursively
        private void Print(string prefix, bool isTail)
        {
            Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + this.Value);
            for (int i = 0; i < this.Children.Count - 1; i++)
            {
                this.Children[i].Print(prefix + (isTail ? "    " : "│   "), false);
            }

            if (this.Children.Count >= 1)
            {
                this.Children[this.Children.Count - 1].Print(prefix + (isTail ? "    " : "│   "), true);
            }
        }
    }
}
