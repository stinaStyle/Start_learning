using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = {"one", "two", "three", "four", "five"};
            string text = "A class is the most powerful data type in C#. Like a structure, \n" +
                       "a class defines the data and behavior of the data type. ";

            File.WriteAllLines(@"D:\Лекции C#\методички\Start_learning\Lab_2\lines.txt", lines);
            File.WriteAllText(@"D:\Лекции C#\методички\Start_learning\Lab_2\text.txt", text);
            using (StreamWriter file = new StreamWriter(@"D:\Лекции C#\методички\Start_learning\Lab_2\testyourluck.txt"))
            {
                file.WriteLine(" \t test your luck");
                foreach (var line in lines)
                {
                    if (!line.Contains("two"))
                    {
                        file.WriteLine(line);
                    }
                }

            }
            // Read the file as one string.
            string textRead = File.ReadAllText(@"D:\Лекции C#\методички\Start_learning\Lab_2\testyourluck.txt");
            
            // Display the file contents to the console. Variable text is a string.
            Console.WriteLine("The text in file testyourluck.txt for {0} is \r\n {1}", DateTime.Now, textRead);

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] a = File.ReadAllLines(@"D:\Лекции C#\методички\Start_learning\Lab_2\lines.txt");


            // Display the file contents by using a foreach loop.
            Console.WriteLine("\n Every line in file lines.txt : ");
            foreach (var line in a)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            string s = File.ReadAllText(@"D:\Лекции C#\методички\Start_learning\Lab_2\text.txt");
            Console.WriteLine("\n All text in the file text.txt: \t\n {0}", s);
            
            Console.WriteLine("\n Press any key to exit");
            Console.ReadLine();

        }
    }
}
