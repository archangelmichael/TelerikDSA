namespace _01.PriorityQueueImplementation
{
    using System;

    /* Implement a class PriorityQueue<T> based on the data structure "binary heap". */
    public class TestPriorityQueue
    {
        public static void Main(string[] args)
        {
            var newQueue = new PriorityQueue<int>();
            //// TEST ENQUEUE
            newQueue.Enqueue(6);
            newQueue.Enqueue(34);
            newQueue.Enqueue(3);
            newQueue.Enqueue(98);
            //// LOOK TOP ELEMENT
            Console.WriteLine(newQueue.Peek());
            newQueue.Enqueue(1);
            //// REMOVE TOP ELEMENT
            Console.WriteLine(newQueue.Dequeue());
            //// LOOK NEXT ELEMENT
            Console.WriteLine(newQueue.Peek());
            //// CLEAR QUEUE
            newQueue.Clear();
            //// If try to get element from empty queue, an exception will be thrown 
            Console.WriteLine(newQueue.Peek());
        }
    }
}
