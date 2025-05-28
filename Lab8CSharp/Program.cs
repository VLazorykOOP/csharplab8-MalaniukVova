using System;
using System.Text.RegularExpressions;

namespace MyProgram
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введіть текст для перевірки на наявність адрес Gmail:");
            string text = Console.ReadLine();

            // Регулярний вираз для адрес Gmail
            Regex regex = new Regex(@"[a-zA-Z0-9._%+-]+@gmail\.com");

            // Пошук усіх збігів
            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                Console.WriteLine("Знайдено адреси Gmail:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Адреси Gmail у тексті не знайдено.");
            }
        }
    }
}