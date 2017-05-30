/*
 * Задание 2
 * Программа должна выводить пользователю промежуточные вычисления 
 * (например, a, b, c и дискриминант (если вычисляли при помощи него) и корни (если есть))
 */ 

namespace Task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solver s = new Solver();

            for (;;)
            {
                s.ShowDialog();
            }
        }
    }
}
