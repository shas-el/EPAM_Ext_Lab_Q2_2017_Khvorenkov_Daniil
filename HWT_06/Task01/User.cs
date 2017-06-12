/*
 * Пользователь с именем, фамилией, отчеством, датой рождения и возрастом.
 * Возраст вычисляется на основе даты рождения и текущей даты.
 */

namespace Task01
{
    using System;
    using System.Text;

    public class User
    {
        private string firstName = "-";
        private string lastName = "-";
        private string patronymic = "-";
        private DateTime dateOfBirth;

        public User(string firstName, string lastName, string patronymic = "-")
        {
            //Допустим, что у всех есть имя и фамилия
            if (firstName != null && lastName != null)
            {
                FirstName = firstName;
                LastName = lastName;
                Patronymic = patronymic;
            }
            else
            {
                FirstName = "-";
                LastName = "-";
                Patronymic = "-";
            }

            DateOfBirth = DateTime.MinValue;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }

        public string Patronymic
        {
            get
            {
                return patronymic;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    patronymic = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
                Age = DateTime.Now.Year - dateOfBirth.Year;

                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                {
                    Age--;
                }
            }
        }

        public int Age { get; private set; }

        /// <summary>
        /// Возвращает строку, представляющую пользователя для представления в консоли.
        /// </summary>
        /// <returns>Строка опсиания.</returns>
        public string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("First Name: {0}\n", FirstName);
            sb.AppendFormat("Last Name: {0}\n", LastName);
            sb.AppendFormat("Patronymic: {0}\n", Patronymic);
            sb.AppendFormat("Date of birth: {0}\n", DateOfBirth.ToShortDateString());
            sb.AppendFormat("Age: {0}\n", Age);
            return sb.ToString();
        }
    }
}
