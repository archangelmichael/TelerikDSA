namespace _11.LinkedListImplementation
{
    public class ListItem<T>
    {
        private T value;

        private ListItem<T> nextItem;

        public ListItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ListItem<T> Next
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
