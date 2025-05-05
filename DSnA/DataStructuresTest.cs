using DSnA.DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA
{
    // Dominic and Riley created this code
    internal class DataStructuresTest
    {
        public static void Application(int numberOfStudents)
        {
            Console.WriteLine($"Loading {numberOfStudents} students... ");

            int[] studentIDs = Program.GenerateRandomArray(numberOfStudents);

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
            bool foundInArray = Program.LinearSearch(studentIDs, targetID);
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
    }
}
