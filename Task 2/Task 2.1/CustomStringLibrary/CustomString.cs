﻿using System;

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

        public int Length => _content.Length; 

        public CustomString()
        {
            _content = new char[0];
        }

        public CustomString(string text)
        {
            _content = text.ToCharArray();
        }

        public CustomString(CustomString customString)
        {
            _content = new char[customString.Length];

            Array.Copy(customString._content, _content, Length);
        }

        /// <summary>
        /// Собственный метод, возвращающий текущую строку,
        /// повторенную заданное количество раз
        /// </summary>
        public CustomString Repeat(int count)
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

        public char this[int i]
        {
            set => _content[i] = value;
            get => _content[i];
        }

        /// <summary>
        /// Посимвольное сравнение двух строк.
        /// </summary>
        public bool Equals(CustomString str)
        {
            if (str == null)
                return false;

            if (this.Length == str.Length)
            {
                for (int i = 0; i < Length; i++)
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

        public override bool Equals(object obj) => this.Equals(obj as CustomString);

        public void Append(CustomString str)
        {
            char[] newContent = new char[this.Length + str.Length];
            Array.Copy(_content, newContent, this.Length);
            Array.Copy(str._content, 0, newContent, this.Length, str.Length);

            this._content = newContent;
        }

        public void Append(string str) => Append(new CustomString(str));

        /// <summary>
        /// Возвращает индекс первого вхождения указанного символа.
        /// Возвращает -1 если символ не найден.
        /// </summary>
        public int IndexOf(char ch)
        {
            for (int i = 0; i < Length; i++)
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
            CustomString resultString = new CustomString(s1);
            resultString.Append(s2);
            return resultString;
        }
        public static bool operator ==(CustomString s1, CustomString s2) => s1.Equals(s2);
        public static bool operator !=(CustomString s1, CustomString s2) => !s1.Equals(s2);
    }
}
