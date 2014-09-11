namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Cannot sort null collection!");
            }

            MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeArray(IList<T> arr, int start, int mid, int end)
        {
            /* Create a temporary array for stroing merged array (Length of temp array will be 
             * sum of size of both array to be merged)*/
            IList<T> temp = new List<T>(end - start + 1);

            int i = start, j = mid + 1, k = 0;
            // Now traverse both array simultaniously and store the smallest element of both to temp array
            while (i <= mid && j <= end)
            {
                if (arr[i].CompareTo(arr[j]) < 0)
                {
                    temp.Add(arr[i]);
                    k++;
                    i++;
                }
                else
                {
                    temp.Add(arr[j]);
                    k++;
                    j++;
                }
            }
            // If there is any element remain in first array then add it to temp array
            while (i <= mid)
            {
                temp.Add(arr[i]);
                k++;
                i++;
            }
            // If any element remain in second array then add it to temp array
            while (j <= end)
            {
                temp.Add(arr[j]);
                k++;
                j++;
            }
            // Now temp has merged sorted element of both array

            // Traverse temp array and store element of temp array to original array
            k = 0;
            i = start;
            while (k < temp.Count && i <= end)
            {
                arr[i] = temp[k];
                i++;
                k++;
            }
        }

        // Recursive Merge Procedure
        private void MergeSort(IList<T> arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (end + start) / 2;
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);
                MergeArray(arr, start, mid, end);
            }
        }
    }

}
