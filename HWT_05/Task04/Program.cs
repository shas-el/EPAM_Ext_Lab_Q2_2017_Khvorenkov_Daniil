/*
 * Написать свой собственный класс MyString, описывающий строку как 
 * массив символов. Перегрузить для этого класса типовые операции.
 */

namespace Task04
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            MyString myString = new MyString('*', 10);
            Console.WriteLine(myString.ToCharArray());
            char[] abcArray = { 'a', 'b', 'c' };
            Console.WriteLine(abcArray);
            Console.WriteLine((myString + new MyString(abcArray)).ToString());
            MyString abcString = new MyString(abcArray);
            Console.WriteLine("Индекс 'b': {0}", MyString.Concat(myString, abcString).IndexOf('b'));
            Console.WriteLine(
                "Строки одинаковые: {0}\nСтроки разные: {1}\n\n",
                myString == abcString,
                myString != abcString);

            char[] emptyArray = { };
            MyString emptyString = new MyString(emptyArray);
            Console.WriteLine(
                "Пустая строка:\nПустая: {0}\n\"Белая\": {1}",
                MyString.IsNullOrEmpty(emptyString),
                MyString.IsNullOrWhiteSpace(emptyString));
            char[] whiteArray = { ' ', ' ', ' ' };
            MyString whiteString = new MyString(whiteArray);
            Console.WriteLine(
                "Строка из трех пробелов:\nПустая: {0}\n\"Белая\": {1}",
                MyString.IsNullOrEmpty(whiteString),
                MyString.IsNullOrWhiteSpace(whiteString));
            Console.ReadKey();
        }
    }
}
