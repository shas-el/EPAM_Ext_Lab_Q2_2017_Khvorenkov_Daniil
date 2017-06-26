/*
 * Написать  программу,  описывающую  небольшой  офис,  в  котором работают сотрудники – объекты класса Person, обладающие полем имя 
 * (Name). Каждый из сотрудников содержит пару методов: приветствие сотрудника, пришедшего на работу (принимает в качестве аргументов 
 * объект сотрудника и время его прихода)  и прощание с ним (принимает только  объект  сотрудника).  В  зависимости  от  времени  суток, 
 * приветствие может быть различным: до 12 часов – «Доброе утро», с 12 до 17 – «Добрый день», начиная с 17 часов – «Добрый вечер». Каждый 
 * раз при входе очередного сотрудника в офис, все пришедшие ранее его приветствуют. При уходе сотрудника домой с ним также прощаются все 
 * присутствующие.    Вызов    процедуры    приветствия/прощания производить  через  групповые  делегаты.  Факт  прихода  и  ухода 
 * сотрудника отслеживается через генерируемые им события. Событие прихода  описывается  делегатом,  передающим  в  числе  параметров 
 * наследника EventArgs, явно содержащего поле с временем прихода. Продемонстрировать работу офиса при последовательном приходе 
 * и уходе сотрудников.
 */

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)//todo pn а теперь посмотри ниже и подумай, удобно ли читать 20 слитых вместе строк кода?
        {
            Office office = new Office("Nice Office");
            Person john = new Person("John");
            john.Entered += office.GreetByOffice;
            john.Quit += office.GoodbyeByOffice;
            Person bob = new Person("Bob");
            bob.Entered += office.GreetByOffice;
            bob.Quit += office.GoodbyeByOffice;
            Person george = new Person("George");
            george.Entered += office.GreetByOffice;
            george.Quit += office.GoodbyeByOffice;
            Person benny = new Person("Benny");
            benny.Entered += office.GreetByOffice;
            benny.Quit += office.GoodbyeByOffice;
            john.EnterRoom(office, 10);
            bob.EnterRoom(office, 11);
            george.EnterRoom(office, 14);
            bob.QuitRoom(office, 15);
            benny.EnterRoom(office, 17);
            john.QuitRoom(office, 17);
            george.QuitRoom(office, 18);
            benny.QuitRoom(office, 18);            
            Console.ReadKey();
        }
    }
}
