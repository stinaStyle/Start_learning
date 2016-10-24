using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static int Fact(int number)
        {           
            int f = 1;
            for (int i = 1; i <= number; i++)
            {
                f *= i;                 
            }
            return f;
        }
        static void Main(string[] args)
        {
            using (StreamWriter file = new StreamWriter("factorial.txt"))
            {
                int number = int.Parse(Console.ReadLine());
                Fact(number);
                
                file.WriteLine("fact = {0}", f);
                int hands = 1+2+3+4+5;
                file.WriteLine("Вручную n = {0}", hands);
            }
        }
    }
}
