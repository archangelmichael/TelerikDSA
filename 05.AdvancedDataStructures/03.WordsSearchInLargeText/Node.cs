namespace _03.WordsSearchInLargeText
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(char value)
        {
            this.Value = value;
            this.Count = 1;
            this.Children = new Dictionary<char, Node>();
        }

        public char Value { get; set; }

        public int Count { get; set; }

        public Dictionary<char, Node> Children { get; set; }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Node;
            return this.Value.Equals(other.Value);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1} times", this.Value, this.Count);
        }
    }
}
