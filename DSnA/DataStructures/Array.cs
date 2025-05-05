using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA.DataStructures
{
    // Riley contributed this code
    public static class ArrayTest
    {
        public static int[] InsertElement(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(10000);
            }

            return array;
        }
    }
}
