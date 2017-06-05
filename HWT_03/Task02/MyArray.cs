/*
 * Генерирует и хранит трехмерный массив. Заменяет положительные значения на 0.
 */

namespace Task02
{
    using System;
    using System.Text;

    public class MyArray
    {
        private int[,,] array;

        /// <summary>
        /// Создает кубический массив заданной длины и заполняет его случайными значениями от -100 до 100.
        /// </summary>
        /// <param name="length">Длина массива</param>
        public MyArray(int length)
        {
            array = new int[length, length, length];
            Random r = new Random();

            for (int a = 0; a < length; a++)
            {
                for (int b = 0; b < length; b++)
                {
                    for (int c = 0; c < length; c++)
                    {
                        array[a, b, c] = r.Next(-100, 100);
                    }
                }
            }
        }

        public int[,,] Array
        {
            get { return array; }
        }

        /// <summary>
        /// Возвращает элементы массива в виде строки.
        /// </summary>
        /// <returns>Строка элементов</returns>
        public string ElementsString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (int i in array)
            {
                stringBuilder.AppendFormat("{0}  ", i);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Заменяет положительные элементы массива на нули
        /// </summary>
        public void NaturalsToZero()
        {
            for (int a = 0; a < array.GetLength(0); a++)
            {
                for (int b = 0; b < array.GetLength(1); b++)
                {
                    for (int c = 0; c < array.GetLength(2); c++)
                    {
                        if (array[a, b, c] > 0)
                        {
                            array[a, b, c] = 0;
                        }
                    }
                }
            }
        }
    }
}
