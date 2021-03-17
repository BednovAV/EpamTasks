using System;

namespace CustomStringLibrary
{
    /*
     * Напишите собственный класс, описывающий строку как массив символов. Реализуйте для этого
     * класса типовые операции (сравнение, конкатенация, поиск символов, конвертация из/в массив
     * символов). Подумайте, какие функции вы бы добавили к имеющемуся в .NET функционалу строк
     * (достаточно 1-2 функций).
     * 
     * Вариант со * - подумайте над использованием в своем классе функционала индексатора
     * (indexer). Реализуйте его для своей строки.
     * 
     * Вариант с ** - попробуйте создать из своей сборки переносимую библиотеку (DLL). Осмысленно
     * назовите её, а также namespace и сам класс. Попробуйте использовать написанный вами класс в
     * другом проекте.
     */
    public class CustomString
    {
        private char[] _content;

        public int Lenght { get => _content.Length; }

        public CustomString()
        {
            _content = new char[0];
        }

        public CustomString(string text)
        {
            _content = text.ToCharArray();
        }

        /// <summary>
        /// Собственный метод, возвращающий текущую строку,
        /// повторенную заданное количество раз
        /// </summary>
        public CustomString Reply(int count)
        {
            CustomString result = new CustomString();

            for (int i = 0; i < count; i++)
            {
                result += this;
            }

            return result;
        }

        /// <summary>
        /// Собственный метод, возвращающий количесвто повторений заданного
        /// символа в текущей строке
        /// </summary>
        public int CharCount(char value)
        {
            int count = 0;
            foreach (var item in _content)
            {
                if (item == value) count -= -1;
            }

            return count;
        }

        char this[int i]
        {
            set => _content[i] = value;
            get => _content[i];
        }

        /// <summary>
        /// Посимвольное сравнение двух строк.
        /// </summary>
        /// <param name="string"></param>
        public bool Equals(CustomString str)
        {
            if (this.Lenght == str.Lenght)
            {
                for (int i = 0; i < Lenght; i++)
                {
                    if (this[i] != str[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomString)
            {
                return this.Equals((CustomString)obj);
            }
            else
            {
                return false;
            }
        }

        public void Append(CustomString str)
        {
            char[] newContent = new char[this.Lenght + str.Lenght];
            Array.Copy(_content, newContent, this.Lenght);
            Array.Copy(str._content, 0, newContent, this.Lenght, str.Lenght);

            this._content = newContent;
        }

        public void Append(string str) => Append(new CustomString(str));

        /// <summary>
        /// Возвращает индекс первого вхождения указанного символа.
        /// Возвращает -1 если символ не найден.
        /// </summary>
        public int IndexOf(char ch)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_content[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Возвращает массив символов
        /// </summary>
        public char[] ToCharArray() => (char[])_content.Clone();

        public override string ToString() => new String(_content);

        public static CustomString operator +(CustomString s1, CustomString s2)
        {
            CustomString resultString = new CustomString();

            char[] newContent = new char[s1.Lenght + s2.Lenght];
            Array.Copy(s1._content, newContent, s1.Lenght);
            Array.Copy(s2._content, 0, newContent, s1.Lenght, s2.Lenght);

            resultString._content = newContent;

            return resultString;
        }
        public static bool operator ==(CustomString s1, CustomString s2) => s1.Equals(s2);
        public static bool operator !=(CustomString s1, CustomString s2) => !s1.Equals(s2);
    }
}
