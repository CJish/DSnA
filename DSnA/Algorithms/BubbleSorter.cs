
﻿namespace DSnA.Algorithms
{
    // Riley contributed this code
    public static class BubbleSorter
    {
        public static void BubbleSort(int[] arr)
        {

            int upper = arr.Length;
            for (int outer = upper - 1; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    if (arr[inner] > arr[inner + 1])
                    {
                        Swap(ref arr[inner], ref arr[inner + 1]);
                    }
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {


            int temp = a;
            a = b;
            b = temp;
        }
        static void PrintAll(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
