using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class Program
    {
        static void Main(string[] args)
        {
            //запрос на вводразмера массива
            int size = 0;
            while (size <= 0)
            {
                try
                {
                    Console.Write("Введите размер массива: ");
                    size = int.Parse(Console.ReadLine());
                    if (size == 0)
                    {
                        Console.WriteLine("Введите не 0");
                    }
                    else if (size < 0)
                    {
                        Console.WriteLine("Размер массива не может быть отрицательным");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}! Введиете целое число");
                }
            }

            IndicationsControl indicationsControl = new IndicationsControl(size);

            //заполнение массива
            for (int i = 0; i < size; i++)
            {
                double temperature;
                Console.Write("Введите температуру: ");
                while (!double.TryParse(Console.ReadLine(), out temperature))
                {
                    try
                    {
                        Console.WriteLine("Ошибка, введите число!");
                        Console.Write("Введите температуру: ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e.Message}! Введиете число");
                    }
                }

                Console.Write("Введите направление ветра: ");
                string windDirection = Console.ReadLine();
                while (string.IsNullOrEmpty(windDirection))
                {
                    try
                    {
                        Console.WriteLine("Ошибка, введите направление ветра!");
                        Console.Write("Введите направление ветра: ");
                        windDirection = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e.Message}! Введиете направление ветра!");
                    }
                }

                double windSpeed;
                Console.Write("Введите скорость ветра: ");
                while (!double.TryParse(Console.ReadLine(), out windSpeed))
                {
                    try
                    {
                        Console.WriteLine("Ошибка, введите число ");
                        Console.Write("Введите скорость ветра: ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e.Message}! Введиете число");
                    }
                }

                indicationsControl.indications[i] = new Indications { temperature = temperature, windDirection = windDirection, windSpeed = windSpeed };
            }

            //вызов метода сортировки.
            indicationsControl.sort();


            //вызов метода сохранения в файл.
            indicationsControl.saveFile("Weather.txt");
            Console.ReadKey();
        }
    }
}