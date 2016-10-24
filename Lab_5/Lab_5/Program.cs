using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Program
    {
        static int N = 20;
        static int min;
        private static int plus;
        static int[] arr1 = new int[N];
        static Random rnd = new Random();
        static int[] arr2 = new int[] { 1, 2, -3, -4, 5, -6, 7, 8, -9, 10, 11, 12, -13, 14, -15 };
        static int[] arr3 = new int[N];
        static int[] arr4 = new int[N];
        
        static void WriteFile()
        {
            using (StreamWriter file = new StreamWriter("file.txt"))
            {
                int s=0, g=0, hm,jp, ap;
                for (int i = 0; i < N; i++)
                {
                    arr1[i] = rnd.Next(N);
                    file.WriteLine( "arr1 {0} \t", arr1[i]);
                }
                foreach (int i in arr2)
                {
                    if (i < 0)
                    {
                        arr3[min] = i;
                        min += 1;
                        s += i;
                        
                        file.WriteLine("arr3 {0}  \t", i);
                    }
                    else
                    {
                        arr4[plus] = i;
                        plus += 1;
                        g += i;
                        file.WriteLine(" \t arr4 {0} ", i);
                    }
                    
                }
                hm = s / min;
                jp = g/plus;
                ap = ((g + s)/(plus + min));
                file.WriteLine("Сумма положительных {0} \t Сумма отрицательных {1}", g, s);
                file.WriteLine("Количество положительных {0} \t Количество отрицательных {1}", plus, min);
                file.WriteLine("Среднее арифметическое положительных {0} \t Среднее арифметическое отрицательных {1}", jp, hm);
                file.WriteLine("Среднее арифметическое всего массива {0}", ap);
            }
        }
        static void Main()
        {
            
            WriteFile();
            
        }
    }
}
