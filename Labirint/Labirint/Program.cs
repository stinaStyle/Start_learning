using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{

    class Program
    {
        public static int x = 15;
        public static int y = 15;
        public static string O = "O";
        public static string[,] box = new string[100, 100];

        public static string[,] GenMap(string[,] arr1)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {   string l = "#";
                    string h = "9";
                    arr1[i, i] = l;
                    if (j > 10 && j < 25)
                    {
                        arr1[i, i] = h;
                    }
                }
                
            }
            //Console.SetCursorPosition(x, y);
            
          
            return arr1;
        }

        public static void ShowMap(string[,] arr)
        {
            for (int t = 0; t < 100; t++)
            {
                Console.Write(arr[t, t] + "\n");
                for (int i = 0; i < 100; i++) { Console.Write(arr[t, t]);}
            }
        }
        public static void Push()
        {
            
            while (true)
            {
                ConsoleKeyInfo pr = Console.ReadKey(false);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" ");
                switch (pr.Key)
                {
                    case ConsoleKey.UpArrow: y--; break;
                    case ConsoleKey.DownArrow: y++; break;
                    case ConsoleKey.LeftArrow: x--; break;
                    case ConsoleKey.RightArrow: x++; break;
                }
                if (x < 0) x = 15;
                if (y < 0) y = 15;
                Console.SetCursorPosition(x,y);
                Console.Write(O);
            }
        }
        
        static void Main(string[] args)
        {
            GenMap(box);
            ShowMap(box);
            Push();
            Console.ReadLine();
        }
    }
}
