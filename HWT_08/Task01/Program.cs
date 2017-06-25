/*
 * Написать  программу,  выполняющую  сортировку  массива  строк  по 
 * возрастанию длины. Если строки состоят из равного числа символов, 
 * их следует отсортировать по алфавиту. Реализовать метод сравнения 
 * строк отдельным методом, передаваемым в сортировку через делегат.
 */

namespace Task01
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            ArrayProcessor processor = new ArrayProcessor();
            string[] array = { "one", "two", "three", "four", "five", "six" };

            foreach (string s in array)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            processor.Sort(array, CompareOne);

            foreach (string s in array)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            processor.Sort(array, CompareTwo);

            foreach (string s in array)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }

        private static int CompareOne(string firstString, string secondString)
        {
            if (firstString.Length > secondString.Length)
            {
                return 1;
            }
            else if (secondString.Length > firstString.Length)
            {
                return -1;
            }

            for (int i = 0; i < firstString.Length; i++)
            {
                if (firstString[i] > secondString[i])
                {
                    return 1;
                }
                else if (secondString[i] > firstString[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        private static int CompareTwo(string firstString, string secondString)
        {
            if (firstString.Length > secondString.Length)
            {
                return -1;
            }
            else if (secondString.Length > firstString.Length)
            {
                return 1;
            }

            for (int i = 0; i < firstString.Length; i++)
            {
                if (firstString[i] > secondString[i])
                {
                    return -1;
                }
                else if (secondString[i] > firstString[i])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
