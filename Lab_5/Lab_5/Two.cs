using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Two
    {
        static int D = 40;
        static int even;
        static int odd;
        static int[] ArrTwo = new int[D];
        static int[] ArrEven = new int[D];
        static int[] ArrOdd = new int[D];
        static Random rnd2 = new Random();

        public static void WriteFileTwo()
        {
            using (StreamWriter fileTwo = new StreamWriter("file-two.txt"))
            {
                int sumE =0, sumO =0;
                for (int i = 0; i < D; i++)
                {
                    ArrTwo[i] = rnd2.Next(1, 1000)/10;
                    fileTwo.Write(ArrTwo[i] +"\t");
                    if (i%2 == 0)
                    {
                        ArrEven[even] = ArrTwo[i];
                        even += 1;
                        sumE += i;
                        fileTwo.WriteLine("Массив с четными индексами, индекс № {0} \t", i);
                    }
                    else
                    {
                        ArrOdd[odd] = ArrTwo[i];
                        odd += 1;
                        sumO += i;
                        fileTwo.WriteLine("Массив с нечетными индексами, индекс № {0}", i);
                    }
                }
                
                fileTwo.WriteLine("Сумма элементов четного массива {0}", sumE);
                fileTwo.WriteLine("Сумма элементов нечетного массива {0}", sumO);
            }
        }
    }
}
