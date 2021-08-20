using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangol.Tutorial.General
{
  public class MultiDimensionalArray
    {
      [runnable]
        public static void Run()
        {
            int[,] multi = new int[3, 4];// { { 2, 3 }, { 1, 3 }, { 3, 6 }, { 5, 2 } };
            int[,] show = new int[3, 4];
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    multi[i, j] = i;
                    show[i, j] = (i + 1) + (j + 1);
                    Console.WriteLine("Array :[{0},{1}]={2}", i, j, show[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
}
