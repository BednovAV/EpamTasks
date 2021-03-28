using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1._2
{
    public static class TextAnalyzerLogic
    {
        /// <summary>
        /// Returns a collection of key/value pairs.
        /// The key is a word, the value is the number of its repetitions in the text.
        /// </summary>
        public static IDictionary<string, int> WordsFrequency(string text)
        {
            string[] words = TextSplit(text);

            var vocabulary = new Dictionary<string, int>();
            foreach (var item in words)
            {
                string word = item.ToUpper();

                if (vocabulary.ContainsKey(word))
                {
                    vocabulary[word]++;
                }
                else
                {
                    vocabulary[word] = 1;
                }
            }

            return vocabulary;
        }

        private static string[] TextSplit(string text)
        {
            var separators = new List<char>() { ' ' };
            foreach (var item in text)
            {
                if (char.IsPunctuation(item) && !(separators.Contains(item)) && item != '-')
                    separators.Add(item);
            }

            return text.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
