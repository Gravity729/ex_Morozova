using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class IndicationsControl
    {
        public Indications[] indications;

        public IndicationsControl(int size)
        {
            indications = new Indications[size];
        }

        // метод для сортировки поубыванию значений:скорость ветра и направление вретра.
        public void sort()
        {
            try
            {
                indications = indications.OrderByDescending(x => x.windSpeed)
                    .ThenByDescending(x => x.windDirection)
                    .ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка сортировки! Ошибка: {e.Message}");
            }
        }

        // метод для сохранения массива в файл.
        public void saveFile(string filename)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filename))
                {
                    foreach (Indications indication in indications)
                    {
                        streamWriter.WriteLine($"Температура: {indication.temperature}, направление ветра: {indication.windDirection}, скорость ветра: {indication.windSpeed}");
                    }
                }
                Console.WriteLine("Массив успешно сохранен в файл!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка сохранения в файл: {e.Message}");
            }
        }
    }
}