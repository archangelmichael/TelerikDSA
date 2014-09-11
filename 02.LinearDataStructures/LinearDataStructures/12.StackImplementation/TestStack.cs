namespace _12.StackImplementation
{
    using System;
    /*
     * Implement the ADT stack as auto-resizable array. 
     * Resize the capacity on demand (when no space is available to add / insert a new element).
     */
    public class TestStack
    {
        public static void Main(string[] args)
        {
            MyStack<int> testAutoResizableStack = new MyStack<int>();
            testAutoResizableStack.Push(23);
            testAutoResizableStack.Push(2);
            Console.WriteLine("Current top element: " + testAutoResizableStack.Peek());
            testAutoResizableStack.Pop();
            Console.WriteLine("Size: " + testAutoResizableStack.Count);
            testAutoResizableStack.Push(23);
            testAutoResizableStack.Push(2);
            testAutoResizableStack.Push(23);
            testAutoResizableStack.Push(2);
            Console.WriteLine("Size: " + testAutoResizableStack.Count);
        }
    }
}
