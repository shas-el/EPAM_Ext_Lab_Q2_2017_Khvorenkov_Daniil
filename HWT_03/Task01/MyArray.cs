/*
 * Генерирует и хранит массив. Находит максимальное и минимальное числа, сортирует массив.
 */

namespace Task01
{
    using System;

    public class MyArray
    {
        private int[] array;

        /// <summary>
        /// Создает массив заданной длины и заполняет его случайными значениями до 100.
        /// </summary>
        /// <param name="length">Длина массива</param>
        public MyArray(int length)
        {
            array = new int[length];
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = r.Next(100);
            }
        }

        public int[] Array
        {
            get { return array; }
        }

        /// <summary>
        /// Сортировка массива перестановками
        /// </summary>
        public void Sort()
        {
            int temp;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Возвращаяет максимальное значение в массиве.
        /// </summary>
        /// <returns>Максимальное значение.</returns>
        public int Max()
        {
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Возвращаяет минимальное значение в массиве.
        /// </summary>
        /// <returns>Минимальное значение.</returns>
        public int Min()
        {
            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}
