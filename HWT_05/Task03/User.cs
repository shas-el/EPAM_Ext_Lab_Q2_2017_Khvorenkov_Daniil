/*
 * Пользователь с именем, фамилией, отчеством, датой рождения и возрастом.
 * Возраст вычисляется на основе даты рождения и текущей даты.
 */

namespace Task03
{
    using System;

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
    }
}
