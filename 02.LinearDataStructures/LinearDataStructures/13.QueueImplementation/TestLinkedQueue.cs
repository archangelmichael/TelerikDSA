namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*
     * Implement the ADT queue as dynamic linked list. 
     * Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
     */ 
    public class TestLinkedQueue
    {
        public static void Main(string[] args)
        {
            MyLinkedQueue<int> linkedQueue = new MyLinkedQueue<int>();
            linkedQueue.Enqueue(12);
            linkedQueue.Enqueue(34);
            linkedQueue.Enqueue(22);
            Console.WriteLine(linkedQueue.Peek());
            Console.WriteLine(linkedQueue.Dequeue());
            Console.WriteLine(linkedQueue.Peek());
        }
    }
}
