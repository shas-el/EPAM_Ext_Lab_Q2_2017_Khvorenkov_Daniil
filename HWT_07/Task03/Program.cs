/*
 * На  базе  обычного  массива  (коллекции  .NET  не  использовать) 
 * реализовать свой собственный класс  DynamicArray, представляющий 
 * собой массив с запасом.
 */

namespace Task03
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            MyDynamicArray<string> array = new MyDynamicArray<string>();
            array.Add("string 1");
            array.Add("string 2");
            array.Add("string 3");
            array.Add("string 4");
            array.Add("string 5");
            array.Add("string 6");
            array.Add("string 7");
            array.Add("string 8");
            array.Add("string 9");
            List<string> collection = new List<string>();
            collection.Add("collection string 1");
            collection.Add("collection string 2");
            collection.Add("collection string 3");
            collection.Add("collection string 4");
            collection.Add("collection string 5");
            collection.Add("collection string 6");
            collection.Add("collection string 7");
            collection.Add("collection string 8");
            array.AddRange(collection);
            array.Remove(9);
            array.Insert("new string 9", 9);

            foreach (string s in array)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
