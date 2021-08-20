using EvanDangol.Reflection;
using System;
namespace EvanDangol.Tutorial.General
{
    #region BubbleSort
    class BubblesortClass
    {
        private int[] arr;
        private int upper;
        private int numElements = -1;//initial
        public BubblesortClass()
        {
            numElements = 0;
        }
        public BubblesortClass(int size)
        {
            arr = new int[size];//populate array with something
            upper = size - 1;
            numElements = 0;
        }
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }
        public void DisplayElements()
        {
            for (int i = 0; i <= upper; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public void Clear()
        {
            for (int i = 0; i <= upper; i++)
                arr[i] = 0;
            numElements = 0;
        }
        public void BubbleSort()
        {
            int temp;
            for (int outer = upper; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1; inner++)
                    if ((int)arr[inner] > arr[inner + 1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                    }
                this.DisplayElements();//to show sorting in progress
            }
        }
    }
    public class ArrayClass
    {
        [runnable]
        public static void ArrayTesterEntry()
        {
            BubblesortClass nums = new BubblesortClass(10);
            Random rnd = new Random(100);
            for (int i = 0; i < 10; i++)
                nums.Insert((int)(rnd.NextDouble() * 100));
            Console.WriteLine("Before sorting: ");
            nums.DisplayElements();
            Console.WriteLine("\nDuring sorting: ");
            nums.BubbleSort();
            Console.WriteLine("\nAfter sorting: ");
            nums.DisplayElements();
        }
    }
    #endregion
}
