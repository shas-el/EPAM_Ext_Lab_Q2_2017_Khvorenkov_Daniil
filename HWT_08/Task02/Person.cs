namespace Task02
{
    using System;

    public delegate void SaySomething(string message);

    public class Person
    {
        private string firstName;
        private const int noon = 12;
        private const int evening = 17;

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

        public void Greet(Person person, int time, SaySomething outFunc)
        {
            if (person != null)
            {
                if (time < noon)//todo pn хардкод
                {
                    outFunc(string.Format("Good morning, {0}! - said {1}", person.FirstName, this.FirstName));//todo pn у отдельного класса бизнес логики не должно быть зависимости от класса вывода данных.
				}

                if (time >= noon && time < evening)
                {
                    outFunc(string.Format("Good day, {0}! - said {1}", person.FirstName, this.FirstName));
                }

                if (time >= evening)
                {
                    outFunc(string.Format("Good evening, {0}! - said {1}", person.FirstName, this.FirstName));
                }
            }
        }

        public void SayGoodbye(Person person, SaySomething outFunc)
        {
            if (person != null)
            {
               outFunc(string.Format("Goodbye, {0}! - said {1}", person.FirstName, this.FirstName));
            }
        }

        public void EnterRoom(IRoom room, int time)
        {
            if (room != null)
            {
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
                OnQuit(new PersonEventArgs(time, this));
            }
        }

        public void OnQuit(PersonEventArgs e)
        {
            Quit?.Invoke(this, e);
        }
    }
}
