using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static double Point(double x, double y)
        {
            return x * x + y * y < 5 ? 1 : 0; ;
        }
        static double makeDelta()
        {
            double a = 10;
            double b = -10;
            double d = ((a - (b)) / 500);
            return d;
        }

        static double CompareMax(double x, double y)
        {
            double max = y >= x ? y : x;
            return max;
        }
        static double CompareMax(double x, double y, double z)
        {
            double max = CompareMax(x,y) > z ? CompareMax(x,y): z;
            return max;
        }

        static double CompareMin(double x, double y)
        {
            return x <= y ? x : y; ;
        }

        static double CompareMin(double x, double y, double z)
        {
            return CompareMin(x, y) > z ? z : CompareMin(x, y);
        }
       
        
        static void Main(string[] args)
        {
            using (StreamWriter file = new StreamWriter("table.txt"))
            {
                double x;
                double y = 0;
                double z = 0;
                for (double i = -10; i < 10; i += makeDelta())
                {

                    x = i;
                    for (double r = -10; r < 10; r += makeDelta())
                    {
                        y = r;

                        
                      
                        
                        file.Write(Point(x, y) + "\t");

                    }
                    file.Write("\r\n");

                }
            }



        }
    }
}
