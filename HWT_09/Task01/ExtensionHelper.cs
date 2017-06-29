namespace Task01
{
    public static class ExtensionHelper
    {
        public static int Sum(this int[] array)
        {
            var sum = 0;

            foreach (int i in array)
            {
                sum += i;
            }

            return sum;
        }

        public static double Sum(this double[] array)
        {
            var sum = .0;

            foreach (double d in array)
            {
                sum += d;
            }

            return sum;
        }
    }
}
