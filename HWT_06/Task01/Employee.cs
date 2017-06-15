/*
 * User со стажем и должностью
 */

namespace Task01
{
    using System.Text;

    public enum JobPosition
    {
        None,
        JuniorDeveloper,
        Developer,
        SeniorDeveloper
    }

    public class Employee : User
    {
        private int daysWorked = 0;
        private JobPosition position = JobPosition.None;

        public Employee(string firstName, string lastName, string patronymic = "-") : base(firstName, lastName, patronymic)
        {
        }

        public int DaysWorked
        {
            get
            {
                return daysWorked;
            }

            set
            {
                if (value >= 0)//todo pn стаж не может быть больше возраста
                {
                    daysWorked = value;
                }
            }
        }

        public JobPosition Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Возвращает строку, представляющую сотрудника для представления в консоли.
        /// </summary>
        /// <returns>Строка опсиания.</returns>
        public new string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.GetDescription());
            sb.AppendFormat("Position: {0}\n", Position);
            sb.AppendFormat("Days worked: {0}\n", DaysWorked);
            return sb.ToString();
        }
    }
}
