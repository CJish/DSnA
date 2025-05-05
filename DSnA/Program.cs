using BenchmarkDotNet.Running;
using DSnA.DataStructures;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System.Diagnostics;

namespace DSnA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Algorithm Performance ---------------------------\n");
            CompareAll.CompareAllSorts(10, 1000);
            Console.WriteLine();
            CompareAll.CompareAllSorts(10, 5000);
            Console.WriteLine();
            CompareAll.CompareAllSorts(10, 20000);

            Console.WriteLine("\nAlgorithm Application -------------------------\n");
            AlgorithmTest.Application(200);

            Console.WriteLine("\nData Structures Performance -------------------\n");
            CompareAll.CompareAllSearch(10, 1000);
            Console.WriteLine();
            CompareAll.CompareAllSearch(10, 5000);
            Console.WriteLine();
            CompareAll.CompareAllSearch(10, 20000);

            Console.WriteLine("\nData Structures Application -------------------\n");
            DataStructuresTest.Application(50);
        }
        public static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1000, 9999);
            }
            return array;
        }
        public static bool LinearSearch(int[] array, int key)
        {
            foreach (int value in array)
            {
                if (value == key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
