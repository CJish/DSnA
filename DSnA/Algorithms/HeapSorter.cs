using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA.Algorithms
{
    // Riley contributed this code
    public static class HeapSortTest
    {
        public static void HeapSort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int heapSize, int rootIndex)
        {
            int large = rootIndex;
            int left = 2 * rootIndex + 1;
            int right = 2 * rootIndex + 2;

            if (left < heapSize && array[left] > array[large])
            {
                large = left;
            }
            if (right < heapSize && array[right] > array[large])
            {
                large = right;
            }
            if (large != rootIndex)
            {
                int swap = array[rootIndex];
                array[rootIndex] = array[large];
                array[large] = swap;

                Heapify(array, heapSize, large);
            }
        }
    }
}
