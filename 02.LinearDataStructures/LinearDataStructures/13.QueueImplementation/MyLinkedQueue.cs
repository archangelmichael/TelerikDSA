namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class MyLinkedQueue<T>
    {
        private LinkedList<T> queueList;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MyLinkedQueue()
        {
            this.queueList = new LinkedList<T>();
        }

        /// <summary>
        /// The number of elements in the queue
        /// </summary>
        public int Count 
        { 
            get 
            { 
                return this.queueList.Count; 
            } 
        }

        /// <summary>
        /// Adds an element to the back of the queue
        /// </summary>
        /// <param name="item">The element to add at the end</param>
        public void Enqueue(T item)
        {
            this.queueList.AddLast(item);
        }

        /// <summary>
        /// Gets the first element in the queue WITHOUT removing it
        /// </summary>
        /// <returns>The first element in the queue</returns>
        public T Peek()
        {
            if (this.queueList.Count == 0)
            {
                throw new ArgumentException("The queue is empty!");
            }

            return this.queueList.First.Value;
        }

        /// <summary>
        /// Gets and removes the first element from the queue
        /// </summary>
        /// <returns>The first element in the queue</returns>
        public T Dequeue()
        {
            T itemToGet = this.Peek();
            this.queueList.RemoveFirst();
            return itemToGet;
        }
    }
}
