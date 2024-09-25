/*
 
 Разработать в среде Visual Studio в соответствии со своим вариантом
консольную программу, которая считывает значение n (размерность
одномерного массива), введенное пользователем, поэлементно считывает с
экрана n вещественных значений будущего массива и выводит результат
работы программы в соответствии с номером варианта:
В одномерном массиве, состоящих из n вещественных чисел, вычислить:

-------------------------------------------------------------------

Минимальный по модулю элемент массива и сумму модулей элементов
массива, расположенных после первого элемента, равного нулю.

 */
using System;

class Program
{
    static void Main()
    {
        // Считываем размерность массива
        Console.Write("Введите размерность массива (n): ");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];

        // Считываем элементы массива
        Console.WriteLine("Введите " + n + " вещественных чисел:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            array[i] = double.Parse(Console.ReadLine());
        }

        // Находим минимальный по модулю элемент
        double minModulusElement = Math.Abs(array[0]);
        foreach (var item in array)
        {
            if (Math.Abs(item) < minModulusElement)
            {
                minModulusElement = Math.Abs(item);
            }
        }

        // Находим сумму модулей элементов после первого нуля
        double sumOfModulesAfterZero = 0;
        bool zeroFound = false;

        for (int i = 0; i < n; i++)
        {
            if (zeroFound)
            {
                sumOfModulesAfterZero += Math.Abs(array[i]);
            }

            if (array[i] == 0 && !zeroFound)
            {
                zeroFound = true;
            }
        }

        // Выводим результаты
        Console.WriteLine($"Минимальный по модулю элемент: {minModulusElement}");
        Console.WriteLine($"Сумма модулей элементов после первого нуля: {sumOfModulesAfterZero}");
    }
}