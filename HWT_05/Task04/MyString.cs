/*
 * Представляет строку как массив символов
 */

namespace Task04
{
    public class MyString
    {
        private char[] myString;

        public MyString(char value, int count)
        {
            myString = new char[count];

            for (int i = 0; i < count; i++)
            {
                myString[i] = value;
            }
        }

        public MyString(char[] value)
        {
            myString = new char[value.Length];
            value.CopyTo(myString, 0);
        }

        public int Length
        {
            get { return myString.Length; }
        }

        public static bool IsNullOrEmpty(MyString myString)
        {
            if (myString.ToCharArray() == null)
            {
                return true;
            }

            if (myString.ToCharArray().Length == 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsNullOrWhiteSpace(MyString myString)
        {
            if (myString.ToCharArray() == null)
            {
                return true;
            }

            for (int i = 0; i < myString.Length; i++)
            {
                if (!char.IsWhiteSpace(myString.ToCharArray()[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static MyString Concat(MyString a, MyString b)
        {
            int length = a.Length + b.Length;
            char[] chars = new char[length];
            a.ToCharArray().CopyTo(chars, 0);
            b.ToCharArray().CopyTo(chars, a.Length);
            return new MyString(chars);
        }

        public static MyString operator +(MyString a, MyString b)
        {
            return Concat(a, b);
        }

        public static bool operator ==(MyString a, MyString b)
        {
            if (a.ToCharArray() == b.ToCharArray())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(MyString a, MyString b)
        {
            if (a.ToCharArray() == b.ToCharArray())
            {
                return false;
            }

            return true;
        }

        public char[] ToCharArray()
        {
            return myString;
        }

        public new string ToString()
        {
            return new string(myString);
        }

        public int IndexOf(char value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (myString[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
