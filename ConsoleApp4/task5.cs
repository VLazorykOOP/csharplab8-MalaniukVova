using System;
using System.IO;

namespace MyProgram
{
    class task5
    {
        static void Main()
        {
            string surname = "Shevchenko";
            string dir1 = $@"d:\temp\{surname}1";
            string dir2 = $@"d:\temp\{surname}2";
            string dirAl = $@"d:\temp\Al";
            string t1Path = Path.Combine(dir1, "t1.txt");
            string t2Path = Path.Combine(dir1, "t2.txt");
            string t3Path = Path.Combine(dir2, "t3.txt");
            string t2NewPath = Path.Combine(dir2, "t2.txt");
            string t1CopyPath = Path.Combine(dir2, "t1.txt");

            try
            {
                // 1. Створення каталогів
                Directory.CreateDirectory(dir1);
                Directory.CreateDirectory(dir2);
                Console.WriteLine($"Створено каталоги: {dir1}, {dir2}");

                // 2-3. Створення t1.txt у dir1
                File.WriteAllText(t1Path, "Шевченко Степан Іванович, 2001, місце проживання Суми");
                Console.WriteLine($"Створено файл: {t1Path}");

                // 4-5. Створення t2.txt у dir1
                File.WriteAllText(t2Path, "Комар Сергій Федорович, 2000, місце проживання Київ");
                Console.WriteLine($"Створено файл: {t2Path}");

                // 6-7. Створення t3.txt у dir2 із вмістом t1.txt та t2.txt
                string t1Content = File.ReadAllText(t1Path);
                string t2Content = File.ReadAllText(t2Path);
                File.WriteAllText(t3Path, t1Content + "\n" + t2Content);
                Console.WriteLine($"Створено файл: {t3Path}");

                // 8. Виведення детальної інформації про створені файли
                Console.WriteLine("\nІнформація про файли:");
                foreach (string file in new[] { t1Path, t2Path, t3Path })
                {
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine($"Файл: {fi.Name}");
                    Console.WriteLine($"Розмір: {fi.Length} байтів");
                    Console.WriteLine($"Створено: {fi.CreationTime}");
                    Console.WriteLine($"Останнє змінення: {fi.LastWriteTime}");
                    Console.WriteLine();
                }

                // 9. Переміщення t2.txt до dir2
                File.Move(t2Path, t2NewPath);
                Console.WriteLine($"Переміщено {t2Path} до {t2NewPath}");

                // 10. Копіювання t1.txt до dir2
                File.Copy(t1Path, t1CopyPath);
                Console.WriteLine($"Скопійовано {t1Path} до {t1CopyPath}");

                // 11. Перейменування dir2 на Al і видалення dir1
                Directory.Move(dir2, dirAl);
                Console.WriteLine($"Перейменовано {dir2} на {dirAl}");
                Directory.Delete(dir1, true);
                Console.WriteLine($"Видалено каталог: {dir1}");

                // 12. Виведення інформації про файли в Al
                Console.WriteLine("\nФайли в каталозі Al:");
                foreach (string file in Directory.GetFiles(dirAl))
                {
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine($"Файл: {fi.Name}");
                    Console.WriteLine($"Розмір: {fi.Length} байтів");
                    Console.WriteLine($"Створено: {fi.CreationTime}");
                    Console.WriteLine($"Останнє змінення: {fi.LastWriteTime}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}