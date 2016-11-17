using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //объявление основных данных
        public static int x = 15;
        public static int y = 15;
        public static string O = "O";

        const string wall = "▓"; // узри же константы
        const string empty = " ";

        public static string[,] box = new string[30, 20]; // размер сделай по-меньше



        //генерация карты
        //public static string[,] GenMap(string[,] arr1) // зачем? У нас есть массив box
        public static void GenMap()
        {
            // неправильно
            //for (int i = 0; i < 100; i++)
            //{
            //    string l = "▓";
            //    string h = "9";
            //    arr1[i, i] = l;
            //    for (int j = 0; j < 100; j++)
            //    {
            //        arr1[i, j] = l;
            //        //if (j > 10 && j < 25)
            //        //{
            //        //    arr1[i, i] = h;
            //        //}
            //    }

            //}

            

            Random r = new Random();
            for (int i = 0; i < box.GetLength(0); i++)
            {
                for (int j = 0; j < box.GetLength(1); j++)
                {
                    if (r.Next(10) > 5)
                    {
                        box[i, j] = wall;
                    }
                    else
                    {
                        box[i, j] = empty;
                    }
                }
            }
        }

        //отрисовка карты 
        public static void ShowMap(string[,] arr)
        {
            /*for (int t = 0; t < 100; t++)
            {
                Console.Write("\n");
                for (int i = 0; i < 19; i++) { Console.Write(" "); }
                for (int i = 20; i < 100; i++) { Console.Write(arr[t, t]); }
            }*/ 

            // это было неправильно

            // Рисует сгенерированную карту
            var horiz = Math.Max(Console.BufferWidth, arr.GetLength(0));
            var vert = Math.Max(Console.BufferHeight, arr.GetLength(1));

            Console.SetBufferSize(horiz, vert);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(arr[i, j]);
                }
            }
        }

        //горизонтальные дорожки
        public static void DrawHL(string[,] arr, int a, int b, int c, int d, int e)
        {
            int v = 0;
            int g = 0;
            Console.SetCursorPosition(x + 3, y);

            for (int i = 0; i < a; i++)
            { Console.Write(" a" + i); } //ставлю буковки чтоб видеть где что сработало
            Console.SetCursorPosition(x + 10, y + 5);
            for (int i = 0; i < b; i++)
            { Console.Write(" b" + i); }
            Console.SetCursorPosition(x + 30, y + 10);
            for (int i = 0; i < c; i++)
            { Console.Write(" c" + i); }
            Console.SetCursorPosition(x + 50, y + 15);
            for (int i = 0; i < d; i++)
            { Console.Write(" d" + i); }
            Console.SetCursorPosition(x + 70, y + 17);
            for (int i = 0; i < e; i++)
            { Console.Write(" e" + i); }
        }

        //вертикальные дорожки
        public static void DrawVL(string[,] arr)
        {
            Console.SetCursorPosition(x + 3, y);
            for (int i = 0; i < 10; i++)
            {
                string g = "g";
                y = 20;
                x = i;
                arr[i, y] = g;
                Console.Write(arr[i, y]);
            }
        }



        // ползающий символ
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
                Console.SetCursorPosition(x, y);
                Console.Write(O);
            }
        }

        /// ///////////////////////////////////////////////////////////////////////////////////





        //////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            GenMap();
            ShowMap(box);
            //DrawHL(box, 10, 10, 10, 10, 10);
            //DrawVL(box);
            Push();
            Console.ReadLine();
        }



    }
}

