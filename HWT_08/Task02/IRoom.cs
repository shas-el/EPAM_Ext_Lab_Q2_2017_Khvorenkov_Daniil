namespace Task02
{
    using System.Collections.Generic;

    public interface IRoom
    {
        List<Person> People { get; }

        string Name { get; }

        void AddPerson(Person person, int time);

        void RemovePerson(Person person);
    }
}
