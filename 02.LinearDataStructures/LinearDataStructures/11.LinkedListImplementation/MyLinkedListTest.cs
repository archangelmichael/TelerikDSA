namespace _11.LinkedListImplementation
{
    using System;
    /*
     *Implement the data structure linked list. 
     *Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). 
     *Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>). 
     */
    public class MyLinkedListTest
    {
        public static void Main(string[] args)
        {
            MyLinkedList<int> testLinkedList = new MyLinkedList<int>();
            testLinkedList.AddItem(23);
            testLinkedList.AddFirst(32);
            Console.WriteLine(testLinkedList);
            testLinkedList.AddItem(22);
            testLinkedList.AddFirst(5);
            Console.WriteLine(testLinkedList);
            testLinkedList.RemoveItem(23);
            testLinkedList.RemoveFirst();
            Console.WriteLine(testLinkedList);
        }
    }
}
