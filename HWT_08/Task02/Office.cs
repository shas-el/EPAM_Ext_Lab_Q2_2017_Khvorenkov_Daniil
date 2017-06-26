namespace Task02
{
    using System.Collections.Generic;

    public class Office : IRoom
    {
        public delegate void SayHello(Person person, int time, SaySomething outFunc);
        public SayHello Greetings;
        public delegate void SayGoodbye(Person person, SaySomething outFunc);
        public SayGoodbye Goodbyes;

        public Office(string name)
        {
            Name = name ?? "-";
            People = new List<Person>();
        }

        public string Name { get; set; }

        public List<Person> People { get; private set; }

        public void AddPerson(Person person, int time)
        {
            if (person != null)
            {
                People.Add(person);
                Greetings += person.Greet;
                Goodbyes += person.SayGoodbye;
            }
        }

        public void RemovePerson(Person person)
        {
            if (person != null)
            {
                People.Remove(person);
                Greetings -= person.Greet;
                Goodbyes -= person.SayGoodbye;
            }
        }
    }
}
