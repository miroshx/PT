
class Program
{
    static void Main()
    {
        int count = 0;

        // Чтение трех предложений от пользователя
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Введите предложение {i}:");
            string sentence = Console.ReadLine();

            // Разделение строки на слова
            string[] words = sentence.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            // Подсчет слов с длиной <= 4 символов
            foreach (string word in words)
            {
                if (word.Length <= 4)
                {
                    count++;
                }
            }
        }

        // Вывод результата
        Console.WriteLine($"Количество слов длиной не более 4 букв: {count}");
    }
}
