/*
 * В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета 
 * по  кругу  вычёркивается  каждый  второй  человек,  пока  не  останется
 * один. Составить программу, моделирующую процесс.
 */

namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            PersonCircle circle = new PersonCircle(new List<Person>());
            circle.Add("Jim", "Green");
            circle.Add("Lucy", "King");
            circle.Add("Bob", "Smith");
            circle.Add("Alexia", "King");
            circle.Add("Nelly", "Cook");
            circle.Add("Freda", "Ford");
            circle.Add("Nocial", "Stone");
            circle.Add("Joanna", "Fox");
            circle.Add("Mignon", "Kelley");
            circle.Add("Ruby", "Lee");

            while (circle.People.Count > 1)
            {
                Console.WriteLine(circle.GetPeopleListing());
                circle.RemoveEvery2ndPerson();
            }

            Console.WriteLine(circle.GetPeopleListing());            
            Console.ReadKey();
        }
    }
}
