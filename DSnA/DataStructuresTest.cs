using DSnA.DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA
{
    // 
    internal class DataStructuresTest
    {
        public static void Performance(int size)
        {
            Console.WriteLine($"Searching in an array of {size} integers: ");

            int[] array = GenerateRandomArray(size);

            BinarySearchTree bst = new BinarySearchTree();
            foreach (int value in array)
            {
                bst.Insert(value);
            }
            SinglyLinkedList sll = new SinglyLinkedList();
            for (int i = 0; i < array.Length; i++)
                sll.InsertFirst(array[i]);

            Random random = new Random();
            int target = array[random.Next(array.Length)];
            Stopwatch sw = new Stopwatch();

            sw.Start();
            LinearSearch(array, target);
            sw.Stop();
            Console.WriteLine($"Array search time: {sw.ElapsedTicks} ticks");

            sw.Restart();
            bst.Search(target);
            sw.Stop();
            Console.WriteLine($"Binary Tree search time: {sw.ElapsedTicks} ticks");

            sw.Restart();
            sll.Search(target);
            sw.Stop();
            Console.WriteLine($"Singly Linked List search time: {sw.ElapsedTicks} ticks");
        }

        public static void Application(int numberOfStudents)
        {
            Console.WriteLine($"Loading {numberOfStudents} students... ");

            int[] studentIDs = GenerateRandomArray(numberOfStudents);

            BinarySearchTree studentTree = new BinarySearchTree();
            foreach (int id in studentIDs)
                studentTree.Insert(id);

            SinglyLinkedList sll = new SinglyLinkedList();
            for (int i = 0; i < studentIDs.Length; i++)
                sll.InsertFirst(studentIDs[i]);

            Random random = new Random();
            int targetID = studentIDs[random.Next(studentIDs.Length)];
            Console.WriteLine($"Searching for Student ID: {targetID}");
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("\nArray Linear Search:");
            sw.Start();
            bool foundInArray = LinearSearch(studentIDs, targetID);
            sw.Stop();
            Console.WriteLine($"Array Search Time: {sw.ElapsedTicks} ticks");
            Console.WriteLine($"Student ID found in array: {foundInArray}");

            Console.WriteLine("\nBinary Search Tree:");
            sw.Restart();
            bool foundInTree = studentTree.Search(targetID);
            sw.Stop();
            Console.WriteLine($"Binary Search Tree time: {sw.ElapsedTicks} ticks");
            Console.WriteLine($"Student ID found in tree: {foundInTree}");

            Console.WriteLine("\nSingly Linked List:");
            sw.Restart();
            bool foundInList = sll.Search(targetID);
            sw.Stop();
            Console.WriteLine($"Singly Linked List time: {sw.ElapsedTicks} ticks");
            Console.WriteLine($"Student ID found in tree: {foundInTree}");
        }

        static int[] GenerateRandomArray(int size)
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
