namespace Task02
{
    using System;

    public class Person
    {
        private string firstName;

        public Person(string firstName)
        {
            FirstName = firstName ?? "-";
        }

        public event EventHandler<PersonEventArgs> Entered;

        public event EventHandler<PersonEventArgs> Quit;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if (value != null)
                {
                    firstName = value;
                }
            }
        }

        public void Greet(Person person, int time)
        {
            if (person != null)
            {
                if (time < 12)//todo pn хардкод
                {
                    Console.WriteLine("Good morning, {0}! - said {1}", person.FirstName, this.FirstName);//todo pn у отдельного класса бизнес логики не должно быть зависимости от класса вывода данных.
				}

                if (time >= 12 && time < 17)
                {
                    Console.WriteLine("Good day, {0}! - said {1}", person.FirstName, this.FirstName);
                }

                if (time >= 17)
                {
                    Console.WriteLine("Good evening, {0}! - said {1}", person.FirstName, this.FirstName);
                }
            }
        }

        public void SayGoodbye(Person person)
        {
            if (person != null)
            {
                Console.WriteLine("Goodbye, {0}! - said {1}", person.FirstName, this.FirstName);
            }
        }

        public void EnterRoom(IRoom room, int time)
        {
            if (room != null)
            {
                Console.WriteLine("\n[{0} came to {1}]", FirstName, room.Name);
                OnEntered(new PersonEventArgs(time, this));
                room.AddPerson(this, time);
            }
        }

        public void OnEntered(PersonEventArgs e)
        {
            Entered?.Invoke(this, e);
        }

        public void QuitRoom(IRoom room, int time)
        {
            if (room != null && room.People.Contains(this))
            {
                room.RemovePerson(this);
                Console.WriteLine("\n[{0} left {1}]", FirstName, room.Name);
                OnQuit(new PersonEventArgs(time, this));
            }
        }

        public void OnQuit(PersonEventArgs e)
        {
            Quit?.Invoke(this, e);
        }
    }
}
