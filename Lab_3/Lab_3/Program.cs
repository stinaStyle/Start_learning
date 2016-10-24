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
//          
//            if (x>5) return 0;
//            if (x < -5) return 0;
//            if (y > 5) return 0;
//            if (y < -5) return 0;

            double x1 = 12;
            double x2 = -12;
            double y1 = 12;
            double y2 = -12;

           
           
            
            if (x < 0 && y > 0)
            {
                if (-12 * x - 12 * y + 144 > 0) return 7;
                return 1;
            }
            if (x > 0 && y > 0)
            {
                if (-12 * x - 12 * y + 144 > 0) return 7;
                return 2;
            }
            if (x > 0 && y < 0)
            {
                if (-12 * x - 12 * y + 144 > 0) return 7;
                return 3;
            }
            if (x < 0 && y < 0)
            {
                if ((-12 * x - 12 * y + 144 > 0)) return 7;
                return 4;
            }
            return 0;
        }
        static double makeDelta()
        {
            double a = 200;
            double b = -200;
            double d = ((a - (b)) / 50);
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
                double x = 2;
                double y = -2;
                double z = 0;
//                file.Write(Point(x,y));
                for (double i = -200; i < 200; i += makeDelta())
                {

                    x = i;
                    for (double r = -200; r < 200; r += makeDelta())
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
