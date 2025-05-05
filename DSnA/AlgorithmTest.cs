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
        public static void Application(int numberOfProducts)
        {
            Console.WriteLine($"Loading {numberOfProducts} product prices...");

            Stopwatch stopwatch = new Stopwatch();
            int[] prices = Program.GenerateRandomArray(numberOfProducts);
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

        static void DisplayTop5Prices(int[] prices)
        {
            for (int i = 0; i < Math.Min(5, prices.Length); i++)
            {
                Console.WriteLine($"#{i + 1}: ${prices[i]}");
            }
        }
    }
}
