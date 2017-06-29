/*
 * Написать методы поиска элемента в массиве (например, поиск всех положительных элементов в массиве) в виде: 
 * 1.Метода, реализующего поиск напрямую; 
 * 2.Метода, которому условие поиска передаётся через делегат; 
 * 3.Метода, которому условие поиска передаётся через делегат в виде анонимного метода; 
 * 4.Метода, которому условие поиска передаётся через делегат в виде лямбда-выражения; 
 * 5.LINQ-выражения Сравнить скорость выполнения вычислений.
 */

namespace Task03
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            const int iterationsNumber = 1600;
            const int arrayLength = 10000;

            int[] array = new int[arrayLength];
            Random r = new Random();
            for (int i = 0; i < arrayLength / 2; i++)
            {
                array[i] = r.Next(-100, 100);
            }

            //Console.WriteLine("###Debug###");
            Console.WriteLine("###Release###");
            Tester tester = new Tester(array);
            Console.WriteLine("Regular method search median: {0}", tester.TestRegular(iterationsNumber));
            Console.WriteLine("Delegate function search median: {0}", tester.TestDelegate(iterationsNumber));
            Console.WriteLine("Anonymous function search median: {0}", tester.TestAnonymous(iterationsNumber));
            Console.WriteLine("Lambda-function search median: {0}", tester.TestLambda(iterationsNumber));
            Console.WriteLine("LINQ search median: {0}", tester.TestLinq(iterationsNumber));

            Console.ReadKey();
        }
    }
}
