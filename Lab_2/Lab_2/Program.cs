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


            // Dialog for variables
            Console.WriteLine("Variable a: ");
            var a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Variable i");
            var i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Variable c");
            var c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Variable l");
            bool l = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Your Name: ");
            string Name = Console.ReadLine();

            //Write variables to the file LAB_2.txt
            using (StreamWriter file = new StreamWriter(@"D:\Лекции C#\методички\Start_learning\Lab_2\LAB_2.txt"))
            {
                file.WriteLine("\t a = {0}", a);
                file.WriteLine("\t i = {0}", i);
                file.WriteLine("\t c = {0}", c);
                file.WriteLine("\t l = {0}", l);
                file.WriteLine("\t Name: {0}", Name);
            }

            

            using (StreamWriter file1 = new StreamWriter(@"D:\Лекции C#\методички\Start_learning\Lab_2\LAB_2.2.txt"))
            {
                
                //Function 
                for (int x = -3; x < 4; ++x)
                {
                   var  y = ((1 - (Math.Sqrt(x))) / (1 + (Math.Pow(x, 4))));


                    file1.WriteLine(y);


                }
              

            }
        }










            


        }
    }

