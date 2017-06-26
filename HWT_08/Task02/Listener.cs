namespace Task02
{
    using System;

    class Listener
    {
        private Office office;

        public Listener(Office office)
        {
            this.office = office ?? new Office("-");
        }

        public void HandleEntered(object sender, PersonEventArgs e)
        {
            Console.WriteLine("[{0} entered {1}]", e.Person.FirstName, office.Name);
            office.Greetings?.Invoke(e.Person, e.Time, (s) => Console.WriteLine(s));
            Console.WriteLine();
        }

        public void HandleQuit(object sender, PersonEventArgs e)
        {
            Console.WriteLine("[{0} left {1}]", e.Person.FirstName, office.Name);
            office.Goodbyes?.Invoke(e.Person, (s) => Console.WriteLine(s));
            Console.WriteLine();
        }
    }
}
