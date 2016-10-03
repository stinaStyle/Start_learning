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


            

            using (StreamWriter file1 = new StreamWriter(@"D:\Лекции C#\методички\Start_learning\Lab_2\LAB_2.2.txt"))
            {
                
                //Function 
                for (double x = -3; x < 3; x += 0.75)
                {
                   var  y = ((1 - (Math.Pow(x, 2))) / (1 + (Math.Pow(x, 4))));


                    file1.WriteLine(y);


                }
                var j  = ((1 - (Math.Pow(2, 2))) / (1 + (Math.Pow(2, 4))));
                file1.WriteLine(j);
            }
        }










            


        }
    }

