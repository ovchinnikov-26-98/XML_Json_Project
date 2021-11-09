using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XML_Json_Project
{
    class Service
    {
        /// <summary>
        /// Метод проверки ввода даты (формат вывести во входные параметры)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="scheduleDate"></param>
        public static void TextIsDate(string text, out DateTime scheduleDate)
        {
            var dateFormat = "dd.MM.yyyy";
            bool isDate = false;
            do
            {
                if (!DateTime.TryParseExact(text, dateFormat, provider: CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduleDate))
                {
                    Console.Write("Повторите ввод даты: ");
                    text = Console.ReadLine();
                }
                else isDate = true;
            }
            while (!isDate);
        }
        /// <summary>
        /// Проверка ввода пользователя на число
        /// </summary>
        /// <param name="text"></param>
        /// <param name="number"></param>
        public static void TextIsShort(string text, out short number, string ErrorMessage)
        {
            bool isNumber = false;
            do
            {
                if (!short.TryParse(text, out number))
                {
                    Console.Write(ErrorMessage);
                    text = Console.ReadLine();
                }
                else if ((ErrorMessage == "Некорректный ввод возраста, повторите: ") && (number > 120 || number < 14))
                {
                    Console.WriteLine("Возраст не может превышать 120 лет и быть меньше 14 лет. Повторите ввод");
                    text = Console.ReadLine();
                }
                else isNumber = true;
            }
            while (!isNumber);
        }
        public static void TextIsName(string text, out string name, string ErrorMessage)
        {
            bool isName = false;
            do
            {
                if (text == "")
                {
                    Console.Write(ErrorMessage);
                    text = Console.ReadLine();
                }
                else
                {
                    foreach (char s in text)
                    {
                        if (char.IsDigit(s))
                        {
                            isName = false;
                            Console.WriteLine(ErrorMessage);
                            text = Console.ReadLine();
                            break;
                        }
                        isName = true;
                    }
                }
                name = text;
            }
            while (!isName);
        }

    }
}
