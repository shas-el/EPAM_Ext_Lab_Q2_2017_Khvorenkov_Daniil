/*
 * Круг людей.
 */

namespace Task01
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PersonCircle
    {
        public PersonCircle(List<Person> people)
        {
            People = people;
        }

        public List<Person> People { get; private set; }

        /// <summary>
        /// Добавляет человека в круг.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        public void Add(string firstName, string lastName)
        {
            People.Add(new Person(firstName, lastName));
        }

        /// <summary>
        /// Убирает из круга каждого второго человека.
        /// </summary>
        public void RemoveEvery2ndPerson()
        {
            List<Person> temp = new List<Person>();

            for (int i = 0; i < People.Count; i += 2)
            {
                temp.Add(People.ElementAt(i));
            }

            People = temp;
        }

        /// <summary>
        /// Вовзвращает строку в которой перечислены люди в круге и их порядковый номер.
        /// </summary>
        /// <returns>Строка для вывода.</returns>
        public string GetPeopleListing()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Person p in People)
            {
                sb.AppendFormat("[{0}]: {1} {2}\n", People.IndexOf(p) + 1, p.FirstName, p.LastName);
            }

            return sb.ToString();
        }
    }
}
