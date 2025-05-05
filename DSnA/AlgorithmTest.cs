using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSnA.Algorithms;

namespace DSnA
{
    // Riley contributed this code
    public class AlgorithmTest
    {
        public static void Performance(int size)
        {
            Console.WriteLine($"Sorting an array of {size} integers: ");

            int[] bubbleArray = GenerateRandomArray(size);
            int[] heapArray = (int[])bubbleArray.Clone();
            int[] insertionArray = (int[])bubbleArray.Clone();
            int[] mergeArray = (int[])bubbleArray.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSorter.BubbleSort(bubbleArray);
            stopwatch.Stop();
            Console.WriteLine($"Bubble sort time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            HeapSorter.HeapSort(heapArray);
            stopwatch.Stop();
            Console.WriteLine($"Heap sort time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            InsertionSortTest.InsertionSortArray(insertionArray);
            stopwatch.Stop();
            Console.WriteLine($"Insertion sort time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            MergeSorter.MergeSort(mergeArray);
            stopwatch.Stop();
            Console.WriteLine($"Merge sort time: {stopwatch.ElapsedTicks} ticks");
        }

        public static void Application(int numberOfProducts)
        {
            Console.WriteLine($"Loading {numberOfProducts} product prices...");

            Stopwatch stopwatch = new Stopwatch();
            int[] prices = GenerateRandomArray(numberOfProducts);
            int[] bubblePrices = (int[])prices.Clone();
            int[] heapPrices = (int[])prices.Clone();

            Console.Write("\nSorting prices using Bubble Sort: ");
            stopwatch.Start();
            BubbleSorter.BubbleSort(bubblePrices);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedTicks} ticks");
            Console.WriteLine("Five Cheapest Prices after Bubble Sort:");
            DisplayTop5Prices(bubblePrices);

            Console.Write("\nSorting prices using Heap Sort: ");
            stopwatch.Restart();
            HeapSorter.HeapSort(heapPrices);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedTicks} ticks");
            Console.WriteLine("Five Cheapest Prices after Heap Sort:");
            DisplayTop5Prices(heapPrices);

            Console.Write("\nSorting prices using Insertion Sort: ");
            stopwatch.Restart();
            InsertionSortTest.InsertionSortArray(heapPrices);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedTicks} ticks");
            Console.WriteLine("Five Cheapest Prices after Insertion Sort:");
            DisplayTop5Prices(heapPrices);

            Console.Write("\nSorting prices using Merge Sort: ");
            stopwatch.Restart();
            MergeSorter.MergeSort(heapPrices);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedTicks} ticks");
            Console.WriteLine("Five Cheapest Prices after Merge Sort:");
            DisplayTop5Prices(heapPrices);
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(10000);
            }
            return array;
        }

        static void DisplayTop5Prices(int[] prices)
        {
            for (int i = 0; i < Math.Min(5, prices.Length); i++)
            {
                Console.WriteLine($"#{i + 1}: ${prices[i]}");
            }
        }
    }
}
