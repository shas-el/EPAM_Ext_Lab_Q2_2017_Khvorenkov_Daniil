namespace Task03
{
    using System;
    using System.Linq;

    class Tester
    {
        public Tester(int[] array)
        {
            Array = array;
            Test = new TestClass();
        }

        public int[] Array { get; set; }

        public TestClass Test { get; set; }

        public long TestRegular(int iterationsNumber)
        {
            long[] results = new long[iterationsNumber];
            
            for (int i = 0; i < iterationsNumber; i++)
            {
                results[i] = Test.RegularSearch(Array);
            }

            results = results.OrderBy(i => i).ToArray();
            return results[iterationsNumber / 2];
        }

        public long TestDelegate(int iterationsNumber)
        {
            long[] results = new long[iterationsNumber];

            for (int i = 0; i < iterationsNumber; i++)
            {
                results[i] = Test.DelegateSearch(Array, IsPositive);
            }

            results = results.OrderBy(i => i).ToArray();
            return results[iterationsNumber / 2];
        }

        private bool IsPositive(int i)
        {
            return i >= 0;
        }

        public long TestAnonymous(int iterationsNumber)
        {
            long[] results = new long[iterationsNumber];

            for (int i = 0; i < iterationsNumber; i++)
            {
                results[i] = Test.DelegateSearch(Array, delegate(int x) { return x >= 0; });
            }

            results = results.OrderBy(i => i).ToArray();
            return results[iterationsNumber / 2];
        }

        public long TestLambda(int iterationsNumber)
        {
            long[] results = new long[iterationsNumber];

            for (int i = 0; i < iterationsNumber; i++)
            {
                results[i] = Test.DelegateSearch(Array, x => x >= 0);
            }

            results = results.OrderBy(i => i).ToArray();
            return results[iterationsNumber / 2];
        }

        public long TestLinq(int iterationsNumber)
        {
            long[] results = new long[iterationsNumber];

            for (int i = 0; i < iterationsNumber; i++)
            {
                results[i] = Test.LinqSearch(Array);
            }

            results = results.OrderBy(i => i).ToArray();
            return results[iterationsNumber / 2];
        }
    }
}
