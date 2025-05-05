using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DSnA.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA
{
    // Chris
    public class AlgorithmsBenchmarks
    {
        private int[] arr;
        private List<int> li;
        private SinglyLinkedList sll;
        /*
        [GlobalSetup]
        public void Setup()
        {
            int size = 10000;
            Random rand = new Random();

            arr = new int[size];
            li = new List<int>(size);
            sll = new SinglyLinkedList();

            for (int i = 0; i < size; i++)
            {
                int val = rand.Next(size);
                arr[i] = val;
                li.Add(val);
                sll.InsertLast(new SinglyLinkedList.Node(val));
            }
        }
        [Benchmark]
        public void InsertionSortArray()
        {
            InsertionSort.InsertionSortArray((int[])arr.Clone());
        }

        [Benchmark]
        public void InsertionSortList()
        {
            InsertionSort.InsertionSortList(new List<int>(li));
        }

        [Benchmark]
        public void InsertionSortSLL()
        {
            SinglyLinkedList sllCopy = new SinglyLinkedList();
            SinglyLinkedList.Node temp = sll.First;

            while (temp != null)
            {
                sllCopy.InsertLast(new SinglyLinkedList.Node(temp.Data));
                temp = temp.Next;
            }

            InsertionSort.InsertionSortSLL(sllCopy);
        }
        */
    }
}
