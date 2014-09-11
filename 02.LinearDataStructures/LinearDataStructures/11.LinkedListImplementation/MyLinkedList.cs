namespace _11.LinkedListImplementation
{
    using System;
    using System.Text;

    public class MyLinkedList<T> 
        where T : IComparable
    {
        private ListItem<T> firstElement;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MyLinkedList()
        {
            this.firstElement = null;
        }

        /// <summary>
        /// The first element from the Linked List
        /// </summary>
        public T FirstElement
        {
            get
            {
                return this.firstElement.Value;
            }
        }

        /// <summary>
        /// Adds an item to the Linked List
        /// </summary>
        /// <param name="element">item to be added</param>
        public void AddItem(T element)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem<T>(element);
            }
            else
            {
                var currentElement = this.firstElement;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }

                currentElement.Next = new ListItem<T>(element);
            }
        }

        /// <summary>
        /// Removes an item from the Linked List
        /// </summary>
        /// <param name="element">item to be remove</param>
        public void RemoveItem(T element)
        {
            if (this.firstElement == null)
            {
                return;
            }

            var currentItem = this.firstElement;
            if (currentItem.Value.CompareTo(element) == 0)
            {
                this.firstElement = currentItem.Next;
                return;
            }

            while (currentItem.Next != null)
            {
                if (currentItem.Next.Value.CompareTo(element) == 0)
                {
                    currentItem.Next = currentItem.Next.Next;
                    return;
                }

                currentItem = currentItem.Next;
            }
        }
    
        /// <summary>
        /// Adds an item at the begining of the Linked List
        /// </summary>
        /// <param name="element">item to be added at the begining</param>
        public void AddFirst(T element)
        {
            var newNode = new ListItem<T>(element);
            newNode.Next = this.firstElement;
            this.firstElement = newNode;
        }

        /// <summary>
        /// Removes an item from the begining of the Linked List
        /// </summary>
        /// <param name="element">item to be removed from the begining</param>
        public void RemoveFirst()
        {
            this.firstElement = this.firstElement.Next;
        }

        public override string ToString()
        {
            if (this.firstElement == null)
            {
                return string.Format("[ ]");
            }

            StringBuilder linkedListElements = new StringBuilder("[ ");
            var currentItem = this.firstElement;
            linkedListElements.Append(currentItem.Value);
            while (currentItem.Next != null)
            {
                linkedListElements.Append(", ");
                linkedListElements.Append(currentItem.Next);
                currentItem = currentItem.Next;
            }

            linkedListElements.Append(" ]");
            return linkedListElements.ToString();
        }
    }
}
