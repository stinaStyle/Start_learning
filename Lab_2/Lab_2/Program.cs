using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static double CalculateDelta(double x0, double x1)
        {
            double d = ((x1 - (x0))/8);
            return d;
        }

       

        static void Main()
        {
            using (StreamWriter file0 = new StreamWriter(@"D:\Лекции C#\методички\Start_learning\Lab_2\LAB_2.1.txt"))
            {
                file0.WriteLine(-3);
                file0.WriteLine(3);
                file0.WriteLine(2);
                file0.WriteLine(-2);
                file0.WriteLine(2);
                file0.WriteLine(1.57);
                file0.WriteLine(-2);
                file0.WriteLine(4);
                file0.WriteLine(3.14);
            }
            
           


            using (StreamWriter file1 = new StreamWriter(@"D:\Лекции C#\методички\Start_learning\Lab_2\LAB_2.2.txt"))
            {
                //Function 
                Calculate(file1, -3, 3, 2, x => ((1 - (Math.Pow(x, 2))) / (1 + (Math.Pow(x, 4)))), "((1 - (Math.Pow(x, 2))) / (1 + (Math.Pow(x, 4))))");
                Calculate(file1, -2, 2, 1.57, x => (Math.Sin(x)) / ((Math.Pow(x, 2)) - 1), "(Math.Sin(x)) / ((Math.Pow(x, 2)) - 1)");
                Calculate(file1, -2, 4, 3.14, x => (2 * Math.PI) / (Math.Pow(x, 2) - Math.PI), "(2 * Math.PI) / (Math.Pow(x, 2) - Math.PI)");

            }
        }

        static void Calculate(StreamWriter files, double x0, double x1, double f, Func<double, double> obj, string s1)
        {
            files.WriteLine(s1);          
            for (double x = x0; x < x1; x += CalculateDelta(x0, x1))
            {

                var y1 = obj(x);
                files.WriteLine(" x = {0} y = {1}", x, y1);
            }
            var j = obj(f);
            files.WriteLine(" x = {0}  y = {1} ", f, j);
        }








            


        }
    }

