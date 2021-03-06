using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._2.StringNotSting
{
    class Program
    {
        /*
        * Task 1.2.1. AVERAGES
        * Напишите программу, которая определяет среднюю длину слова во введённой текстовой строке.
        * Учтите, что символы пунктуации на длину слов влиять не должны.Не стоит искать каждый
        * символ-разделитель вручную: пожалейте своё время и используйте стандартные методы классов
        * String и Char.
        */
        static void Averages()
        {
            Console.Write("Ввод: ");
            string text = Console.ReadLine();
            char[] sep = new char[] { ' ', '.', ',', ':', '!', '?'};
            string[] words = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            int allChars = 0;
            foreach (var item in words)
            {
                allChars += item.Length;
            }

            double average = (double)allChars / words.Length;
            Console.WriteLine("Вывод: {0:.##}", average); // результат округляется до сотых
        }

        /*
         * 1.2.2. DOUBLER
         * Напишите программу, которая удваивает в первой введённой строке все символы, принадлежащие
         * второй введённой строке.
         */
        static void Doubler()
        {
            Console.Write("Ввод 1: ");
            string str1 = Console.ReadLine();

            Console.Write("Ввод 2: ");
            string str2 = Console.ReadLine();

            StringBuilder resultBuilder = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                if (str2.Contains(str1[i]))
                {
                    resultBuilder.Append(str1[i].ToString() + str1[i].ToString());
                }
                else
                {
                    resultBuilder.Append(str1[i]);
                }
            }

            string result = resultBuilder.ToString();
            Console.WriteLine($"Вывод: {result}");
        }

        /*
         * 1.2.3. LOWERCASE
         * Напишите программу, которая считает количество слов, начинающихся с маленькой буквы.
         * Предлоги, союзы и междометия считаются словами. Финальную точку в предложении (как и любой
         * другой знак) можно не учитывать
         * Вариант со * - разделители между словами могут быть любые: запятые, двоеточия, точки с
         * запятой.
         */
        static void Lowercase()
        {
            Console.Write("Ввод: ");
            string text = Console.ReadLine();
            char[] sep = new char[] { ' ', '.', ',', ':', '!', '?' };
            string[] words = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            int lowersCount = 0;
            foreach (var item in words)
            {
                if (char.IsLower(item[0]))
                {
                    lowersCount++;
                }
            }

            Console.WriteLine($"Вывод: {lowersCount}");
        }

        /*
         * 1.2.4. VALIDATOR
         * Напишите программу, которая заменяет первую букву первого слова в предложении на заглавную.
         * В качестве окончания предложения можете считать только «.|?|!». Многоточие и «?!» можете
         * опустить.
         */
        static void Validator()
        {
            Console.Write("Ввод: ");
            string text = Console.ReadLine();
            string sep = ".!?";
            StringBuilder resultBuilder = new StringBuilder();

            int startSentence = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if(sep.Contains(text[i]) || i == text.Length - 1)
                {
                    string sentence = text.Substring(startSentence, i - startSentence + 1).TrimStart();
                    resultBuilder.Append(char.ToUpper(sentence[0]) + sentence.Substring(1) + " ");
                    startSentence = ++i;
                }
            }

            string result = resultBuilder.ToString();
            Console.WriteLine($"Вывод: {result}");
        }

        static void Main(string[] args)
        {
            //Averages();

            //Doubler();

            //Lowercase();

            //Validator();
        }
    }
}
