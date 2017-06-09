/*
 * Написать  класс  User,  описывающий  человека  (Фамилия, Имя, Отчество, Дата рождения, Возраст).
 * Написать   программу, демонстрирующую использование этого класса.
 */

namespace Task03
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
            List<User> users = new List<User>();
            User sampleUser = new User("Bob", "Fisher");
            sampleUser.DateOfBirth = new DateTime(1984, 4, 20);
            users.Add(sampleUser);
            DescribeUserbase(users);

            for (;;)
            {
                Console.WriteLine("Press Esc to exit;\nPress any other key to add another user\n");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("\nEnter first name: ");
                var firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                var lastName = Console.ReadLine();
                Console.Write("Enter patronymic: ");
                var patronymic = Console.ReadLine();                
                User user = new User(firstName, lastName, patronymic);
                DateTime dateOfBirth;
                Console.Write("Enter date of birth (DD/MM/YYYY): ");

                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    user.DateOfBirth = dateOfBirth;
                }

                users.Add(user);
                DescribeUserbase(users);
            }
        }

        private static void DescribeUserbase(List<User> users)
        {
            Console.WriteLine("Users in the userbase:\n\n***********\n");

            foreach (User u in users)
            {
                DescribeUser(u);
            }

            Console.WriteLine("***********\n");
        }

        private static int AskForInt(string name)
        {
            int value;
            Console.Write("Insert {0}: ", name);

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Incorrect {0}", name);
                Console.Write("Insert {0}: ", name);
            }

            return value;
        }

        private static void DescribeUser(User u)
        {
            Console.WriteLine("First name: {0}", u.FirstName);
            Console.WriteLine("Last name: {0}", u.LastName);
            Console.WriteLine("Patronymic: {0}", u.Patronymic);
            Console.WriteLine("Date of birth: {0}", u.DateOfBirth.ToShortDateString());
            Console.WriteLine("Age: {0}\n", u.Age);
        }
    }
}
