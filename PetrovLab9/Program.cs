using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PetrovLab9
{
    class Program
    {
        //Смоделируйте работу простого калькулятора. Программа должна запрашивать 2 числа,
        //а затем – код операции (например, 1 – сложение, 2 – вычитание, 3 – произведение, 4 – частное).
        //После этого на консоль выводится ответ. Используйте обработку исключений для защиты от ввода некорректных данных.
        static void Main(string[] args)
        {
            Boolean fault = true;
            int a = 0;
            int b = 0;
            Console.WriteLine("Введите 2 целых числа");
            try //Защищаемся от ввода не целого числа или не числа вовсе
            {
                Console.Write("1-oe число = ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("2-oe число = ");
                b = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                bugMes(1); // Сообщаем пользователю об ошибке (Входное значение не является целым числом)
                fault = false;
            }
            if (fault) // Если на начальном этапе ввода данных произошла ошибка, то не продолжаем.
            {
                try // Защищаемся от ввода не целого числа или не числа вовсе
                {
                    Console.WriteLine("Выберите операцию:\n  Сложение - 0\n  Вычитание - 1\n  Умножение - 2\n  Деление - 3");
                    int operation = Convert.ToInt32(Console.ReadLine());
                    if (b == 0 && operation == 3)
                    {
                        bugMes(2); // Сообщаем пользователю об ошибке (Попытка деления на ноль)
                    }
                    else if (operation < 0 && operation > 3)
                    {
                        bugMes(0); // Сообщаем пользователю об ошибке (Нет такой операции)
                    }
                    else
                    {
                        calc(a, b, operation);
                    }
                }
                catch
                {
                    bugMes(1); // Сообщаем пользователю об ошибке (Входное значение не является целым числом)
                }
            }
            Console.ReadKey();
        }
        static void bugMes (int c) // Метод вывода сообщений об ошибках
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (c == 0)
            {
                Console.WriteLine("Ошибка! Нет такой операции");
            }
            else if (c == 1)
            {
                Console.WriteLine("Ошибка! Входное значение не является целым числом");
            }
            else
            {
                Console.WriteLine("Ошибка! Попытка деления на ноль");
            }
            Console.ResetColor();
        }
        static void calc (int a, int b, int operation) // Метод для вычислений и вывода результатов
        {
            switch (operation)
            {
                case 0:
                    Console.WriteLine($"Результат сложения = {a + b}");
                    break;
                case 1:
                    Console.WriteLine($"Результат вычитания = {a - b}");
                    break;
                case 2:
                    Console.WriteLine($"Результат умножения = {a * b}");
                    break;
                case 3:
                    Console.WriteLine($"Результат деления = {a / b}");
                    break;
                default:
                    bugMes(0);
                    break;
            }
        }

    }
}
