/*
 * Генерирует и хранит двумерный массив. Определяет сумму четных элементов.
 */

namespace Task04
{
    using System;
    using System.Text;

    public class MyArray
    {
        private int[,] array;

        /// <summary>
        /// Создает квадратный массив заданной длины и заполняет его случайными значениями от 0 до 10.
        /// </summary>
        /// <param name="length">Длина массива</param>
        public MyArray(int length)
        {
            array = new int[length, length];
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = r.Next(10);
                }
            }
        }

        public int[,] Array
        {
            get { return array; }
        }

        /// <summary>
        /// Возвращает сумму четных элементов массива.
        /// </summary>
        /// <returns>Сумма четных элементов.</returns>
        public int EvensSum()
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Возвращает строку, представляющую элементы массива в виде квадратной матрицы.
        /// </summary>
        /// <returns>Строка элементов.</returns>
        public string ElementsString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sb.AppendFormat("{0}  ", array[i, j]);
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}