namespace Task03
{
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Считает количество положительных чисел в массиве.
    /// </summary>
    //Для формирования нового массива с элементами результат был примерно такой же.
    public class TestClass
    {
        public delegate bool SearchFunction(int i);

        public long RegularSearch(int[] array)
        {
            var counter = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (int i in array)
            {
                if (i >= 0)
                {
                    counter++;
                }
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }

        public long DelegateSearch(int[] array, SearchFunction func)
        {
            var counter = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (int i in array)
            {
                if (func(i))
                {
                    counter++;
                }
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }

        public long LinqSearch(int[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int naturalNumbers = array.Count(x => x >= 0);

            sw.Stop();
            return sw.ElapsedTicks;
        }

        public long LinqSelectSearch(int[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int naturalNumbers = array.Select(x => x >= 0).Count();

            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
