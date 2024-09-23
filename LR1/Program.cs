
class Program
{
    static void Main(string[] args)
    {
        // Ввод и обработка трех аргументов
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Введите значение аргумента {i}: ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                // Вычисление f(x) = x^2 - ln|x + 1| - 3
                double result = Math.Pow(x, 2) - Math.Log(Math.Abs(x + 1)) - 3;

                // Округление до 2 знаков после запятой и вывод результата
                Console.WriteLine($"f({x}) = {Math.Round(result, 2)}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }
}