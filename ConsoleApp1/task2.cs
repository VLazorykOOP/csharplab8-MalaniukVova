using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MyProgram
{
    class task2
    {
        static void Main()
        {
            // Зчитування тексту з файлу
            string inputFile = "input.txt";
            string outputFile = "output.txt";

            try
            {
                string text = File.ReadAllText(inputFile);

                // Регулярний вираз для шістнадцяткових цифр (0-9, a-f, A-F)
                Regex regex = new Regex(@"[0-9a-fA-F]");

                // Заміна шістнадцяткових цифр на '+'
                string newText = regex.Replace(text, "+");

                // Запис результату у вихідний файл
                File.WriteAllText(outputFile, newText);

                Console.WriteLine("Шістнадцяткові цифри успішно замінено. Результат записано до output.txt");
                Console.WriteLine("Новий текст:\n" + newText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}