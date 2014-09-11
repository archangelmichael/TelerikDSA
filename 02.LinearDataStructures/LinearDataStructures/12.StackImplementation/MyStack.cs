namespace _12.StackImplementation
{
    using System;

    /// <summary>
    /// Implements stack with autoresizable array
    /// </summary>
    /// <typeparam name="T">The type of elements to store in my stack</typeparam>
    public class MyStack<T>
    {
        private const int InitialSize = 4;

        private T[] array;
        private int pointer;

        /// <summary>
        /// Default stack constructor
        /// </summary>
        public MyStack() : this(InitialSize) 
        { 
        }

        /// <summary>
        /// Constructor with given initial stack size
        /// </summary>
        /// <param name="initialSize"> the initial size of the stack</param>
        public MyStack(int initialSize)
        {
            this.array = new T[initialSize];
            this.pointer = 0;
        }

        /// <summary>
        /// the size of the stack
        /// </summary>
        public int Count 
        {
            get { return this.pointer; }
        }

        /// <summary>
        /// Puts the given element at the top of the stack
        /// </summary>
        /// <param name="element">the element to be put at the top of the stack</param>
        public void Push(T element)
        {
            if (this.pointer == this.array.Length)
            {
                this.AutoGrow();
            }

            this.array[this.pointer] = element;
            this.pointer++;
        }

        /// <summary>
        /// Gets the top element added last and removes it from the stack
        /// </summary>
        /// <returns>the last element added</returns>
        public T Pop()
        {
            this.pointer--;
            return this.Peek();
        }

        /// <summary>
        /// Shows the top element added last
        /// </summary>
        /// <returns>the last element added</returns>
        public T Peek()
        {
            if (this.pointer == 0)
            {
                throw new ArgumentException("The stack is empty");
            }

            T objectToReturn = this.array[this.pointer - 1];
            return objectToReturn;
        }

        /// <summary>
        /// Resizes the array used to store all values in the stack by coping its values
        /// in a new array with 2 times bigger length
        /// </summary>
        private void AutoGrow()
        {
            T[] newArray = new T[2 * this.array.Length];
            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}
