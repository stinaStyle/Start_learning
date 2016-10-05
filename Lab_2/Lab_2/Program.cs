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
                file1.WriteLine("1) ((1 - (Math.Pow(x, 2)))/(1 + (Math.Pow(x, 4))))");
                for (double x = -3; x < 3; x += 0.75)
                {
                    var y1 = ((1 - (Math.Pow(x, 2)))/(1 + (Math.Pow(x, 4))));
                    file1.WriteLine("1) x = {0} y = {1}", x, y1);
                }
                var j = ((1 - (Math.Pow(2, 2)))/(1 + (Math.Pow(2, 4))));
                file1.WriteLine("1) x = 2  y = {0} ", j);

                file1.WriteLine("2) (Math.Sin(x))/((Math.Pow(x, 2)) - 1)");
                for (double x = -2; x < 2; x += 0.5)
                {
                    var y2 = (Math.Sin(x))/((Math.Pow(x, 2)) - 1);
                    file1.WriteLine("2) x = {0} y = {1}", x, y2);
                }
                var o = (Math.Sin(1.57))/((Math.Pow(1.57, 2)) - 1);
                file1.WriteLine("2) x = 1.57 y = {0} ", o);


                file1.WriteLine("3) (2*Math.PI)/(Math.Pow(x, 2) - Math.PI)");
                for (double x = -2; x < 4; x += 0.75)
                {
                    var y3 = (2*Math.PI)/(Math.Pow(x, 2) - Math.PI);
                    file1.WriteLine("3) x = {0} y = {1}", x, y3);
                }
                var p = (2*Math.PI)/(Math.Pow(3.14, 2) - Math.PI);
                file1.WriteLine("3) x = 3.14 y = {0}", p);
            }
        }










            


        }
    }

