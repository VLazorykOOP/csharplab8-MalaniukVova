using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MyProgram
{
    class task3
    {
        static void Main()
        {
            string inputFile = "input.txt";
            string outputFile = "output.txt";

            try
            {
                // Зчитування тексту з файлу
                string text = File.ReadAllText(inputFile);

                // Розділення тексту на слова за допомогою регулярного виразу
                string[] words = Regex.Split(text, @"[\s,.!?;]+");

                // Обробка кожного слова
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length % 2 == 1 && words[i].Length > 0) // Непарна довжина
                    {
                        int middleIndex = words[i].Length / 2;
                        words[i] = words[i].Remove(middleIndex, 1);
                    }
                }

                // Відновлення тексту
                string newText = string.Join(" ", words);

                // Запис результату у вихідний файл
                File.WriteAllText(outputFile, newText);

                Console.WriteLine("Середні літери видалено зі слів непарної довжини. Результат записано до output.txt");
                Console.WriteLine("Новий текст:\n" + newText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}