using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Three
    {
        static int M = 70;
        public static int[] ArrThree = new int[M];


        public static void WriteFileThree()
        {
            using (StreamWriter fileThree = new StreamWriter("file-three.txt"))
            {
                int minVal = 0;
                int maxVal = Program.arr2.Max();

                for (int i = 0; i < Program.arr2.Length; i++)
                {
                    if (i < 0)
                    {
                        minVal = i;
                        break;
                    }
                }

                double ans = ((maxVal + minVal)/2);
                fileThree.Write("Среднее арифметическое между первым отрицательным и максимальным = {0}", ans);

            }
        }
    }
}
