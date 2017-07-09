namespace Task01
{
    using System.Collections.Generic;

    public static class ExtensionHelper
    {
        public static int Sum(this IEnumerable<int> array)//todo pn а мы обобщенные типы не проходили чтоли?                                                     
        {
            var sum = 0;

            if (array != null)
            {
                foreach (int i in array)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static double Sum(this IEnumerable<double> array)
        {
            var sum = .0;

            if (array != null)
            {
                foreach (double d in array)
                {
                    sum += d;
                }
            }

            return sum;
        }
    }
}
