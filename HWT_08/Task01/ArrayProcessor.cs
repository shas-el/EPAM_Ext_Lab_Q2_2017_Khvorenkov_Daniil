namespace Task01
{
    public class ArrayProcessor
    {
        public delegate int ComparisonFunction(string firstString, string secondString);

        public void Sort(string[] array, ComparisonFunction func)
        {
            string temp;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (func(array[i], array[j]) == 1)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
