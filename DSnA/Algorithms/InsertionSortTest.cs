using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace DSnA.Algorithms
{
    // Chris contributed this code
    public class InsertionSortTest
    {
        public static void InsertionSortArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        //[Benchmark]
        public static void InsertionSortCompare(int iterations, int size)
        {
            Stopwatch watch = new Stopwatch();

            double liTime = 0;
            double sllTime = 0;
            double arrTime = 0;

            Random rand = new Random();
            for (int i = 0; i < iterations; i++)
            {
                int[] arr = new int[size];
                for (int j = 0; j < size; j++)
                {
                    arr[j] = rand.Next(size);
                }

                List<int> li = arr.ToList();
                DataStructures.SinglyLinkedListTest sll = DataStructures.SinglyLinkedListTest.CreateListFromArray(arr);

                watch.Start();
                InsertionSortArray(arr);
                watch.Stop();
                arrTime += Convert.ToInt32(watch.ElapsedTicks);
                watch.Reset();

                watch.Start();
                InsertionSortList(li);
                watch.Stop();
                liTime += Convert.ToInt32(watch.ElapsedTicks);
                watch.Reset();

                DataStructures.SinglyLinkedListTest.Print(sll);
                Console.WriteLine("\n");
                watch.Start();
                InsertionSortSLL(sll);
                watch.Stop();
                sllTime += Convert.ToInt32(watch.ElapsedTicks);
                watch.Reset();
                //SinglyLinkedList.Print(sll);
                //Console.WriteLine("\n\n\n");
            }

            double arrAvg = arrTime / iterations;
            double liAvg = liTime / iterations;
            double sllAvg = sllTime / iterations;

            Console.WriteLine($"Total time to sort a randomized sample of {size} numbers {iterations} times in an: ");
            Console.WriteLine($"\t\tARRAY: {arrTime} ticks");
            Console.WriteLine($"\t\tLIST: {liTime} ticks");
            Console.WriteLine($"\t\tSINGLY LINKED LIST: {sllTime} ticks");

            Console.WriteLine($"AVERAGE time to sort {size} numbers {iterations} times in an: ");
            Console.WriteLine($"\t\tARRAY: {arrAvg} ticks");
            Console.WriteLine($"\t\tLIST: {liAvg} ticks");
            Console.WriteLine($"\t\tSINGLY LINKED LIST: {sllAvg} ticks");
        }

        //[Benchmark]
        public static void InsertionSortList(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int current = list[i];
                int j = i - 1;
                while (j >= 0 && list[j] > current)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = current;
            }
        }
        
        // [Benchmark]
        // SLL = Singly Linked List
        public static void InsertionSortSLL(DataStructures.SinglyLinkedListTest sll)
        {
            if (sll.IsEmpty() || sll.Count() <= 1 || sll.First == null) { return; }

            DataStructures.SinglyLinkedListTest.Node sorted = null; // keep track of the sorted portion
            DataStructures.SinglyLinkedListTest.Node current = sll.First;

            while (current != null)
            {
                DataStructures.SinglyLinkedListTest.Node next = current.Next;

                // Only print the comparison if sorted is not null
                if (sorted != null)
                {
                    //Console.WriteLine($"Comparing {current.Data} (type: {current.Data.GetType()}) with {sorted.Data} (type: {sorted.Data.GetType()})");
                }
                else
                {
                    //Console.WriteLine($"Adding {current.Data} to sorted portion (since sorted is null)");
                }

                if (sorted == null || Compare(current.Data, sorted.Data) <= 0)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    DataStructures.SinglyLinkedListTest.Node temp = sorted;
                    while (temp.Next != null && Compare(temp.Next.Data, current.Data) < 0)
                    {
                        temp = temp.Next;
                    }

                    current.Next = temp.Next;
                    temp.Next = current;
                }

                current = next;
            }

            sll.First = sorted;
        }

        public static int Compare(object a, object b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Cannot compare null objects.");
            }

            //Console.WriteLine($"Comparing {a} with {b}");

            // Check if both are comparable
            if (a is IComparable comparableA && b is IComparable comparableB)
            {
                return comparableA.CompareTo(b);
            }

            // Log and throw an error
            Console.WriteLine("Objects are not comparable.");
            throw new ArgumentException($"Objects are not comparable. \n" +
                $"\"Comparing {{current.Data}} (type: {{current.Data.GetType()}}) with {{sorted.Data}} (type: {{sorted.Data.GetType()}})");
        }
    }
}
