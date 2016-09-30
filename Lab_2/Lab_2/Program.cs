using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 250;
            Console.WriteLine(value);
            Console.WriteLine("value = {0, 5}", value);
            int a = -12;
            int b = 20;
            Console.WriteLine("a = {0, 4}  b = {1, 3}", a, b);
            double myDouble = 1234.56789;
            Console.WriteLine("myDouble = {0, 10:f3}", myDouble);
            float myFloat = 1234.56789f;
            var л = 1.2365f;
            Console.Write(л.GetType().Name);
            Console.WriteLine("{0:C}", 123.342);
            Console.WriteLine("myFloat = {0, 10:f3}", myFloat);
            decimal myDecimal = 1234.56789m;
            Console.WriteLine("myDecimal = {0, 10:f3}", myDecimal);
            Console.WriteLine("{0:C}", 123.342);
            var s = string.Format("{0:C}", 123.342);
            Console.WriteLine(s);
            Console.ReadLine();



            /////////////////////////////////////////////////////////////
            /// 

            string e;
            double r, t;
            StreamWriter f = new StreamWriter("out.txt");
            StreamWriter f1 = new StreamWriter("in.txt");
            f.WriteLine("test your luck");



        }
    }
}
