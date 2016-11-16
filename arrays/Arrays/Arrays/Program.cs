using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public static class ArrayExtensions
    {
        public static void Change(this int[,] arr, int i,  int q, int y, int w)
        {
            int empty = 0;
            empty = arr[i, q];
            arr[i, q] = arr[y, w];
            arr[y, w] = empty;          

        }
    }
    class Program
    {
        public static void ChangeVLine(int l1, int l2)
        {
            int t = myArr.GetUpperBound(1);
            for (int i = 0; i <= t; i++)
            {
                ArrayExtensions.Change(myArr, l1, i, l2, i);
                
            }
        }
        public static void ChangeHLine(int l1, int l2)
        {
            int t = myArr.GetUpperBound(0);
            for (int i = 0; i <= t; i++)
            {
                ArrayExtensions.Change(myArr, i, l1, i, l2);

            }
        }

        public static void Show(int[,] arr)
        {
            Console.WriteLine("{0}  {1}  {2}  {3}", arr[0, 0], arr[1, 0], arr[2, 0], arr[3,0]);
            Console.WriteLine("{0}  {1}  {2}  {3}", arr[0, 1], arr[1, 1], arr[2, 1], arr[3,1]);
            Console.WriteLine("{0}  {1}  {2}  {3}", arr[0, 2], arr[1, 2], arr[2, 2], arr[3,2]);
            
        }
        public static int[,] myArr = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}, {10, 11, 12} };
        public static int[][] myArr2 = new int[4][];
            

        

       

        static void Main(string[] args)
        {
            myArr2[0] = new int[4];
            myArr2[1] = new int[6];
            myArr2[2] = new int[3];
            myArr2[3] = new int[4];


            Console.WriteLine("--------------------------- myArr");
            Show(myArr);

            
            ChangeVLine(0, 2);
            Console.WriteLine("--------------------------- vert cicle");
            

            Show(myArr);

            Console.WriteLine("--------------------------- right  way");
            ArrayExtensions.Change(myArr, 1, 0, 2, 0);
            ArrayExtensions.Change(myArr, 1, 1, 2, 1);
            ArrayExtensions.Change(myArr, 1, 2, 2, 2);

            Show(myArr);

            Console.WriteLine("--------------------------- horisontal cicle");
            ChangeHLine(0, 2);
            Show(myArr);
            Console.ReadLine();
        }
    }
}
