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
        static double makeDelta()
        {
            double a = 10;
            double b = -10;
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
                double x;
                double y = 0;
                double z = 0;
                for (double i = 1.2; i > -1.2; i -= ((1.2 - (-1.2)) / 100))
                {

                    x = i;
                    for (double r = -2; r < 1.77; r += ((1.77 - (-2)) / 100))
                    {
                        var it = 0;
                        var rt = x;
                        var imt = y;
                        var arg = (y * y) + (x * x);
                        while ((arg < 4) && (it < 40))
                        {
                            double rt2 = (rt * rt) - (imt * imt) + y;
                            imt = (2 * rt * imt) + x;
                            rt = rt2;
                            arg = (rt * rt) + (imt * imt);
                            it += 1;
                        }

                        z = it;



                        double min;
                        double max;
                        y = r;
                        file.Write(it + "\t");
//                        file.Write((CompareMax((Math.Pow(x,3)), (Math.Pow(z,2))) + (Math.Cos(4*(Math.Pow(y,2))))) + "\t");
//                        file.Write((CompareMin(x,y)+0.5) / (Math.Pow(CompareMax(x,y), 2) - Math.Sin(z)) + "\t");
//                        file.Write( CompareMax( x, y, z) + "\t");
//                        file.Write(CompareMin(x, y, z) + "\t");
                        //                        min = x > y ? y : x;
                        //                        max = y > x ? x : y;
                        //                        file.Write(((min + 0.5) / (Math.Pow(max, 2)- (Math.Sin(z)))+ "\t"));
                    }
                    file.Write("\r\n");

                }
            }



        }
    }
}
