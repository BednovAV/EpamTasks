using System;
using System.Linq;
using System.Text;

namespace Task3._3._2
{
    /*
     * Расширьте строку следующим методом:
     * - проверка, на каком языке написано слово в строке. Ограничимся четырьмя вариантами – Russian,
     * English, Number and Mixed. Совокупность нескольких слов, микс символов или букв (из разных
     * языков) относить к последней категории. Если в строке имеются пробелы, знаки препинания и
     * прочие символы – можете также откидывать к последней категории. Словом на русском языке
     * считайте любую последовательность русских символов (АаАа - подходит). На английском –
     * аналогично, но с англоязычными символами.
     */
    public static class StringExtensionMethods
    {

        public static StringType CheckLanguage(this string text)
        {
            if (text == string.Empty)
                return StringType.Mixed;

            StringType currentType = CheckChar(text.First());

            if (currentType == StringType.Mixed)
                return StringType.Mixed;

            if (text.All(item => CheckChar(item) == currentType))
            {
                return currentType;
            }
            else
            {
                return StringType.Mixed;
            }
        }

        private static StringType CheckChar(char c)
        {
            if (c >= 'А' && c <= 'я')
            {
                return StringType.Russian;
            }
            else if((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
            {
                return StringType.English;
            }
            else if(char.IsDigit(c))
            {
                return StringType.Number;
            }
            else
            {
                return StringType.Mixed;
            }
        }
    }

    public enum StringType
    {
        Russian,
        English,
        Number,
        Mixed
    }
}
