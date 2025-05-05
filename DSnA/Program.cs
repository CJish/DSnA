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
            CompareAll.CompareAllSorts(100, 100000);










            //// Riley contributed the code below this line
            //Console.WriteLine("Algorithms Performance Test\n");
            //AlgorithmTest.TestRun(10000);
            //AlgorithmTest.TestRun(20000);

            //Console.WriteLine("\nReal World Application\n");
            //AlgorithmTest.RealWorldApplication();

            //Console.WriteLine("Data Structures Performance Test\n");
            //BinarySearchTreeTest.TestRun(10000);
            //BinarySearchTreeTest.TestRun(20000);

            //Console.WriteLine("\nReal World Application\n");
            //BinarySearchTreeTest.RealWorldApplication();

            /* The method InsertionSortSLL() isn't working properly with
             * the benchmark testing. It keeps throwing up error 
             * System.ArgumentException: Objects are not comparable
             * even though the method itself properly sorts all of the 
             * Singly Linked Lists I've thrown at it.
             * 
             * Uncomment the var summary = BenchmarkRunner line and all of 
             * the methods with [Benchmark] throughout the classes to run the benchmark
             */

            //var summary = BenchmarkRunner.Run<AlgorithmsBenchmarks>();
        }
    }
}
