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
                using (StreamReader file = new StreamReader(@"D:\Лекции C#\методички\Start_learning\Lab_2\LAB_2.1.txt"))
                {

                    while (!file.EndOfStream)
                    {
                        

                        for (int n = 1; n <= 3; n++)
                        {
                            double v = double.Parse(file.ReadLine());
                            double k = double.Parse(file.ReadLine());
                            double l = double.Parse(file.ReadLine());
                            if (n == 1)
                            {
                                Calculate(file1, v, k, l, x => ((1 - (Math.Pow(x, 2))) / (1 + (Math.Pow(x, 4)))),
                            "((1 - (Math.Pow(x, 2))) / (1 + (Math.Pow(x, 4))))");
                            }
                            else if (n == 2)
                            {
                                Calculate(file1, v, k, l, x => (Math.Sin(x)) / ((Math.Pow(x, 2)) - 1),
                            "(Math.Sin(x)) / ((Math.Pow(x, 2)) - 1)");
                            }
                            else
                            {
                                Calculate(file1, v, k, l, x => (2 * Math.PI) / (Math.Pow(x, 2) - Math.PI),
                            "(2 * Math.PI) / (Math.Pow(x, 2) - Math.PI)");
                            }
                        }

                        //Function 
//                        Calculate(file1, v, k, l, x => ((1 - (Math.Pow(x, 2)))/(1 + (Math.Pow(x, 4)))),
//                            "((1 - (Math.Pow(x, 2))) / (1 + (Math.Pow(x, 4))))");
//
//                        v = double.Parse(file.ReadLine());
//                        k = double.Parse(file.ReadLine());
//                        l = double.Parse(file.ReadLine());
//                        Calculate(file1, v, k, l, x => (Math.Sin(x))/((Math.Pow(x, 2)) - 1),
//                            "(Math.Sin(x)) / ((Math.Pow(x, 2)) - 1)");
//
//                        v = double.Parse(file.ReadLine());
//                        k = double.Parse(file.ReadLine());
//                        l = double.Parse(file.ReadLine());
//                        Calculate(file1, v, k, l, x => (2*Math.PI)/(Math.Pow(x, 2) - Math.PI),
//                            "(2 * Math.PI) / (Math.Pow(x, 2) - Math.PI)");
                    }

                }
                

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

