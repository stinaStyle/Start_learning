using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_0
{
    class Program
    {
        static void Main(string[] args)
        {
            // версия операционной системы и время 
            OperatingSystem sis = System.Environment.OSVersion;
            Console.WriteLine("The system: {0}", sis.Platform);

            Console.WriteLine("Ебаная математика GO! ");
            Console.WriteLine("введите 0,31");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x = {0}", x);
            var bl = Math.Exp(-Math.Sin(1.3 * x - 0.7));
            var ps = Math.Sqrt(Math.Log((4 / 3) + x) + (9 / 7));
            var nu = ps - bl;
            Console.WriteLine("{0} - {1} = {2}", ps, bl, nu);

            Console.WriteLine("#3");
            Console.WriteLine("введите 2,23");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x = {0}", x);
            var a = 5 - (x * (Math.Cos(3.5 - x)));
            var b = 3.7 * (Math.Sqrt(a));
            var c = Math.Pow((5 - x), 3);
            var d = Math.Pow(c, 1 / 5);
            var result3 = b - d;
            var e = 3.7*(Math.Sqrt(5 - (x*(Math.Cos(3.5 - x))))) - Math.Pow(Math.Pow((5 - x), 3), 1.0/5.0);
            Console.WriteLine("{0} - {1} = {2}", b, d, result3);

            
            Console.WriteLine("#12");
            Console.WriteLine("введите 2,03");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите 1,043");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x = {0} \n y = {1}", x, y);
            var q = (Math.Sin(Math.Atan(x))/2);
            var result12 = y + (Math.Log(Math.Abs((4/7) - (Math.Sin(Math.Atan(x))/2))));
            Console.WriteLine("result = {0}",result12);


            Console.WriteLine("#22");
            Console.WriteLine("введите 1,28");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x = {0}", x);
            var w = Math.Exp(-Math.Sin((2*x)/5));
            var r = Math.Exp(Math.Cos(x/2));
            var t = Math.Sqrt((4/3) + x);
            var result22 = (Math.Exp(-Math.Sin((2*x)/5))) - (Math.Exp(Math.Cos(x/2))) + (Math.Sqrt((4/3) + x));
            Console.WriteLine("result 22 = {0}", result22);



            Console.WriteLine("#20");
            Console.WriteLine("введите 2,07");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x = {0}", x);
            var u = 20.7+(Math.Pow(Math.Sin(1.2*x), 2)) - (Math.Acos(x / 8)) * (Math.Exp(1.5 *x));
            Console.WriteLine("result20 = {0}", u);





            Console.ReadLine();
        }
    }
}
