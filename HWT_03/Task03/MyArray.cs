/*
 * Генерирует и хранит массив. Определяет сумму неотрицательных элементов.
 */

namespace Task03
{
    using System;

    public class MyArray
    {
        private int[] array;

        /// <summary>
        /// Создает массив заданной длины и заполняет его случайными значениями от -100 до 100.
        /// </summary>
        /// <param name="length">Длина массива</param>
        public MyArray(int length)
        {
            array = new int[length];
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = r.Next(-100, 100);
            }
        }

        public int[] Array
        {
            get { return array; }
        }

        /// <summary>
        /// Возвращает сумму положительных чисел в массиве.
        /// </summary>
        /// <returns>Сумма положительных элементов</returns>
        public int NaturalsSum()
        {
            int sum = 0;
            
            foreach (int i in array)
            {
                if (i > 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}