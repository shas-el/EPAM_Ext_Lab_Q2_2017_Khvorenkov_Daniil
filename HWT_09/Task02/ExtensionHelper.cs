namespace Task02
{
    public static class ExtensionHelper
    {
        public static bool IsNaturalNumber(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            foreach (char c in s)
            {
                if (!(char.IsDigit(c)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
