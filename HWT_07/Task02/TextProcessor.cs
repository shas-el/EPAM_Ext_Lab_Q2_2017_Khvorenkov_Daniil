/*
 * Совершает манипуляции с текстом. В данном случае считает количество слов.
 */

namespace Task02
{
    using System;
    using System.Linq;
    using System.Text;

    public class TextProcessor
    {
        private string text;

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                if (value != null)
                {
                    text = value;
                    Words = text.Split(new char[] { ' ', '.' });
                }
            }
        }

        public string[] Words { get; private set; }

        /// <summary>
        /// Возвращает строку, в которой содержится информация о количестве слов в тексте
        /// и количество повторений для каждого слова (отображаются в нижнем регистре).
        /// </summary>
        /// <returns>Строка для отображения.</returns>
        public string GetWordsList()
        {
            if (Words != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Number of words: {0}\n", Words.Where(w => w != string.Empty).Count());
                sb.Append("Unique words and number of entries by word:\n");
                var uniqueWords = Words
                    .GroupBy(w => w, StringComparer.InvariantCultureIgnoreCase)
                    .Where(w => w.Key != string.Empty);

                foreach (var word in uniqueWords)
                {
                    sb.AppendFormat("{0}: [{1}]\n", word.Key.ToLower(), word.Count());
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}