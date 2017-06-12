/*
 * На основе класса User (см. задание 3 из предыдущей темы), создать класс  Employee, описывающий  сотрудника  фирмы.
 * В  дополнение  к полям  пользователя  добавить  поля  «стаж  работы»  и  «должность». 
 * Обеспечить нахождение класса в заведомо корректном состоянии.
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
            Employee e = new Employee("Bob", "Fisher");
            Console.WriteLine(e.GetDescription());
            e.DateOfBirth = new DateTime(1984, 4, 20);
            Console.WriteLine(e.GetDescription());
            e.Position = JobPosition.SeniorDeveloper;
            e.DaysWorked = 800;
            Console.WriteLine(e.GetDescription());
            Console.ReadKey();
        }
    }
}
