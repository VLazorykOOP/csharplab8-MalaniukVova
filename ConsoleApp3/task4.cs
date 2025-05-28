using System;
using System.IO;

namespace MyProgram
{
    class task4
    {
        static void Main()
        {
            string filePath = "numbers.dat";

            // Введення послідовності (до 5 чисел)
            Console.WriteLine("Введіть до 5 дійсних чисел:");
            var numbers = new System.Collections.Generic.List<double>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Число {i + 1}: ");
                string input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Порожній рядок. Введення завершено.");
                    break;
                }
                if (double.TryParse(input, out double num))
                {
                    numbers.Add(num);
                }
                else
                {
                    Console.WriteLine("Некоректне число. Введення завершено.");
                    break;
                }
            }

            // Перевірка, чи були введені числа
            if (numbers.Count == 0)
            {
                Console.WriteLine("Список чисел порожній. Програма завершена.");
                return;
            }
            Console.WriteLine($"Введено {numbers.Count} чисел: {string.Join(", ", numbers)}");

            // Запис у двійковий файл
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (double num in numbers)
                    {
                        writer.Write(num);
                    }
                }
                Console.WriteLine("Числа успішно записано у файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при записі у файл: " + ex.Message);
                return;
            }

            // Введення порогового значення
            Console.Write("Введіть порогове число: ");
            string thresholdInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(thresholdInput) || !double.TryParse(thresholdInput, out double threshold))
            {
                Console.WriteLine("Помилка: введено некоректне порогове значення.");
                return;
            }
            Console.WriteLine($"Порогове значення: {threshold}");

            // Зчитування та виведення чисел із непарними індексами, більших за поріг
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    Console.WriteLine("Числа з непарними індексами, більші за " + threshold + ":");
                    for (int i = 1; i <= numbers.Count; i++)
                    {
                        if (i % 2 == 1) // Непарні індекси (1-based: 1, 3, 5, ...)
                        {
                            fs.Seek((i - 1) * sizeof(double), SeekOrigin.Begin);
                            double num = reader.ReadDouble();
                            Console.WriteLine($"Перевірка: Індекс {i}, Число {num}, Поріг {threshold}");
                            if (num > threshold)
                            {
                                Console.WriteLine($"Індекс {i}: {num}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при зчитуванні: " + ex.Message);
            }

            // Затримка для перегляду результатів
            Console.WriteLine("Натисніть Enter, щоб закрити...");
            Console.ReadLine();
        }
    }
}