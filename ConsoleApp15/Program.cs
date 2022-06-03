using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Program
{
    static void Main(string[] args)
    {// Cчитываем из файла сообщения
        string m = File.ReadAllText("dictionary.txt", Encoding.UTF8);

        int nomer; // Номер в алфавите
        int d; // Смещение
        string s; //Результат
        int j; // Переменная для циклов

        char[] massage = m.ToCharArray(); // Превращаем строку в массив символов.

        char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        // Перебираем каждый символ сообщения
        for (int i = 0; i < massage.Length; i++)
        {
            // Ищем индекс буквы
            for (j = 0; j < alfavit.Length; j++)
            {
                if (massage[i] == alfavit[j])
                {
                    break;
                }
            }

            if (j != 33) // Если j равно 33, значит символ не из алфавита
            {
                nomer = j; // Индекс буквы
                d = nomer + 3; // Делаем смещение

                // Проверяем, чтобы не вышли за пределы алфавита
                if (d > 32)
                {
                    d = d - 33;
                }

                massage[i] = alfavit[d]; // Меняем букву
            }
        }

        s = new string(massage); // Собираем символы обратно в строку.
        File.WriteAllText("input.txt", s); // Записываем результат в файл.
        
        List<string> lines = File.ReadAllLines("input.txt").ToList();

        for (int i = 0; i < lines.Count; ++i)
        {
            int count = lines.Count(str => str == lines[i]);
            if (count > 1)
            {
                Console.WriteLine
                (
                    "Строка '{0}' повторяется {1} раз(-а).",
                    lines[i], count
                );
                lines.Remove(lines[i]);
            }
        }
    }

}
