namespace Task02
{
    using System;

    public class PersonEventArgs : EventArgs
    {
        public PersonEventArgs(int time, Person person)
        {
            Time = time;
            Person = person;
        }

        public int Time { get; private set; }

        public Person Person { get; private set; }
    }
}
