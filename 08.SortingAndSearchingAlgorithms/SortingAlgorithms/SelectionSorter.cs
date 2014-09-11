namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Cannot sort null collection!");
            }

            SelectionSort(collection);
        }

        private void SelectionSort(IList<T> collection)
        {
            int i, j, minIndex;
            for (i = 0; i < collection.Count - 1; i++)
            {
                minIndex = i;
                for (j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T tmp = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = tmp;
                }
            }
        }
    }
}
