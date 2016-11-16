using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public static class ArrayExtensions
    {
        public static void Show(this int[,] array)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0 ,5}", array[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int M = 5;
            int N = 6;
            int t;
            int[,] Arr = new int[M, N];
            int[] iArr3 = new int[N];
            Random rnd = new Random();
            int sum = 0;
            int plsum = 0;
            int r = 0;
            Console.WriteLine("массив 1 ");
            for (int i = 0; i < M; i++)
            {

                for (int j = 0; j < N; j++)
                {
                  
                    t = rnd.Next(1, 16);
                    Arr[i, j] = t;
                    iArr3[j] = t;
                    sum = sum + t;
                    
                    if (t>0)
                    {
                        
                        r = r + 1;
                        plsum = (plsum + t);
                    } 
                    
                    Console.BackgroundColor = (ConsoleColor)t;
                    Console.Write("{0 ,5}", t);
                }

                Console.WriteLine();

            }
            plsum = plsum/r;
            Console.WriteLine("-------------------------------------");


            Arr.Show();
            Console.WriteLine(); Console.WriteLine("сумма элементов {0,5}", sum);
            Console.WriteLine(); Console.WriteLine("среднее арифметическое положительных элементов {0,5}", plsum);
            Console.ReadLine();
        }
    }
}


//namespace Example6
//{
//    class Example6_5
//    {
//        static void Main()
//        {
//            int M = 6, N = 8;
//            int i, j, temp;
//            int[,] iArray1 = new int[M, N];
//            int[,] iArray2 = new int[M, N];
//            int[] iArray3 = new int[N];
//            Random rnd = new Random();
//            string strValue = "\n -----------------------------------------";
//            Console.Write("\n ");
//            Console.WriteLine("\n ");
//            Console.WriteLine(strValue);
//            // 􀈛􀈔􀈣􀈢􀈟􀈡􀈙􀈡􀈜􀈙􀀃􀈠􀈔􀈥􀈥􀈜􀈖􀈔
//            for (i = 0; i < M; i++)
//            {
//                for (j = 0; j < N; j++)

//                {
//                    temp = rnd.Next(1, 101);
//                    iArray1[i, j] =
//                    Convert.ToInt32(temp);
//                    iArray2[i, j] =
//                    Convert.ToInt32(temp);
//                    iArray3[j] = iArray1[i, j];
//                }
//                foreach (int jj in iArray3)
//                {
//                    Console.Write("{0, 5}", jj);
//                }
//                Console.Write("\n");
//            }
//            Console.WriteLine(strValue);
//            Console.WriteLine("\n zas: ");
//            Console.WriteLine(strValue);
//            for (j = 0; j < N; j++)
//            {
//                temp = iArray2[2, j];
//                iArray2[2, j] = iArray2[M - 2, j];
//                iArray2[M - 1, j] = temp;
//            }
//            for (i = 0; i < M; i++)
//            {
//                for (j = 0; j < N; j++)

//                {
//                    iArray3[j] = iArray2[i, j];
//                }
//                foreach (int jj in iArray3)
//                {
//                    Console.Write("{0, 5}", jj);
//                }
//                Console.Write("\n");
//            }
//            Console.WriteLine(strValue);
//            Console.WriteLine();
//            Console.WriteLine();
//        }
//    }
//}

